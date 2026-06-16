using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using service15.Models; // Подключаем сгенерированные модели СУБД

namespace service15.Forms
{
    public partial class ManageMastersForm : Form
    {
        // Переменная для хранения ID выбранного из таблицы мастера (null — если создаем нового)
        private int? _selectedMasterId = null;

        public ManageMastersForm()
        {
            InitializeComponent();
        }

        // Автоматическая загрузка данных при открытии окна справочника
        private void ManageMastersForm_Load(object sender, EventArgs e)
        {
            LoadMastersData();
        }

        /// <summary>
        /// Комментарий: Логика загрузки и отображения списка мастеров из СУБД service_bd_15 в таблицу
        /// </summary>
        private void LoadMastersData()
        {
            try
            {
                using (var db = new service_bd_15Context())
                {
                    // Извлекаем мастеров из базы данных PostgreSQL
                    var mastersList = db.Masters
                        .Select(m => new
                        {
                            Id = m.Id,
                            FullName = m.FullName,
                            Specialty = m.Specialty,
                            Rating = m.Rating
                        })
                        .ToList();

                    // Привязываем данные к твоей таблице dataGridView1
                    dataGridView1.DataSource = mastersList;

                    // Настраиваем русские заголовки
                    dataGridView1.Columns["Id"].Visible = false; // Скрываем технический ID
                    dataGridView1.Columns["FullName"].HeaderText = "ФИО Мастера";
                    dataGridView1.Columns["Specialty"].HeaderText = "Специализация";
                    dataGridView1.Columns["Rating"].HeaderText = "Рейтинг мастера";

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки мастеров: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Сбрасываем форму в исходное состояние
            ClearFields();
        }

        // Событие: клик по ячейке/строке таблицы (выбор мастера для редактирования)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dynamic selectedRow = dataGridView1.CurrentRow.DataBoundItem;

                // Запоминаем ID и раскидываем старые данные по полям
                _selectedMasterId = selectedRow.Id;
                txtFullName.Text = selectedRow.FullName;
                txtSpecialty.Text = selectedRow.Specialty;
                numericUpDown1.Value = (decimal)selectedRow.Rating; // Привязка к твоему numericUpDown1

                // Переключаем кнопку в режим сохранения изменений
                btnSave.Text = "Изменить данные";
            }
        }

        // Кнопка: Сохранить (Добавление / Изменение данных мастера)
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация входных данных: ФИО и специальность обязательны
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtSpecialty.Text))
            {
                MessageBox.Show("Пожалуйста, заполните ФИО мастера и его специализацию!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new service_bd_15Context())
                {
                    if (_selectedMasterId == null)
                    {
                        // Режим: ДОБАВЛЕНИЕ нового мастера
                        Master newMaster = new Master
                        {
                            FullName = txtFullName.Text.Trim(),
                            Specialty = txtSpecialty.Text.Trim(),
                            Rating = numericUpDown1.Value
                        };
                        db.Masters.Add(newMaster);
                    }
                    else
                    {
                        // Режим: РЕДАКТИРОВАНИЕ существующего мастера
                        var masterToUpdate = db.Masters.Find(_selectedMasterId);
                        if (masterToUpdate != null)
                        {
                            masterToUpdate.FullName = txtFullName.Text.Trim();
                            masterToUpdate.Specialty = txtSpecialty.Text.Trim();
                            masterToUpdate.Rating = numericUpDown1.Value;
                        }
                    }

                    db.SaveChanges(); // Сохраняем всё в PostgreSQL
                    MessageBox.Show("Данные справочника мастеров успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Обновляем таблицу на лету без перезапуска приложения
                    LoadMastersData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения мастера: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Удалить мастера из системы
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedMasterId == null)
            {
                MessageBox.Show("Пожалуйста, выберите мастера из таблицы для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Вы действительно хотите удалить мастера \"{txtFullName.Text}\"?\n\nВнимание: Каскадно удалятся все назначенные ему заявки!",
                                                  "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var db = new service_bd_15Context())
                    {
                        var masterToDelete = db.Masters.Find(_selectedMasterId);
                        if (masterToDelete != null)
                        {
                            db.Masters.Remove(masterToDelete);
                            db.SaveChanges(); // Фиксируем в базе

                            MessageBox.Show("Мастер успешно удален из системы!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadMastersData(); // Перерисовываем таблицу на лету
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении мастера: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Кнопка: Закрыть окно
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Возвращаемся назад на форму редактирования заявки
        }

        /// <summary>
        /// Дополнительный метод для сброса полей формы в исходное состояние
        /// </summary>
        private void ClearFields()
        {
            _selectedMasterId = null;
            txtFullName.Clear();
            txtSpecialty.Clear();
            numericUpDown1.Value = 4.5m; // Ставим дефолтный хороший рейтинг
            btnSave.Text = "Добавить нового";
        }

        // Оставляем пустые заглушки для событий, чтобы не ругался дизайнер формы
        private void txtFullName_TextChanged(object sender, EventArgs e) { }
        private void txtSpecialty_TextChanged(object sender, EventArgs e) { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }
    }
}