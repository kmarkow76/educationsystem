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
    public partial class EditRequestForm : Form
    {
        public tracking_of_requestsContext _context = new tracking_of_requestsContext();
        private int _requestId;

        public EditRequestForm(int requestId)
        {
            InitializeComponent();
            this.Text = "Редактирование заявки";
            _requestId = requestId;
        }

        private void EditRequestForm_Load(object sender, EventArgs e)
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

            var request = _context.RepairRequests.Find(_requestId);
            if (request == null)
            {
                MessageBox.Show("Заявка не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            cbClient.SelectedValue = request.ClientId;
            cbDevice.SelectedValue = request.DeviceId;
            cbEmployee.SelectedValue = request.EmployeeId;
            cbStatus.SelectedItem = request.Status;
            tbFaultDescription.Text = request.FaultDescription;
            tbWorkList.Text = request.WorkList;
            nudBasePrice.Value = request.BaseWorkPrice;
            chbIsUrgent.Checked = request.IsUrgent;
            mtbCreated.Text = request.CreatedDate.ToString("dd.MM.yyyy");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbClient.SelectedValue == null || cbDevice.SelectedValue == null || cbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите клиента, технику и сотрудника.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbFaultDescription.Text))
            {
                MessageBox.Show("Введите описание неисправности.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbWorkList.Text))
            {
                MessageBox.Show("Введите перечень работ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParseExact(mtbCreated.Text, "dd.MM.yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime createdDate))
            {
                MessageBox.Show("Введите корректную дату.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var request = _context.RepairRequests.Find(_requestId);
                if (request == null)
                {
                    MessageBox.Show("Заявка не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                request.ClientId = (int)cbClient.SelectedValue;
                request.DeviceId = (int)cbDevice.SelectedValue;
                request.EmployeeId = (int)cbEmployee.SelectedValue;
                request.FaultDescription = tbFaultDescription.Text.Trim();
                request.WorkList = tbWorkList.Text.Trim();
                request.BaseWorkPrice = nudBasePrice.Value;
                request.IsUrgent = chbIsUrgent.Checked;
                request.Status = cbStatus.SelectedItem.ToString();
                request.CreatedDate = createdDate;

                _context.SaveChanges();

                MessageBox.Show("Заявка успешно обновлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageParts_Click(object sender, EventArgs e)
        {
            // Открываем созданное нами окно, передавая туда общий контекст и ID текущей редактируемой заявки
            var partsForm = new RequestPartsForm(this._context, this._requestId);
            partsForm.ShowDialog();

            // После закрытия окна управления запчастями — итоговая сумма на главной форме пересчитается автоматически!
        }
    }
}