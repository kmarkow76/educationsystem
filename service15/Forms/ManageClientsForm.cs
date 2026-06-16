using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using service15.Models; // Подключаем сгенерированные модели СУБД

namespace service15.Forms
{
    public partial class ManageClientsForm : Form
    {
        // Переменная для хранения ID выбранного из таблицы клиента (null — если создаем нового)
        private int? _selectedClientId = null;

        public ManageClientsForm()
        {
            InitializeComponent();

            // Настраиваем принудительную привязку события загрузки формы через код
            this.Load += new System.EventHandler(this.ManageClientsForm_Load);
        }

        // Событие, срабатывающее автоматически при открытии окна
        private void ManageClientsForm_Load(object sender, EventArgs e)
        {
            LoadClientsData();
        }

        /// <summary>
        /// Комментарий: Логика загрузки и отображения списка клиентов из СУБД service_bd_15 в таблицу
        /// </summary>
        private void LoadClientsData()
        {
            try
            {
                using (var db = new service_bd_15Context())
                {
                    // Извлекаем только нужные для отображения свойства клиентов
                    var clientsList = db.Clients
                        .Select(c => new
                        {
                            Id = c.Id,
                            FullName = c.FullName,
                            Phone = c.Phone
                        })
                        .ToList();

                    // Привязываем список к твоей таблице dgvClients
                    dgvClients.DataSource = clientsList;

                    // Оформляем понятные русские заголовки колонок
                    dgvClients.Columns["Id"].Visible = false; // Скрываем технический ID от пользователя
                    dgvClients.Columns["FullName"].HeaderText = "ФИО Клиента";
                    dgvClients.Columns["Phone"].HeaderText = "Номер телефона";

                    dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке клиентов: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Сбрасываем поля ввода в исходное состояние
            ClearFields();
        }

        // Событие: клик по ячейке таблицы (выбор клиента для редактирования)
        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClients.CurrentRow != null)
            {
                // Извлекаем строку как динамический объект
                dynamic selectedRow = dgvClients.CurrentRow.DataBoundItem;

                // Запоминаем ID выбранного клиента и переносим данные в поля формы
                _selectedClientId = selectedRow.Id;
                txtFullName.Text = selectedRow.FullName;
                txtPhone.Text = selectedRow.Phone;

                // Переводим кнопку в режим редактирования данных
                btnSave.Text = "Изменить данные";
            }
        }

        // Кнопка: Сохранить (Добавление нового или Изменение существующего)
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация входных данных: ФИО и телефон не должны быть пустыми
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Пожалуйста, заполните поля ФИО и Номер телефона!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new service_bd_15Context())
                {
                    if (_selectedClientId == null)
                    {
                        // Режим: ДОБАВЛЕНИЕ нового клиента
                        Client newClient = new Client
                        {
                            FullName = txtFullName.Text.Trim(),
                            Phone = txtPhone.Text.Trim()
                        };
                        db.Clients.Add(newClient);
                    }
                    else
                    {
                        // Режим: РЕДАКТИРОВАНИЕ данных клиента
                        var clientToUpdate = db.Clients.Find(_selectedClientId);
                        if (clientToUpdate != null)
                        {
                            clientToUpdate.FullName = txtFullName.Text.Trim();
                            clientToUpdate.Phone = txtPhone.Text.Trim();
                        }
                    }

                    db.SaveChanges(); // Сохраняем изменения в PostgreSQL
                    MessageBox.Show("Данные справочника клиентов успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Перезагружаем таблицу, чтобы сразу увидеть изменения
                    LoadClientsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении клиента: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Удалить клиента
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedClientId == null)
            {
                MessageBox.Show("Пожалуйста, выберите клиента из таблицы для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Вы действительно хотите безвозвратно удалить клиента \"{txtFullName.Text}\"?\n\nВнимание: Из-за каскадного удаления все его заявки также будут удалены!",
                                                  "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var db = new service_bd_15Context())
                    {
                        var clientToDelete = db.Clients.Find(_selectedClientId);
                        if (clientToDelete != null)
                        {
                            db.Clients.Remove(clientToDelete);
                            db.SaveChanges(); // Фиксируем удаление в базе

                            MessageBox.Show("Клиент успешно удален из системы!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadClientsData(); // Обновляем сетку данных на лету
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении записи: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Кнопка: Закрыть / Назад
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрываем окно справочника и возвращаемся к форме заявки
        }

        /// <summary>
        /// Дополнительный метод для сброса полей формы в исходное состояние
        /// </summary>
        private void ClearFields()
        {
            _selectedClientId = null;
            txtFullName.Clear();
            txtPhone.Clear();
            btnSave.Text = "Добавить нового";
        }

        // Оставляем пустые заглушки для текстовых полей, чтобы не ругался дизайнер
        private void txtFullName_TextChanged(object sender, EventArgs e) { }
        private void txtPhone_TextChanged(object sender, EventArgs e) { }
    }
}