using System;
using System.Windows.Forms;
using agentstvo13.Models; // Подключаем модели

namespace agentstvo13.Forms
{
    public partial class AddClientForm : Form
    {
        public AddClientForm()
        {
            InitializeComponent();
        }

        // Кнопка: Сохранить клиента в базу данных
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация данных (проверка на пустые поля)
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля формы!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new agentstvo_bd_13Context())
                {
                    // Создаем объект нового клиента строго по твоей модели
                    Client newClient = new Client
                    {
                        FullName = txtFullName.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        IsRepeat = chkIsRepeat.Checked
                    };

                    db.Clients.Add(newClient);
                    db.SaveChanges(); // Сохраняем в PostgreSQL

                    MessageBox.Show("Клиент успешно зарегистрирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Закрываем окно
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении клиента: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Добавь эти строчки в самый низ AddClientForm.cs, чтобы убрать ошибки:
        private void txtFullName_TextChanged(object sender, EventArgs e) { }
        private void txtPhone_TextChanged(object sender, EventArgs e) { }
        private void chkIsRepeat_CheckedChanged(object sender, EventArgs e) { }
    }
}