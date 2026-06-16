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
    public partial class ClientForm : Form
    {
        // Инициализируем контекст базы данных
        private tracking_of_requestsContext _context = new tracking_of_requestsContext();

        public ClientForm()
        {
            InitializeComponent();
            this.Text = "Список клиентов"; // Устанавливаем заголовок по ТЗ
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            LoadClients();
        }

        public void LoadClients()
        {
            try
            {
                var data = _context.Clients
                    .Select(s => new {
                        s.Id,
                        ФИО = s.FullName,
                        Телефон = s.Phone,
                        ПостоянныйКлиент = s.IsRegular ? "Да" : "Нет"
                    }).ToList();

                // Привязываем данные к DataGridView
                dataGridView1.DataSource = data;

                // Скрываем колонку с Id, чтобы не путать пользователя
                if (dataGridView1.Columns["Id"] != null)
                    dataGridView1.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка клиентов: {ex.Message}",
                                "Ошибка выполнения",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}