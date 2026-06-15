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
    public partial class InstructorForm : Form
    {
        private drivingshoolContext _context = new drivingshoolContext();
        public InstructorForm()
        {
            InitializeComponent();
            this.Text = "Список инструкторов";
        }

        private void InstructorForm_Load(object sender, EventArgs e)
        {
            LoadInstructors();
        }
        public void LoadInstructors()
        {
            var data = _context.Instructors
                .Select(s => new {
                    s.Id,
                    ФИО = s.FullName,
                    Телефон = s.Phone
                }).ToList();
            dataGridView1.DataSource = data;

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
    }
}
