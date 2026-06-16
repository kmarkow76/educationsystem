// AddReceiptForm.cs
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
    public partial class AddReceiptForm : Form
    {
        private pharmacyContext _context = new pharmacyContext();

        public AddReceiptForm()
        {
            InitializeComponent();
            this.Text = "Добавление поступления";
        }

        private void AddReceiptForm_Load(object sender, EventArgs e)
        {
            // Загружаем препараты в комбобокс
            var drugs = _context.Drugs.ToList();
            drugs.Insert(0, new Drug { Id = 0, Name = "-- Выберите препарат --" });
            cbDrug.DataSource = drugs;
            cbDrug.DisplayMember = "Name";
            cbDrug.ValueMember = "Id";
            cbDrug.SelectedIndex = 0;

            // Загружаем поставщиков в комбобокс
            var suppliers = _context.Suppliers.ToList();
            suppliers.Insert(0, new Supplier { Id = 0, Name = "-- Выберите поставщика --" });
            cbSuppler.DataSource = suppliers;
            cbSuppler.DisplayMember = "Name";
            cbSuppler.ValueMember = "Id";
            cbSuppler.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация препарата
            if (cbDrug.SelectedValue == null || (int)cbDrug.SelectedValue == 0)
            {
                MessageBox.Show("Выберите препарат.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация поставщика
            if (cbSuppler.SelectedValue == null || (int)cbSuppler.SelectedValue == 0)
            {
                MessageBox.Show("Выберите поставщика.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Цена должна быть больше нуля.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация даты
            if (!DateTime.TryParseExact(mtbDate.Text, "dd/MM/yyyy",
                null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                MessageBox.Show("Введите корректную дату в формате ДД/ММ/ГГГГ.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbDate.Focus();
                return;
            }

            try
            {
                // Сохраняем поступление в БД
                var receipt = new Receipt
                {
                    DrugId = (int)cbDrug.SelectedValue,
                    SupplierId = (int)cbSuppler.SelectedValue,
                    Quantity = (int)nudCount.Value,
                    ReceiptPrice = nudPrice.Value,
                    ReceiptDate = date
                };

                _context.Receipts.Add(receipt);
                _context.SaveChanges();

                MessageBox.Show("Поступление успешно добавлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}