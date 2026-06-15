using System;
using System.Windows.Forms;
using dentistry2.Models;

namespace dentistry.Forms
{
    public partial class EditPatientForm : Form
    {
        private dentistry2Context _context = new dentistry2Context();
        private readonly int _patientId;

        public EditPatientForm(int patientId)
        {
            InitializeComponent();
            this.Text = "Редактирование пациента";
            _patientId = patientId;

            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new string[] { "Мужской", "Женский" });
        }

        private void EditPatientForm_Load(object sender, EventArgs e)
        {
            var patient = _context.Patients.Find(_patientId);
            if (patient == null)
            {
                MessageBox.Show("Пациент не найден в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txbFio.Text = patient.Fio;
            mtxbDateof.Text = patient.Dateofbirth?.ToString("dd.MM.yyyy") ?? "";

            if (cmbGender.Items.Contains(patient.Gender))
                cmbGender.SelectedItem = patient.Gender;
            else
                cmbGender.SelectedIndex = 0;

            mtxbPolicy.Text = patient.Policy;
            txbAddress.Text = patient.Address;
            mtxbPhone.Text = patient.Phone;
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
                var patient = _context.Patients.Find(_patientId);
                if (patient != null)
                {
                    patient.Fio = txbFio.Text.Trim();
                    patient.Dateofbirth = birthDate;
                    patient.Gender = cmbGender.SelectedItem?.ToString() ?? "Мужской";
                    patient.Policy = mtxbPolicy.Text.Trim();
                    patient.Address = txbAddress.Text.Trim();
                    patient.Phone = mtxbPhone.Text.Trim();

                    _context.SaveChanges();
                    MessageBox.Show("Данные пациента успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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