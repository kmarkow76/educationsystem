using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using service15.Models; // Подключаем сгенерированные модели из папки Models
using Microsoft.EntityFrameworkCore;

namespace service15.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // Жестко привязываем событие Load через код для надежности
            this.Load += new System.EventHandler(this.MainForm_Load);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadOrdersData();
        }

        /// <summary>
        /// Комментарий: Логика загрузки списка выполненных заявок с детализацией выплат мастерам на основе формул расчета (Задание №2)
        /// </summary>
        public void LoadOrdersData()
        {
            try
            {
                // Используем твое точное имя контекста базы данных
                using (var db = new service_bd_15Context())
                {
                    // Подгружаем заявки со всеми связями из PostgreSQL
                    var rawOrders = db.Orders
                        .Include(o => o.Client)
                        .Include(o => o.Master)
                        .Include(o => o.Service)
                        .ToList();

                    // Выполняем расчет вознаграждения в виде функции "на лету" согласно Заданию №2
                    var displayList = rawOrders.Select(o =>
                    {
                        decimal basePrice = o.Service.BasePrice; // Стоимость для клиента
                        decimal serviceCommission = basePrice * 0.20m; // Комиссия сервиса 20%
                        decimal bonusAmount = 0.00m; // Бонус за рейтинг по умолчанию

                        // Если рейтинг мастера выше 4.8, начисляем бонус +5% от базовой стоимости
                        if (o.Master.Rating > 4.80m)
                        {
                            bonusAmount = basePrice * 0.05m;
                        }

                        // Итоговая выплата мастеру (его 80% доли + бонус за рейтинг)
                        decimal finalMasterPayout = (basePrice - serviceCommission) + bonusAmount;

                        return new
                        {
                            Id = o.Id,
                            MasterName = o.Master.FullName,
                            ServiceDescription = o.Service.ServiceName,
                            ClientCost = Math.Round(basePrice, 2),
                            Commission = Math.Round(serviceCommission, 2),
                            Bonus = Math.Round(bonusAmount, 2),
                            MasterPayout = Math.Round(finalMasterPayout, 2),
                            Address = o.ExecutionAddress,
                            Date = o.ExecutionDate.ToShortDateString(),
                            Status = o.OrderStatus
                        };
                    }).ToList();

                    // Привязываем данные к твоей таблице dataGridView1
                    dataGridView1.DataSource = displayList;

                    // Оформляем красивые русские заголовки колонок
                    dataGridView1.Columns["Id"].Visible = false; // Скрываем технический ID
                    dataGridView1.Columns["MasterName"].HeaderText = "ФИО мастера";
                    dataGridView1.Columns["ServiceDescription"].HeaderText = "Описание услуги";
                    dataGridView1.Columns["ClientCost"].HeaderText = "Стоимость для клиента";
                    dataGridView1.Columns["Commission"].HeaderText = "Комиссия сервиса (20%)";
                    dataGridView1.Columns["Bonus"].HeaderText = "Бонус за рейтинг";
                    dataGridView1.Columns["MasterPayout"].HeaderText = "Итоговая выплата мастеру";
                    dataGridView1.Columns["Address"].HeaderText = "Адрес выполнения";
                    dataGridView1.Columns["Date"].HeaderText = "Дата";
                    dataGridView1.Columns["Status"].HeaderText = "Статус заявки";

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Регистрация заявки
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            OrderEditForm editForm = new OrderEditForm(null);
            editForm.ShowDialog();
            LoadOrdersData(); // Обновление списка без перезапуска (Задание №3)
        }

        // Кнопка: Редактирование заявки
        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите заявку для редактирования!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic selectedRow = dataGridView1.CurrentRow.DataBoundItem;
            int orderId = selectedRow.Id;

            OrderEditForm editForm = new OrderEditForm(orderId);
            editForm.ShowDialog();
            LoadOrdersData(); // Обновление списка без перезапуска (Задание №3)
        }

        // Кнопка: Удалить заявку
        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите заявку из списка для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic selectedRow = dataGridView1.CurrentRow.DataBoundItem;
            int orderId = selectedRow.Id;

            DialogResult result = MessageBox.Show("Удалить выбранную заявку?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var db = new service_bd_15Context())
                    {
                        var order = db.Orders.Find(orderId);
                        if (order != null)
                        {
                            db.Orders.Remove(order);
                            db.SaveChanges();
                            MessageBox.Show("Заявка успешно удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrdersData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Оставляем пустые обработчики, чтобы не ругался дизайнер формы
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}