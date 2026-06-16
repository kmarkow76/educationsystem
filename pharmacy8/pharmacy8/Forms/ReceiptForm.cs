// ReceiptForm.cs
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
    public partial class ReceiptForm : Form
    {
        private pharmacyContext _context = new pharmacyContext();

        public ReceiptForm()
        {
            InitializeComponent();
            this.Text = "Список поступлений";
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            LoadReceipt();
        }

        // Загрузка списка поступлений товаров от поставщиков
        public void LoadReceipt()
        {
            var receipts = _context.Receipts
                .Select(r => new
                {
                    r.Id,
                    Наименование = r.Drug.Name,
                    Поставщик = r.Supplier.Name,
                    Количество = r.Quantity,
                    Цена_поступления = r.ReceiptPrice,
                    Дата_поступления = r.ReceiptDate,
                    Сумма = r.Quantity * r.ReceiptPrice
                })
                .ToList()
                .Select(r => new
                {
                    r.Id,
                    r.Наименование,
                    r.Поставщик,
                    r.Количество,
                    Цена_поступления = $"{r.Цена_поступления:F2} руб.",
                    Дата_поступления = r.Дата_поступления.ToShortDateString(),
                    Сумма = $"{r.Сумма:F2} руб."
                })
                .ToList();

            dataGridView1.DataSource = receipts;

            // Переименовываем заголовки колонок
            dataGridView1.Columns["Id"].HeaderText = "ID";
            dataGridView1.Columns["Наименование"].HeaderText = "Наименование";
            dataGridView1.Columns["Поставщик"].HeaderText = "Поставщик";
            dataGridView1.Columns["Количество"].HeaderText = "Количество";
            dataGridView1.Columns["Цена_поступления"].HeaderText = "Цена поступления";
            dataGridView1.Columns["Дата_поступления"].HeaderText = "Дата поступления";
            dataGridView1.Columns["Сумма"].HeaderText = "Общая сумма";

            dataGridView1.ReadOnly = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addReceipt = new AddReceiptForm();
            addReceipt.ShowDialog();
            // Обновляем список после добавления поступления
            LoadReceipt();
        }

    }
}