// AddSalesForm.cs
using pharmacy8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacy8.Forms
{
    public partial class AddSalesForm : Form
    {
        private pharmacyContext _context = new pharmacyContext();

        public AddSalesForm()
        {
            InitializeComponent();
            this.Text = "Добавление продажи";
        }

        private void AddSalesForm_Load(object sender, EventArgs e)
        {
            // Загружаем препараты в комбобокс
            var drugs = _context.Drugs.ToList();
            drugs.Insert(0, new Drug { Id = 0, Name = "-- Выберите препарат --" });
            cbDrug.DataSource = drugs;
            cbDrug.DisplayMember = "Name";
            cbDrug.ValueMember = "Id";
            cbDrug.SelectedIndex = 0;

            // Загружаем покупателей в комбобокс
            var customers = _context.Customers.ToList();
            customers.Insert(0, new Customer { Id = 0, Name = "-- Выберите покупателя --" });
            cbCustomer.DataSource = customers;
            cbCustomer.DisplayMember = "Name";
            cbCustomer.ValueMember = "Id";
            cbCustomer.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация препарата
            if (cbDrug.SelectedValue == null || (int)cbDrug.SelectedValue == 0)
            {
                MessageBox.Show("Выберите препарат.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация покупателя
            if (cbCustomer.SelectedValue == null || (int)cbCustomer.SelectedValue == 0)
            {
                MessageBox.Show("Выберите покупателя.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация количества
            if (nudCount.Value <= 0)
            {
                MessageBox.Show("Количество должно быть больше нуля.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация цены
            if (nudPrice.Value <= 0)
            {
                MessageBox.Show("Цена за единицу должна быть больше нуля.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация даты
            if (!DateTime.TryParseExact(mtbSaleDate.Text, "dd/MM/yyyy",
                null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                MessageBox.Show("Введите корректную дату в формате ДД/ММ/ГГГГ.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbSaleDate.Focus();
                return;
            }

            try
            {
                // Сохраняем продажу в БД
                var sale = new Sale
                {
                    DrugId = (int)cbDrug.SelectedValue,
                    CustomerId = (int)cbCustomer.SelectedValue,
                    Quantity = (int)nudCount.Value,
                    UnitPrice = nudPrice.Value,
                    SaleDate = date
                };

                _context.Sales.Add(sale);
                _context.SaveChanges();

                MessageBox.Show("Продажа успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}