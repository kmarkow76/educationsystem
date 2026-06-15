using dentistry.Forms;
using dentistry2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dentistry2.Forms
{
    public partial class MainForm : Form
    {
        private dentistry2Context _context = new dentistry2Context();
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Список  пациентов";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadPatients();
        }

        public void LoadPatients()
        {
            var data = _context.Patients
                .Select(s => new
                {
                    s.Id,
                    ФИО = s.Fio,
                    ДатаРождения = s.Dateofbirth,
                    Пол = s.Gender,
                    Полис =  s.Policy,
                    Адрес = s.Address,
                    Телефон = s.Phone
                })
                .ToList();
            dataGridView1.DataSource = data;

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddPatientForm();
            addForm.ShowDialog();
            LoadPatients();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пациента для редактирования");
                return;
            }
            int patientId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            var addForm = new EditPatientForm(patientId);
            addForm.ShowDialog();
            LoadPatients();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. Проверяем, выбрана ли строка в DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пациента из списка для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем ID и ФИО выбранного пациента
            int patientId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            string patientFio = dataGridView1.SelectedRows[0].Cells["ФИО"].Value.ToString();

            // 2. Запрашиваем подтверждение удаления (MessageBox с кнопками Да/Нет)
            DialogResult dialogResult = MessageBox.Show(
                $"Вы действительно хотите удалить пациента:\n{patientFio}?\n\nВнимание: все приёмы данного пациента также будут удалены!",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    // Находим пациента в базе данных
                    var patient = _context.Patients.Find(patientId);
                    if (patient != null)
                    {
                        // Удаляем объект из контекста
                        _context.Patients.Remove(patient);

                        // Сохраняем изменения в БД
                        _context.SaveChanges();

                        MessageBox.Show("Пациент успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Обновляем список пациентов на экране без перезапуска формы (Задание №3)
                        LoadPatients();
                    }
                    else
                    {
                        MessageBox.Show("Пациент уже удален или не найден в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении из базы данных: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnViewVisits_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пациента из списка, чтобы посмотреть его историю.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int patientId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

            var historyForm = new PatientHistoryForm(patientId);
            historyForm.ShowDialog();
        }

        private void bntNewAppointment_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пациента из списка для оформления приёма.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int patientId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

            var newAppForm = new NewAppointmentForm(patientId);
            newAppForm.ShowDialog();
            LoadPatients();
        }

        private void btnViewDoctors_Click(object sender, EventArgs e)
        {
            var addForm = new DoctorForm();
            addForm.ShowDialog();
        }

        /// <summary>
        /// Просмотр скидки по пациенту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisc_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пациента из списка, чтобы узнать его скидку.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int patientId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

            string patientFio = dataGridView1.SelectedRows[0].Cells["ФИО"].Value.ToString();

            int currentDiscount = CalculatePatientDiscount(patientId);

            MessageBox.Show(
             $"Пациент: {patientFio}\nТекущая персональная скидка: {currentDiscount}%",
              "Информация о скидке",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information
    );
        }
        private int CalculatePatientDiscount(int patientId)
        {
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);

            int visitsCount = _context.Appointments
                .Count(a => a.PatientId == patientId && a.Date >= oneYearAgo);
            if (visitsCount <= 3)
            {
                return 0; // до 3 визитов – 0%
            }
            else if (visitsCount >= 4 && visitsCount <= 7)
            {
                return 5; // 4–7 визитов – 5%
            }
            else if (visitsCount >= 8 && visitsCount <= 15)
            {
                return 10; // 8–15 визитов – 10%
            }
            else
            {
                return 15; // более 15 визитов – 15%
            }
        }
    }
}
