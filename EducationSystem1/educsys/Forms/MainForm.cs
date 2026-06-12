using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using educsys.Models;

namespace educsys.Forms
{
    // ============================================================
    // Главная форма — список студентов со средним баллом
    // Заголовок окна: "Список студентов"
    // ============================================================
    public partial class MainForm : Form
    {
        private educContext _context = new educContext();

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Список студентов";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }


        // --------------------------------------------------------
        // Загрузка студентов с расчётом среднего балла
        // --------------------------------------------------------
        private void LoadStudents()
        {
            // Выбираем студентов и считаем средний балл через LINQ
            var data = _context.Students
                .Select(s => new
                {
                    s.Id,
                    ФИО = s.FullName,
                    Группа = s.GroupName,
                    СреднийБалл = s.Grades.Any()
                                   ? Math.Round(s.Grades.Average(g => (double)g.Score), 2)
                                   : 0.0,
                    ДатаПоступления = s.EnrollmentDate.ToString("dd.MM.yyyy"),
                    Телефон = s.Phone
                })
                .ToList();

            dataGridView1.DataSource = data;

            // Скрываем колонку Id — она нужна только для операций
            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }

        // --------------------------------------------------------
        // Кнопка "Добавить студента"
        // --------------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddStudentForm();
            addForm.ShowDialog();
            LoadStudents(); // обновляем список после закрытия формы
        }

        // --------------------------------------------------------
        // Кнопка "Редактировать студента"
        // --------------------------------------------------------
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите студента для редактирования.");
                return;
            }

            int studentId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            var editForm = new EditStudentForm(studentId);
            editForm.ShowDialog();
            LoadStudents(); // обновляем список после закрытия формы
        }

        // --------------------------------------------------------
        // Кнопка "История оценок"
        // --------------------------------------------------------
        private void btnGrades_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите студента.");
                return;
            }

            int studentId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            var gradesForm = new GradesForm(studentId);
            gradesForm.ShowDialog();
        }

        // --------------------------------------------------------
        // Кнопка "История платежей"
        // --------------------------------------------------------
        private void btnPayments_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите студента.");
                return;
            }

            int studentId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            var paymentsForm = new PaymentsForm(studentId);
            paymentsForm.ShowDialog();
        }

        // --------------------------------------------------------
        // Кнопка "Преподаватели"
        // --------------------------------------------------------
        private void btnTeachers_Click(object sender, EventArgs e)
        {
            var teachersForm = new TeachersForm();
            teachersForm.ShowDialog();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosed(e);
        }
    }
}