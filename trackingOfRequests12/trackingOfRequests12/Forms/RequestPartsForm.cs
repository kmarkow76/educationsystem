using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using trackingOfRequests12.Models;

namespace trackingOfRequests12.Forms
{
    public partial class RequestPartsForm : Form
    {
        private tracking_of_requestsContext _context;
        private int _requestId;

        // Передаем контекст и ID заявки из родительской формы
        public RequestPartsForm(tracking_of_requestsContext context, int requestId)
        {
            InitializeComponent();
            _context = context;
            _requestId = requestId;
            this.Text = "Управление запчастями заявки";
        }

        private void RequestPartsForm_Load(object sender, EventArgs e)
        {
            LoadSparePartsCatalog();
            LoadCurrentRequestParts();
        }

        // Загрузка справочника доступных на складе запчастей
        private void LoadSparePartsCatalog()
        {
            cbSpareParts.DataSource = _context.SpareParts.Where(p => p.QuantityInStock > 0).ToList();
            cbSpareParts.DisplayMember = "Name";
            cbSpareParts.ValueMember = "Id";
            cbSpareParts.SelectedIndex = -1;
            nudQuantity.Value = 1;
        }

        // Вывод списка деталей, уже привязанных к этой заявке
        private void LoadCurrentRequestParts()
        {
            try
            {
                var data = _context.RequestParts
                    .Where(rp => rp.RequestId == _requestId)
                    .Select(rp => new
                    {
                        rp.Id,
                        Название = rp.Part.Name,
                        Цена = rp.Part.Price,
                        Количество = rp.Quantity,
                        Стоимость = rp.Part.Price * rp.Quantity
                    }).ToList();

                dgvParts.DataSource = data;

                if (dgvParts.Columns["Id"] != null)
                    dgvParts.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки деталей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Добавить деталь в заявку
        private void btnAddPart_Click(object sender, EventArgs e)
        {
            if (cbSpareParts.SelectedValue == null)
            {
                MessageBox.Show("Выберите деталь из списка.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int partId = (int)cbSpareParts.SelectedValue;
            int qty = (int)nudQuantity.Value;

            try
            {
                var part = _context.SpareParts.Find(partId);
                if (part == null || part.QuantityInStock < qty)
                {
                    MessageBox.Show($"Недостаточно деталей на складе! В наличии: {part?.QuantityInStock ?? 0}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем, добавлена ли уже эта деталь в заявку
                var existingLink = _context.RequestParts
                    .FirstOrDefault(rp => rp.RequestId == _requestId && rp.PartId == partId);

                if (existingLink != null)
                {
                    // Если добавлена — увеличиваем количество
                    existingLink.Quantity += qty;
                }
                else
                {
                    // Если нет — создаем новую запись связки
                    var newLink = new RequestPart
                    {
                        RequestId = _requestId,
                        PartId = partId,
                        Quantity = qty
                    };
                    _context.RequestParts.Add(newLink);
                }

                // Списываем со склада (QuantityInStock)
                part.QuantityInStock -= qty;

                _context.SaveChanges();
                LoadCurrentRequestParts();
                LoadSparePartsCatalog(); // Обновляем остатки в комбобоксе
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Удалить деталь из заявки
        private void btnDeletePart_Click(object sender, EventArgs e)
        {
            if (dgvParts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку с деталью для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int linkId = (int)dgvParts.SelectedRows[0].Cells["Id"].Value;

            try
            {
                var link = _context.RequestParts.Include(rp => rp.Part).FirstOrDefault(rp => rp.Id == linkId);
                if (link != null)
                {
                    // Возвращаем деталь обратно на склад
                    link.Part.QuantityInStock += link.Quantity;

                    _context.RequestParts.Remove(link);
                    _context.SaveChanges();

                    LoadCurrentRequestParts();
                    LoadSparePartsCatalog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}