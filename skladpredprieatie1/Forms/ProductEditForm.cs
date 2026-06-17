using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using skladpredprieatie1.Models; // Подключаем наши сгенерированные модели базы данных

namespace skladpredprieatie1.Forms
{
    public partial class ProductEditForm : Form
    {
        // Храним ID редактируемого товара (если null — значит мы добавляем новый товар)
        private int? _productId;

        // Модифицируем конструктор, чтобы принимать ID товара из главной формы
        public ProductEditForm(int? productId)
        {
            InitializeComponent();
            _productId = productId;

            // Принудительно привязываем системное событие загрузки формы
            this.Load += new System.EventHandler(this.ProductEditForm_Load);

            // Настраиваем заголовки окна в зависимости от режима работы (Задание №3)
            if (_productId == null)
            {
                this.Text = "Добавление товара";
                btnSave.Text = "Добавить товар";
            }
            else
            {
                this.Text = "Редактирование товара";
                btnSave.Text = "Сохранить изменения";
            }
        }

        // Главное событие загрузки формы
        private void ProductEditForm_Load(object sender, EventArgs e)
        {
            LoadSuppliersToComboBox();

            // Если мы зашли в режиме редактирования — подтягиваем старые данные из СУБД (Задание №3)
            if (_productId != null)
            {
                LoadProductDataForEditing();
            }
        }

        /// <summary>
        /// Комментарий: Логика загрузки списка поставщиков в выпадающий список cbSupplier
        /// </summary>
        private void LoadSuppliersToComboBox()
        {
            try
            {
                using (var db = new skladpredprieatie_bd_1Context())
                {
                    var suppliersList = db.Suppliers.ToList();

                    cbSupplier.DataSource = suppliersList;
                    cbSupplier.DisplayMember = "CompanyName"; // Что видит пользователь на экране
                    cbSupplier.ValueMember = "Id";            // Что код сохраняет как внешний ключ
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочника поставщиков: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Комментарий: Автоматическая подгрузка данных изменяемого товара в поля формы
        /// </summary>
        private void LoadProductDataForEditing()
        {
            try
            {
                using (var db = new skladpredprieatie_bd_1Context())
                {
                    var product = db.Products.Find(_productId);
                    if (product != null)
                    {
                        tbProductName.Text = product.ProductName;
                        tbCategory.Text = product.Category;
                        tbUnit.Text = product.UnitOfMeasure;
                        numPrice.Value = product.UnitPrice;
                        numStock.Value = product.QuantityInStock;
                        cbSupplier.SelectedValue = product.SupplierId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подгрузки карточки товара: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Сохранить (Добавление нового или сохранение правок)
        private void btnSave_Click(object sender, EventArgs e)
        {
            // --- ВСТРОЕННАЯ ОБРАБОТКА ОШИБОК И ВАЛИДАЦИЯ ДАННЫХ (Задание №3) ---

            // 1. Проверка на пустое наименование
            if (string.IsNullOrWhiteSpace(tbProductName.Text))
            {
                MessageBox.Show("Наименование товара не может быть пустым!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbProductName.Focus(); // Возвращаем фокус ввода на ошибочное поле
                return;
            }

            // 2. Проверка на пустую категорию
            if (string.IsNullOrWhiteSpace(tbCategory.Text))
            {
                MessageBox.Show("Пожалуйста, укажите категорию товара!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCategory.Focus();
                return;
            }

            // 3. Проверка выбора поставщика
            if (cbSupplier.SelectedValue == null)
            {
                MessageBox.Show("Необходимо выбрать поставщика из списка!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new skladpredprieatie_bd_1Context())
                {
                    if (_productId == null)
                    {
                        // Режим: ДОБАВЛЕНИЕ нового товара в базу
                        Product newProduct = new Product
                        {
                            ProductName = tbProductName.Text.Trim(),
                            Category = tbCategory.Text.Trim(),
                            UnitOfMeasure = tbUnit.Text.Trim(),
                            UnitPrice = numPrice.Value,
                            QuantityInStock = (int)numStock.Value,
                            SupplierId = (int)cbSupplier.SelectedValue
                        };

                        db.Products.Add(newProduct);
                    }
                    else
                    {
                        // Режим: РЕДАКТИРОВАНИЕ существующего товара
                        var productToUpdate = db.Products.Find(_productId);
                        if (productToUpdate != null)
                        {
                            productToUpdate.ProductName = tbProductName.Text.Trim();
                            productToUpdate.Category = tbCategory.Text.Trim();
                            productToUpdate.UnitOfMeasure = tbUnit.Text.Trim();
                            productToUpdate.UnitPrice = numPrice.Value;
                            productToUpdate.QuantityInStock = (int)numStock.Value;
                            productToUpdate.SupplierId = (int)cbSupplier.SelectedValue;
                        }
                    }

                    db.SaveChanges(); // Фиксируем изменения в PostgreSQL
                    MessageBox.Show("Данные товара успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Безопасная навигация: возвращаемся назад на MainForm
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка записи в базу данных: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Отмена / Назад
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрываем окно и возвращаемся назад без сохранения изменений
        }

        // ============================================================================
        // МЕТОДЫ-ЗАГЛУШКИ ДЛЯ ИЗБЕЖАНИЯ ОШИБОК ДИЗАЙНЕРА СИСТЕМЫ
        // ============================================================================
        private void numStock_ValueChanged(object sender, EventArgs e) { }
        private void numPrice_ValueChanged(object sender, EventArgs e) { }
        private void tbUnit_TextChanged(object sender, EventArgs e) { }
        private void tbCategory_TextChanged(object sender, EventArgs e) { }
        private void tbProductName_TextChanged(object sender, EventArgs e) { }
        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}