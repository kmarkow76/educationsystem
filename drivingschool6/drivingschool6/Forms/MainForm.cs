using drivingschool6.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drivingschool6.Forms
{
    public partial class MainForm : Form
    {
        private drivingshoolContext _context = new drivingshoolContext();

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Список зачислений";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadEnrollment();
        }

        // Расчёт скидки на основе данных ученика и типа оплаты
        private decimal CalculateDiscount(Student student, string paymentType)
        {
            decimal discount = 0;

            // Скидка 10% при полной единовременной оплате
            if (paymentType == "полная")
                discount += 10;

            // Скидка 15% если в БД есть ещё один ученик с таким же семейным кодом
            bool hasFamilyMember = _context.Students
                .Any(s => s.FamilyCode == student.FamilyCode && s.Id != student.Id);

            if (hasFamilyMember)
                discount += 15;

            // Скидка 5% для студентов
            if (student.IsStudent == true)
                discount += 5;

            return discount;
        }

        // Загрузка списка зачислений с расчётом итоговой стоимости
        public void LoadEnrollment()
        {
            // Получаем все зачисления вместе со связанными данными
            var enrollments = _context.Enrollments
                .Select(en => new
                {
                    en.Id,
                    ФИО_ученика = en.Student.FullName,
                    Категория = en.Course.Category,
                    Дата_начала = en.StartDate,
                    Кол_во_занятий = en.Course.NumberOfLessons,
                    Базовая_стоимость = en.Course.BasePrice,
                    Тип_оплаты = en.PaymentType,
                    Статус = en.Status,
                    // Передаём нужные поля для расчёта скидки
                    IsStudent = en.Student.IsStudent,
                    FamilyCode = en.Student.FamilyCode,
                    StudentId = en.Student.Id
                })
                .ToList();

            // Формируем итоговую таблицу с расчётом скидки
            var result = enrollments.Select(en =>
            {
                // Получаем студента для передачи в функцию расчёта
                var student = _context.Students.Find(en.StudentId);
                decimal discount = CalculateDiscount(student, en.Тип_оплаты);
                decimal finalPrice = en.Базовая_стоимость * (1 - discount / 100);

                return new
                {
                    en.Id,
                    en.ФИО_ученика,
                    en.Категория,
                    Дата_начала = en.Дата_начала.ToShortDateString(),
                    en.Кол_во_занятий,
                    Базовая_стоимость = $"{en.Базовая_стоимость:F2} руб.",
                    Скидка = $"{discount}%",
                    Итоговая_стоимость = $"{finalPrice:F2} руб.",
                    en.Статус
                };
            }).ToList();

            dataGridView1.DataSource = result;

            // Переименовываем заголовки колонок
            dataGridView1.Columns["Id"].HeaderText = "ID";
            dataGridView1.Columns["ФИО_ученика"].HeaderText = "ФИО ученика";
            dataGridView1.Columns["Категория"].HeaderText = "Категория";
            dataGridView1.Columns["Дата_начала"].HeaderText = "Дата начала";
            dataGridView1.Columns["Кол_во_занятий"].HeaderText = "Кол-во занятий";
            dataGridView1.Columns["Базовая_стоимость"].HeaderText = "Базовая стоимость";
            dataGridView1.Columns["Скидка"].HeaderText = "Скидка";
            dataGridView1.Columns["Итоговая_стоимость"].HeaderText = "Итоговая стоимость";
            dataGridView1.Columns["Статус"].HeaderText = "Статус";

            dataGridView1.ReadOnly = true;
        }

        private void btnAddEnrollment_Click(object sender, EventArgs e)
        {
            var addEnrollment = new AddEnrollmentForm();
            addEnrollment.ShowDialog();
            LoadEnrollment();
        }

        private void bntViewStudent_Click(object sender, EventArgs e)
        {
            var viewStudents = new StudentForm();
            viewStudents.ShowDialog();
        }

        private void bntViewCourse_Click(object sender, EventArgs e)
        {
            var viewCourse = new CourseForm();
            viewCourse.ShowDialog();
        }

        private void btnViewCar_Click(object sender, EventArgs e)
        {
            var viewCar = new CarForm();
            viewCar.ShowDialog();
        }

        private void btnViewInstructor_Click(object sender, EventArgs e)
        {
            var viewInst = new InstructorForm();
            viewInst.ShowDialog();
        }
    }
}