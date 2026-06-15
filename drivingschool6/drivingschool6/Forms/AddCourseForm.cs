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
    public partial class AddCourseForm : Form
    {
        private drivingshoolContext _context = new drivingshoolContext();

        public AddCourseForm()
        {
            InitializeComponent();
            this.Text = "Добавление курса";
            cbCategory.Items.Clear();
            cbCategory.Items.AddRange(new string[] { "A", "B", "C" });
            cbCategory.SelectedIndex = 0;
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
                var course = new Course
                {
                    Category = cbCategory.Text.Trim(),
                    NumberOfLessons = (int)nudCountLesson.Value,       
                    BasePrice = nudPrice.Value                          
                };

                _context.Courses.Add(course);
                _context.SaveChanges();

                MessageBox.Show("Курс успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении в базу данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}