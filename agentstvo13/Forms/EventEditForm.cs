using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using agentstvo13.Models; // Подключаем наши модели СУБД
using Microsoft.EntityFrameworkCore;

namespace agentstvo13.Forms
{
    public partial class EventEditForm : Form
    {
        // Переменная для хранения ID редактируемого мероприятия (null, если добавляем новое)
        private int? _eventId;

        // Модифицируем конструктор, чтобы принимать ID мероприятия
        public EventEditForm(int? eventId)
        {
            InitializeComponent();
            _eventId = eventId;

            // ЖЕСТКАЯ ПРИВЯЗКА: Говорим форме обязательно выполнять метод при загрузке
            this.Load += new System.EventHandler(this.EventEditForm_Load);

            if (_eventId == null)
            {
                this.Text = "Планирование мероприятия";
            }
            else
            {
                this.Text = "Редактирование";
            }
        }

        // Событие загрузки формы (привяжи его к форме в Properties -> События -> Load)
        private void EventEditForm_Load(object sender, EventArgs e)
        {
            LoadComboboxData();

            // Если мы в режиме редактирования — подгружаем данные из СУБД
            if (_eventId != null)
            {
                LoadExistingEventData();
            }
        }

        /// <summary>
        /// Комментарий: Логика загрузки справочников клиентов и площадок в ComboBox из базы данных
        /// </summary>
        private void LoadComboboxData()
        {
            try
            {
                using (var db = new agentstvo_bd_13Context())
                {
                    // 1. ЗАГРУЗКА КЛИЕНТОВ
                    var clientsList = db.Clients.ToList();
                    if (clientsList != null && clientsList.Count > 0)
                    {
                        cmbClients.DataSource = clientsList;
                        cmbClients.DisplayMember = "FullName"; // Имя свойства из твоего файла Client.cs
                        cmbClients.ValueMember = "Id";
                    }

                    // 2. ЗАГРУЗКА ПЛОЩАДОК
                    var venuesList = db.Venues.ToList();
                    if (venuesList != null && venuesList.Count > 0)
                    {
                        cmbVenues.DataSource = venuesList;
                        cmbVenues.DisplayMember = "VenueName"; // Имя свойства из твоего файла Venue.cs
                        cmbVenues.ValueMember = "Id";
                    }

                    // 3. ЗАГРУЗКА СТАТУСОВ (теперь они точно появятся)
                    cmbStatus.Items.Clear();
                    cmbStatus.Items.Add("Не оплачено");
                    cmbStatus.Items.Add("Предоплата");
                    cmbStatus.Items.Add("Оплачено");
                    cmbStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Комментарий: Автоматическая загрузка данных существующей заявки в поля формы при редактировании
        /// </summary>
        private void LoadExistingEventData()
        {
            try
            {
                using (var db = new agentstvo_bd_13Context())
                {
                    var ev = db.Events.Find(_eventId);
                    if (ev != null)
                    {
                        txtEventName.Text = ev.EventName;
                        cmbClients.SelectedValue = ev.ClientId;
                        cmbVenues.SelectedValue = ev.VenueId;
                        dateTimePicker1.Value = ev.EventDate;
                        cmbStatus.SelectedItem = ev.PaymentStatus;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подгрузки данных мероприятия: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Сохранить (Добавление / Изменение)
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Валидация данных в реальном времени и встроенная обработка ошибок (Задание №3)
            if (string.IsNullOrWhiteSpace(txtEventName.Text))
            {
                MessageBox.Show("Введите название мероприятия!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка: Дата мероприятия не должна быть в прошлом (Задание №3)
            if (dateTimePicker1.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Дата проведения мероприятия не может быть в прошлом!", "Некорректная дата", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new agentstvo_bd_13Context())
                {
                    if (_eventId == null)
                    {
                        // Режим: ДОБАВЛЕНИЕ нового мероприятия
                        Event newEvent = new Event
                        {
                            EventName = txtEventName.Text.Trim(),
                            ClientId = (int)cmbClients.SelectedValue,
                            VenueId = (int)cmbVenues.SelectedValue,
                            EventDate = dateTimePicker1.Value.Date,
                            ContractDate = DateTime.Today, // Дата договора — сегодня
                            PaymentStatus = cmbStatus.SelectedItem.ToString()
                        };

                        db.Events.Add(newEvent);
                        db.SaveChanges(); // Сохраняем само событие

                        // Добавим дефолтного подрядчика (например, первого из базы), 
                        // чтобы смета не была пустой и базовая цена рассчитывалась корректно.
                        var defaultContractor = db.Contractors.FirstOrDefault();
                        if (defaultContractor != null)
                        {
                            EventDetail detail = new EventDetail
                            {
                                EventId = newEvent.Id,
                                ContractorId = defaultContractor.Id
                            };
                            db.EventDetails.Add(detail);
                        }
                    }
                    else
                    {
                        // Режим: РЕДАКТИРОВАНИЕ существующего мероприятия
                        var eventToUpdate = db.Events.Find(_eventId);
                        if (eventToUpdate != null)
                        {
                            eventToUpdate.EventName = txtEventName.Text.Trim();
                            eventToUpdate.ClientId = (int)cmbClients.SelectedValue;
                            eventToUpdate.VenueId = (int)cmbVenues.SelectedValue;
                            eventToUpdate.EventDate = dateTimePicker1.Value.Date;
                            eventToUpdate.PaymentStatus = cmbStatus.SelectedItem.ToString();
                        }
                    }

                    db.SaveChanges(); // Отправляем все изменения в PostgreSQL
                    MessageBox.Show("Данные мероприятия успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Закрываем форму и возвращаемся назад
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Отмена / Назад
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Оставляем пустые обработчики, чтобы дизайнер форм чувствовал себя хорошо
        private void txtEventName_TextChanged(object sender, EventArgs e) { }
        private void cmbClients_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbVenues_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) { }

        private void btnFastAddClient_Click(object sender, EventArgs e)
        {
            // Открываем окно добавления нового клиента
            AddClientForm addClientForm = new AddClientForm();
            addClientForm.ShowDialog();

            // Когда окно закроется, принудительно обновляем выпадающий список, 
            // чтобы новый клиент сразу же там появился!
            LoadComboboxData();
        }
    }
}