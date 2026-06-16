using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using trackingOfRequests12.Models;

namespace trackingOfRequests12.Forms
{
    public partial class MainForm : Form
    {
        public tracking_of_requestsContext _context = new tracking_of_requestsContext();
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Список заявок";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadRequest();
        }
        public void LoadRequest()
        {
            var requests = _context.RepairRequests
                .Select(r => new
                {
                    r.Id,
                    Клиент = r.Client.FullName,
                    Техника = r.Device.Brand + " " + r.Device.Model,
                    Неисправность = r.FaultDescription,
                    Перечень_работ = r.WorkList,
                    Базовая_стоимость = r.BaseWorkPrice,
                    Срочный = r.IsUrgent,
                    Постоянный = r.Client.IsRegular,
                    Статус = r.Status,
                    Дата = r.CreatedDate,
            // Считаем сумму запчастей через связанную таблицу
            Стоимость_запчастей = r.RequestParts
                        .Sum(p => (decimal?)p.Quantity * p.Part.Price) ?? 0
                })
                .ToList()
                .Select(r =>
                {
            // Рассчитываем итоговую стоимость работ
            decimal workPrice = CalculateWorkPrice(r.Базовая_стоимость, r.Срочный, r.Постоянный);
                    decimal total = workPrice + r.Стоимость_запчастей;

            // Определяем процент скидки для отображения
            decimal discount = 0;
                    if (r.Постоянный) discount += 5;

                    return new
                    {
                        r.Id,
                        r.Клиент,
                        r.Техника,
                        r.Неисправность,
                        r.Перечень_работ,
                        Стоимость_работ = $"{r.Базовая_стоимость:F2} руб.",
                        Срочность = r.Срочный ? "+20%" : "—",
                        Скидка = discount > 0 ? $"{discount}%" : "—",
                        Стоимость_запчастей = $"{r.Стоимость_запчастей:F2} руб.",
                        Итоговая_стоимость = $"{total:F2} руб.",
                        r.Статус,
                        Дата = r.Дата.ToShortDateString()
                    };
                })
                .ToList();

            dataGridView1.DataSource = requests;

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Клиент"].HeaderText = "Клиент";
            dataGridView1.Columns["Техника"].HeaderText = "Техника";
            dataGridView1.Columns["Неисправность"].HeaderText = "Неисправность";
            dataGridView1.Columns["Перечень_работ"].HeaderText = "Перечень работ";
            dataGridView1.Columns["Стоимость_работ"].HeaderText = "Стоимость работ";
            dataGridView1.Columns["Срочность"].HeaderText = "Срочность";
            dataGridView1.Columns["Скидка"].HeaderText = "Скидка";
            dataGridView1.Columns["Стоимость_запчастей"].HeaderText = "Запчасти";
            dataGridView1.Columns["Итоговая_стоимость"].HeaderText = "Итого";
            dataGridView1.Columns["Статус"].HeaderText = "Статус";
            dataGridView1.Columns["Дата"].HeaderText = "Дата";

            dataGridView1.ReadOnly = true;
        }

        // Расчёт итоговой стоимости работ с учётом срочности и скидки
        private decimal CalculateWorkPrice(decimal basePrice, bool isUrgent, bool isRegular)
        {
            decimal price = basePrice;

            // Доплата за срочность 20%
            if (isUrgent)
                price *= 1.20m;

            // Скидка постоянному клиенту 5%
            if (isRegular)
                price *= 0.95m;

            return price;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addRequest = new AddRequestForm();
            addRequest.ShowDialog();
            LoadRequest();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int requestId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            var editRequest = new EditRequestForm(requestId);
            editRequest.ShowDialog();
            LoadRequest();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку для удаления");
                return;
            }
            int requestId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

            DialogResult dialogResult = MessageBox.Show(
                $"Вы действительно хотите удалить заявку?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    var requesrt = _context.RepairRequests.Find(requestId);
                    if (requesrt != null)
                    {
                        _context.RepairRequests.Remove(requesrt);
                        _context.SaveChanges();

                        MessageBox.Show("Заявка успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRequest();
                    }
                    else
                    {
                        MessageBox.Show("Заявка уже удален или не найден в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Заявка при удалении из базы данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnViewClient_Click(object sender, EventArgs e)
        {
            var viewClient = new ClientForm();
            viewClient.ShowDialog();
        }

        private void btnViewDevice_Click(object sender, EventArgs e)
        {
            var viewDevice = new DeviceForm();
            viewDevice.ShowDialog();
        }

        private void btnViewEmployee_Click(object sender, EventArgs e)
        {
            var viewEmployee = new EmployeeForm();
            viewEmployee.ShowDialog();
        }
    }
}
