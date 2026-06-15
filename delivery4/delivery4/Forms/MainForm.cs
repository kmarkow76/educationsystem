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
    public partial class MainForm : Form
    {
        private deliveryContext _context = new deliveryContext();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        public void LoadOrders()
        {
            var data = _context.Orders
                .Select(s=> new { 
                НомерЗаказа = s.Id,
                ФиоКлиента = s.Client.Fio,
                АдресДоставки = s.Client.Address,
                ДатаОформления = s.OrderDate,
                Статус = s.Status
                }).ToList();
            dataGridView1.DataSource = data;
           
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new OrderAddForm();
            addForm.ShowDialog();
            LoadOrders();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ для редактирования");
                return;
            }
            int orderId = (int)dataGridView1.SelectedRows[0].Cells["НомерЗаказа"].Value;
            var editForm = new OrderEditForm(orderId);
            editForm.ShowDialog();
            LoadOrders();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ для удаления");
                return;
            }
            int orderId = (int)dataGridView1.SelectedRows[0].Cells["НомерЗаказа"].Value;
            DialogResult dialogResult = MessageBox.Show(
                $"Вы действительно хотите удалить заказ?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if(dialogResult == DialogResult.Yes)
            {
                try
                {
                    // Находим пациента в базе данных
                    var order = _context.Orders.Find(orderId);
                    if (order != null)
                    {
                        // Удаляем объект из контекста
                        _context.Orders.Remove(order);

                        // Сохраняем изменения в БД
                        _context.SaveChanges();

                        MessageBox.Show("Заказ успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Обновляем список пациентов на экране без перезапуска формы (Задание №3)
                        LoadOrders();
                    }
                    else
                    {
                        MessageBox.Show("Заказ уже удален или не найден в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении из базы данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bntViewCourier_Click(object sender, EventArgs e)
        {
            var courierForm = new CouriersForm();
            courierForm.ShowDialog();
        }

        private void btnViewClient_Click(object sender, EventArgs e)
        {
            var cleintForm = new ClientForm();
            cleintForm.ShowDialog();

        }
    }
}
