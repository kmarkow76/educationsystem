using pharmacy8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacy8.Forms
{
    public partial class EmployeeForm : Form
    {
        private pharmacyContext _context = new pharmacyContext();
        public EmployeeForm()
        {
            InitializeComponent();
            this.Text = "Список cотрудников";
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadEmployee();
        }
        public void LoadEmployee()
        {
            var data = _context.Employees
                .Select(s => new {
                    s.Id,
                    ФИО = s.Name,
                    Телефон = s.Phone
                }).ToList();

            dataGridView1.DataSource = data;

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
    }
}
