using drivingschool6.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drivingschool6.Forms
{
    public partial class CarForm : Form
    {
        private drivingshoolContext _context = new drivingshoolContext();
        public CarForm()
        {
            InitializeComponent();
            this.Text = "Список машин";
        }

        private void CarForm_Load(object sender, EventArgs e)
        {
            LoadCars();
        }

        public void LoadCars()
        {
            var data = _context.Vehicles
                .Select(s=> new {
                    s.Id,
                    МаркаМашины = s.Make,
                    ГосНомер = s.LicensePlate,
                    Тип = s.Type
                }).ToList();
            dataGridView1.DataSource = data;

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
    }
}
