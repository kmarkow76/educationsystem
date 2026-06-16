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
    public partial class DeviceForm : Form
    {
        public tracking_of_requestsContext _context = new tracking_of_requestsContext();
        public DeviceForm()
        {
            InitializeComponent();
            this.Text = "Список техники";
        }

        private void DeviceForm_Load(object sender, EventArgs e)
        {
            LoadDevice();
        }
        public void LoadDevice()
        {
            try
            {
                // Вытягиваем данные. Благодаря EF Core мы можем зайти в таблицу Клиентов через точку!
                var data = _context.Devices
                    .Select(s => new {
                        s.Id,
                        Владелец = s.Client.FullName, // Выводим понятное ФИО вместо ClientId
                ТипУстройства = s.DeviceType,
                        Бренд = s.Brand,
                        Модель = s.Model,
                        СерийныйНомер = s.SerialNumber
                    }).ToList();

                dataGridView1.DataSource = data;

                // Скрываем технический Id устройства
                if (dataGridView1.Columns["Id"] != null)
                    dataGridView1.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка техники: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
