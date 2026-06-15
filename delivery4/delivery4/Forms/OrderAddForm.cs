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
    public partial class OrderAddForm : Form
    {
        private deliveryContext _context = new deliveryContext();

        public OrderAddForm()
        {
            InitializeComponent();
            this.Text = "Добавление заказа"; // Скорректировано строго под регламент ТЗ

            cbStatus.Items.Clear();
            cbStatus.Items.AddRange(new string[] { "Новый", "В пути", "Доставлен", "Отменен" });
            cbStatus.SelectedIndex = 0;
        }

        private void OrderAddForm_Load(object sender, EventArgs e)
        {
            // Комментарий по ТЗ: Загрузка справочника клиентов в выпадающий список для связывания FK
            cbClient.DataSource = _context.Clients.ToList();
            cbClient.DisplayMember = "Fio";
            cbClient.ValueMember = "Id";
            cbClient.SelectedIndex = -1; 

            // Комментарий по ТЗ: Загрузка справочника курьеров в выпадающий список для связывания FK
            cbCourier.DataSource = _context.Couriers.ToList();
            cbCourier.DisplayMember = "Fio";
            cbCourier.ValueMember = "Id";
            cbCourier.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (cbClient.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите клиента из списка.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbCourier.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите курьера из списка.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParseExact(mtbDateOrder.Text, "dd.MM.yyyy",
                   null, System.Globalization.DateTimeStyles.None, out DateTime orderDate))
            {
                MessageBox.Show("Введите корректную дату заказа в формате ДД.ММ.ГГГГ.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbDateOrder.Focus();
                return;
            }
            if (orderDate > DateTime.Today)
            {
                MessageBox.Show("Дата заказа не может быть в будущем.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbDateOrder.Focus();
                return;
            }

            try
            {
                int clientId = (int)cbClient.SelectedValue;
                int courierId = (int)cbCourier.SelectedValue;

                var order = new Order
                {
                    ClientId = clientId,
                    CourierId = courierId,
                    OrderDate = orderDate,
                    Status = cbStatus.SelectedItem?.ToString() ?? "Новый",
                    Price = nudPrice.Value
                };

                _context.Orders.Add(order);
                _context.SaveChanges();

                MessageBox.Show("Заказ успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}