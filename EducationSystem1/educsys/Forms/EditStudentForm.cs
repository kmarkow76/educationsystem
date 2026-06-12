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
    public partial class EditStudentForm : Form
    {
        private educContext _context = new educContext();
        private readonly int _studentId;

        // ID передаётся через конструктор из главной формы
        public EditStudentForm(int studentId)
        {
            InitializeComponent();
            this.Text = "Редактировать студента";
            _studentId = studentId;
        }

        private void EditStudentForm_Load(object sender, EventArgs e)
        {
            // Настройка масок
            mtbPhone.Mask = "+000-00-000-000";
            mtbDate.Mask = "00/00/0000";

            // Загружаем данные студента в поля автоматически
            var student = _context.Students.Find(_studentId);
            if (student == null)
            {
                MessageBox.Show("Студент не найден.");
                this.Close();
                return;
            }

            tbFullName.Text = student.FullName;
            tbGroup.Text = student.GroupName;
            mtbDate.Text = student.EnrollmentDate.ToString("ddMMyyyy");
            mtbPhone.Text = student.Phone;
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

            // Находим студента и обновляем его данные
            var student = _context.Students.Find(_studentId);
            student.FullName = tbFullName.Text.Trim();
            student.GroupName = tbGroup.Text.Trim();
            student.EnrollmentDate = enrollmentDate;
            student.Phone = mtbPhone.Text;

            _context.SaveChanges();

            MessageBox.Show("Данные студента обновлены!", "Успех");
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
