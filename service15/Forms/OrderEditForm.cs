using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using service15.Models; // Подключаем наши модели СУБД

namespace service15.Forms
{
    public partial class OrderEditForm : Form
    {
        // Переменная для хранения ID редактируемой заявки (null, если создаем новую)
        private int? _orderId;

        // Модифицированный конструктор, который мы вызываем из MainForm
        public OrderEditForm(int? orderId)
        {
            InitializeComponent();
            _orderId = orderId;

            // Настраиваем жесткую привязку события загрузки формы
            this.Load += new System.EventHandler(this.OrderEditForm_Load);

            // Настраиваем заголовки окон в зависимости от режима работы (Задание №3)
            if (_orderId == null)
            {
                this.Text = "Регистрация заявки";
            }
            else
            {
                this.Text = "Редактирование заявки";
            }
        }

        // Главное событие загрузки формы
        private void OrderEditForm_Load(object sender, EventArgs e)
        {
            LoadComboboxData();

            // Если мы в режиме редактирования — автоматически загружаем данные старой заявки в поля (Задание №3)
            if (_orderId != null)
            {
                LoadExistingOrderData();
            }
        }

        /// <summary>
        /// Комментарий: Логика загрузки справочников клиентов, мастеров и видов работ в ComboBox из СУБД service_bd_15
        /// </summary>
        private void LoadComboboxData()
        {
            try
            {
                using (var db = new service_bd_15Context())
                {
                    // 1. Загрузка клиентов
                    var clients = db.Clients.ToList();
                    cmbClients.DataSource = clients;
                    cmbClients.DisplayMember = "FullName";
                    cmbClients.ValueMember = "Id";

                    // 2. Загрузка видов работ (услуг)
                    var services = db.Services.ToList();
                    cmbServices.DataSource = services;
                    cmbServices.DisplayMember = "ServiceName";
                    cmbServices.ValueMember = "Id";

                    // 3. Загрузка мастеров
                    var masters = db.Masters.ToList();
                    cmbMasters.DataSource = masters;
                    cmbMasters.DisplayMember = "FullName";
                    cmbMasters.ValueMember = "Id";

                    // 4. Заполнение фиксированных статусов заявок (Задание №3)
                    cmbStatus.Items.Clear();
                    cmbStatus.Items.Add("Новая");
                    cmbStatus.Items.Add("В работе");
                    cmbStatus.Items.Add("Выполнена");
                    cmbStatus.Items.Add("Отменена");
                    cmbStatus.SelectedIndex = 0; // По умолчанию "Новая"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке справочников: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Комментарий: Автоматическая загрузка данных существующей заявки в поля формы при редактировании (Задание №3)
        /// </summary>
        private void LoadExistingOrderData()
        {
            try
            {
                using (var db = new service_bd_15Context())
                {
                    var order = db.Orders.Find(_orderId);
                    if (order != null)
                    {
                        cmbClients.SelectedValue = order.ClientId;
                        cmbServices.SelectedValue = order.ServiceId;
                        cmbMasters.SelectedValue = order.MasterId;
                        txtAddress.Text = order.ExecutionAddress;
                        dateTimePicker1.Value = order.ExecutionDate;
                        cmbStatus.SelectedItem = order.OrderStatus;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подгрузки данных заявки: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Сохранить (Добавление или Изменение)
        private void btnSave_Click(object sender, EventArgs e)
        {
            // --- ВСТРОЕННАЯ ОБРАБОТКА ОШИБОК И ВАЛИДАЦИЯ (Задание №3) ---

            // 1. Проверка указания адреса
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Пожалуйста, укажите адрес выполнения работ!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus(); // Визуальная подсказка: фокус на поле ввода адреса
                return;
            }

            // 2. Проверка выбора вида работ
            if (cmbServices.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите вид работ из списка!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new service_bd_15Context())
                {
                    if (_orderId == null)
                    {
                        // Режим: ДОБАВЛЕНИЕ новой заявки
                        Order newOrder = new Order
                        {
                            ClientId = (int)cmbClients.SelectedValue,
                            ServiceId = (int)cmbServices.SelectedValue,
                            MasterId = (int)cmbMasters.SelectedValue,
                            ExecutionAddress = txtAddress.Text.Trim(),
                            ExecutionDate = dateTimePicker1.Value.Date,
                            OrderStatus = cmbStatus.SelectedItem.ToString()
                        };

                        db.Orders.Add(newOrder);
                    }
                    else
                    {
                        // Режим: РЕДАКТИРОВАНИЕ существующей заявки
                        var orderToUpdate = db.Orders.Find(_orderId);
                        if (orderToUpdate != null)
                        {
                            orderToUpdate.ClientId = (int)cmbClients.SelectedValue;
                            orderToUpdate.ServiceId = (int)cmbServices.SelectedValue;
                            orderToUpdate.MasterId = (int)cmbMasters.SelectedValue;
                            orderToUpdate.ExecutionAddress = txtAddress.Text.Trim();
                            orderToUpdate.ExecutionDate = dateTimePicker1.Value.Date;
                            orderToUpdate.OrderStatus = cmbStatus.SelectedItem.ToString();
                        }
                    }

                    db.SaveChanges(); // Сохраняем изменения в PostgreSQL
                    MessageBox.Show("Данные заявки успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Возврат назад (Задание №3)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения в базу данных: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Отмена / Возврат назад
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Последовательная навигация: возврат на MainForm
        }

        // ============================================================================
        // МЕТОДЫ-ЗАГЛУШКИ ДЛЯ ИЗБЕЖАНИЯ ОШИБОК ДИЗАЙНЕРА CS1061
        // ============================================================================
        private void cmbClients_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbServices_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbMasters_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtAddress_TextChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) { }

        private void btnFastAddClient_Click(object sender, EventArgs e)
        {
            // Открываем справочник-окно клиентов
            ManageClientsForm form = new ManageClientsForm();
            form.ShowDialog();
            LoadComboboxData(); // Перезагружаем списки на лету
        }

        private void btnFastAddMaster_Click(object sender, EventArgs e)
        {
            // Открываем справочник-окно мастеров
            ManageMastersForm form = new ManageMastersForm();
            form.ShowDialog();
            LoadComboboxData(); // Перезагружаем списки на лету
        }
    }
}