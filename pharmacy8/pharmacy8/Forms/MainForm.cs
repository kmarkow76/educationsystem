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
    public partial class MainForm : Form
    {
        private pharmacyContext _context = new pharmacyContext();
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Список препаратов";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadDrug();
        }
        public void LoadDrug()
        {
            var data = _context.Drugs
                        .Select(s => new {
                            s.Id,
                            Наименование = s.Name,
                            Категория = s.Category,
                            Производитель = s.Manufacturer,
                            Цена = s.Price,
                            КоличествоНаСкладе = s.QuantityInStock,
                            СрокГодности = s.ExpirationDate,
                            ВНаличии = s.AvailabilityStatus

                        }).ToList();
            
            dataGridView1.DataSource = data;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addDrug = new AddDrugForm();
            addDrug.ShowDialog();
            LoadDrug();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0 )
            {
                MessageBox.Show("Выберите препарат для редактирования");
                return;
            }
            int drugId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            var editDrug = new EditDrugForm(drugId);
            editDrug.ShowDialog();
            LoadDrug();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите препарат для удаления");
                return;
            }
            int drugId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

            DialogResult dialogResult = MessageBox.Show(
                $"Вы действительно хотите удалить препарат?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    var drug = _context.Drugs.Find(drugId);
                    if (drug != null)
                    {
                        _context.Drugs.Remove(drug);
                        _context.SaveChanges();

                        MessageBox.Show("Препарат успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDrug();
                    }
                    else
                    {
                        MessageBox.Show("Препарат уже удален или не найден в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Препарат при удалении из базы данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnViewReceipt_Click(object sender, EventArgs e)
        {
            var viewReceipt = new ReceiptForm();
            viewReceipt.ShowDialog();
        }

        private void btnViewSale_Click(object sender, EventArgs e)
        {
            var viewSale = new SaleForm();
            viewSale.ShowDialog();
        }

        private void btnViewSupplier_Click(object sender, EventArgs e)
        {
            var viewSupplier = new SupplerForm();
            viewSupplier.ShowDialog();
        }

        private void btnViewEmployee_Click(object sender, EventArgs e)
        {
            var viewEmployee = new EmployeeForm();
            viewEmployee.ShowDialog();
        }

        private void btnViewCustomer_Click(object sender, EventArgs e)
        {
            var viewCustomer = new CustomerForm();
            viewCustomer.ShowDialog();
        }
    }
}
