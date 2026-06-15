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
    public partial class EditStudentForm : Form
    {
        private drivingshoolContext _context = new drivingshoolContext();
        private readonly int _studentId;
        public EditStudentForm(int studentId)
        {
            InitializeComponent();
            this.Text = "Редактирование ученика";
            _studentId = studentId;

        }

        private void EditStudentForm_Load(object sender, EventArgs e)
        {
            var student = _context.Students.Find(_studentId);
            if(student == null)
            {
                MessageBox.Show("Ученик не найден в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txbFio.Text = student.FullName;
            mtxbPhone.Text = student.Phone;
            txbCode.Text = student.FamilyCode;
            ckbksStudent.Checked = student.IsStudent ?? false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbFio.Text))
            {
                MessageBox.Show("Поле ФИО обязательно для заполнения.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(mtxbPhone.Text))
            {
                MessageBox.Show("Поле Телефон обязательно для заполнения.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var student = _context.Students.Find(_studentId);
                if (student != null)
                {
                    student.FullName = txbFio.Text.Trim();
                    student.Phone = mtxbPhone.Text.Trim();
                    student.FamilyCode = txbCode.Text.Trim();
                    student.IsStudent = ckbksStudent.Checked;
                    _context.SaveChanges();
                    MessageBox.Show("Данные ученика успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
