// EditScheduleForm.cs
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
    public partial class EditScheduleForm : Form
    {
        private routetrackingContext _context = new routetrackingContext();
        private readonly int _scheduleId;

        public EditScheduleForm(int scheduleId)
        {
            InitializeComponent();
            this.Text = "Редактирование расписания";
            _scheduleId = scheduleId;
        }

        private void EditScheduleForm_Load(object sender, EventArgs e)
        {
            // Загружаем маршруты в комбобокс
            var routes = _context.Routes.ToList();
            comboBox1.DataSource = routes;
            comboBox1.DisplayMember = "RouteNumber";
            comboBox1.ValueMember = "Id";

            // Загружаем транспортные средства в комбобокс
            var vehicles = _context.Vehicles.ToList();
            comboBox2.DataSource = vehicles;
            comboBox2.DisplayMember = "Model";
            comboBox2.ValueMember = "Id";

            // Загружаем водителей в комбобокс
            var drivers = _context.Drivers.ToList();
            comboBox3.DataSource = drivers;
            comboBox3.DisplayMember = "FullName";
            comboBox3.ValueMember = "Id";

            // Фиксированные значения статуса
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(new string[] { "запланирован", "выполняется", "завершен", "отменен" });

            // Загружаем данные текущего расписания
            var schedule = _context.Schedules.Find(_scheduleId);

            if (schedule == null)
            {
                MessageBox.Show("Расписание не найдено в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Подгружаем значения в поля формы
            comboBox1.SelectedValue = schedule.RouteId;
            comboBox2.SelectedValue = schedule.VehicleId;
            comboBox3.SelectedValue = schedule.DriverId;
            maskedTextBox1.Text = schedule.DepartureTime.ToString(@"hh\:mm");
            maskedTextBox2.Text = schedule.ArrivalTime.ToString(@"hh\:mm");
            maskedTextBox3.Text = schedule.TripDate.ToString("dd/MM/yyyy");
            comboBox4.SelectedItem = schedule.Status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация маршрута
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Выберите маршрут.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация транспортного средства
            if (comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Выберите транспортное средство.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация водителя
            if (comboBox3.SelectedValue == null)
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
            if (comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус рейса.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var schedule = _context.Schedules.Find(_scheduleId);

                if (schedule != null)
                {
                    // Обновляем данные расписания
                    schedule.RouteId = (int)comboBox1.SelectedValue;
                    schedule.VehicleId = (int)comboBox2.SelectedValue;
                    schedule.DriverId = (int)comboBox3.SelectedValue;
                    schedule.DepartureTime = departure;
                    schedule.ArrivalTime = arrival;
                    schedule.TripDate = tripDate;
                    schedule.Status = comboBox4.SelectedItem.ToString();

                    _context.SaveChanges();

                    MessageBox.Show("Расписание успешно обновлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}