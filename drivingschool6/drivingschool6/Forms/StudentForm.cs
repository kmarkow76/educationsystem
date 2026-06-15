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
    public partial class StudentForm : Form
    {
        private drivingshoolContext _context = new drivingshoolContext();
        public StudentForm()
        {
            InitializeComponent();
            this.Text = "Список учеников";
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        public void LoadStudents()
        {
            var data = _context.Students
                .Select(s => new { 
                    s.Id,
                    ФИО = s.FullName,
                    Телефон = s.Phone,
                    ЯвляетсяСтудентом = s.IsStudent,
                    КодСемьи = s.FamilyCode
                }).ToList();
            dataGridView1.DataSource = data;

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addStudent = new AddCourseForm();
            addStudent.ShowDialog();
            LoadStudents();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите ученика для редактирования");
                return;
            }
            int studentId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            var editStudent = new EditStudentForm(studentId);
            editStudent.ShowDialog();
            LoadStudents();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите ученика для удаления");
                return;
            }
            int studentId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

            DialogResult dialogResult = MessageBox.Show(
                $"Вы действительно хотите удалить ученика?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    var student = _context.Students.Find(studentId);
                    if (student != null)
                    {
                        _context.Students.Remove(student);
                        _context.SaveChanges();

                        MessageBox.Show("Ученик успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudents();
                    }
                    else
                    {
                        MessageBox.Show("Ученик уже удален или не найден в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ученик при удалении из базы данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
