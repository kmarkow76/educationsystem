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
    public partial class PassengerForm : Form
    {
        private routetrackingContext _context = new routetrackingContext();
        public PassengerForm()
        {
            InitializeComponent();
            this.Text = "Список пассажиров";
        }

        private void PassengerForm_Load(object sender, EventArgs e)
        {
            LoadPassenger();
        }
        public void LoadPassenger()
        {
            var data = _context.Passengers.Select(s => new {
                s.Id,
                ФИО = s.FullName,
                Телефон = s.Phone,
                Льготный = s.IsPrivileged,
                Регулярный = s.IsRegular
            }).ToList();

            dataGridView1.DataSource = data;
            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
    }
}
