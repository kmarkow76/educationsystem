// EditDrugForm.cs
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
    public partial class EditDrugForm : Form
    {
        private pharmacyContext _context = new pharmacyContext();
        private readonly int _drugId;

        public EditDrugForm(int drugId)
        {
            InitializeComponent();
            _drugId = drugId;
            this.Text = "Редактирование препарата";
            cbCategory.Items.Clear();
            cbCategory.Items.AddRange(new string[] { "БАДЫ", "Антибиотики", "Другие" });
            cbCategory.SelectedIndex = 0;
        }

        private void EditDrugForm_Load(object sender, EventArgs e)
        {
            var drug = _context.Drugs.Find(_drugId);

            if (drug == null)
            {
                MessageBox.Show("Препарат не найден в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Загружаем данные препарата в поля формы
            tbName.Text = drug.Name;
            cbCategory.SelectedItem = drug.Category;
            tbManufactor.Text = drug.Manufacturer;
            nudPrice.Value = drug.Price;
            nudCount.Value = drug.QuantityInStock;
            mtbData.Text = drug.ExpirationDate.ToString("dd.MM.yyyy");
            ckbIs.Checked = drug.AvailabilityStatus ?? false;
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
                var drug = _context.Drugs.Find(_drugId);

                if (drug != null)
                {
                    // Обновляем данные препарата
                    drug.Name = tbName.Text.Trim();
                    drug.Category = cbCategory.SelectedItem.ToString();
                    drug.Manufacturer = tbManufactor.Text.Trim();
                    drug.Price = nudPrice.Value;
                    drug.QuantityInStock = (int)nudCount.Value;
                    drug.ExpirationDate = date;
                    drug.AvailabilityStatus = ckbIs.Checked;

                    _context.SaveChanges();

                    MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении в базу данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}