using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using educsys.Models;

namespace educsys.Forms
{
    public partial class AddStudentForm : Form
    {
        private educContext _context = new educContext();

        public AddStudentForm()
        {
            InitializeComponent();
            this.Text = "Добавить студента";
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {
            mtbDate.Text = DateTime.Now.ToString("ddMMyyyy");
        }

        // --------------------------------------------------------
        // Кнопка "Сохранить"
        // --------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация обязательных полей
            if (string.IsNullOrWhiteSpace(tbFullName.Text))
            {
                MessageBox.Show("Поле ФИО обязательно для заполнения.", "Ошибка");
                tbFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbGroup.Text))
            {
                MessageBox.Show("Поле Группа обязательно для заполнения.", "Ошибка");
                tbGroup.Focus();
                return;
            }

            if (!DateTime.TryParseExact(mtbDate.Text, "dd/MM/yyyy",
                    null, System.Globalization.DateTimeStyles.None, out DateTime enrollmentDate))
            {
                MessageBox.Show("Введите корректную дату в формате ДД/ММ/ГГГГ.", "Ошибка");
                mtbDate.Focus();
                return;
            }

            // Создаём и сохраняем нового студента
            var student = new Student
            {
                FullName = tbFullName.Text.Trim(),
                GroupName = tbGroup.Text.Trim(),
                EnrollmentDate = enrollmentDate,
                Phone = mtbPhone.Text
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            MessageBox.Show("Студент успешно добавлен!", "Успех");
            this.Close();
        }

        // --------------------------------------------------------
        // Кнопка "Отмена"
        // --------------------------------------------------------
        private void btnCancel_Click(object sender, EventArgs e)
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
