using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using restoran9.Models; // Твоя папка с сгенерированными EF-моделями

namespace restoran9.Forms
{
    public partial class OrderForm : Form
    {
        private int? _orderId; // Хранит ID заказа, если мы зашли в режиме редактирования
        private List<OrderItemTemp> _itemsInCheck = new List<OrderItemTemp>(); // Локальный список блюд в чеке

        // Вспомогательный класс для хранения позиций чека на форме
        public class OrderItemTemp
        {
            public int DishId { get; set; }
            public string DishName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public decimal Total => Price * Quantity;
        }

        // КОНСТРУКТОР №1: Вызывается при создании НОВОГО заказа
        public OrderForm()
        {
            InitializeComponent();
            _orderId = null;
            this.Text = "Новый заказ"; // Русский заголовок окна
            InitFormLists();
        }

        // КОНСТРУКТОР №2: Вызывается при РЕДАКТИРОВАНИИ существующего заказа
        public OrderForm(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
            this.Text = "Редактирование заказа"; // Русский заголовок окна
            InitFormLists();
            LoadOrderDataForEdit();
        }

        // Первоначальное заполнение списков данными из базы данных
        private void InitFormLists()
        {
            try
            {
                using (var db = new restoran_bd_9Context())
                {
                    // Подгружаем клиентов в выпадающий список
                    cmbCustomer.DataSource = db.Customers.ToList();
                    cmbCustomer.DisplayMember = "FullName";
                    cmbCustomer.ValueMember = "CustomerId";

                    // Подгружаем столики
                    cmbTable.DataSource = db.Tables.ToList();
                    cmbTable.DisplayMember = "TableNumber";
                    cmbTable.ValueMember = "TableId";

                    // Подгружаем сотрудников (официантов)
                    cmbEmployee.DataSource = db.Employees.ToList();
                    cmbEmployee.DisplayMember = "FullName";
                    cmbEmployee.ValueMember = "EmployeeId";

                    // Подгружаем блюда меню
                    cmbDish.DataSource = db.Dishes.ToList();
                    cmbDish.DisplayMember = "Name";
                    cmbDish.ValueMember = "DishId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации компонентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Автоматическое заполнение полей данными из БД при редактировании
        private void LoadOrderDataForEdit()
        {
            try
            {
                using (var db = new restoran_bd_9Context())
                {
                    var order = db.Orders
                        .Include(o => o.Orderitems)
                        .ThenInclude(oi => oi.Dish)
                        .FirstOrDefault(o => o.OrderId == _orderId);

                    if (order != null)
                    {
                        cmbCustomer.SelectedValue = order.CustomerId ?? -1;
                        cmbTable.SelectedValue = order.TableId ?? -1;
                        cmbEmployee.SelectedValue = order.EmployeeId ?? -1;

                        // Возвращаем статус из формата БД на русский язык для комбобокса
                        cmbStatus.SelectedItem = order.Status == "created" ? "Создан" :
                                                 order.Status == "cooking" ? "Готовится" :
                                                 order.Status == "done" ? "Выполнен" :
                                                 order.Status == "paid" ? "Оплачен" : "Создан";

                        // Восстанавливаем список заказанных блюд
                        _itemsInCheck.Clear();
                        foreach (var item in order.Orderitems)
                        {
                            _itemsInCheck.Add(new OrderItemTemp
                            {
                                DishId = item.DishId,
                                DishName = item.Dish.Name,
                                Quantity = item.Quantity,
                                Price = item.PriceAtTime
                            });
                        }

                        RefreshOrderItemsGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подгрузке данных заказа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обновление таблицы чека и автоматический расчет стоимости по алгоритму (Задание №2)
        private void RefreshOrderItemsGrid()
        {
            dgvOrderItems.DataSource = null;

            // Вывод данных в таблицу с русскими названиями свойств
            dgvOrderItems.DataSource = _itemsInCheck.Select(i => new
            {
                Наименование = i.DishName,
                Количество = i.Quantity,
                Цена = i.Price,
                Всего = i.Total
            }).ToList();

            // Переименование заголовков таблицы чека на русский язык
            if (dgvOrderItems.Columns["Наименование"] != null)
            {
                dgvOrderItems.Columns["Наименование"].HeaderText = "Наименование блюда";
                dgvOrderItems.Columns["Количество"].HeaderText = "Кол-во";
                dgvOrderItems.Columns["Цена"].HeaderText = "Цена (руб.)";
                dgvOrderItems.Columns["Всего"].HeaderText = "Всего (руб.)";
                dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            // Вычисляем чистую сумму заказа
            decimal totalAmount = _itemsInCheck.Sum(i => i.Total);
            txtTotalAmount.Text = totalAmount.ToString("0.00");

            // Проверяем статус постоянного клиента для дополнительной скидки
            bool isPermanent = false;
            if (cmbCustomer.SelectedItem != null)
            {
                var currentCustomer = (Customer)cmbCustomer.SelectedItem;
                isPermanent = currentCustomer.IsPermanent ?? false;
            }

            // АЛГОРИТМ РАСЧЕТА СКИДКИ (Задание №2)
            int discountPercent = 0;
            if (totalAmount > 2000)
            {
                discountPercent = 20; // 20% если больше 2000
            }
            else if (totalAmount > 1000)
            {
                discountPercent = 10; // 10% если больше 1000
            }

            if (isPermanent)
            {
                discountPercent += 5; // Дополнительные 5% постоянным клиентам
            }

            // Считаем финальные суммы
            decimal discountValue = totalAmount * ((decimal)discountPercent / 100);
            decimal finalAmount = totalAmount - discountValue;

            txtDiscount.Text = discountPercent.ToString() + "%";
            txtFinalAmount.Text = finalAmount.ToString("0.00");
        }

        // Перерасчет скидки при изменении выбранного клиента
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshOrderItemsGrid();
        }

        // КНОПКА «+»: БЫСТРОЕ ДОБАВЛЕНИЕ НОВОГО КЛИЕНТА В БАЗУ ДАННЫХ
        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            // Открываем созданное окно добавления клиента
            NewCustomerForm customerWindow = new NewCustomerForm();

            // Если администратор сохранил клиента и нажал «Добавить»
            if (customerWindow.ShowDialog() == DialogResult.OK)
            {
                // Полностью обновляем списки, чтобы новый клиент скачался из PostgreSQL
                InitFormLists();

                // Автоматически выбираем созданного клиента в выпадающем списке по его ID
                cmbCustomer.SelectedValue = customerWindow.CreatedCustomerId;
            }
        }

        // КНОПКА: ДОБАВИТЬ БЛЮДО В ЧЕК
        private void btnAddDish_Click(object sender, EventArgs e)
        {
            if (cmbDish.SelectedItem == null) return;

            var selectedDish = (Dish)cmbDish.SelectedItem;
            int quantity = (int)numQuantity.Value;

            // Если блюдо уже добавляли — увеличиваем количество
            var existingItem = _itemsInCheck.FirstOrDefault(i => i.DishId == selectedDish.DishId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _itemsInCheck.Add(new OrderItemTemp
                {
                    DishId = selectedDish.DishId,
                    DishName = selectedDish.Name,
                    Quantity = quantity,
                    Price = selectedDish.Price
                });
            }

            RefreshOrderItemsGrid();
        }

        // КНОПКА: СОХРАНИТЬ ЗАКАЗ (Добавление / Изменение в БД с валидацией)
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Встроенная обработка ошибок ввода пользователя (Валидация по Заданию №3)
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите клиента из списка!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbTable.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, укажите номер столика!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_itemsInCheck.Count == 0)
            {
                MessageBox.Show("Нельзя сохранить пустой заказ! Добавьте хотя бы одно блюдо в чек.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new restoran_bd_9Context())
                {
                    Order order;

                    // Если редактируем существующий заказ
                    if (_orderId.HasValue)
                    {
                        order = db.Orders.Include(o => o.Orderitems).FirstOrDefault(o => o.OrderId == _orderId.Value);
                        if (order == null) return;

                        // Очищаем старые позиции чека, чтобы перезаписать их новыми актуальными
                        db.Orderitems.RemoveRange(order.Orderitems);
                    }
                    else // Если создаем новый заказ
                    {
                        order = new Order();
                        db.Orders.Add(order);
                    }

                    // Наполняем модель данными из формы
                    order.CustomerId = (int)cmbCustomer.SelectedValue;
                    order.TableId = (int)cmbTable.SelectedValue;
                    order.EmployeeId = (int)cmbEmployee.SelectedValue;

                    if (!_orderId.HasValue)
                    {
                        order.OrderDate = DateTime.Now;
                    }

                    // Переводим выбранный русский статус в код для БД
                    if (cmbStatus.SelectedItem != null)
                    {
                        string statusRu = cmbStatus.SelectedItem.ToString();
                        order.Status = statusRu == "Создан" ? "created" :
                                       statusRu == "Готовится" ? "cooking" :
                                       statusRu == "Выполнен" ? "done" :
                                       statusRu == "Оплачен" ? "paid" : "created";
                    }
                    else
                    {
                        order.Status = "created";
                    }

                    order.TotalAmount = decimal.Parse(txtTotalAmount.Text);
                    order.DiscountPercent = int.Parse(txtDiscount.Text.Replace("%", ""));
                    order.FinalAmount = decimal.Parse(txtFinalAmount.Text);

                    // Переносим позиции блюд из локального списка в базу данных
                    foreach (var item in _itemsInCheck)
                    {
                        order.Orderitems.Add(new Orderitem
                        {
                            DishId = item.DishId,
                            Quantity = item.Quantity,
                            PriceAtTime = item.Price
                        });
                    }

                    db.SaveChanges(); // Сохранение изменений в PostgreSQL
                    MessageBox.Show("Данные по заказу успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Критическая ошибка базы данных при сохранении: {ex.Message}", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // КНОПКА: НАЗАД (Последовательная навигация)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Неиспользуемые сгенерированные заглушки методов оставляем пустыми
        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbDish_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numQuantity_ValueChanged(object sender, EventArgs e) { }
        private void dgvOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtTotalAmount_TextChanged(object sender, EventArgs e) { }
        private void txtDiscount_TextChanged(object sender, EventArgs e) { }
        private void txtFinalAmount_TextChanged(object sender, EventArgs e) { }
    }
}