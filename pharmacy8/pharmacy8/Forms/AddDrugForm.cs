// AddDrugForm.cs
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
    public partial class AddDrugForm : Form
    {
        private pharmacyContext _context = new pharmacyContext();

        public AddDrugForm()
        {
            InitializeComponent();
            this.Text = "Добавление препарата";
            cbCategory.Items.Clear();
            cbCategory.Items.AddRange(new string[] { "БАДЫ", "Антибиотики", "Другие" });
            cbCategory.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация наименования
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Наименование препарата не может быть пустым.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация категории
            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию препарата.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация производителя
            if (string.IsNullOrWhiteSpace(tbManufactor.Text))
            {
                MessageBox.Show("Производитель препарата не может быть пустым.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация количества
            if (nudCount.Value <= 0)
            {
                MessageBox.Show("Количество препарата должно быть больше нуля.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация цены
            if (nudPrice.Value <= 0)
            {
                MessageBox.Show("Стоимость препарата должна быть больше нуля.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация формата даты
            if (!DateTime.TryParseExact(mtbData.Text, "dd.MM.yyyy",
                   null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                MessageBox.Show("Введите корректную дату в формате ДД.ММ.ГГГГ.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbData.Focus();
                return;
            }

            // Срок годности должен быть в будущем
            if (date <= DateTime.Today)
            {
                MessageBox.Show("Срок годности должен быть позже сегодняшней даты.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbData.Focus();
                return;
            }

            try
            {
                var drug = new Drug
                {
                    Name = tbName.Text.Trim(),
                    Category = cbCategory.SelectedItem.ToString(),
                    Manufacturer = tbManufactor.Text.Trim(),
                    Price = nudPrice.Value,        // ← decimal, не int
                    QuantityInStock = (int)nudCount.Value,
                    ExpirationDate = date,
                    AvailabilityStatus = ckbIs.Checked
                };

                _context.Drugs.Add(drug);
                _context.SaveChanges();

                MessageBox.Show("Препарат успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении в базу данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}