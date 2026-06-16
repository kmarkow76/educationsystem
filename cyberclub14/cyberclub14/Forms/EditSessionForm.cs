using System;
using System.Linq;
using System.Windows.Forms;
using cyberclub14.Models;

namespace cyberclub14.Forms
{
    public partial class EditSessionForm : Form
    {
        private cyberclubContext _context = new cyberclubContext();
        private MainForm _parent;
        private int _sessionId;
        private int _oldPlaceId;

        public EditSessionForm(MainForm parent, int sessionId)
        {
            InitializeComponent();
            _parent = parent;
            _sessionId = sessionId;
            this.Text = "Редактирование параметров сессии";
        }

        private void EditSessionForm_Load(object sender, EventArgs e)
        {
            cbMembers.DataSource = _context.ClubMembers.ToList();
            cbMembers.DisplayMember = "Nickname";
            cbMembers.ValueMember = "Id";

            cbTariffs.DataSource = _context.Tariffs.ToList();
            cbTariffs.DisplayMember = "Name";
            cbTariffs.ValueMember = "Id";

            cbStatus.Items.AddRange(new string[] { "Активна", "Завершена" });

            // Комментарий: Автоматическая загрузка данных редактируемой заявки в поля формы (по ТЗ)
            var session = _context.GameSessions.Find(_sessionId);
            if (session == null)
            {
                MessageBox.Show("Объект сессии не найден в СУБД.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _oldPlaceId = session.PlaceId;

            // Выводим все места, исключая занятые другими (своё текущее место оставляем доступным в списке)
            cbPlaces.DataSource = _context.GamingPlaces
                .Where(p => p.IsOccupied != true || p.Id == _oldPlaceId)
                .ToList();
            cbPlaces.DisplayMember = "PlaceNumber";
            cbPlaces.ValueMember = "Id";

            // Установка фокуса на текущие сохраненные значения
            cbMembers.SelectedValue = session.MemberId;
            cbPlaces.SelectedValue = session.PlaceId;
            cbTariffs.SelectedValue = session.TariffId;
            cbStatus.SelectedItem = session.Status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbStatus.SelectedItem == null) return;

            int newPlaceId = (int)cbPlaces.SelectedValue;
            string newStatus = cbStatus.SelectedItem.ToString();

            try
            {
                var session = _context.GameSessions.Find(_sessionId);
                if (session == null) return;

                // ЛОГИКА АВТОРАСЧЕТА ПРИ КЛИКЕ НА "ЗАВЕРШЕНА" ВНУТРИ РЕДАКТИРОВАНИЯ
                if (newStatus == "Завершена" && session.Status != "Завершена")
                {
                    // Фиксируем время завершения прямо сейчас
                    session.EndTime = DateTime.Now;

                    var tariff = _context.Tariffs.Find((int)cbTariffs.SelectedValue);
                    var member = _context.ClubMembers.Find((int)cbMembers.SelectedValue);

                    // Вызываем функцию расчета (она лежит в CloseSessionForm)
                    var result = CloseSessionForm.CalculateSession(
                        tariff.PricePerHour,
                        session.StartTime,
                        session.EndTime.Value,
                        tariff.IsNightPackage.GetValueOrDefault(),
                        member.HasClubCard.GetValueOrDefault()
                    );

                    // Записываем посчитанные деньги
                    session.BasePrice = result.basePrice;
                    session.DiscountPercent = result.discountPercent;
                    session.TotalPrice = result.totalPrice;
                }

                // Обработка логики перемещения игрока за другой ПК
                if (_oldPlaceId != newPlaceId)
                {
                    var oldPlace = _context.GamingPlaces.Find(_oldPlaceId);
                    if (oldPlace != null) oldPlace.IsOccupied = false; // Освобождаем старый

                    var newPlace = _context.GamingPlaces.Find(newPlaceId);
                    if (newPlace != null) newPlace.IsOccupied = true;  // Занимаем новый
                }

                // Если сессия закрывается — в любом случае освобождаем текущий ПК
                if (newStatus == "Завершена")
                {
                    var currentPlace = _context.GamingPlaces.Find(newPlaceId);
                    if (currentPlace != null) currentPlace.IsOccupied = false;
                }

                // Обновляем базовые поля
                session.MemberId = (int)cbMembers.SelectedValue;
                session.PlaceId = newPlaceId;
                session.TariffId = (int)cbTariffs.SelectedValue;
                session.Status = newStatus;

                _context.SaveChanges();
                _parent.LoadSessions(); // Обновляем главную таблицу
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка записи изменений сессии: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}