using routetracking10.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace routetracking10.Forms
{
    public partial class MainForm : Form
    {
        private routetrackingContext _context = new routetrackingContext();
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Список маршрутов";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadRoute();
        }
        public void LoadRoute()
        {
            var data = _context.Routes
                .Select(s => new { 
                    s.Id,
                    НомерМаршрута = s.RouteNumber,
                    НачальнаяТочка = s.StartPoint,
                    КонечнаяТочка = s.EndPoint,
                    Цена = s.BasePrice
                }).ToList();
            dataGridView1.DataSource = data;

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
        private void bntAdd_Click(object sender, EventArgs e)
        {
            var addRoute = new AddRouteForm();
            addRoute.ShowDialog();
            LoadRoute();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите маршрут для редактирования");
                return;
            }
            int routeId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            var editRoute = new EditRouteForm(routeId);
            editRoute.ShowDialog();
            LoadRoute();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("");
                return;
            }
            int routeId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

            DialogResult dialogResult = MessageBox.Show(
                "Вы действительно хотите удалить выбранный маршрут?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    var route = _context.Routes.Find(routeId);
                    if (route != null)
                    {
                        _context.Routes.Remove(route);
                        _context.SaveChanges();

                        MessageBox.Show("Маршрут успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRoute();
                    }
                    else
                    {
                        MessageBox.Show("Маршрут уже удален или не найден в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Маршрут при удалении из базы данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnViewSchedule_Click(object sender, EventArgs e)
        {
            var viewSchedule = new ScheduleForm();
            viewSchedule.ShowDialog();
        }

        private void btnViewDrivers_Click(object sender, EventArgs e)
        {
            var viewDrivers = new DriverForm();
            viewDrivers.ShowDialog();
        }

        private void btnViewPassenger_Click(object sender, EventArgs e)
        {
            var viewPassengers = new PassengerForm();
            viewPassengers.ShowDialog();
        }

        private void btnViewCars_Click(object sender, EventArgs e)
        {
            var viewCars = new VehicleForm();
            viewCars.ShowDialog();
        }

        private void btnViewTickets_Click(object sender, EventArgs e)
        {
            var viewTickets = new TicketForm();
            viewTickets.ShowDialog();
        }
    }
}
