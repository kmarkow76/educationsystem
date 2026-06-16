// SaleForm.cs
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
    public partial class SaleForm : Form
    {
        private pharmacyContext _context = new pharmacyContext();

        public SaleForm()
        {
            InitializeComponent();
            this.Text = "Список продаж";
        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            LoadSales();
        }

        // Расчёт скидки на основе суммы покупки и статуса покупателя
        private decimal CalculateDiscount(decimal totalAmount, bool isRegular)
        {
            decimal discount = 0;

            // Скидка по сумме покупки
            if (totalAmount > 1500)
                discount += 10;
            else if (totalAmount > 500)
                discount += 5;

            // Дополнительная скидка для постоянных покупателей
            if (isRegular)
                discount += 5;

            return discount;
        }

        // Загрузка списка продаж с расчётом скидок и итоговой стоимости
        public void LoadSales()
        {
            var sales = _context.Sales
                .Select(s => new
                {
                    s.Id,
                    Наименование = s.Drug.Name,
                    Количество = s.Quantity,
                    Цена_за_единицу = s.UnitPrice,
                    Дата_продажи = s.SaleDate,
                    Сумма_покупки = s.Quantity * s.UnitPrice,
                    IsRegular = s.Customer.IsRegular,
                })
                .ToList();

            // Формируем итоговую таблицу с расчётом скидки
            var result = sales.Select(s =>
            {
                decimal discount = CalculateDiscount(s.Сумма_покупки, s.IsRegular ?? false);
                decimal finalPrice = s.Сумма_покупки * (1 - discount / 100);

                return new
                {
                    s.Id,
                    s.Наименование,
                    s.Количество,
                    Цена_за_единицу = $"{s.Цена_за_единицу:F2} руб.",
                    Дата_продажи = s.Дата_продажи.ToShortDateString(),
                    Сумма_покупки = $"{s.Сумма_покупки:F2} руб.",
                    Скидка = $"{discount}%",
                    Итоговая_стоимость = $"{finalPrice:F2} руб."
                };
            }).ToList();

            dataGridView1.DataSource = result;

            // Переименовываем заголовки колонок
            dataGridView1.Columns["Id"].HeaderText = "ID";
            dataGridView1.Columns["Наименование"].HeaderText = "Наименование";
            dataGridView1.Columns["Количество"].HeaderText = "Кол-во упаковок";
            dataGridView1.Columns["Цена_за_единицу"].HeaderText = "Цена за единицу";
            dataGridView1.Columns["Дата_продажи"].HeaderText = "Дата продажи";
            dataGridView1.Columns["Сумма_покупки"].HeaderText = "Сумма покупки";
            dataGridView1.Columns["Скидка"].HeaderText = "Скидка";
            dataGridView1.Columns["Итоговая_стоимость"].HeaderText = "Итоговая стоимость";

            dataGridView1.ReadOnly = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addSales = new AddSalesForm();
            addSales.ShowDialog();
            // Обновляем список после добавления продажи
            LoadSales();
        }
    }
}