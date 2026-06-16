using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using restoran9.Models; // Папка с вашими сгенерированными моделями

namespace restoran9.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Настраиваем заголовок формы на русском языке
            this.Text = "Управление рестораном — Список заказов";

            // Автоматически загружаем данные в таблицу при открытии приложения
            LoadOrdersList();
        }

        // Вспомогательный класс для возврата результатов расчета скидки
        public class DiscountResult
        {
            public int Percent { get; set; }        // Процент скидки
            public decimal FinalAmount { get; set; } // Итоговая сумма к оплате
        }

        // ФУНКЦИЯ РАСЧЕТА СКИДКИ (Задание №2)
        private DiscountResult CalculateDiscount(decimal totalAmount, bool isPermanentCustomer)
        {
            int discountPercent = 0;

            // 1. Проверяем скидку от суммы заказа
            if (totalAmount > 2000)
            {
                discountPercent = 20; // 20% если сумма больше 2000
            }
            else if (totalAmount > 1000)
            {
                discountPercent = 10; // 10% если сумма больше 1000
            }

            // 2. Добавляем 5% для постоянных клиентов
            if (isPermanentCustomer)
            {
                discountPercent += 5;
            }

            // 3. Высчитываем итоговую стоимость
            decimal discountValue = totalAmount * ((decimal)discountPercent / 100);
            decimal finalAmount = totalAmount - discountValue;

            return new DiscountResult
            {
                Percent = discountPercent,
                FinalAmount = finalAmount
            };
        }

        // МЕТОД ЗАГРУЗКИ ДАННЫХ И ДЕТАЛИЗАЦИИ НА РУССКОМ ЯЗЫКЕ
        private void LoadOrdersList()
        {
            try
            {
                using (var db = new restoran_bd_9Context())
                {
                    // Загружаем заказы и подтягиваем связанные свойства
                    var ordersData = db.Orders
                        .Include(o => o.Customer)
                        .Include(o => o.Table)
                        .Include(o => o.Orderitems)
                            .ThenInclude(oi => oi.Dish)
                        .ToList();

                    // Формируем плоский список на русском языке для DataGridView
                    var displayList = ordersData.Select(o => {

                        // Собираем перечень блюд через свойство Orderitems
                        string dishesList = string.Join(", ", o.Orderitems.Select(oi => $"{oi.Dish.Name} ({oi.Quantity} шт.)"));

                        // Считаем общее количество позиций в заказе
                        int totalPositions = o.Orderitems.Sum(oi => oi.Quantity);

                        // Проверяем ФИО клиента
                        string customerName = o.Customer != null ? o.Customer.FullName : "Гость";

                        // Проверяем номер столика
                        string tableNum = o.Table != null ? o.Table.TableNumber.ToString() : "Не указан";

                        // Переводим статус из базы данных на русский язык
                        string statusRu = o.Status == "created" ? "Создан" :
                                          o.Status == "cooking" ? "Готовится" :
                                          o.Status == "done" ? "Выполнен" :
                                          o.Status == "paid" ? "Оплачен" : o.Status;

                        return new
                        {
                            НомерЗаказа = o.OrderId,
                            ФИОКлиента = customerName,
                            НомерСтолика = tableNum,
                            ПереченьБлюд = dishesList,
                            КоличествоПозиций = totalPositions,
                            СтоимостьЗаказа = o.TotalAmount,
                            ДатаЗаказа = o.OrderDate?.ToString("dd.MM.yyyy HH:mm") ?? "",
                            ПроцентСкидки = o.DiscountPercent.ToString() + "%",
                            ИтоговаяСтоимость = o.FinalAmount,
                            Статус = statusRu
                        };
                    }).ToList();

                    // Привязываем данные к таблице
                    dgvMain.DataSource = displayList;

                    // Принудительно задаем русские названия колонок в интерфейсе
                    dgvMain.Columns["НомерЗаказа"].HeaderText = "№ Заказа";
                    dgvMain.Columns["ФИОКлиента"].HeaderText = "ФИО Клиента";
                    dgvMain.Columns["НомерСтолика"].HeaderText = "Стол №";
                    dgvMain.Columns["ПереченьБлюд"].HeaderText = "Заказанные блюда";
                    dgvMain.Columns["КоличествоПозиций"].HeaderText = "Кол-во позиций";
                    dgvMain.Columns["СтоимостьЗаказа"].HeaderText = "Сумма (руб.)";
                    dgvMain.Columns["ДатаЗаказа"].HeaderText = "Дата/Время";
                    dgvMain.Columns["ПроцентСкидки"].HeaderText = "Скидка";
                    dgvMain.Columns["ИтоговаяСтоимость"].HeaderText = "Итого к оплате";
                    dgvMain.Columns["Статус"].HeaderText = "Статус заказа";

                    // Красиво распределяем колонки по ширине окна
                    dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка заказов: {ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // КНОПКА ОБНОВИТЬ СПИСОК
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrdersList();
        }

        // КНОПКА ДОБАВИТЬ ЗАКАЗ (Реализация последовательной навигации по Заданию №3)
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр формы в режиме добавления (пустой конструктор)
            OrderForm addForm = new OrderForm();

            // Открываем модально. Если пользователь сохранил изменения — обновляем список
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadOrdersList();
            }
        }

        // КНОПКА РЕДАКТИРОВАТЬ ЗАКАЗ (Реализация CRUD и валидация строки)
        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка в таблице
            if (dgvMain.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите заказ из таблицы для редактирования!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Вытаскиваем ID выбранного заказа из анонимного типа DataGridView
            int orderId = (int)dgvMain.CurrentRow.Cells["НомерЗаказа"].Value;

            // Создаем экземпляр формы, используя второй конструктор с ID
            OrderForm editForm = new OrderForm(orderId);

            // Открываем и проверяем результат закрытия
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadOrdersList();
            }
        }

        // КНОПКА УДAЛИТЬ ЗАКАЗ (Полноценный CRUD для Задания №1)
        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите заказ из таблицы для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем ID выбранного заказа
            int orderId = (int)dgvMain.CurrentRow.Cells["НомерЗаказа"].Value;

            // Запрос подтверждения на русском языке с иконкой вопроса
            var confirmResult = MessageBox.Show($"Вы уверены, что хотите удалить заказ №{orderId}?",
                                                 "Подтверждение удаления",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (var db = new restoran_bd_9Context())
                    {
                        var order = db.Orders.Find(orderId);
                        if (order != null)
                        {
                            db.Orders.Remove(order);
                            db.SaveChanges();

                            // Сразу обновляем таблицу на экране
                            LoadOrdersList();
                            MessageBox.Show("Заказ успешно удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось удалить заказ: {ex.Message}", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}