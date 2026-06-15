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
    public partial class EditCourseForm : Form
    {
        private drivingshoolContext _context = new drivingshoolContext();
        private readonly int _courseId;

        public EditCourseForm(int courseId)
        {
            InitializeComponent();
            this.Text = "Редактирование курса";
            _courseId = courseId;

            // Заполняем список категорий
            cbCategory.Items.Clear();
            cbCategory.Items.AddRange(new string[] { "A", "B", "C" });
        }

        private void EditCourseForm_Load(object sender, EventArgs e)
        {
            var course = _context.Courses.Find(_courseId);

            if (course == null)
            {
                MessageBox.Show("Курс не найден в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Загружаем данные курса в поля формы
            cbCategory.SelectedItem = course.Category;
            nudCountLesson.Value = course.NumberOfLessons;
            nudPrice.Value = course.BasePrice;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Валидация категории
            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию обучения.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация количества занятий
            if (nudCountLesson.Value <= 0)
            {
                MessageBox.Show("Количество занятий должно быть больше нуля.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация стоимости курса
            if (nudPrice.Value <= 0)
            {
                MessageBox.Show("Стоимость курса должна быть больше нуля.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var course = _context.Courses.Find(_courseId);

                if (course != null)
                {
                    // Сохраняем обновлённые данные курса
                    course.Category = cbCategory.Text.Trim();
                    course.NumberOfLessons = (int)nudCountLesson.Value;
                    course.BasePrice = nudPrice.Value;

                    _context.SaveChanges();

                    MessageBox.Show("Данные курса успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}