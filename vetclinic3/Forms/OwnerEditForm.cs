using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vetclinic3.Models; // Подключаем контекст базы данных

namespace vetclinic3.Forms
{
    public partial class OwnerEditForm : Form
    {
        private int? _ownerId; // Переменная для хранения ID редактируемого владельца

        // Изменяем конструктор, чтобы он принимал id (null - добавление, число - редактирование)
        public OwnerEditForm(int? ownerId)
        {
            InitializeComponent();
            _ownerId = ownerId;

            if (_ownerId.HasValue)
            {
                this.Text = "Редактирование владельца";
                LoadOwnerData();
            }
            else
            {
                this.Text = "Добавление нового владельца";
            }
        }

        // Метод для загрузки данных существующего владельца в поля формы
        private void LoadOwnerData()
        {
            try
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    var owner = db.Owners.Find(_ownerId.Value);
                    if (owner != null)
                    {
                        txtFullName.Text = owner.FullName;
                        txtPhone.Text = owner.Phone;
                        chkIsRegular.Checked = owner.IsRegular; // Устанавливаем галочку true/false
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            // Оставляем пустым
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            // Оставляем пустым
        }

        private void chkIsRegular_CheckedChanged(object sender, EventArgs e)
        {
            // Оставляем пустым
        }

        // Логика кнопки "Сохранить"
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация: имя клиента обязательно
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Поле 'ФИО Владельца' обязательно для заполнения!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    Owner owner;

                    if (_ownerId.HasValue)
                    {
                        // Если редактируем — ищем существующего в базе
                        owner = db.Owners.Find(_ownerId.Value);
                    }
                    else
                    {
                        // Если добавляем — создаем новую запись
                        owner = new Owner();
                        db.Owners.Add(owner);
                    }

                    if (owner != null)
                    {
                        // Переносим данные из элементов интерфейса в модель
                        owner.FullName = txtFullName.Text.Trim();
                        owner.Phone = txtPhone.Text.Trim();
                        owner.IsRegular = chkIsRegular.Checked; // Считываем состояние флажка

                        db.SaveChanges(); // Сохраняем изменения в PostgreSQL
                    }
                }

                this.DialogResult = DialogResult.OK; // Говорим главной форме, что всё прошло успешно
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Логика кнопки "Отмена"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // Закрываем без сохранения изменений
        }
    }
}