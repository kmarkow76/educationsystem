using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using beauty5.Models; // Твое пространство имен проекта

namespace beauty5.Forms
{
    public partial class MainForm : Form
    {
        // Контекст базы данных beauty_bd_5
        private beauty_bd_5Context _db = new beauty_bd_5Context();
        private string currentMode = "Appointments";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Логика загрузки данных: при старте открываем журнал записей салона
            ShowAppointmentsData();
        }

        #region ЗАДАНИЕ №2: АЛГОРИТМ РАСЧЕТА СТОИМОСТИ И СКИДОК

        // Функция расчета стоимости услуг и величины скидки по ID записи
        private AppointmentCostResult CalculateOrderCost(int appointmentId)
        {
            using (var db = new beauty_bd_5Context())
            {
                // Ищем запись и подтягиваем клиента, чтобы проверить его статус
                var appointment = db.Appointments
                    .Include(a => a.Client)
                    .FirstOrDefault(a => a.AppointmentId == appointmentId);

                // Собираем все услуги, привязанные к этой записи
                var details = db.AppointmentDetails
                    .Where(d => d.AppointmentId == appointmentId)
                    .Include(d => d.Service)
                    .ToList();

                // Считаем чистую стоимость всех услуг без скидок
                decimal rawTotal = details.Sum(d => d.Service.Price * d.Quantity);

                decimal discountPercent = 0;

                // Условие 1: при сумме заказа более 1000 рублей — скидка 10%
                if (rawTotal > 1000 && rawTotal <= 2000)
                {
                    discountPercent = 10;
                }
                // Условие 2: при сумме заказа более 2000 рублей — скидка 20%
                else if (rawTotal > 2000)
                {
                    discountPercent = 20;
                }

                // Условие 3: для постоянных клиентов предоставляется дополнительная скидка 5% (is_regular == 1)
                if (appointment?.Client?.IsRegular == 1)
                {
                    discountPercent += 5;
                }

                // Вычисляем итоговую цену заказа
                decimal discountAmount = rawTotal * (discountPercent / 100);
                decimal finalCost = rawTotal - discountAmount;

                return new AppointmentCostResult
                {
                    RawCost = rawTotal,
                    DiscountPercent = discountPercent,
                    FinalCost = finalCost
                };
            }
        }

        #endregion

        #region РЕЖИМЫ НАВИГАЦИИ (ПРОСМОТР ДАННЫХ И ПЕРЕВЕРНУТЫЕ ЗАГОЛОВКИ)

        // 1. Отображение Журнала Записей Клиентов
        private void ShowAppointmentsData()
        {
            currentMode = "Appointments";
            SetGridEditable(false);

            try
            {
                using (var db = new beauty_bd_5Context())
                {
                    var list = db.Appointments
                        .Include(a => a.Client)
                        .Include(a => a.Master)
                        .OrderByDescending(a => a.AppointmentDate)
                        .ToList();

                    // Формируем вывод для таблицы (Задание №2 - ФИО, мастер, даты, скидки)
                    dgvMain.DataSource = list.Select(a => {
                        var cost = CalculateOrderCost(a.AppointmentId);
                        return new
                        {
                            Номер_Записи = a.AppointmentId,
                            ФИО_Клиента = a.Client.FullName,
                            Мастер = a.Master.FullName,
                            Дата_Записи = a.AppointmentDate.ToString("g"),
                            Стоимость_Услуг = cost.RawCost,
                            Процент_Скидки = $"{cost.DiscountPercent}%",
                            Итоговая_Стоимость = cost.FinalCost,
                            Статус_Записи = a.Status
                        };
                    }).ToList();

                    // Красиво переименовываем заголовки столбцов на русский язык
                    dgvMain.Columns["Номер_Записи"].HeaderText = "№ Записи";
                    dgvMain.Columns["ФИО_Клиента"].HeaderText = "ФИО Клиента";
                    dgvMain.Columns["Мастер"].HeaderText = "Мастер";
                    dgvMain.Columns["Дата_Записи"].HeaderText = "Дата и время записи";
                    dgvMain.Columns["Стоимость_Услуг"].HeaderText = "Стоимость услуг";
                    dgvMain.Columns["Процент_Скидки"].HeaderText = "Размер скидки";
                    dgvMain.Columns["Итоговая_Стоимость"].HeaderText = "Итоговая стоимость";
                    dgvMain.Columns["Статус_Записи"].HeaderText = "Статус записи";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки записей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Справочник: Клиенты
        private void ShowClientsData()
        {
            currentMode = "Clients";
            SetGridEditable(true);

            _db.Clients.Load();
            dgvMain.DataSource = _db.Clients.Local.ToBindingList();

            // Скрываем служебные колонки связей Entity Framework
            HideSystemColumns(new[] { "Appointments" });

            // Переводим названия полей БД на русский язык в интерфейсе таблицы
            dgvMain.Columns["ClientId"].HeaderText = "ID Клиента";
            dgvMain.Columns["FullName"].HeaderText = "ФИО Клиента";
            dgvMain.Columns["Phone"].HeaderText = "Номер телефона";
            dgvMain.Columns["IsRegular"].HeaderText = "Постоянный клиент (1-Да, 0-Нет)";
        }

        // 3. Справочник: Мастера
        private void ShowMastersData()
        {
            currentMode = "Masters";
            SetGridEditable(true);

            _db.Masters.Load();
            dgvMain.DataSource = _db.Masters.Local.ToBindingList();

            HideSystemColumns(new[] { "Appointments" });

            dgvMain.Columns["MasterId"].HeaderText = "ID Мастера";
            dgvMain.Columns["FullName"].HeaderText = "ФИО Мастера";
            dgvMain.Columns["Specialization"].HeaderText = "Специализация";
            dgvMain.Columns["Phone"].HeaderText = "Номер телефона";
        }

        // 4. Справочник: Услуги (Прайс)
        private void ShowServicesData()
        {
            currentMode = "Services";
            SetGridEditable(true);

            _db.Services.Load();
            dgvMain.DataSource = _db.Services.Local.ToBindingList();

            HideSystemColumns(new[] { "AppointmentDetails" });

            dgvMain.Columns["ServiceId"].HeaderText = "ID Услуги";
            dgvMain.Columns["ServiceName"].HeaderText = "Наименование услуги";
            dgvMain.Columns["Price"].HeaderText = "Стоимость услуги";
        }

        // Настройка режимов таблицы (Просмотр журнала / Прямое редактирование справочников)
        private void SetGridEditable(bool isEditable)
        {
            btnAddAppointment.Visible = !isEditable;
            btnEditAppointment.Visible = !isEditable;
            btnSaveChanges.Visible = isEditable;

            dgvMain.ReadOnly = !isEditable;
            dgvMain.AllowUserToAddRows = isEditable; // Разрешаем ввод новых строк прямо через нижнюю пустую строку
        }

        private void HideSystemColumns(string[] columns)
        {
            foreach (var col in columns)
            {
                if (dgvMain.Columns.Contains(col)) dgvMain.Columns[col].Visible = false;
            }
        }

        #endregion

        #region УПРАВЛЕНИЕ И ИЗМЕНЕНИЯ СПРАВОЧНИКОВ ПРЯМО В ТАБЛИЦЕ

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                dgvMain.EndEdit();
                _db.SaveChanges(); // Сохраняем все добавленные строки в базу beauty_bd_5
                MessageBox.Show("Изменения справочника успешно сохранены в базу данных!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения данных: {ex.Message}\nТаблица будет обновлена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _db = new beauty_bd_5Context(); // Пересоздаем контекст при ошибке
                if (currentMode == "Clients") ShowClientsData();
                else if (currentMode == "Masters") ShowMastersData();
                else if (currentMode == "Services") ShowServicesData();
            }
        }

        private void btnShowAppointments_Click(object sender, EventArgs e) => ShowAppointmentsData();
        private void btnShowClients_Click(object sender, EventArgs e) => ShowClientsData();
        private void btnShowMasters_Click(object sender, EventArgs e) => ShowMastersData();
        private void btnShowServices_Click(object sender, EventArgs e) => ShowServicesData();

        // НАЖАТИЕ НА КНОПКУ «ДОБАВИТЬ ЗАПИСЬ»
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр нашей формы (передаем null, так как это новая запись)
            AppointmentForm appForm = new AppointmentForm(null);

            // Открываем форму как всплывающее (модальное) окно
            if (appForm.ShowDialog() == DialogResult.OK)
            {
                // Этот код сработает, когда внутри всплывающего окна нажмут «Сохранить»
                // Вызываем метод, который обновляет данные в твоей таблице dgvMain
                ShowAppointmentsData();
            }
        }

        // НАЖАТИЕ НА КНОПКУ «РЕДАКТИРОВАТЬ ЗАПИСЬ»
        private void btnEditAppointment_Click(object sender, EventArgs e)
        {
            // Проверяем, что в главной таблице dgvMain выбрана хотя бы одна строчка
            if (dgvMain.CurrentRow != null)
            {
                // Вытаскиваем ID выбранной записи из первой ячейки (столбца "Номер_Записи")
                int appointmentId = Convert.ToInt32(dgvMain.CurrentRow.Cells["Номер_Записи"].Value);

                // Открываем форму и передаем туда этот ID для загрузки существующих данных визита
                AppointmentForm appForm = new AppointmentForm(appointmentId);

                if (appForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновляем главную таблицу dgvMain, чтобы сразу увидеть изменения в журнале визитов
                    ShowAppointmentsData();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись в таблице для её редактирования!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }

    // Класс для удобной передачи результатов вычисления стоимости
    public class AppointmentCostResult
    {
        public decimal RawCost { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal FinalCost { get; set; }
    }
}