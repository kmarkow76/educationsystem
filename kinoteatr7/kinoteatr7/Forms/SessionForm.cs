using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using kinoteatr7.Models;

namespace kinoteatr7.Forms
{
    public partial class SessionForm : Form
    {
        private kinoteatr_bd_7Context _db = new kinoteatr_bd_7Context();
        private int? _recordId;
        private string _mode; // "Tickets" или "Sessions"

        public SessionForm(int? recordId, string mode)
        {
            InitializeComponent();
            _recordId = recordId;
            _mode = mode;

            // ЖЕСТКАЯ ПРИВЯЗКА КНОПОК
            btnSave.Click -= btnSave_Click;
            btnSave.Click += btnSave_Click;

            btnCancel.Click -= btnCancel_Click;
            btnCancel.Click += btnCancel_Click;

            // Принудительно загружаем данные в списки сразу
            LoadComboBoxData();

            // Настраиваем только заголовки окна, поля больше НЕ блокируем!
            ConfigureInterface();

            // Если это редактирование — подгружаем существующие данные
            if (_recordId != null)
            {
                LoadRecordDataForEditing();
            }
            else
            {
                // Если это создание новой записи, ставим дефолтные значения, чтобы поля не были пустыми
                SetDefaultValuesForNewRecord();
            }
        }

        private void SessionForm_Load(object sender, EventArgs e)
        {
            // Настраиваем показ Даты и Времени одновременно для dateTimePicker1
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
        }

        // Заполнение выпадающих списков данными из базы
        private void LoadComboBoxData()
        {
            try
            {
                cmbMovies.DataSource = _db.Movies.ToList();
                cmbMovies.DisplayMember = "Title";
                cmbMovies.ValueMember = "MovieId";

                cmbHalls.DataSource = _db.Halls.ToList();
                cmbHalls.DisplayMember = "HallName";
                cmbHalls.ValueMember = "HallId";

                cmbClients.DataSource = _db.Clients.ToList();
                cmbClients.DisplayMember = "FullName";
                cmbClients.ValueMember = "ClientId";

                cmbEmployees.DataSource = _db.Employees.ToList();
                cmbEmployees.DisplayMember = "FullName";
                cmbEmployees.ValueMember = "EmployeeId";

                // Статусы билетов
                cmbStatus.Items.Clear();
                cmbStatus.Items.AddRange(new string[] { "Свободно", "Забронировано", "Продано" });
                cmbStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации списков: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Теперь этот метод меняет ТОЛЬКО заголовки окна. Все поля остаются ДОСТУПНЫМИ!
        private void ConfigureInterface()
        {
            // Убираем свойство Enabled = false и ReadOnly для всех элементов. Всё открыто для редактирования!
            cmbMovies.Enabled = true;
            cmbHalls.Enabled = true;
            dateTimePicker1.Enabled = true;
            txtPrice.ReadOnly = false;

            cmbClients.Enabled = true;
            cmbEmployees.Enabled = true;
            nudRow.Enabled = true;
            nudSeat.Enabled = true;
            nudQuantity.Enabled = true;
            cmbStatus.Enabled = true;

            if (_mode == "Sessions")
            {
                this.Text = _recordId == null ? "Новый сеанс" : "Редактирование сеанса";
            }
            else if (_mode == "Tickets")
            {
                this.Text = _recordId == null ? "Продажа билетов" : "Редактирование билета";
            }
        }

        // Подстановка начальных значений для новых записей, чтобы избежать пустых полей
        private void SetDefaultValuesForNewRecord()
        {
            var defaultSession = _db.Sessions.FirstOrDefault();
            if (defaultSession != null)
            {
                cmbMovies.SelectedValue = defaultSession.MovieId;
                cmbHalls.SelectedValue = defaultSession.HallId;
                dateTimePicker1.Value = defaultSession.SessionDate;
                txtPrice.Text = defaultSession.BasePrice.ToString();
            }
            else
            {
                txtPrice.Text = "0";
            }
        }

        // Автоматическая подгрузка данных при редактировании
        private void LoadRecordDataForEditing()
        {
            try
            {
                if (_mode == "Sessions")
                {
                    var session = _db.Sessions.Find(_recordId);
                    if (session != null)
                    {
                        cmbMovies.SelectedValue = session.MovieId;
                        cmbHalls.SelectedValue = session.HallId;
                        dateTimePicker1.Value = session.SessionDate;
                        txtPrice.Text = session.BasePrice.ToString();
                    }
                }
                else if (_mode == "Tickets")
                {
                    var ticket = _db.Tickets.Include(t => t.Session).FirstOrDefault(t => t.TicketId == _recordId);
                    if (ticket != null)
                    {
                        if (ticket.Session != null)
                        {
                            cmbMovies.SelectedValue = ticket.Session.MovieId;
                            cmbHalls.SelectedValue = ticket.Session.HallId;
                            dateTimePicker1.Value = ticket.Session.SessionDate;
                            txtPrice.Text = ticket.Session.BasePrice.ToString();
                        }

                        cmbClients.SelectedValue = ticket.ClientId;
                        cmbEmployees.SelectedValue = ticket.EmployeeId;
                        nudRow.Value = ticket.RowNumber;
                        nudSeat.Value = ticket.SeatNumber;
                        nudQuantity.Value = ticket.Quantity;
                        cmbStatus.SelectedItem = ticket.Status;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подгрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Сохранение изменений в базу данных
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация цены
            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Пожалуйста, введите корректную стоимость!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMovies.SelectedValue == null || cmbHalls.SelectedValue == null)
            {
                MessageBox.Show("Необходимо выбрать фильм и кинозал!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_mode == "Sessions")
                {
                    Session session = _recordId == null ? new Session() : _db.Sessions.Find(_recordId);

                    session.MovieId = (int)cmbMovies.SelectedValue;
                    session.HallId = (int)cmbHalls.SelectedValue;
                    session.SessionDate = dateTimePicker1.Value;
                    session.BasePrice = price;

                    if (_recordId == null) _db.Sessions.Add(session);
                }
                else if (_mode == "Tickets")
                {
                    Ticket ticket = _recordId == null ? new Ticket() : _db.Tickets.Find(_recordId);

                    // Ищем или создаем сеанс, соответствующий выбранным в форме Фильму, Залу и Дате
                    var targetSession = _db.Sessions.FirstOrDefault(s =>
                        s.MovieId == (int)cmbMovies.SelectedValue &&
                        s.HallId == (int)cmbHalls.SelectedValue);

                    if (targetSession == null)
                    {
                        // Если админ вручную поменял фильм/зал, и такого сеанса еще нет в БД, создадим его автоматически
                        targetSession = new Session
                        {
                            MovieId = (int)cmbMovies.SelectedValue,
                            HallId = (int)cmbHalls.SelectedValue,
                            SessionDate = dateTimePicker1.Value,
                            BasePrice = price
                        };
                        _db.Sessions.Add(targetSession);
                        _db.SaveChanges(); // Сохраняем, чтобы получить SessionId
                    }

                    ticket.SessionId = targetSession.SessionId;
                    ticket.ClientId = (int)cmbClients.SelectedValue;
                    ticket.EmployeeId = (int)cmbEmployees.SelectedValue;
                    ticket.RowNumber = (int)nudRow.Value;
                    ticket.SeatNumber = (int)nudSeat.Value;
                    ticket.Quantity = (int)nudQuantity.Value;
                    ticket.Status = cmbStatus.SelectedItem?.ToString() ?? "Продано";

                    if (_recordId == null) _db.Tickets.Add(ticket);
                }

                _db.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении в базу данных: {ex.Message}", "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Заглушки для предотвращения конфликтов в дизайнере формы
        private void cmbMovies_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbHalls_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void txtPrice_TextChanged(object sender, EventArgs e) { }
        private void cmbClients_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbEmployees_SelectedIndexChanged(object sender, EventArgs e) { }
        private void nudRow_ValueChanged(object sender, EventArgs e) { }
        private void nudSeat_ValueChanged(object sender, EventArgs e) { }
        private void nudQuantity_ValueChanged(object sender, EventArgs e) { }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}