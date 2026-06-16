// TicketForm.cs
using routetracking10.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace routetracking10.Forms
{
    public partial class TicketForm : Form
    {
        private routetrackingContext _context = new routetrackingContext();

        public TicketForm()
        {
            InitializeComponent();
            this.Text = "Список билетов";
        }

        private void TicketForm_Load(object sender, EventArgs e)
        {
            LoadTickets();
        }

        // Расчёт скидки на основе типа пассажира и типа билета
        private decimal CalculateDiscount(bool isPrivileged, bool isRegular, string ticketType)
        {
            // Льготный пассажир получает 50% — не суммируется с другими скидками
            if (isPrivileged)
                return 50;

            decimal discount = 0;

            // Постоянный пассажир — скидка 10%
            if (isRegular)
                discount += 10;

            // Месячный проездной — скидка 15%
            if (ticketType == "месячный")
                discount += 15;

            return discount;
        }

        // Загрузка списка билетов с расчётом стоимости и скидок
        public void LoadTickets()
        {
            var tickets = _context.Tickets
                .Select(t => new
                {
                    t.Id,
                    Номер_маршрута = t.Schedule.Route.RouteNumber,
                    Маршрут = t.Schedule.Route.StartPoint + " → " + t.Schedule.Route.EndPoint,
                    Дата_рейса = t.Schedule.TripDate,
                    Отправление = t.Schedule.DepartureTime,
                    Прибытие = t.Schedule.ArrivalTime,
                    Пассажир = t.Passenger.FullName,
                    Тип_билета = t.TicketType,
                    Базовая_цена = t.Schedule.Route.BasePrice,
                    IsPrivileged = t.Passenger.IsPrivileged,
                    IsRegular = t.Passenger.IsRegular,
                })
                .ToList()
                .Select(t =>
                {
                    // Вычисляем скидку и итоговую стоимость для каждого билета
                    decimal discount = CalculateDiscount(t.IsPrivileged, t.IsRegular, t.Тип_билета);
                    decimal finalPrice = t.Базовая_цена * (1 - discount / 100);

                    return new
                    {
                        t.Id,
                        t.Номер_маршрута,
                        t.Маршрут,
                        Дата_рейса = t.Дата_рейса.ToShortDateString(),
                        Отправление = t.Отправление.ToString(@"hh\:mm"),
                        Прибытие = t.Прибытие.ToString(@"hh\:mm"),
                        t.Пассажир,
                        t.Тип_билета,
                        Стоимость_проезда = $"{t.Базовая_цена:F2} руб.",
                        Скидка = $"{discount}%",
                        Итоговая_стоимость = $"{finalPrice:F2} руб."
                    };
                })
                .ToList();

            dataGridView1.DataSource = tickets;

            // Скрываем Id и переименовываем заголовки
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Номер_маршрута"].HeaderText = "№ маршрута";
            dataGridView1.Columns["Маршрут"].HeaderText = "Маршрут";
            dataGridView1.Columns["Дата_рейса"].HeaderText = "Дата рейса";
            dataGridView1.Columns["Отправление"].HeaderText = "Отправление";
            dataGridView1.Columns["Прибытие"].HeaderText = "Прибытие";
            dataGridView1.Columns["Пассажир"].HeaderText = "Пассажир";
            dataGridView1.Columns["Тип_билета"].HeaderText = "Тип билета";
            dataGridView1.Columns["Стоимость_проезда"].HeaderText = "Стоимость проезда";
            dataGridView1.Columns["Скидка"].HeaderText = "Скидка";
            dataGridView1.Columns["Итоговая_стоимость"].HeaderText = "Итоговая стоимость";

            dataGridView1.ReadOnly = true;
        }

    }
}