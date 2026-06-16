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
    public partial class DriverForm : Form
    {
        private routetrackingContext _context = new routetrackingContext();
        public DriverForm()
        {
            InitializeComponent();
            this.Text = "Список водителей";
        }
        private void DriverForm_Load(object sender, EventArgs e)
        {
            LoadDriver();
        }
        public void LoadDriver()
        {
            var data = _context.Drivers.Select(s => new {
                s.Id,
                ФИО = s.FullName,
                Телефон = s.Phone,
                Права = s.LicenseNumber
            }).ToList();

            dataGridView1.DataSource = data;
            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
    }
}
