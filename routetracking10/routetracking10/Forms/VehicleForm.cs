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
    public partial class VehicleForm : Form
    {
        private routetrackingContext _context = new routetrackingContext();
        public VehicleForm()
        {
            InitializeComponent();
            this.Text = "Список транспорта";
        }

        private void VehicleForm_Load(object sender, EventArgs e)
        {
            LoadVehicle();
        }
        public void LoadVehicle()
        {
            var data = _context.Vehicles.Select(s=> new { 
                        s.Id,
                        ГосНомер = s.LicensePlate,
                        Марка = s.Model,
                        Вместительность = s.Capacity,
                        Тип = s.Type
            }).ToList();

            dataGridView1.DataSource = data;
            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
    }
}
