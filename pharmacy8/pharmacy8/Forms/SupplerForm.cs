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
    public partial class SupplerForm : Form
    {
        private pharmacyContext _context = new pharmacyContext();
        public SupplerForm()
        {
            InitializeComponent();
            this.Text = "Список поставщиков";
        }

        private void SupplerForm_Load(object sender, EventArgs e)
        {
            LoadSupplers();
        }
        public void LoadSupplers()
        {
            var data = _context.Suppliers
                .Select(s => new {
                    s.Id,
                    ФИО = s.Name,
                    Телефон = s.Phone,
                    Адрес = s.Address
                }).ToList();

            dataGridView1.DataSource = data;

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
    }
}
