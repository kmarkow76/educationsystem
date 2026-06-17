using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using skladpredprieatie1.Models; // Подключаем контекст и модели СУБД

namespace skladpredprieatie1.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Жестко привязываем событие загрузки формы через код
            this.Load += new System.EventHandler(this.MainForm_Load);
        }

        // Событие при старте приложения
        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshAllData();
        }

        /// <summary>
        /// Комментарий: Метод для одновременного обновления обеих таблиц (Товары и Операции) без перезапуска системы
        /// </summary>
        public void RefreshAllData()
        {
            LoadProducts();
            LoadWarehouseOperations();
        }

        /// <summary>
        /// Комментарий: Логика загрузки текущих остатков товаров из PostgreSQL (Задание №1 и №3)
        /// </summary>
        private void LoadProducts()
        {
            try
            {
                using (var db = new skladpredprieatie_bd_1Context())
                {
                    // Подтягиваем данные о товаре вместе с названием компании поставщика
                    var productsData = db.Products
                        .Select(p => new
                        {
                            p.Id,
                            p.ProductName,
                            p.Category,
                            p.UnitOfMeasure,
                            p.QuantityInStock,
                            p.UnitPrice,
                            SupplierName = p.Supplier.CompanyName // Навигационное свойство связи
                        }).ToList();

                    dgvProducts.DataSource = productsData;

                    // Оформляем красивую шапку таблицы
                    dgvProducts.Columns["Id"].Visible = false;
                    dgvProducts.Columns["ProductName"].HeaderText = "Наименование товара";
                    dgvProducts.Columns["Category"].HeaderText = "Категория";
                    dgvProducts.Columns["UnitOfMeasure"].HeaderText = "Ед. изм.";
                    dgvProducts.Columns["QuantityInStock"].HeaderText = "Остаток на складе";
                    dgvProducts.Columns["UnitPrice"].HeaderText = "Цена за ед. (руб.)";
                    dgvProducts.Columns["SupplierName"].HeaderText = "Поставщик";

                    dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки остатков товаров: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Комментарий: Логика загрузки журнала операций с автоматическим расчетом скидок (Задание №2)
        /// </summary>
        private void LoadWarehouseOperations()
        {
            try
            {
                using (var db = new skladpredprieatie_bd_1Context())
                {
                    // Выгружаем операции из БД
                    var operationsFromDb = db.WarehouseOperations
                        .Select(o => new
                        {
                            o.Id,
                            ProductName = o.Product.ProductName,
                            o.OperationType,
                            o.Quantity,
                            UnitPrice = o.Product.UnitPrice,
                            o.OperationDate,
                            IsPermanentSupplier = o.Product.Supplier.IsPermanent // Нужно для расчета доп. скидки
                        }).ToList();

                    // Формируем коллекцию с расчетными полями "на лету" (Задание №2)
                    var calculatedOperations = operationsFromDb.Select(o =>
                    {
                        decimal baseCost = o.Quantity * o.UnitPrice;
                        decimal discountPercent = 0;

                        // Скидки рассчитываются строго для ВЫДАЧИ товаров со склада
                        if (o.OperationType == "Выдача")
                        {
                            if (baseCost > 50000)
                                discountPercent = 10;
                            else if (baseCost > 10000)
                                discountPercent = 5;

                            // Если контрагент (поставщик этого товара) постоянный — даем еще +5%
                            if (o.IsPermanentSupplier)
                                discountPercent += 5;
                        }

                        decimal finalCost = baseCost - (baseCost * (discountPercent / 100));

                        return new
                        {
                            o.Id,
                            o.ProductName,
                            o.OperationType,
                            o.Quantity,
                            o.UnitPrice,
                            o.OperationDate,
                            BaseCost = baseCost,
                            Discount = $"{discountPercent}%",
                            FinalCost = finalCost
                        };
                    }).ToList();

                    dgvOperations.DataSource = calculatedOperations;

                    // Настраиваем сетку для Журнала операций
                    dgvOperations.Columns["Id"].Visible = false;
                    dgvOperations.Columns["ProductName"].HeaderText = "Наименование товара";
                    dgvOperations.Columns["OperationType"].HeaderText = "Тип операции";
                    dgvOperations.Columns["Quantity"].HeaderText = "Количество";
                    dgvOperations.Columns["UnitPrice"].HeaderText = "Цена за ед.";
                    dgvOperations.Columns["OperationDate"].HeaderText = "Дата операции";
                    dgvOperations.Columns["BaseCost"].HeaderText = "Стоимость товаров";
                    dgvOperations.Columns["Discount"].HeaderText = "Процент скидки";
                    dgvOperations.Columns["FinalCost"].HeaderText = "Итоговая стоимость";

                    dgvOperations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка расчета складских операций: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Добавить новый товар
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Открываем форму добавления, передавая null (значит режим добавления)
            ProductEditForm form = new ProductEditForm(null);
            form.ShowDialog();
            RefreshAllData(); // Обновляем таблицы после закрытия формы (Задание №3)
        }

        // Кнопка: Редактировать выбранный товар
        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                // Получаем ID выделенного в таблице товара
                dynamic selectedRow = dgvProducts.CurrentRow.DataBoundItem;
                int productId = selectedRow.Id;

                // Передаем ID в конструктор — форма автоматически включит режим редактирования
                ProductEditForm form = new ProductEditForm(productId);
                form.ShowDialog();
                RefreshAllData(); // Перерисовываем список
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар из таблицы для изменения!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Твоя Кнопка 1 (Удаление товара)
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку с товаром для его удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic selectedRow = dgvProducts.CurrentRow.DataBoundItem;
            int productId = selectedRow.Id;

            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить товар \"{selectedRow.ProductName}\"?\nВнимание: Это удалит всю связанную с ним историю операций!",
                                                  "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var db = new skladpredprieatie_bd_1Context())
                    {
                        var productToDelete = db.Products.Find(productId);
                        if (productToDelete != null)
                        {
                            db.Products.Remove(productToDelete);
                            db.SaveChanges(); // Коммитим в Postgres
                            MessageBox.Show("Товар успешно списан и удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshAllData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления записи: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Кнопка: Оформить новую операцию (Поступление / Выдача)
        private void btnNewOperation_Click(object sender, EventArgs e)
        {
            // Здесь мы будем вызывать форму оформления новой операции
            // Назовем её, например, NewOperationForm
            NewOperationForm form = new NewOperationForm();
            form.ShowDialog();
            RefreshAllData(); // Автоматическое обновление остатков после проведения накладной
        }

        // Пустые заглушки событий, чтобы дизайнер не ругался
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvOperations_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}