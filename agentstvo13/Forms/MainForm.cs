using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using agentstvo13.Models; // Подключаем сгенерированные модели
using Microsoft.EntityFrameworkCore;

namespace agentstvo13.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Событие загрузки формы — привяжи его в свойствах (Properties) через молнию ⚡ на событие Load
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadEventsData();
        }

        /// <summary>
        /// Комментарий: Логика загрузки списка мероприятий с детализацией сметы и расчетом стоимости
        /// </summary>
        public void LoadEventsData()
        {
            try
            {
                using (var db = new agentstvo_bd_13Context())
                {
                    // Вытягиваем мероприятия со всеми зависимостями из PostgreSQL
                    var rawEvents = db.Events
                        .Include(e => e.Client)
                        .Include(e => e.Venue)
                        .Include(e => e.EventDetails)
                            .ThenInclude(ed => ed.Contractor)
                        .ToList();

                    // Формируем список с динамическим расчетом "на лету" по условиям Задания №2
                    var displayList = rawEvents.Select(e =>
                    {
                        // 1. Расчет базовой стоимости: сумма всех подрядчиков + аренда площадки
                        decimal contractorsSum = e.EventDetails.Sum(ed => ed.Contractor.ServiceCost);
                        decimal rentalPrice = e.Venue.RentalPrice;
                        decimal baseAmount = contractorsSum + rentalPrice;

                        decimal discountPercent = 0;
                        string appliedDiscounts = "Нет";

                        // Проверка условия: "Раннее бронирование" (договор более чем за 2 месяца / 60 дней до мероприятия)
                        if ((e.EventDate - e.ContractDate).Days > 60)
                        {
                            discountPercent += 10;
                            appliedDiscounts = "Раннее (10%)";
                        }

                        // Проверка условия: повторный клиент
                        if (e.Client.IsRepeat)
                        {
                            discountPercent += 5;
                            if (appliedDiscounts == "Нет")
                                appliedDiscounts = "Повторный (5%)";
                            else
                                appliedDiscounts += " + Повторный (5%)";
                        }

                        // 2. Итоговая стоимость с учетом скидок
                        decimal discountAmount = baseAmount * (discountPercent / 100);
                        decimal finalAmount = baseAmount - discountAmount;

                        return new
                        {
                            Id = e.Id,
                            EventName = e.EventName,
                            EventDate = e.EventDate.ToShortDateString(),
                            ClientName = e.Client.FullName,
                            VenueName = e.Venue.VenueName,
                            BaseCost = Math.Round(baseAmount, 2),
                            Discounts = appliedDiscounts,
                            FinalCost = Math.Round(finalAmount, 2),
                            Status = e.PaymentStatus
                        };
                    }).ToList();

                    // Привязываем обработанный список к DataGridView
                    dgvEvents.DataSource = displayList;

                    // Настраиваем понятные русские заголовки
                    dgvEvents.Columns["Id"].Visible = false; // Скрываем технический ID
                    dgvEvents.Columns["EventName"].HeaderText = "Название мероприятия";
                    dgvEvents.Columns["EventDate"].HeaderText = "Дата проведения";
                    dgvEvents.Columns["ClientName"].HeaderText = "Клиент";
                    dgvEvents.Columns["VenueName"].HeaderText = "Площадка";
                    dgvEvents.Columns["BaseCost"].HeaderText = "Базовая цена";
                    dgvEvents.Columns["Discounts"].HeaderText = "Скидки";
                    dgvEvents.Columns["FinalCost"].HeaderText = "Итоговая стоимость";
                    dgvEvents.Columns["Status"].HeaderText = "Статус оплаты";

                    dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка мероприятий: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Запланировать мероприятие (Добавление нового)
        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            // Передаем null, так как это создание новой записи
            EventEditForm editForm = new EventEditForm(null);
            editForm.ShowDialog();

            // После закрытия окна автоматически обновляем список без перезапуска приложения
            LoadEventsData();
        }

        // Твоя кнопка из кода (Редактировать выбранное)
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка в таблице
            if (dgvEvents.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите мероприятие из списка для редактирования!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Достаем ID выбранного мероприятия из анонимного типа таблицы
            dynamic selectedRow = dgvEvents.CurrentRow.DataBoundItem;
            int eventId = selectedRow.Id;

            // Открываем форму и передаем туда ID для автоматической подгрузки данных
            EventEditForm editForm = new EventEditForm(eventId);
            editForm.ShowDialog();

            // Обновляем список после редактирования
            LoadEventsData();
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void dgvEvents_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            // 1. Проверяем, выбрана ли строка в таблице dgvEvents
            if (dgvEvents.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите мероприятие из списка для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Достаем ID и название выбранного мероприятия для вывода в сообщении
            dynamic selectedRow = dgvEvents.CurrentRow.DataBoundItem;
            int eventId = selectedRow.Id;
            string eventName = selectedRow.EventName;

            // 2. Запрашиваем подтверждение удаления (Предотвращение случайных нажатий)
            DialogResult result = MessageBox.Show($"Вы действительно хотите безвозвратно удалить мероприятие \"{eventName}\" и всю его смету?",
                                                  "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var db = new agentstvo_bd_13Context())
                    {
                        // Ищем мероприятие в базе данных по ID
                        var eventToDelete = db.Events.Find(eventId);
                        if (eventToDelete != null)
                        {
                            // Благодаря каскадному удалению (ON DELETE CASCADE), которое мы заложили в SQL-скрипте,
                            // связанные записи из таблицы сметы (event_details) удалятся автоматически!
                            db.Events.Remove(eventToDelete);
                            db.SaveChanges(); // Фиксируем изменения в PostgreSQL

                            MessageBox.Show("Мероприятие успешно удалено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 3. Обновляем таблицу на главном экране в реальном времени
                            LoadEventsData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении из базы данных: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOpenClientsList_Click(object sender, EventArgs e)
        {
            // Открываем окно со списком клиентов
            ClientsListForm clientsList = new ClientsListForm();
            clientsList.ShowDialog();

            // После возвращения обновляем и главную таблицу, 
            // так как при удалении клиента могли каскадно удалиться его мероприятия!
            LoadEventsData();
        }
    }
}