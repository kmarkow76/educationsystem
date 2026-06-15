using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using delivery4.Models;

namespace delivery4.Forms
{
    public partial class OrderEditForm : Form
    {
        private deliveryContext _context = new deliveryContext();
        private readonly int _orderId;
        public OrderEditForm(int orderId)
        {
            InitializeComponent();
            this.Text = "Редактирование заказа";
            _orderId = orderId;

            cbStatus.Items.Clear();
            cbStatus.Items.AddRange(new string[] { "Доставлен", "В пути", "Отменен", "Новый" });
        }

        // Замени свой метод загрузки формы на этот:
        private void OrderEditForm_Load(object sender, EventArgs e)
        {
            
            cbClient.DataSource = _context.Clients.ToList();
            cbClient.DisplayMember = "Fio";
            cbClient.ValueMember = "Id";

            cbCourier.DataSource = _context.Couriers.ToList();
            cbCourier.DisplayMember = "Fio";
            cbCourier.ValueMember = "Id";

            var order = _context.Orders.Find(_orderId);
            if (order == null)
            {
                MessageBox.Show("Заказ не найден в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

           
            cbClient.SelectedValue = order.ClientId;
            cbCourier.SelectedValue = order.CourierId;

            mtbDateOrder.Text = order.OrderDate.ToString("dd.MM.yyyy");

            if (cbStatus.Items.Contains(order.Status))
                cbStatus.SelectedItem = order.Status;
            else
                cbStatus.SelectedIndex = 0;

            nudPrice.Value = order.Price;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbClient.Text))
            {
                MessageBox.Show("Поле клиент обязательно для заполнения.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(cbCourier.Text))
            {
                MessageBox.Show("Поле клиент обязательно для заполнения.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var order = _context.Orders.Find(_orderId);
                if (order != null)
                {
                    order.ClientId = (int)cbClient.SelectedValue;
                    order.CourierId = (int)cbCourier.SelectedValue;
                    order.OrderDate = orderDate;
                    order.Status = cbStatus.SelectedItem?.ToString() ?? "Новый";
                    order.Price = nudPrice.Value;
                    

                    _context.SaveChanges();
                    MessageBox.Show("Данные заказа успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
