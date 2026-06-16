using System;
using System.Windows.Forms;
using restoran9.Models; // Твоя папка с моделями базы данных

namespace restoran9.Forms
{
    public partial class NewCustomerForm : Form
    {
        // Специальное свойство, чтобы форма заказа (OrderForm) могла узнать ID созданного клиента
        public int CreatedCustomerId { get; private set; }

        public NewCustomerForm()
        {
            InitializeComponent();
            this.Text = "Новый посетитель"; // Четкий русский заголовок окна по Заданию №3
        }

        // КНОПКА «ДОБАВИТЬ»
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Встроенная валидация: проверяем, что поле ФИО не осталось пустым
            if (string.IsNullOrWhiteSpace(tbFullName.Text))
            {
                MessageBox.Show("Пожалуйста, введите ФИО клиента!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new restoran_bd_9Context())
                {
                    // Создаем новый объект для таблицы Customers
                    var newCustomer = new Customer
                    {
                        FullName = tbFullName.Text.Trim(),
                        IsPermanent = chbIsPermanent.Checked // Берем значение (true/false) из флажка
                    };

                    // Добавляем запись в контекст и сохраняем в базу данных
                    db.Customers.Add(newCustomer);
                    db.SaveChanges(); // Тут PostgreSQL автоматически генерирует новый CustomerId

                    // Запоминаем этот сгенерированный ID, чтобы передать его в форму заказа
                    CreatedCustomerId = newCustomer.CustomerId;

                    MessageBox.Show("Новый клиент успешно добавлен в базу данных!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK; // Сигнализируем, что сохранение прошло успешно
                    this.Close(); // Закрываем форму
                }
            }
            catch (Exception ex)
            {
                // Информативное сообщение об ошибке с заголовком и иконкой (Задание №3)
                MessageBox.Show($"Критическая ошибка при сохранении клиента: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // КНОПКА «ОТМЕНА»
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Передаем статус отмены
            this.Close(); // Просто закрываем форму
        }

        // Эти обработчики событий оставляем пустыми, они нам для логики не нужны
        private void tbFullName_TextChanged(object sender, EventArgs e) { }
        private void chbIsPermanent_CheckedChanged(object sender, EventArgs e) { }
    }
}