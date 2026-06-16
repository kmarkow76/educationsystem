using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using kinoteatr7.Models;

namespace kinoteatr7.Forms
{
    public partial class MainForm : Form
    {
        // Контекст базы данных
        private kinoteatr_bd_7Context _db = new kinoteatr_bd_7Context();
        private string currentMode = "Tickets"; // Режим по умолчанию

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // При старте принудительно показываем кнопку сохранения
            btnSaveChanges.Visible = true;
            // Загружаем билеты безопасно
            ShowTicketsData();
        }

        #region ЗАДАНИЕ №2: ФУНКЦИЯ РАСЧЕТА СТОИМОСТИ С УЧЕТОМ СКИДОК

        private TicketCostResult CalculateTicketCost(int quantity, decimal pricePerTicket, int isRegular)
        {
            decimal rawTotal = pricePerTicket * quantity;
            decimal discountPercent = 0;

            // Условие 1: от 3 до 5 билетов — 10%
            if (quantity >= 3 && quantity <= 5)
            {
                discountPercent = 10;
            }
            // Условие 2: более 5 билетов — 15%
            else if (quantity > 5)
            {
                discountPercent = 15;
            }

            // Условие 3: для постоянных клиентов доп. скидка 5%
            if (isRegular == 1)
            {
                discountPercent += 5;
            }

            decimal discountAmount = rawTotal * (discountPercent / 100);
            decimal finalCost = rawTotal - discountAmount;

            return new TicketCostResult
            {
                RawCost = rawTotal,
                DiscountPercent = discountPercent,
                FinalCost = finalCost
            };
        }

        #endregion

        #region ЛОГИКА ОТОБРАЖЕНИЯ И НАВИГАЦИИ

        private void ShowTicketsData()
        {
            currentMode = "Tickets";
            this.Text = "Список проданных билетов";

            // Перед загрузкой сносим старые привязки, чтобы избежать конфликтов на втором круге
            dgvMain.DataSource = null;
            dgvMain.Columns.Clear();

            SetGridEditable(false);

            try
            {
                using (var db = new kinoteatr_bd_7Context())
                {
                    var list = db.Tickets
                        .Include(t => t.Session).ThenInclude(s => s.Movie)
                        .Include(t => t.Session).ThenInclude(s => s.Hall)
                        .Include(t => t.Client)
                        .Include(t => t.Employee)
                        .ToList();

                    // Если билетов нет, просто выходим
                    if (list.Count == 0)
                    {
                        return;
                    }

                    // Используем безопасный оператор '?.' на случай пустых связей в БД
                    dgvMain.DataSource = list.Select(t => {
                        var cost = CalculateTicketCost(t.Quantity, t.Session?.BasePrice ?? 0, t.Client?.IsRegular ?? 0);
                        return new
                        {
                            Номер_Билета = t.TicketId,
                            ФИО_Клиента = t.Client?.FullName ?? "Не указан",
                            Название_Фильма = t.Session?.Movie?.Title ?? "Не указан",
                            Номер_Зала = t.Session?.Hall?.HallName ?? "Не указан",
                            Дата_Время_Сеанса = t.Session?.SessionDate.ToString("g") ?? "",
                            Количество_Билетов = t.Quantity,
                            Стоимость_Билета = t.Session?.BasePrice ?? 0,
                            Процент_Скидки = $"{cost.DiscountPercent}%",
                            Итоговая_Стоимость = cost.FinalCost,
                            Статус = t.Status ?? "Новый",
                            Кассир = t.Employee?.FullName ?? "Не указан"
                        };
                    }).ToList();

                    if (dgvMain.Columns["Номер_Билета"] != null) dgvMain.Columns["Номер_Билета"].HeaderText = "№ Билета";
                    if (dgvMain.Columns["ФИО_Клиента"] != null) dgvMain.Columns["ФИО_Клиента"].HeaderText = "ФИО Клиента";
                    if (dgvMain.Columns["Название_Фильма"] != null) dgvMain.Columns["Название_Фильма"].HeaderText = "Фильм";
                    if (dgvMain.Columns["Номер_Зала"] != null) dgvMain.Columns["Номер_Зала"].HeaderText = "Зал";
                    if (dgvMain.Columns["Дата_Время_Сеанса"] != null) dgvMain.Columns["Дата_Время_Сеанса"].HeaderText = "Дата и время";
                    if (dgvMain.Columns["Количество_Билетов"] != null) dgvMain.Columns["Количество_Билетов"].HeaderText = "Кол-во билетов";
                    if (dgvMain.Columns["Стоимость_Билета"] != null) dgvMain.Columns["Стоимость_Билета"].HeaderText = "Цена билета";
                    if (dgvMain.Columns["Процент_Скидки"] != null) dgvMain.Columns["Процент_Скидки"].HeaderText = "Скидка";
                    if (dgvMain.Columns["Итоговая_Стоимость"] != null) dgvMain.Columns["Итоговая_Стоимость"].HeaderText = "Итоговая стоимость";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки билетов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowSessionsData()
        {
            currentMode = "Sessions";
            this.Text = "Список сеансов";

            dgvMain.DataSource = null;
            dgvMain.Columns.Clear();

            SetGridEditable(false);

            try
            {
                using (var db = new kinoteatr_bd_7Context())
                {
                    var list = db.Sessions.Include(s => s.Movie).Include(s => s.Hall).ToList();

                    if (list.Count == 0)
                    {
                        return;
                    }

                    dgvMain.DataSource = list.Select(s => new
                    {
                        ID_Сеанса = s.SessionId,
                        Фильм = s.Movie?.Title ?? "Не указан",
                        Кинозал = s.Hall?.HallName ?? "Не указан",
                        Дата_Время = s.SessionDate.ToString("g"),
                        Базовая_Цена = s.BasePrice
                    }).ToList();

                    if (dgvMain.Columns["ID_Сеанса"] != null) dgvMain.Columns["ID_Сеанса"].HeaderText = "ID Сеанса";
                    if (dgvMain.Columns["Фильм"] != null) dgvMain.Columns["Фильм"].HeaderText = "Название фильма";
                    if (dgvMain.Columns["Кинозал"] != null) dgvMain.Columns["Кинозал"].HeaderText = "Кинозал";
                    if (dgvMain.Columns["Дата_Время"] != null) dgvMain.Columns["Дата_Время"].HeaderText = "Дата и время";
                    if (dgvMain.Columns["Базовая_Цена"] != null) dgvMain.Columns["Базовая_Цена"].HeaderText = "Цена билета";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сеансов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowMoviesData()
        {
            currentMode = "Movies";
            this.Text = "Справочник: Фильмы";

            dgvMain.DataSource = null;
            dgvMain.Columns.Clear();

            SetGridEditable(true);
            _db.Movies.Load();
            dgvMain.DataSource = _db.Movies.Local.ToBindingList();
            HideSystemColumns(new[] { "Sessions" });
            if (dgvMain.Columns.Contains("MovieId")) { dgvMain.Columns["MovieId"].HeaderText = "ID"; dgvMain.Columns["MovieId"].ReadOnly = true; }
            if (dgvMain.Columns.Contains("Title")) dgvMain.Columns["Title"].HeaderText = "Название фильма";
            if (dgvMain.Columns.Contains("DurationMinutes")) dgvMain.Columns["DurationMinutes"].HeaderText = "Длительность (мин)";
            if (dgvMain.Columns.Contains("Genre")) dgvMain.Columns["Genre"].HeaderText = "Жанр";
        }

        private void ShowHallsData()
        {
            currentMode = "Halls";
            this.Text = "Справочник: Кинозалы";

            dgvMain.DataSource = null;
            dgvMain.Columns.Clear();

            SetGridEditable(true);

            try
            {
                _db.Halls.Load();
                dgvMain.DataSource = _db.Halls.Local.ToBindingList();
                HideSystemColumns(new[] { "Sessions" });

                if (dgvMain.Columns.Contains("HallId"))
                {
                    dgvMain.Columns["HallId"].HeaderText = "ID";
                    dgvMain.Columns["HallId"].ReadOnly = true;
                }
                if (dgvMain.Columns.Contains("HallName"))
                {
                    dgvMain.Columns["HallName"].HeaderText = "Название зала";
                }
                if (dgvMain.Columns.Contains("TotalSeats"))
                {
                    dgvMain.Columns["TotalSeats"].HeaderText = "Всего мест";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке кинозалов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowEmployeesData()
        {
            currentMode = "Employees";
            this.Text = "Справочник: Сотрудники";

            dgvMain.DataSource = null;
            dgvMain.Columns.Clear();

            SetGridEditable(true);
            _db.Employees.Load();
            dgvMain.DataSource = _db.Employees.Local.ToBindingList();
            HideSystemColumns(new[] { "Tickets" });
            if (dgvMain.Columns.Contains("EmployeeId")) { dgvMain.Columns["EmployeeId"].HeaderText = "ID"; dgvMain.Columns["EmployeeId"].ReadOnly = true; }
            if (dgvMain.Columns.Contains("FullName")) dgvMain.Columns["FullName"].HeaderText = "ФИО Сотрудника";
            if (dgvMain.Columns.Contains("Position")) dgvMain.Columns["Position"].HeaderText = "Должность";
        }

        private void ShowClientsData()
        {
            currentMode = "Clients";
            this.Text = "Справочник: Клиенты";

            dgvMain.DataSource = null;
            dgvMain.Columns.Clear();

            SetGridEditable(true);
            _db.Clients.Load();
            dgvMain.DataSource = _db.Clients.Local.ToBindingList();
            HideSystemColumns(new[] { "Tickets" });
            if (dgvMain.Columns.Contains("ClientId")) { dgvMain.Columns["ClientId"].HeaderText = "ID"; dgvMain.Columns["ClientId"].ReadOnly = true; }
            if (dgvMain.Columns.Contains("FullName")) dgvMain.Columns["FullName"].HeaderText = "ФИО Клиента";
            if (dgvMain.Columns.Contains("Phone")) dgvMain.Columns["Phone"].HeaderText = "Телефон";
            if (dgvMain.Columns.Contains("IsRegular")) dgvMain.Columns["IsRegular"].HeaderText = "Постоянный (1/0)";
        }

        private void SetGridEditable(bool isEditable)
        {
            bool isTicketsOrSessions = (currentMode == "Tickets" || currentMode == "Sessions");

            btnAddRecord.Visible = isTicketsOrSessions;
            btnEditRecord.Visible = isTicketsOrSessions;
            btnSaveChanges.Visible = true;

            dgvMain.ReadOnly = false;

            // ИСПРАВЛЕНО: Реверсивный цикл 'for' вместо ломающегося 'foreach'
            if (dgvMain.Columns.Count > 0)
            {
                for (int i = dgvMain.Columns.Count - 1; i >= 0; i--)
                {
                    dgvMain.Columns[i].ReadOnly = !isEditable;
                }
            }

            dgvMain.AllowUserToAddRows = isEditable;
            dgvMain.AllowUserToDeleteRows = isEditable;

            if (isEditable)
            {
                dgvMain.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                dgvMain.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
            else
            {
                dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvMain.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void HideSystemColumns(string[] columns)
        {
            foreach (var col in columns) if (dgvMain.Columns.Contains(col)) dgvMain.Columns[col].Visible = false;
        }

        #endregion

        #region ПРИВЯЗКА КНОПОК НАВИГАЦИИ К МЕТОДАМ

        private void btnShowTickets_Click(object sender, EventArgs e) => ShowTicketsData();
        private void btnShowSessions_Click(object sender, EventArgs e) => ShowSessionsData();
        private void btnShowMovies_Click(object sender, EventArgs e) => ShowMoviesData();
        private void btnShowHalls_Click(object sender, EventArgs e) => ShowHallsData();
        private void btnShowEmployees_Click(object sender, EventArgs e) => ShowEmployeesData();
        private void btnShowClients_Click(object sender, EventArgs e) => ShowClientsData();

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                dgvMain.EndEdit();
                _db.SaveChanges();
                MessageBox.Show("Изменения сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _db = new kinoteatr_bd_7Context();
                if (currentMode == "Movies") ShowMoviesData();
                else if (currentMode == "Halls") ShowHallsData();
                else if (currentMode == "Employees") ShowEmployeesData();
                else if (currentMode == "Clients") ShowClientsData();
            }
        }

        #endregion

        #region КНОПКИ УПРАВЛЕНИЯ ВСПЛЫВАЮЩИМИ ОКНАМИ

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            SessionForm subForm = new SessionForm(null, currentMode);
            if (subForm.ShowDialog() == DialogResult.OK)
            {
                if (currentMode == "Tickets") ShowTicketsData();
                else if (currentMode == "Sessions") ShowSessionsData();
            }
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow != null)
            {
                try
                {
                    int recordId = currentMode == "Tickets"
                        ? Convert.ToInt32(dgvMain.CurrentRow.Cells["Номер_Билета"].Value)
                        : Convert.ToInt32(dgvMain.CurrentRow.Cells["ID_Сеанса"].Value);

                    SessionForm subForm = new SessionForm(recordId, currentMode);
                    if (subForm.ShowDialog() == DialogResult.OK)
                    {
                        if (currentMode == "Tickets") ShowTicketsData();
                        else if (currentMode == "Sessions") ShowSessionsData();
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось получить ID выбранной строки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }

    // Класс вынесен за пределы MainForm, но находится внутри namespace
    public class TicketCostResult
    {
        public decimal RawCost { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal FinalCost { get; set; }
    }
}