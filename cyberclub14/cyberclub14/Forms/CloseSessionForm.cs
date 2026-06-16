using System;
using System.Linq;
using System.Windows.Forms;
using cyberclub14.Models;

namespace cyberclub14.Forms
{
    public partial class CloseSessionForm : Form
    {
        private cyberclubContext _context = new cyberclubContext();
        private MainForm _parent;
        private int _sessionId;

        public CloseSessionForm(MainForm parent, int sessionId)
        {
            InitializeComponent();
            _parent = parent;
            _sessionId = sessionId;
            this.Text = "Закрытие сессии";
        }

        private void CloseSessionForm_Load(object sender, EventArgs e)
        {
            var session = _context.GameSessions.Find(_sessionId);
            if (session == null || session.Status == "Завершена")
            {
                MessageBox.Show("Сессия не найдена в базе или уже закрыта.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            dtpEndTime.Value = DateTime.Now;
            cbStatus.Items.AddRange(new string[] { "Завершена", "Пауза" });
            cbStatus.SelectedIndex = 0;
        }

        /// <summary>
        /// ТРЕБОВАНИЕ ЗАДАНИЯ №2: Функция расчета стоимости игровой сессии
        /// </summary>
        public static (decimal basePrice, int discountPercent, decimal totalPrice) CalculateSession(
            decimal pricePerHour,
            DateTime start,
            DateTime end,
            bool isNightPackage,
            bool hasClubCard)
        {
            double totalHoursRaw = (end - start).TotalHours;
            if (totalHoursRaw <= 0) return (0, 0, 0);

            // Округление времени игры до полного часа вверх
            decimal hours = (decimal)Math.Ceiling(totalHoursRaw);

            // Базовая стоимость
            decimal basePrice = pricePerHour * hours;
            int discountPercent = 0;

            // Скидка 1: Пакет «Ночь» (с 23:00 до 08:00) = фикс 40%
            if (isNightPackage && start.Hour >= 23 && end.Hour <= 8)
            {
                discountPercent += 40;
            }

            // Скидка 2: Владелец клубной карты = доп 10%
            if (hasClubCard)
            {
                discountPercent += 10;
            }

            if (discountPercent > 100) discountPercent = 100;

            // Итоговый расчет стоимости сессии
            decimal totalPrice = basePrice * ((100 - discountPercent) / 100m);

            return (basePrice, discountPercent, totalPrice);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbStatus.SelectedItem == null) return;

            try
            {
                var session = _context.GameSessions.Find(_sessionId);
                if (session == null) return;

                DateTime start = session.StartTime;
                DateTime end = dtpEndTime.Value;

                if (end <= start)
                {
                    MessageBox.Show("Время окончания сессии не может быть раньше времени старта!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var tariff = _context.Tariffs.Find(session.TariffId);
                var member = _context.ClubMembers.Find(session.MemberId);
                var place = _context.GamingPlaces.Find(session.PlaceId);

                // Вызов функции расчета стоимости сессии
                var result = CalculateSession(
                    tariff.PricePerHour,
                    start,
                    end,
                    tariff.IsNightPackage.GetValueOrDefault(),
                    member.HasClubCard.GetValueOrDefault()
                );

                // Запись детализации расчета в объект сессии
                session.EndTime = end;
                session.BasePrice = result.basePrice;
                session.DiscountPercent = result.discountPercent;
                session.TotalPrice = result.totalPrice;
                session.Status = cbStatus.SelectedItem.ToString();

                // Контроль занятости мест: освобождаем ПК, если сессия завершена полностью
                if (session.Status == "Завершена" && place != null)
                {
                    place.IsOccupied = false;
                }

                _context.SaveChanges();
                _parent.LoadSessions(); // Обновление главной таблицы
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчете и сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}