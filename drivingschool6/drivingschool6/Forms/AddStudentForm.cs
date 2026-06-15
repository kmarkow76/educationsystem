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
    public partial class AddStudentForm : Form
    {
        private drivingshoolContext _context = new drivingshoolContext();
        public AddStudentForm()
        {
            InitializeComponent();
            this.Text = "Добавление ученика";
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
                var student = new Student
                {
                    FullName = txbFio.Text.Trim(),
                    Phone = mtxbPhone.Text.Trim(),
                    FamilyCode = txbCode.Text.Trim(),
                    IsStudent = ckbksStudent.Checked
                };
                _context.Students.Add(student);
                _context.SaveChanges();
                MessageBox.Show("Данные ученика успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
