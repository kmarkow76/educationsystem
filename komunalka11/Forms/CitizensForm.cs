using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using komunalka11.Models; // Подключаем наши модели БД
using Microsoft.EntityFrameworkCore;

namespace komunalka11.Forms
{
    public partial class CitizensForm : Form
    {
        // Переменная для отслеживания выбранного жильца (null - если добавляем нового)
        private int? selectedCitizenId = null;

        public CitizensForm()
        {
            InitializeComponent();
        }

        // При загрузке окна сразу тянем данные из базы
        private void CitizensForm_Load(object sender, EventArgs e)
        {
            LoadCitizensData();
        }

        /// <summary>
        /// Комментарий: Логика загрузки и связывания данных жильцов и лицевых счетов из БД
        /// </summary>
        private void LoadCitizensData()
        {
            try
            {
                using (var db = new komunalka_bd_11Context())
                {
                    // Собираем данные в плоскую структуру для красивого вывода в грид
                    var data = db.Accounts
                        .Include(a => a.Citizen)
                        .Select(a => new
                        {
                            CitizenId = a.Citizen.Id,
                            AccountId = a.Id,
                            FullName = a.Citizen.FullName,
                            AccountNumber = a.AccountNumber,
                            Address = a.Address,
                            HasPrivilege = a.Citizen.HasPrivilege ? "Да" : "Нет"
                        })
                        .ToList();

                    dgvCitizens.DataSource = data;

                    // Настройка колонок
                    dgvCitizens.Columns["CitizenId"].Visible = false;
                    dgvCitizens.Columns["AccountId"].Visible = false;
                    dgvCitizens.Columns["FullName"].HeaderText = "ФИО жильца";
                    dgvCitizens.Columns["AccountNumber"].HeaderText = "Лицевой счет";
                    dgvCitizens.Columns["Address"].HeaderText = "Адрес проживания";
                    dgvCitizens.Columns["HasPrivilege"].HeaderText = "Льгота (25%)";

                    dgvCitizens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                ClearFields(); // Сбрасываем поля ввода
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки жильцов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Клик по ячейке таблицы — подгружаем данные в поля для редактирования
        private void dgvCitizens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что кликнули по существующей строке, а не по шапке
            if (e.RowIndex >= 0)
            {
                var row = dgvCitizens.Rows[e.RowIndex];

                // Извлекаем ID из скрытых колонок
                selectedCitizenId = Convert.ToInt32(row.Cells["CitizenId"].Value);

                // Заполняем поля формы данными из таблицы
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtAccountNumber.Text = row.Cells["AccountNumber"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                chkHasPrivilege.Checked = row.Cells["HasPrivilege"].Value.ToString() == "Да";

                // Делаем поле номера счета недоступным для изменения, если это редактирование (опционально)
                txtAccountNumber.ReadOnly = true;
            }
        }

        // Кнопка Сохранить (Добавление нового или изменение старого)
        private void btnSaveCitizen_Click(object sender, EventArgs e)
        {
            // 1. Валидация данных в реальном времени (Проверка на пустые строки)
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtAccountNumber.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля формы!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new komunalka_bd_11Context())
                {
                    if (selectedCitizenId == null)
                    {
                        // Режим: ДОБАВЛЕНИЕ нового жильца и счета

                        // Проверяем уникальность лицевого счета
                        if (db.Accounts.Any(a => a.AccountNumber == txtAccountNumber.Text.Trim()))
                        {
                            MessageBox.Show("Лицевой счет с таким номером уже существует!", "Дубликат данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Создаем объект жильца
                        Citizen newCitizen = new Citizen
                        {
                            FullName = txtFullName.Text.Trim(),
                            HasPrivilege = chkHasPrivilege.Checked
                        };
                        db.Citizens.Add(newCitizen);
                        db.SaveChanges(); // Сохраняем сначала жильца, чтобы получить его ID

                        // Создаем лицевой счет, привязанный к новому жильцу
                        Account newAccount = new Account
                        {
                            AccountNumber = txtAccountNumber.Text.Trim(),
                            Address = txtAddress.Text.Trim(),
                            CitizenId = newCitizen.Id
                        };
                        db.Accounts.Add(newAccount);
                    }
                    else
                    {
                        // Режим: РЕДАКТИРОВАНИЕ существующего жильца
                        var citizenToUpdate = db.Citizens.Find(selectedCitizenId);
                        if (citizenToUpdate != null)
                        {
                            citizenToUpdate.FullName = txtFullName.Text.Trim();
                            citizenToUpdate.HasPrivilege = chkHasPrivilege.Checked;

                            // Находим счет, связанный с этим жильцом, чтобы обновить адрес
                            var accountToUpdate = db.Accounts.FirstOrDefault(a => a.CitizenId == selectedCitizenId);
                            if (accountToUpdate != null)
                            {
                                accountToUpdate.Address = txtAddress.Text.Trim();
                            }
                        }
                    }

                    db.SaveChanges(); // Фиксируем изменения в PostgreSQL
                    MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCitizensData(); // Обновляем сетку без перезапуска приложения
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка Назад (Закрываем текущую форму)
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Вспомогательный метод для очистки полей формы
        private void ClearFields()
        {
            selectedCitizenId = null;
            txtFullName.Clear();
            txtAccountNumber.Clear();
            txtAccountNumber.ReadOnly = false;
            txtAddress.Clear();
            chkHasPrivilege.Checked = false;
        }

        // Остальные пустые обработчики оставляем, чтобы дизайнер не ругался
        private void txtFullName_TextChanged(object sender, EventArgs e) { }
        private void txtAccountNumber_TextChanged(object sender, EventArgs e) { }
        private void txtAddress_TextChanged(object sender, EventArgs e) { }
        private void chkHasPrivilege_CheckedChanged(object sender, EventArgs e) { }
        private void gbManage_Enter(object sender, EventArgs e) { }
        private void dgvCitizens_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        
    }
}