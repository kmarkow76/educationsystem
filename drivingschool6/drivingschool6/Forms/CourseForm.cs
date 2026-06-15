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
    public partial class CourseForm : Form
    {
        private drivingshoolContext _context = new drivingshoolContext();
        public CourseForm()
        {
            InitializeComponent();
            this.Text = "Список курсов";
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            LoadCourse();
        }
        public void LoadCourse()
        {
            var data = _context.Courses
                .Select(s => new {
                    s.Id,
                   Категория = s.Category,
                   КолвоУроков = s.NumberOfLessons,
                   БазоваяСтоимсоть = s.BasePrice
                }).ToList();
            dataGridView1.DataSource = data;

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addCourse = new AddCourseForm();
            addCourse.ShowDialog();
            LoadCourse();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите ученика для редактирования");
                return;
            }
            int courseId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            var editCourse = new EditCourseForm(courseId);
            editCourse.ShowDialog();
            LoadCourse();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите курс для удаления");
                return;
            }
            int courseId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

            DialogResult dialogResult = MessageBox.Show(
                $"Вы действительно хотите удалить курс?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    var course = _context.Courses.Find(courseId);
                    if (course != null)
                    {
                        _context.Courses.Remove(course);
                        _context.SaveChanges();

                        MessageBox.Show("Курс успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCourse();
                    }
                    else
                    {
                        MessageBox.Show("Курс уже удален или не найден в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Курс при удалении из базы данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
