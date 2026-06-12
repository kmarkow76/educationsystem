using educsys.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace educsys.Forms
{
    public partial class PaymentsForm : Form
    {
        private educContext _context = new educContext();
        private readonly int _studentId;

        public PaymentsForm(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;
        }

        private void PaymentsForm_Load(object sender, EventArgs e)
        {
            var student = _context.Students.Find(_studentId);
            this.Text = $"История платежей: {student?.FullName}";

            LoadPayments();
            LoadCoursesComboBox();
        }

        // --------------------------------------------------------
        // Задание №4: модуль вывода истории платежей
        // Показывает: наименование, сумма, дата, тип платежа
        // --------------------------------------------------------
        private void LoadPayments()
        {
            var payments = _context.Payments
                .Where(p => p.StudentId == _studentId)
                .Select(p => new
                {
                    Наименование = p.PaymentType,
                    Сумма = p.Amount,
                    ДатаОплаты = p.PaymentDate.ToString("dd.MM.yyyy"),
                    ТипПлатежа = p.PaymentType
                })
                .ToList();

            dataGridView1.DataSource = payments;

            // Итоговая сумма платежей студента
            decimal total = _context.Payments
                .Where(p => p.StudentId == _studentId)
                .Sum(p => p.Amount);
            lblTotal.Text = $"Итого оплачено: {total:F2} руб.";
        }

        // Загружаем список курсов в ComboBox для расчёта стоимости
        private void LoadCoursesComboBox()
        {
            cmbCourse.DataSource = _context.Courses.ToList();
            cmbCourse.DisplayMember = "Name";
            cmbCourse.ValueMember = "Id";
        }

        // --------------------------------------------------------
        // Задание №4: метод расчёта стоимости обучения
        // Принимает: courseId, тип материала, кол-во часов, цену за час
        // Возвращает: общую стоимость обучения
        // --------------------------------------------------------
        private decimal CalculateCost(int courseId, string materialType, int hours, decimal pricePerHour)
        {
            // Коэффициент зависит от типа образовательного материала
            decimal multiplier = materialType switch
            {
                "Лекция" => 1.0m,
                "Семинар" => 1.2m,
                "Онлайн" => 0.8m,
                _ => 1.0m
            };

            return hours * pricePerHour * multiplier;
        }

        // --------------------------------------------------------
        // Кнопка "Рассчитать стоимость"
        // --------------------------------------------------------
        private void btnCalculateCost_Click(object sender, EventArgs e)
        {
            if (cmbCourse.SelectedValue == null)
            {
                MessageBox.Show("Выберите курс.", "Ошибка");
                return;
            }

            if (!int.TryParse(nudHours.Value.ToString(), out int hours) || hours <= 0)
            {
                MessageBox.Show("Введите корректное количество часов.", "Ошибка");
                return;
            }

            int courseId = (int)cmbCourse.SelectedValue;
            string materialType = cmbMaterialType.SelectedItem?.ToString() ?? "Лекция";
            decimal pricePerHour = nudPrice.Value;

            decimal totalCost = CalculateCost(courseId, materialType, hours, pricePerHour);

            lblCostResult.Text = $"Стоимость обучения: {totalCost:F2} руб.";
        }

        // --------------------------------------------------------
        // Кнопка "Добавить платёж"
        // --------------------------------------------------------
        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPaymentName.Text))
            {
                MessageBox.Show("Введите наименование платежа.", "Ошибка");
                return;
            }

            var payment = new Payment
            {
                StudentId = _studentId,
                Amount = nudAmount.Value,
                PaymentDate = dtpPaymentDate.Value,
                PaymentType = tbPaymentName.Text.Trim()
            };

            _context.Payments.Add(payment);
            _context.SaveChanges();

            LoadPayments(); // обновляем историю
            MessageBox.Show("Платёж добавлен!", "Успех");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosed(e);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        
    }
}
