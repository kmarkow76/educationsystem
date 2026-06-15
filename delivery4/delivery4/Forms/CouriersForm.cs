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
    public partial class CouriersForm : Form
    {
        private deliveryContext _contex = new deliveryContext(); 
        public CouriersForm()
        {
            InitializeComponent();
            this.Text = "Список курьеров";

            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now.Date;
        }

        private void CouriersForm_Load(object sender, EventArgs e)
        {
            LoadCourier();
        }
        public void LoadCourier()
        {
            try
            {
                DateTime startDate = dtpStart.Value.Date;
                DateTime endDate = dtpEnd.Value.Date.AddDays(1).AddTicks(-1); // до 23:59:59.999 включительно

                var data = _contex.Couriers
                    .Select(s => new
                    {
                        s.Id,
                        ФИО = s.Fio,
                        Телефон = s.Phone,
                        КоличествоЗаказов = s.Orders.Count(o =>
                            o.OrderDate >= startDate &&
                            o.OrderDate <= endDate &&
                            o.Status == "Доставлен")
                    }).ToList();

                dataGridView1.DataSource = data;

                if (dataGridView1.Columns["Id"] != null)
                    dataGridView1.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчете доставок: {ex.Message}",
                    "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadCourier();
        }

    }
}
