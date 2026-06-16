// ScheduleForm.cs
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
    public partial class ScheduleForm : Form
    {
        private routetrackingContext _context = new routetrackingContext();

        public ScheduleForm()
        {
            InitializeComponent();
            this.Text = "Расписание рейсов";
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        // Загрузка списка расписания с детализацией маршрута
        public void LoadSchedule()
        {
            var data = _context.Schedules
                .Select(s => new
                {
                    s.Id,
                    Номер_маршрута = s.Route.RouteNumber,
                    Маршрут = s.Route.StartPoint + " → " + s.Route.EndPoint,
                    Дата_рейса = s.TripDate,
                    Отправление = s.DepartureTime,
                    Прибытие = s.ArrivalTime,
                    Транспорт = s.Vehicle.Model,
                    Водитель = s.Driver.FullName,
                    Стоимость = s.Route.BasePrice,
                    s.Status
                })
                .ToList()
                .Select(s => new
                {
                    s.Id,
                    s.Номер_маршрута,
                    s.Маршрут,
                    Дата_рейса = s.Дата_рейса.ToShortDateString(),
                    Отправление = s.Отправление.ToString(@"hh\:mm"),
                    Прибытие = s.Прибытие.ToString(@"hh\:mm"),
                    s.Транспорт,
                    s.Водитель,
                    Стоимость = $"{s.Стоимость:F2} руб.",
                    Статус = s.Status
                })
                .ToList();

            dataGridView1.DataSource = data;

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Номер_маршрута"].HeaderText = "№ маршрута";
            dataGridView1.Columns["Маршрут"].HeaderText = "Маршрут";
            dataGridView1.Columns["Дата_рейса"].HeaderText = "Дата рейса";
            dataGridView1.Columns["Отправление"].HeaderText = "Отправление";
            dataGridView1.Columns["Прибытие"].HeaderText = "Прибытие";
            dataGridView1.Columns["Транспорт"].HeaderText = "Транспорт";
            dataGridView1.Columns["Водитель"].HeaderText = "Водитель";
            dataGridView1.Columns["Стоимость"].HeaderText = "Стоимость";
            dataGridView1.Columns["Статус"].HeaderText = "Статус";

            dataGridView1.ReadOnly = true;
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            var addSchedule = new AddScheduleForm();
            addSchedule.ShowDialog();
            // Обновляем список после добавления
            LoadSchedule();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите расписание для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int scheduleId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            var editSchedule = new EditScheduleForm(scheduleId);
            editSchedule.ShowDialog();
            // Обновляем список после редактирования
            LoadSchedule();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите расписание для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int scheduleId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

            DialogResult result = MessageBox.Show(
                "Вы действительно хотите удалить этот рейс?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var schedule = _context.Schedules.Find(scheduleId);
                    if (schedule != null)
                    {
                        _context.Schedules.Remove(schedule);
                        _context.SaveChanges();

                        MessageBox.Show("Рейс успешно удалён.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSchedule();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}