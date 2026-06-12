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
    // ============================================================
    // Форма истории оценок студента + средний балл + доступ к курсу
    // Задание № 2 — расчёт среднего балла как функция с БД
    // ============================================================
    public partial class GradesForm : Form
    {
        private educContext _context = new educContext();
        private readonly int _studentId;

        public GradesForm(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;
        }

        private void GradesForm_Load(object sender, EventArgs e)
        {
            // Показываем имя студента в заголовке
            var student = _context.Students.Find(_studentId);
            this.Text = $"Оценки студента: {student?.FullName}";

            LoadGrades();
            ShowAverageScore();
        }

        // --------------------------------------------------------
        // Загрузка оценок студента в таблицу
        // --------------------------------------------------------
        private void LoadGrades()
        {
            var grades = _context.Grades
                .Where(g => g.StudentId == _studentId)
                .Select(g => new
                {
                    Курс = g.Course.Name,
                    Оценка = g.Score,
                    Дата = g.GradeDate.ToString("dd.MM.yyyy")
                })
                .ToList();

            dataGridView1.DataSource = grades;
        }

        // --------------------------------------------------------
        // Задание №2: расчёт среднего балла как отдельная функция
        // с подключением к базе данных
        // --------------------------------------------------------
        private double CalculateAverageScore(int studentId)
        {
            // Проверяем наличие оценок перед расчётом
            bool hasGrades = _context.Grades.Any(g => g.StudentId == studentId);
            if (!hasGrades)
                return 0;

            return (double)_context.Grades
                .Where(g => g.StudentId == studentId)
                .Average(g => g.Score);
        }

        // --------------------------------------------------------
        // Задание №2: доступ к следующему курсу
        // Условие: средний балл >= 60
        // --------------------------------------------------------
        private bool CanAccessNextCourse(int studentId)
        {
            double avg = CalculateAverageScore(studentId);
            return avg >= 60;
        }

        // --------------------------------------------------------
        // Отображение среднего балла и доступа к курсу на форме
        // --------------------------------------------------------
        private void ShowAverageScore()
        {
            double avg = CalculateAverageScore(_studentId);
            lblAverage.Text = $"Средний балл: {avg:F2}";

            bool canAccess = CanAccessNextCourse(_studentId);
            lblAccess.Text = canAccess
                ? "Доступ к следующему курсу: ДА ✓"
                : "Доступ к следующему курсу: НЕТ (нужен балл >= 60)";
            lblAccess.ForeColor = canAccess
                ? System.Drawing.Color.Green
                : System.Drawing.Color.Red;
        }

        // --------------------------------------------------------
        // Кнопка "Рассчитать средний балл за период"
        // --------------------------------------------------------
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!dtpFrom.Value.Date.Equals(DateTime.MinValue.Date) &&
                !dtpTo.Value.Date.Equals(DateTime.MinValue.Date))
            {
                // Расчёт среднего балла за указанный период
                var avgForPeriod = _context.Grades
                    .Where(g => g.StudentId == _studentId &&
                                g.GradeDate >= dtpFrom.Value.Date &&
                                g.GradeDate <= dtpTo.Value.Date)
                    .Average(g => (double?)g.Score) ?? 0;

                MessageBox.Show(
                    $"Средний балл за период: {avgForPeriod:F2}",
                    "Результат"
                );
            }
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

    }
}
