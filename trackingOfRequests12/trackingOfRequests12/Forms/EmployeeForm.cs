using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using trackingOfRequests12.Models;

namespace trackingOfRequests12.Forms
{
    public partial class EmployeeForm : Form
    {
        public tracking_of_requestsContext _context = new tracking_of_requestsContext();
        public EmployeeForm()
        {
            InitializeComponent();
            this.Text = "Список сотрудников";
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }
        public void LoadEmployees()
        {
            var data = _context.Employees.Select(s=> new { 
            s.Id,
            ФИО = s.FullName,
            Телефон = s.Phone,
            Должность = s.Position
            }).ToList();
            dataGridView1.DataSource = data;

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
    }
}
