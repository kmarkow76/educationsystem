using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vetclinic3.Models; // Подключаем модели нашей базы данных

namespace vetclinic3.Forms
{
    public partial class VetEditForm : Form
    {
        private int? _vetId; // Переменная для хранения ID редактируемого врача

        // Изменяем конструктор, чтобы он принимал id (null - если добавляем, число - если редактируем)
        public VetEditForm(int? vetId)
        {
            InitializeComponent();
            _vetId = vetId;

            if (_vetId.HasValue)
            {
                this.Text = "Редактирование данных врача";
                LoadVetData();
            }
            else
            {
                this.Text = "Добавление нового врача";
            }
        }

        // Метод для подтягивания данных врача в текстовые поля при редактировании
        private void LoadVetData()
        {
            try
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    var vet = db.Vets.Find(_vetId.Value);
                    if (vet != null)
                    {
                        txtDoctorName.Text = vet.DoctorName;
                        txtSpecialization.Text = vet.Specialization;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных врача: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDoctorName_TextChanged(object sender, EventArgs e)
        {
            // Оставляем пустым, как сгенерировал дизайнер
        }

        private void txtSpecialization_TextChanged(object sender, EventArgs e)
        {
            // Оставляем пустым, как сгенерировал дизайнер
        }

        // Логика кнопки "Сохранить"
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Простая валидация: ФИО не должно быть пустым
            if (string.IsNullOrWhiteSpace(txtDoctorName.Text))
            {
                MessageBox.Show("Поле 'ФИО Доктора' не может быть пустым!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    Vet vet;

                    if (_vetId.HasValue)
                    {
                        // Если редактируем — находим врача по ID в базе данных
                        vet = db.Vets.Find(_vetId.Value);
                    }
                    else
                    {
                        // Если добавляем — создаем новую пустую запись
                        vet = new Vet();
                        db.Vets.Add(vet);
                    }

                    if (vet != null)
                    {
                        // Заполняем поля данными из TextBox
                        vet.DoctorName = txtDoctorName.Text.Trim();
                        vet.Specialization = txtSpecialization.Text.Trim();

                        db.SaveChanges(); // Сохраняем изменения в PostgreSQL
                    }
                }

                this.DialogResult = DialogResult.OK; // Передаем MainForm сигнал "Все прошло успешно"
                this.Close(); // Закрываем форму
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Логика кнопки "Отмена"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Передаем сигнал отмены
            this.Close(); // Просто закрываем окно без изменений
        }
    }
}