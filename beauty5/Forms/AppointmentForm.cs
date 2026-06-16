using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using beauty5.Models; // Твое пространство имен моделей проекта

namespace beauty5.Forms
{
    public partial class AppointmentForm : Form
    {
        private int? _appointmentId;
        // Временный список для хранения услуг в оперативной памяти (если создаем новую запись)
        private List<AppointmentDetail> _tempDetails = new List<AppointmentDetail>();

        // Конструктор формы: принимает ID записи (для редактирования) или null (для создания)
        public AppointmentForm(int? appointmentId = null)
        {
            InitializeComponent();
            _appointmentId = appointmentId;

            // Задание №3: Названия окон должны четко отражать суть операции
            if (_appointmentId.HasValue)
            {
                this.Text = "Редактирование записи клиента";
            }
            else
            {
                this.Text = "Новая запись";
            }

            // Принудительно подписываем форму на событие загрузки
            this.Load += new System.EventHandler(this.AppointmentForm_Load);
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            // Наполнение выпадающих списков из базы данных beauty_bd_5 при открытии окна
            try
            {
                using (var db = new beauty_bd_5Context())
                {
                    // 1. Загружаем клиентов
                    cbClient.DataSource = null;
                    cbClient.DisplayMember = "FullName"; // Или то поле, которое хранит ФИО в твоей модели Client
                    cbClient.ValueMember = "ClientId";
                    cbClient.DataSource = db.Clients.ToList();

                    // 2. Загружаем мастеров
                    cbMaster.DataSource = null;
                    cbMaster.DisplayMember = "FullName"; // Или то поле, которое хранит ФИО в твоей модели Master
                    cbMaster.ValueMember = "MasterId";
                    cbMaster.DataSource = db.Masters.ToList();

                    // 3. Загружаем доступные услуги салона (Прайс)
                    cbServices.DataSource = null;
                    cbServices.DisplayMember = "ServiceName";
                    cbServices.ValueMember = "ServiceId";
                    cbServices.DataSource = db.Services.ToList();

                    // Очищаем пустые строки из дизайнера в статусах визита, оставляя только нужные
                    var validStatuses = new List<string> { "Запланирована", "Выполнена", "Отменена" };
                    cbStatus.Items.Clear();
                    foreach (var status in validStatuses)
                    {
                        cbStatus.Items.Add(status);
                    }

                    // Если это режим РЕДАКТИРОВАНИЯ — подгружаем существующие данные из базы
                    if (_appointmentId.HasValue)
                    {
                        var app = db.Appointments.Find(_appointmentId.Value);
                        if (app != null)
                        {
                            cbClient.SelectedValue = app.ClientId;
                            cbMaster.SelectedValue = app.MasterId;
                            dtpDate.Value = app.AppointmentDate;
                            cbStatus.SelectedItem = app.Status;

                            // Отображаем услуги, которые уже привязаны к визиту
                            RefreshDetailsGrid();
                        }
                    }
                    else
                    {
                        // Если новая запись — выставляем дефолтные пустые значения, чтобы не было автовыбора
                        cbStatus.SelectedIndex = 0; // По умолчанию "Запланирована"
                        cbClient.SelectedIndex = -1;
                        cbMaster.SelectedIndex = -1;
                        cbServices.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Критическая ошибка инициализации данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод обновления таблицы выбранных услуг на русском языке
        private void RefreshDetailsGrid()
        {
            using (var db = new beauty_bd_5Context())
            {
                List<AppointmentDetail> sourceList;

                if (_appointmentId.HasValue)
                {
                    // Режим редактирования: тянем данные напрямую из PostgreSQL со связями
                    sourceList = db.AppointmentDetails
                        .Where(d => d.AppointmentId == _appointmentId.Value)
                        .Include(d => d.Service)
                        .ToList();
                }
                else
                {
                    // Режим создания: берем накопленный временный список из памяти
                    sourceList = _tempDetails;
                }

                // Выводим данные в DataGridView с полностью русскими заголовками
                dgvMainDetails.DataSource = sourceList.Select(d => new {
                    Наименование_Услуги = d.Service?.ServiceName ?? "Неизвестная услуга",
                    Цена_Услуги = d.Service?.Price ?? 0,
                    Количество = d.Quantity,
                    Итоговая_Сумма = (d.Service?.Price ?? 0) * d.Quantity
                }).ToList();

                if (dgvMainDetails.Columns.Contains("Наименование_Услуги"))
                {
                    dgvMainDetails.Columns["Наименование_Услуги"].HeaderText = "Наименование услуги";
                    dgvMainDetails.Columns["Цена_Услуги"].HeaderText = "Цена";
                    dgvMainDetails.Columns["Количество"].HeaderText = "Количество";
                    dgvMainDetails.Columns["Итоговая_Сумма"].HeaderText = "Сумма (руб.)";
                }
            }
        }

        // НАЖАТИЕ НА КНОПКУ «ДОБАВИТЬ УСЛУГУ»
        private void btnAddService_Click(object sender, EventArgs e)
        {
            // Проверка выбора услуги из прайса (Валидация в реальном времени)
            if (cbServices.SelectedValue == null || cbServices.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, сначала выберите услугу из выпадающего списка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedServiceId = Convert.ToInt32(cbServices.SelectedValue);
            int quantity = (int)nudQuantity.Value;

            using (var db = new beauty_bd_5Context())
            {
                var serviceObj = db.Services.Find(selectedServiceId);
                if (serviceObj == null) return;

                if (_appointmentId.HasValue)
                {
                    // Если запись уже есть в базе — сразу пишем строку детализации в БД
                    var newDetail = new AppointmentDetail
                    {
                        AppointmentId = _appointmentId.Value,
                        ServiceId = selectedServiceId,
                        Quantity = quantity
                    };
                    db.AppointmentDetails.Add(newDetail);
                    db.SaveChanges();
                }
                else
                {
                    // Если запись новая — удерживаем услуги внутри временного списка в ОЗУ
                    var newDetail = new AppointmentDetail
                    {
                        ServiceId = selectedServiceId,
                        Quantity = quantity,
                        Service = serviceObj // сохраняем ссылку для красивого отображения названия в таблице
                    };
                    _tempDetails.Add(newDetail);
                }
            }

            RefreshDetailsGrid(); // Мгновенно обновляем интерфейс таблицы услуг
        }

        // НАЖАТИЕ НА КНОПКУ «СОХРАНИТЬ ЗАПИСЬ»
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация обязательных полей (Задание №3)
            if (cbClient.SelectedValue == null || cbClient.SelectedIndex == -1)
            {
                MessageBox.Show("Невозможно сохранить запись! Выберите Клиента из выпадающего списка.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbMaster.SelectedValue == null || cbMaster.SelectedIndex == -1)
            {
                MessageBox.Show("Невозможно сохранить запись! Закрепите Мастера за процедурой.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbStatus.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, укажите текущий статус записи клиента.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new beauty_bd_5Context())
                {
                    Appointment app;

                    if (_appointmentId.HasValue)
                    {
                        // Редактирование существующей записи
                        app = db.Appointments.Find(_appointmentId.Value);
                        if (app == null) return;

                        app.ClientId = Convert.ToInt32(cbClient.SelectedValue);
                        app.MasterId = Convert.ToInt32(cbMaster.SelectedValue);
                        app.AppointmentDate = dtpDate.Value;
                        app.Status = cbStatus.SelectedItem.ToString();

                        db.Appointments.Update(app);
                    }
                    else
                    {
                        // Создание абсолютно новой записи
                        app = new Appointment
                        {
                            ClientId = Convert.ToInt32(cbClient.SelectedValue),
                            MasterId = Convert.ToInt32(cbMaster.SelectedValue),
                            AppointmentDate = dtpDate.Value,
                            Status = cbStatus.SelectedItem.ToString()
                        };

                        db.Appointments.Add(app);
                        db.SaveChanges(); // Генерируем уникальный ID записи в СУБД

                        // Переносим все набранные услуги из памяти прямо в PostgreSQL
                        foreach (var detail in _tempDetails)
                        {
                            detail.AppointmentId = app.AppointmentId;
                            detail.Service = null; // сбрасываем локальный объект перед отправкой в БД
                            db.AppointmentDetails.Add(detail);
                        }
                    }

                    db.SaveChanges(); // Фиксируем транзакцию в СУБД
                    MessageBox.Show("Данные записи визита успешно сохранены в систему!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK; // Даем сигнал главному окну на обновление таблиц
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Критическая ошибка сохранения данных в базу: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // НАЖАТИЕ НА КНОПКУ «НАЗАД / ОТМЕНА»
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // Закрываем окно без сохранения изменений
        }

        // Пустые обработчики, сгенерированные дизайнером, оставляем, чтобы проект не ругался
        private void label1_Click(object sender, EventArgs e) { }
        private void cbClient_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbMaster_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpDate_ValueChanged(object sender, EventArgs e) { }
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbServices_SelectedIndexChanged(object sender, EventArgs e) { }
        private void nudQuantity_ValueChanged(object sender, EventArgs e) { }
        private void dgvMainDetails_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}