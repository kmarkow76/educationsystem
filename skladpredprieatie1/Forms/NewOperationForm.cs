using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using skladpredprieatie1.Models; // Доступ к контексту базы данных

namespace skladpredprieatie1.Forms
{
    public partial class NewOperationForm : Form
    {
        public NewOperationForm()
        {
            InitializeComponent();

            // Привязываем системное событие загрузки формы через код
            this.Load += new System.EventHandler(this.NewOperationForm_Load);
        }

        // Событие при открытии окна
        private void NewOperationForm_Load(object sender, EventArgs e)
        {
            LoadInitialData();

            // Ставим тип операции по умолчанию, чтобы комбобокс не был пустым
            if (cbOperationType.Items.Count > 0)
            {
                cbOperationType.SelectedIndex = 0; // Выберет "Поступление"
            }
        }

        /// <summary>
        /// Комментарий: Логика первоначальной загрузки списков товаров и сотрудников из БД в ComboBox
        /// </summary>
        private void LoadInitialData()
        {
            try
            {
                using (var db = new skladpredprieatie_bd_1Context())
                {
                    // 1. Загружаем товары
                    cbProduct.DataSource = db.Products.ToList();
                    cbProduct.DisplayMember = "ProductName";
                    cbProduct.ValueMember = "Id";

                    // 2. Загружаем сотрудников
                    cbEmployee.DataSource = db.Employees.ToList();
                    cbEmployee.DisplayMember = "FullName";
                    cbEmployee.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации данных: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Провести операцию (Основная логика со сквозным контролем остатков)
        private void btnExecute_Click(object sender, EventArgs e)
        {
            // --- ВАЛИДАЦИЯ ДАННЫХ (Задание №3) ---
            if (cbProduct.SelectedValue == null || cbEmployee.SelectedValue == null || cbOperationType.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля формы!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string operationType = cbOperationType.SelectedItem.ToString();
            int inputQuantity = (int)numQuantity.Value;
            int productId = (int)cbProduct.SelectedValue;
            int employeeId = (int)cbEmployee.SelectedValue;

            // Если это выдача, проверяем, указан ли получатель
            if (operationType == "Выдача" && string.IsNullOrWhiteSpace(tbRecipient.Text))
            {
                MessageBox.Show("При выдаче товара необходимо обязательно указать получателя!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbRecipient.Focus();
                return;
            }

            try
            {
                using (var db = new skladpredprieatie_bd_1Context())
                {
                    // Находим товар в базе данных, чтобы изменить его остаток
                    var product = db.Products.Find(productId);
                    if (product == null)
                    {
                        MessageBox.Show("Выбранный товар не найден в базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // --- КОНТРОЛЬ ТЕКУЩИХ ОСТАТКОВ (Задание №1) ---
                    if (operationType == "Выдача")
                    {
                        if (product.QuantityInStock < inputQuantity)
                        {
                            MessageBox.Show($"Недостаточно товара на складе для выдачи!\n\n" +
                                            $"Запрошено: {inputQuantity} {product.UnitOfMeasure}.\n" +
                                            $"В наличии всего: {product.QuantityInStock} {product.UnitOfMeasure}.",
                                            "Контроль остатков", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Прерываем проведение операции
                        }

                        // Если товара хватает — уменьшаем остаток на складе
                        product.QuantityInStock -= inputQuantity;
                    }
                    else if (operationType == "Поступление")
                    {
                        // При поступлении — увеличиваем остаток на складе
                        product.QuantityInStock += inputQuantity;
                    }

                    // Создаем саму запись складской операции в журнале
                    WarehouseOperation newOp = new WarehouseOperation
                    {
                        ProductId = productId,
                        EmployeeId = employeeId,
                        OperationType = operationType,
                        Quantity = inputQuantity,
                        OperationDate = DateTime.Now, // Фиксируем текущую дату проведения
                        RecipientName = operationType == "Выдача" ? tbRecipient.Text.Trim() : null
                    };

                    db.WarehouseOperations.Add(newOp);
                    db.SaveChanges(); // Сохраняем операцию и новый остаток товара одной транзакцией

                    MessageBox.Show($"Документ успешно проведен!\nБаза данных пересчитала остаток товара.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Возвращаемся обратно на главную форму
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Критическая ошибка проведения накладной: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Просто закрываем форму и возвращаемся назад
        }

        // ============================================================================
        // ЗАГЛУШКИ ДЛЯ ДИЗАЙНЕРА СИСТЕМЫ Windows Forms
        // ============================================================================
        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbEmployee_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbOperationType_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numQuantity_ValueChanged(object sender, EventArgs e) { }
        private void tbRecipient_TextChanged(object sender, EventArgs e) { }
    }
}