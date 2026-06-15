using dentistry2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dentistry2.Forms
{
    public partial class DoctorForm : Form
    {
        private dentistry2Context _context = new dentistry2Context();
        public DoctorForm()
        {
            InitializeComponent();
            this.Text = "Список докторов";
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            LoadDoctors();
        }
        
        public void LoadDoctors()
        {
            var data = _context.Doctors
               .Select(s => new
               {
                   s.Id,
                   ФИО = s.Fio,
                   Телефон = s.Phone,
                   Специальность = s.Specialties
               })
               .ToList();
            dataGridView1.DataSource = data;

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
    }
}
