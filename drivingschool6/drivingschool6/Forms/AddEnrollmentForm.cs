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
    public partial class AddEnrollmentForm : Form
    {
        private drivingshoolContext _context = new drivingshoolContext();

        public AddEnrollmentForm()
        {
            InitializeComponent();
            this.Text = "Добавление зачисления";
        }

        private void AddEnrollmentForm_Load(object sender, EventArgs e)
        {
            // Загружаем учеников — добавляем пустую строку в начало
            var students = _context.Students.ToList();
            students.Insert(0, new Student { Id = 0, FullName = "-- Выберите ученика --" });
            cbStudent.DataSource = students;
            cbStudent.DisplayMember = "FullName";
            cbStudent.ValueMember = "Id";
            cbStudent.SelectedIndex = 0;

            // Загружаем инструкторов
            var instructors = _context.Instructors.ToList();
            instructors.Insert(0, new Instructor { Id = 0, FullName = "-- Выберите инструктора --" });
            cbInstructor.DataSource = instructors;
            cbInstructor.DisplayMember = "FullName";
            cbInstructor.ValueMember = "Id";
            cbInstructor.SelectedIndex = 0;

            // Загружаем автомобили
            var vehicles = _context.Vehicles.ToList();
            vehicles.Insert(0, new Vehicle { Id = 0, LicensePlate = "-- Выберите автомобиль --" });
            cbCar.DataSource = vehicles;
            cbCar.DisplayMember = "LicensePlate";
            cbCar.ValueMember = "Id";
            cbCar.SelectedIndex = 0;

            // Загружаем курсы
            var courses = _context.Courses.ToList();
            courses.Insert(0, new Course { Id = 0, Category = "-- Выберите курс --" });
            cbCourse.DataSource = courses;
            cbCourse.DisplayMember = "Category";
            cbCourse.ValueMember = "Id";
            cbCourse.SelectedIndex = 0;

            // Тип оплаты
            cbPaymentType.Items.Clear();
            cbPaymentType.Items.Add("-- Выберите тип оплаты --");
            cbPaymentType.Items.AddRange(new string[] { "полная", "частичная" });
            cbPaymentType.SelectedIndex = 0;

            // Статус
            cbStatus.Items.Clear();
            cbStatus.Items.Add("-- Выберите статус --");
            cbStatus.Items.AddRange(new string[] { "обучается", "завершил обучение", "отчислен" });
            cbStatus.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Валидация ученика
            if (cbStudent.SelectedValue == null || (int)cbStudent.SelectedValue == 0)
            {
                MessageBox.Show("Выберите ученика.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация инструктора
            if (cbInstructor.SelectedValue == null || (int)cbInstructor.SelectedValue == 0)
            {
                MessageBox.Show("Выберите инструктора.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация автомобиля
            if (cbCar.SelectedValue == null || (int)cbCar.SelectedValue == 0)
            {
                MessageBox.Show("Выберите автомобиль.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация курса
            if (cbCourse.SelectedValue == null || (int)cbCourse.SelectedValue == 0)
            {
                MessageBox.Show("Выберите курс.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация типа оплаты
            if (cbPaymentType.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите тип оплаты.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация статуса
            if (cbStatus.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите статус обучения.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Сохраняем новое зачисление в БД
                var enrollment = new Enrollment
                {
                    StudentId = (int)cbStudent.SelectedValue,
                    InstructorId = (int)cbInstructor.SelectedValue,
                    CarId = (int)cbCar.SelectedValue,
                    CourseId = (int)cbCourse.SelectedValue,
                    StartDate = dtpStartDate.Value.Date,
                    PaymentType = cbPaymentType.SelectedItem.ToString(),
                    Status = cbStatus.SelectedItem.ToString()
                };

                _context.Enrollments.Add(enrollment);
                _context.SaveChanges();

                MessageBox.Show("Зачисление успешно добавлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}