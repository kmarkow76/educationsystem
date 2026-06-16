using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using trackingOfRequests12.Models;

namespace trackingOfRequests12.Forms
{
    public partial class AddRequestForm : Form
    {
        public tracking_of_requestsContext _context = new tracking_of_requestsContext();

        public AddRequestForm()
        {
            InitializeComponent();
            this.Text = "Новая заявка";
        }

        private void AddRequestForm_Load(object sender, EventArgs e)
        {
            var clients = _context.Clients.ToList();
            cbClient.DataSource = clients;
            cbClient.DisplayMember = "FullName";
            cbClient.ValueMember = "Id";

            var devices = _context.Devices.ToList();
            cbDevice.DataSource = devices;
            cbDevice.DisplayMember = "Model";
            cbDevice.ValueMember = "Id";

            var employees = _context.Employees.ToList();
            cbEmployee.DataSource = employees;
            cbEmployee.DisplayMember = "FullName";
            cbEmployee.ValueMember = "Id";

            cbStatus.Items.AddRange(new string[] { "Новая", "В работе", "Выполнена", "Отменена" });
            cbStatus.SelectedIndex = 0;

            mtbCreated.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // ... [Твои проверки валидации полей остаются без изменений] ...

            if (!DateTime.TryParseExact(mtbCreated.Text, "dd.MM.yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime createdDate))
            {
                MessageBox.Show("Введите корректную дату.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var request = new RepairRequest
                {
                    ClientId = (int)cbClient.SelectedValue,
                    DeviceId = (int)cbDevice.SelectedValue,
                    EmployeeId = (int)cbEmployee.SelectedValue,
                    FaultDescription = tbFaultDescription.Text.Trim(),
                    WorkList = tbWorkList.Text.Trim(),
                    BaseWorkPrice = nudBasePrice.Value,
                    IsUrgent = chbIsUrgent.Checked,
                    Status = cbStatus.SelectedItem.ToString(),
                    CreatedDate = createdDate
                };

                _context.RepairRequests.Add(request);
                _context.SaveChanges(); // База данных генерирует Id для заявки!

                // Меняем логику здесь: спрашиваем пользователя, нужно ли добавить запчасти
                DialogResult result = MessageBox.Show(
                    "Заявка успешно создана! Хотите добавить к ней необходимые запчасти и детали?",
                    "Добавление деталей",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Открываем модальное окно запчастей, передавая Id только что сохраненной заявки
                    var partsForm = new RequestPartsForm(this._context, request.Id);
                    partsForm.ShowDialog();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}