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
    public partial class AnimalEditForm : Form
    {
        private int? _animalId; // Храним ID животного для редактирования

        // Переписываем конструктор, чтобы он принимал ID (null - для добавления нового)
        public AnimalEditForm(int? animalId)
        {
            InitializeComponent();
            _animalId = animalId;

            LoadOwnersToComboBox(); // Загружаем список хозяев в выпадающий список

            if (_animalId.HasValue)
            {
                this.Text = "Редактирование медкарты";
                LoadAnimalData();
            }
            else
            {
                this.Text = "Завести новую медкарту";
            }
        }

        // Метод для вывода списка всех владельцев в ComboBox
        private void LoadOwnersToComboBox()
        {
            try
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    var owners = db.Owners.OrderBy(o => o.FullName).ToList();

                    cmbOwner.DataSource = owners;
                    cmbOwner.DisplayMember = "FullName"; // Что видит пользователь в списке
                    cmbOwner.ValueMember = "Id";         // Идентификатор, который запишем в базу
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка владельцев: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка данных существующего питомца в поля формы
        private void LoadAnimalData()
        {
            try
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    var animal = db.Animals.Find(_animalId.Value);
                    if (animal != null)
                    {
                        txtPetName.Text = animal.PetName;
                        txtSpecies.Text = animal.Species;
                        txtBreed.Text = animal.Breed;
                        numAge.Value = animal.AgeYears;
                        cmbOwner.SelectedValue = animal.OwnerId; // Выделяем его текущего хозяина
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных медкарты: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPetName_TextChanged(object sender, EventArgs e)
        {
            // Пустой обработчик из дизайнера
        }

        private void txtSpecies_TextChanged(object sender, EventArgs e)
        {
            // Пустой обработчик из дизайнера
        }

        private void txtBreed_TextChanged(object sender, EventArgs e)
        {
            // Пустой обработчик из дизайнера
        }

        private void numAge_ValueChanged(object sender, EventArgs e)
        {
            // Пустой обработчик из дизайнера
        }

        private void cmbOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Пустой обработчик из дизайнера
        }

        // Логика кнопки "Сохранить"
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPetName.Text))
            {
                MessageBox.Show("Кличка животного обязательно должна быть заполнена!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbOwner.SelectedValue == null)
            {
                MessageBox.Show("Необходимо выбрать владельца питомца!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new vetclinic_bd_3Context())
                {
                    Animal animal;

                    if (_animalId.HasValue)
                    {
                        // Если редактируем — находим в базе
                        animal = db.Animals.Find(_animalId.Value);
                    }
                    else
                    {
                        // Если добавляем — создаем новую пустую запись
                        animal = new Animal();
                        db.Animals.Add(animal);
                    }

                    if (animal != null)
                    {
                        animal.PetName = txtPetName.Text.Trim();
                        animal.Species = txtSpecies.Text.Trim();
                        animal.Breed = txtBreed.Text.Trim();
                        animal.AgeYears = (int)numAge.Value;
                        animal.OwnerId = (int)cmbOwner.SelectedValue; // Передаем ID выбранного владельца

                        db.SaveChanges(); // Фиксируем изменения в PostgreSQL
                    }
                }

                this.DialogResult = DialogResult.OK; // Сигнал для MainForm
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения медкарты: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Логика кнопки "Отмена"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}