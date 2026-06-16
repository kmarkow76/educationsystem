using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using agentstvo13.Models; // Твои модели

namespace agentstvo13.Forms
{
    public partial class ClientsListForm : Form
    {
        public ClientsListForm()
        {
            InitializeComponent();
            // Жестко привязываем событие загрузки, чтобы списки не были пустыми
            this.Load += new System.EventHandler(this.ClientsListForm_Load);
        }

        private void ClientsListForm_Load(object sender, EventArgs e)
        {
            LoadClientsData();
        }

        /// <summary>
        /// Комментарий: Логика загрузки списка клиентов из PostgreSQL в DataGridView
        /// </summary>
        private void LoadClientsData()
        {
            try
            {
                using (var db = new agentstvo_bd_13Context())
                {
                    // Получаем клиентов и преобразуем для красивого вывода
                    var clients = db.Clients.Select(c => new
                    {
                        Id = c.Id,
                        FullName = c.FullName,
                        Phone = c.Phone,
                        IsRepeatStatus = c.IsRepeat ? "Постоянный" : "Новый"
                    }).ToList();

                    dgvClients.DataSource = clients;

                    // Настраиваем русские заголовки колонок
                    dgvClients.Columns["Id"].Visible = false; // Скрываем ID
                    dgvClients.Columns["FullName"].HeaderText = "ФИО Клиента";
                    dgvClients.Columns["Phone"].HeaderText = "Номер телефона";
                    dgvClients.Columns["IsRepeatStatus"].HeaderText = "Статус клиента";

                    dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке клиентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Удалить клиента
        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите клиента из списка для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic selectedRow = dgvClients.CurrentRow.DataBoundItem;
            int clientId = selectedRow.Id;
            string clientName = selectedRow.FullName;

            DialogResult result = MessageBox.Show($"Вы действительно хотите удалить клиента \"{clientName}\"?\n\nВнимание: Если у этого клиента есть запланированные мероприятия, они также будут удалены!",
                                                  "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var db = new agentstvo_bd_13Context())
                    {
                        var client = db.Clients.Find(clientId);
                        if (client != null)
                        {
                            db.Clients.Remove(client);
                            db.SaveChanges(); // Сохраняем изменения в PostgreSQL

                            MessageBox.Show("Клиент успешно удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadClientsData(); // Обновляем таблицу на лету
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Кнопка: Назад
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Пустая заглушка для таблицы, чтобы убрать ошибку дизайнера CS1061
        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Метод пустой, ничего писать сюда не нужно
        }
    }
}