using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vetclinic3.Models;

namespace vetclinic3.Forms
{
    public partial class MainForm : Form
    {
        // Глобальное объявление таблицы врачей, чтобы все внутренние методы её видели
        private DataGridView dgvVets;

        public MainForm()
        {
            InitializeComponent();

            // 1. Настраиваем левую таблицу (Владельцы)
            dgvOwners.Location = new System.Drawing.Point(18, 16);
            dgvOwners.Size = new System.Drawing.Size(600, 188); // Сделали поуже, чтобы освободить место справа
            dgvOwners.AllowUserToAddRows = false;
            dgvOwners.ReadOnly = true;
            dgvOwners.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 2. Инициализируем и позиционируем правую таблицу (Врачи)
            dgvVets = new DataGridView();
            dgvVets.AllowUserToAddRows = false;
            dgvVets.ReadOnly = true;
            dgvVets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVets.RowHeadersWidth = 51;
            dgvVets.RowTemplate.Height = 29;

            // Сдвигаем вправо (X = 650) ровно над кнопками врачей
            dgvVets.Location = new System.Drawing.Point(650, 16);
            dgvVets.Size = new System.Drawing.Size(670, 188);
            dgvVets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Добавляем таблицу врачей на третью вкладку
            tabPage3.Controls.Add(dgvVets);

            // Дополнительно: сделаем выделение всей строки для остальных таблиц (для удобства кликов по кнопкам)
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.Load += new System.EventHandler(this.MainForm_Load);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshAllData();
        }

        public void RefreshAllData()
        {
            LoadAppointments();
            LoadAnimals();
            LoadOwnersAndVets();
        }

        private void LoadAppointments()
        {
            try
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    var rawAppointments = db.Appointments
                        .Select(a => new
                        {
                            a.Id,
                            PetName = a.Animal.PetName,
                            OwnerName = a.Animal.Owner.FullName,
                            IsRegularCustomer = a.Animal.Owner.IsRegular,
                            DoctorName = a.Vet.DoctorName,
                            a.AppointmentDate,
                            a.Diagnosis,
                            a.Treatment,
                            a.ServicesCost,
                            a.MedsCost,
                            a.Status
                        }).ToList();

                    var calculatedAppointments = rawAppointments.Select(a =>
                    {
                        decimal discountPercent = 0;

                        if (a.Status != "Отменен")
                        {
                            if (a.ServicesCost > 3000)
                                discountPercent = 10;
                            else if (a.ServicesCost > 1000)
                                discountPercent = 5;

                            if (a.IsRegularCustomer)
                                discountPercent += 5;
                        }

                        decimal discountAmount = a.ServicesCost * (discountPercent / 100);
                        decimal finalCost = (a.ServicesCost - discountAmount) + a.MedsCost;

                        if (a.Status == "Отменен") finalCost = 0;

                        return new
                        {
                            a.Id,
                            a.PetName,
                            a.OwnerName,
                            a.DoctorName,
                            a.AppointmentDate,
                            a.Diagnosis,
                            a.Treatment,
                            a.ServicesCost,
                            a.MedsCost,
                            Discount = $"{discountPercent}%",
                            FinalCost = finalCost,
                            a.Status
                        };
                    }).ToList();

                    dgvAppointments.DataSource = calculatedAppointments;

                    dgvAppointments.Columns["Id"].Visible = false;
                    dgvAppointments.Columns["PetName"].HeaderText = "Кличка животного";
                    dgvAppointments.Columns["OwnerName"].HeaderText = "Владелец";
                    dgvAppointments.Columns["DoctorName"].HeaderText = "Ветеринарный врач";
                    dgvAppointments.Columns["AppointmentDate"].HeaderText = "Дата приема";
                    dgvAppointments.Columns["Diagnosis"].HeaderText = "Диагноз";
                    dgvAppointments.Columns["Treatment"].HeaderText = "Лечение";
                    dgvAppointments.Columns["ServicesCost"].HeaderText = "Стоимость услуг";
                    dgvAppointments.Columns["MedsCost"].HeaderText = "Стоимость медикаментов";
                    dgvAppointments.Columns["Discount"].HeaderText = "Размер скидки";
                    dgvAppointments.Columns["FinalCost"].HeaderText = "Итоговая стоимость";
                    dgvAppointments.Columns["Status"].HeaderText = "Статус";

                    dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки журнала приемов: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAnimals()
        {
            try
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    dgvAnimals.DataSource = db.Animals.Select(an => new
                    {
                        an.Id,
                        an.PetName,
                        an.Species,
                        an.Breed,
                        an.AgeYears,
                        OwnerName = an.Owner.FullName
                    }).ToList();

                    dgvAnimals.Columns["Id"].Visible = false;
                    dgvAnimals.Columns["PetName"].HeaderText = "Кличка";
                    dgvAnimals.Columns["Species"].HeaderText = "Вид животного";
                    dgvAnimals.Columns["Breed"].HeaderText = "Порода";
                    dgvAnimals.Columns["AgeYears"].HeaderText = "Возраст (лет)";
                    dgvAnimals.Columns["OwnerName"].HeaderText = "ФИО Хозяина";

                    dgvAnimals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки ветеринарных карт: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOwnersAndVets()
        {
            try
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    dgvOwners.DataSource = db.Owners.Select(o => new { o.Id, o.FullName, o.Phone, o.IsRegular }).ToList();
                    dgvOwners.Columns["Id"].Visible = false;
                    dgvOwners.Columns["FullName"].HeaderText = "ФИО Клиента";
                    dgvOwners.Columns["Phone"].HeaderText = "Телефон";
                    dgvOwners.Columns["IsRegular"].HeaderText = "Постоянный клиент";

                    if (dgvVets != null)
                    {
                        dgvVets.DataSource = db.Vets.Select(v => new { v.Id, v.DoctorName, v.Specialization }).ToList();
                        dgvVets.Columns["Id"].Visible = false;
                        dgvVets.Columns["DoctorName"].HeaderText = "ФИО Доктора";
                        dgvVets.Columns["Specialization"].HeaderText = "Специализация";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления справочников: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            AppointmentEditForm form = new AppointmentEditForm(null);
            form.ShowDialog();
            RefreshAllData();
        }

        private void btnEditApp_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow != null)
            {
                dynamic selectedRow = dgvAppointments.CurrentRow.DataBoundItem;
                int appId = selectedRow.Id;

                AppointmentEditForm form = new AppointmentEditForm(appId);
                form.ShowDialog();
                RefreshAllData();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите прием для редактирования!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteApp_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null) return;
            dynamic selectedRow = dgvAppointments.CurrentRow.DataBoundItem;
            int appId = selectedRow.Id;

            var res = MessageBox.Show("Удалить запись о данном приеме безвозвратно?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    var app = db.Appointments.Find(appId);
                    if (app != null) { db.Appointments.Remove(app); db.SaveChanges(); }
                }
                RefreshAllData();
            }
        }

        private void btnCancelApp_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null) return;
            dynamic selectedRow = dgvAppointments.CurrentRow.DataBoundItem;
            int appId = selectedRow.Id;

            using (var db = new vetclinic_bd_3Context())
            {
                var app = db.Appointments.Find(appId);
                if (app != null)
                {
                    app.Status = "Отменен";
                    db.SaveChanges();
                    MessageBox.Show("Статус приема успешно изменен на 'Отменен'. Все финансовые расчеты обнулены!", "Действие отменено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            RefreshAllData();
        }

        private void btnAddAnimal_Click(object sender, EventArgs e)
        {
            // Открываем форму для создания новой медкарты
            AnimalEditForm form = new AnimalEditForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshAllData(); // Обновляем таблицы
            }
        }

        private void btnEditAnimal_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрано ли животное в таблице dgvAnimals
            if (dgvAnimals.CurrentRow != null)
            {
                dynamic selectedRow = dgvAnimals.CurrentRow.DataBoundItem;
                int animalId = selectedRow.Id;

                // Открываем форму для изменения данных карты
                AnimalEditForm form = new AnimalEditForm(animalId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshAllData(); // Обновляем таблицы
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите животное из списка для изменения карты!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteAnimal_Click(object sender, EventArgs e)
        {
            if (dgvAnimals.CurrentRow == null) return;
            dynamic selectedRow = dgvAnimals.CurrentRow.DataBoundItem;
            int animalId = selectedRow.Id;

            var res = MessageBox.Show("Удалить медкарту животного? Это удалит каскадно всю историю его приемов!", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    var animal = db.Animals.Find(animalId);
                    if (animal != null) { db.Animals.Remove(animal); db.SaveChanges(); }
                }
                RefreshAllData();
            }
        }

        private void btnAddOwner_Click(object sender, EventArgs e)
        {
            // Открываем форму для добавления владельца
            OwnerEditForm form = new OwnerEditForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshAllData(); // Перерисовываем таблицы
            }
        }

        private void btnEditOwner_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли владелец в левой таблице dgvOwners
            if (dgvOwners.CurrentRow != null)
            {
                dynamic selectedRow = dgvOwners.CurrentRow.DataBoundItem;
                int ownerId = selectedRow.Id;

                // Открываем форму для редактирования текущего владельца
                OwnerEditForm form = new OwnerEditForm(ownerId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshAllData(); // Обновляем таблицы
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите владельца из списка для изменения!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDeleteOwner_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow == null) return;
            dynamic selectedRow = dgvOwners.CurrentRow.DataBoundItem;
            int ownerId = selectedRow.Id;

            var res = MessageBox.Show("Удалить владельца и всех его питомцев?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    var owner = db.Owners.Find(ownerId);
                    if (owner != null) { db.Owners.Remove(owner); db.SaveChanges(); }
                }
                RefreshAllData();
            }
        }

        private void btnAddVet_Click(object sender, EventArgs e)
        {
            // Открываем форму для добавления нового врача (передаем null)
            VetEditForm form = new VetEditForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshAllData(); // Обновляем таблицы на форме после успешного сохранения
            }
        }

        private void btnEditVet_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка в таблице врачей
            if (dgvVets != null && dgvVets.CurrentRow != null)
            {
                dynamic selectedRow = dgvVets.CurrentRow.DataBoundItem;
                int vetId = selectedRow.Id;

                // Открываем форму для редактирования (передаем ID выбранного врача)
                VetEditForm form = new VetEditForm(vetId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshAllData(); // Обновляем данные на экране
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите врача из списка для изменения!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDeleteVet_Click(object sender, EventArgs e)
        {
            if (dgvVets == null || dgvVets.CurrentRow == null) return;
            dynamic selectedRow = dgvVets.CurrentRow.DataBoundItem;
            int vetId = selectedRow.Id;

            var res = MessageBox.Show("Удалить врача из состава клиники?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    var vet = db.Vets.Find(vetId);
                    if (vet != null) { db.Vets.Remove(vet); db.SaveChanges(); }
                }
                RefreshAllData();
            }
        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvAnimals_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvOwners_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void tabPage2_Click(object sender, EventArgs e) { }
        private void tabPage3_Click(object sender, EventArgs e) { }
    }
}