using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vetclinic3.Models; // Доступ к объектным моделям нашей СУБД

namespace vetclinic3.Forms
{
    public partial class AppointmentEditForm : Form
    {
        // Храним ID редактируемой записи (null означает, что мы создаем новую запись)
        private int? _appointmentId;

        // Конструктор формы с поддержкой передачи ID
        public AppointmentEditForm(int? appointmentId)
        {
            InitializeComponent();
            _appointmentId = appointmentId;

            // Явно связываем событие загрузки формы через код
            this.Load += new System.EventHandler(this.AppointmentEditForm_Load);

            // Настройка заголовков окон под текущий режим работы (Задание №3)
            if (_appointmentId == null)
            {
                this.Text = "Новая запись на прием";
                btnSave.Text = "Записать на прием";
            }
            else
            {
                this.Text = "Редактирование приема";
                btnSave.Text = "Сохранить изменения";
            }
        }

        // Стартовое событие при открытии формы
        private void AppointmentEditForm_Load(object sender, EventArgs e)
        {
            LoadDropDownLists();

            // Если форма открыта на редактирование — извлекаем данные из базы (Задание №3)
            if (_appointmentId != null)
            {
                LoadAppointmentDataForEditing();
            }
            else
            {
                // Для новой записи ставим статус по умолчанию
                if (cbStatus.Items.Count > 0) cbStatus.SelectedIndex = 0; // "Запланирован"
            }
        }

        /// <summary>
        /// Комментарий: Логика загрузки связанных справочников СУБД в ComboBox
        /// </summary>
        private void LoadDropDownLists()
        {
            try
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    // Формируем список животных, склеивая кличку и хозяина для исключения ошибок ввода
                    var animalsList = db.Animals.Select(an => new
                    {
                        an.Id,
                        DisplayInfo = an.PetName + " (Владелец: " + an.Owner.FullName + ")"
                    }).ToList();

                    cbAnimal.DataSource = animalsList;
                    cbAnimal.DisplayMember = "DisplayInfo";
                    cbAnimal.ValueMember = "Id";

                    // Загружаем врачей
                    cbVet.DataSource = db.Vets.ToList();
                    cbVet.DisplayMember = "DoctorName";
                    cbVet.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка заполнения списков формы: {ex.Message}", "Критическая ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Комментарий: Логика автоматической подгрузки старых данных приема для редактирования
        /// </summary>
        private void LoadAppointmentDataForEditing()
        {
            try
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    var app = db.Appointments.Find(_appointmentId);
                    if (app != null)
                    {
                        cbAnimal.SelectedValue = app.AnimalId;
                        cbVet.SelectedValue = app.VetId;
                        dtpDate.Value = app.AppointmentDate;
                        tbDiagnosis.Text = app.Diagnosis;
                        tbTreatment.Text = app.Treatment;
                        numServicesCost.Value = app.ServicesCost;
                        numMedsCost.Value = app.MedsCost;
                        cbStatus.SelectedItem = app.Status;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка извлечения ветеринарной карты приема: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Сохранить / Записать (Основное действие)
        private void btnSave_Click(object sender, EventArgs e)
        {
            // --- ВСТРОЕННАЯ ОБРАБОТКА ОШИБОК И ВАЛИДАЦИЯ ДАННЫХ (Задание №3) ---

            if (cbAnimal.SelectedValue == null)
            {
                MessageBox.Show("Необходимо выбрать животное для оформления приема!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbVet.SelectedValue == null)
            {
                MessageBox.Show("Необходимо назначить ветеринарного врача!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbDiagnosis.Text))
            {
                MessageBox.Show("Пожалуйста, внесите диагноз или причину обращения в электронную карту!", "Ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDiagnosis.Focus();
                return;
            }

            if (cbStatus.SelectedItem == null)
            {
                MessageBox.Show("Укажите текущий статус обслуживания!", "Ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    if (_appointmentId == null)
                    {
                        // Режим: ДОБАВЛЕНИЕ новой записи в журнал
                        Appointment newApp = new Appointment
                        {
                            AnimalId = (int)cbAnimal.SelectedValue,
                            VetId = (int)cbVet.SelectedValue,
                            AppointmentDate = dtpDate.Value,
                            Diagnosis = tbDiagnosis.Text.Trim(),
                            Treatment = tbTreatment.Text.Trim(),
                            ServicesCost = numServicesCost.Value,
                            MedsCost = numMedsCost.Value,
                            Status = cbStatus.SelectedItem.ToString()
                        };

                        db.Appointments.Add(newApp);
                    }
                    else
                    {
                        // Режим: РЕДАКТИРОВАНИЕ существующего приема
                        var appToUpdate = db.Appointments.Find(_appointmentId);
                        if (appToUpdate != null)
                        {
                            appToUpdate.AnimalId = (int)cbAnimal.SelectedValue;
                            appToUpdate.VetId = (int)cbVet.SelectedValue;
                            appToUpdate.AppointmentDate = dtpDate.Value;
                            appToUpdate.Diagnosis = tbDiagnosis.Text.Trim();
                            appToUpdate.Treatment = tbTreatment.Text.Trim();
                            appToUpdate.ServicesCost = numServicesCost.Value;
                            appToUpdate.MedsCost = numMedsCost.Value;
                            appToUpdate.Status = cbStatus.SelectedItem.ToString();
                        }
                    }

                    db.SaveChanges(); // Сохраняем и фиксируем транзакцию в PostgreSQL
                    MessageBox.Show("Данные приема успешно синхронизированы с базой данных!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Последовательная навигация: возвращаемся на MainForm
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Критическая ошибка сохранения документа: {ex.Message}", "Ошибка транзакции СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Назад / Отмена действия
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Безопасное закрытие формы без фиксации изменений в СУБД
        }

        // ============================================================================
        // СИСТЕМНЫЕ ЗАГЛУШКИ ДЛЯ ИЗБЕЖАНИЯ СБОЕВ ДИЗАЙНЕРА VISUAL STUDIO
        // ============================================================================
        private void cbAnimal_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbVet_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpDate_ValueChanged(object sender, EventArgs e) { }
        private void tbDiagnosis_TextChanged(object sender, EventArgs e) { }
        private void tbTreatment_TextChanged(object sender, EventArgs e) { }
        private void numServicesCost_ValueChanged(object sender, EventArgs e) { }
        private void numMedsCost_ValueChanged(object sender, EventArgs e) { }
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}