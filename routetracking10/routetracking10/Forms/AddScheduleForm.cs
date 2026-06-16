// AddScheduleForm.cs
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
    public partial class AddScheduleForm : Form
    {
        private routetrackingContext _context = new routetrackingContext();

        public AddScheduleForm()
        {
            InitializeComponent();
            this.Text = "Добавление расписания";
        }

        private void AddScheduleForm_Load(object sender, EventArgs e)
        {
            // Загружаем маршруты в комбобокс
            var routes = _context.Routes.ToList();
            routes.Insert(0, new Route { Id = 0, RouteNumber = "-- Выберите маршрут --" });
            comboBox1.DataSource = routes;
            comboBox1.DisplayMember = "RouteNumber";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedIndex = 0;

            // Загружаем транспортные средства в комбобокс
            var vehicles = _context.Vehicles.ToList();
            vehicles.Insert(0, new Vehicle { Id = 0, Model = "-- Выберите транспорт --" });
            comboBox2.DataSource = vehicles;
            comboBox2.DisplayMember = "Model";
            comboBox2.ValueMember = "Id";
            comboBox2.SelectedIndex = 0;

            // Загружаем водителей в комбобокс
            var drivers = _context.Drivers.ToList();
            drivers.Insert(0, new Driver { Id = 0, FullName = "-- Выберите водителя --" });
            comboBox3.DataSource = drivers;
            comboBox3.DisplayMember = "FullName";
            comboBox3.ValueMember = "Id";
            comboBox3.SelectedIndex = 0;

            // Фиксированные значения статуса
            comboBox4.Items.Clear();
            comboBox4.Items.Add("-- Выберите статус --");
            comboBox4.Items.AddRange(new string[] { "запланирован", "выполняется", "завершен", "отменен" });
            comboBox4.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация маршрута
            if (comboBox1.SelectedValue == null || (int)comboBox1.SelectedValue == 0)
            {
                MessageBox.Show("Выберите маршрут.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация транспортного средства
            if (comboBox2.SelectedValue == null || (int)comboBox2.SelectedValue == 0)
            {
                MessageBox.Show("Выберите транспортное средство.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация водителя
            if (comboBox3.SelectedValue == null || (int)comboBox3.SelectedValue == 0)
            {
                MessageBox.Show("Выберите водителя.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация времени отправления
            if (!TimeSpan.TryParseExact(maskedTextBox1.Text, @"hh\:mm", null, out TimeSpan departure))
            {
                MessageBox.Show("Введите корректное время отправления в формате ЧЧ:ММ.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Focus();
                return;
            }

            // Валидация времени прибытия
            if (!TimeSpan.TryParseExact(maskedTextBox2.Text, @"hh\:mm", null, out TimeSpan arrival))
            {
                MessageBox.Show("Введите корректное время прибытия в формате ЧЧ:ММ.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox2.Focus();
                return;
            }

            // Валидация даты поездки
            if (!DateTime.TryParseExact(maskedTextBox3.Text, "dd/MM/yyyy",
                null, System.Globalization.DateTimeStyles.None, out DateTime tripDate))
            {
                MessageBox.Show("Введите корректную дату в формате ДД/ММ/ГГГГ.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox3.Focus();
                return;
            }

            // Валидация статуса
            if (comboBox4.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите статус рейса.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Сохраняем новое расписание в БД
                var schedule = new Schedule
                {
                    RouteId = (int)comboBox1.SelectedValue,
                    VehicleId = (int)comboBox2.SelectedValue,
                    DriverId = (int)comboBox3.SelectedValue,
                    DepartureTime = departure,
                    ArrivalTime = arrival,
                    TripDate = tripDate,
                    Status = comboBox4.SelectedItem.ToString()
                };

                _context.Schedules.Add(schedule);
                _context.SaveChanges();

                MessageBox.Show("Расписание успешно добавлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}