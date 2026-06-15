using dentistry2.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace dentistry.Forms
{
    public partial class NewAppointmentForm : Form
    {
        private dentistry2Context _context = new dentistry2Context();
        private readonly int _patientId;
        private int _patientDiscount = 0;

        public NewAppointmentForm(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
            this.Text = "Оформление нового приёма";
        }

        private void NewAppointmentForm_Load(object sender, EventArgs e)
        {
            _patientDiscount = CalculatePatientDiscount(_patientId);
            txbDiscount.Text = _patientDiscount + "%";

            // 1. Загрузка докторов
            cmbDoctor.DataSource = _context.Doctors.ToList();
            cmbDoctor.DisplayMember = "Fio";
            cmbDoctor.ValueMember = "Id";

            // 2. Наполнение комбобокса услуг без изменения БД
            cmbService.Items.Clear();
            cmbService.Items.AddRange(new string[] {
        "Консультация и осмотр",
        "Лечение кариеса",
        "Пломбирование канала",
        "Удаление зуба",
        "Профессиональная чистка"
    });
            cmbService.SelectedIndex = 0; // Выбираем первую по умолчанию
        }

        /// <summary>
        /// Расчет персональной скидки на основе архивных данных посещений
        /// </summary>
        /// <param name="patientId">Id пациента</param>
        /// <returns>скидка</returns>
        private int CalculatePatientDiscount(int patientId)
        {
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);
            int visitsCount = _context.Appointments.Count(a => a.PatientId == patientId && a.Date >= oneYearAgo);

            if (visitsCount <= 3) return 0;
            if (visitsCount <= 7) return 5;
            if (visitsCount <= 15) return 10;
            return 15;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbDoctor.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите врача!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int doctorId = (int)cmbDoctor.SelectedValue;

                var newAppointment = new Appointment
                {
                    Id = (_context.Appointments.Max(a => (int?)a.Id) ?? 0) + 1,
                    Date = DateTime.Now,
                    DoctorId = doctorId,
                    PatientId = _patientId,
                    Description = $"[{cmbService.SelectedItem}] {txbDescription.Text.Trim()}"
                };

                _context.Appointments.Add(newAppointment);
                _context.SaveChanges();

                MessageBox.Show("Приём успешно зарегистрирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении приёма: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}