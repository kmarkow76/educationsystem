using System;
using System.Linq;
using System.Windows.Forms;
using dentistry2.Models;

namespace dentistry.Forms
{
    public partial class AddPatientForm : Form
    {
        private dentistry2Context _context = new dentistry2Context();

        public AddPatientForm()
        {
            InitializeComponent();
            this.Text = "Добавление пациента";

            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new string[] { "Мужской", "Женский" });
            cmbGender.SelectedIndex = 0;
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbFio.Text))
            {
                MessageBox.Show("Поле ФИО обязательно для заполнения.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(mtxbPolicy.Text) || mtxbPolicy.Text.Length < 16)
            {
                MessageBox.Show("Поле ПОЛИС должно содержать 16 цифр.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(mtxbPhone.Text))
            {
                MessageBox.Show("Поле Телефон обязательно для заполнения.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParseExact(mtxbDateof.Text, "dd.MM.yyyy",
                    null, System.Globalization.DateTimeStyles.None, out DateTime birthDate))
            {
                MessageBox.Show("Введите корректную дату рождения в формате ДД.ММ.ГГГГ.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtxbDateof.Focus();
                return;
            }
            
            if (birthDate > DateTime.Today)
            {
                MessageBox.Show("Дата рождения не может быть в будущем.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtxbDateof.Focus();
                return;
            }
            try
            {
                int nextId = (_context.Patients.Max(p => (int?)p.Id) ?? 0) + 1;

                var patient = new Patient
                {
                    Id = nextId,
                    Fio = txbFio.Text.Trim(),
                    Dateofbirth = birthDate,
                    Gender = cmbGender.SelectedItem?.ToString() ?? "Мужской",
                    Policy = mtxbPolicy.Text.Trim(),
                    Address = txbAddress.Text.Trim(),
                    Phone = mtxbPhone.Text.Trim(),
                };

                _context.Patients.Add(patient);
                _context.SaveChanges();

                MessageBox.Show("Пациент успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении в базу данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}