using delivery4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace delivery4.Forms
{
    public partial class ClientForm : Form
    {
        private deliveryContext _context = new deliveryContext();
        public ClientForm()
        {
            InitializeComponent();
            this.Text = "Список клиентов";
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            LoadClients();
        }
        public void LoadClients()
        {
            var data = _context.Clients
                .Select(s => new {
                    s.Id,
                    ФИО = s.Fio,
                    Телефон = s.Phone
                }).ToList();
            dataGridView1.DataSource = data;

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
    }
}
