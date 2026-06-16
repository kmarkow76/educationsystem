// EditRouteForm.cs
using routetracking10.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace routetracking10.Forms
{
    public partial class EditRouteForm : Form
    {
        private routetrackingContext _context = new routetrackingContext();
        private readonly int _routeId;

        public EditRouteForm(int routeId)
        {
            InitializeComponent();
            this.Text = "Редактирование маршрута";
            _routeId = routeId;
        }

        private void EditRouteForm_Load(object sender, EventArgs e)
        {
            var route = _context.Routes.Find(_routeId);

            if (route == null)
            {
                MessageBox.Show("Маршрут не найден в системе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Загружаем данные маршрута в поля формы
            mtbNumberRoute.Text = route.RouteNumber;
            tbStart.Text = route.StartPoint;
            tbEnd.Text = route.EndPoint;
            nudPrice.Value = route.BasePrice;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация номера маршрута
            if (string.IsNullOrWhiteSpace(mtbNumberRoute.Text.Trim('_', ' ')))
            {
                MessageBox.Show("Введите номер маршрута.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbNumberRoute.Focus();
                return;
            }

            // Валидация начального пункта
            if (string.IsNullOrWhiteSpace(tbStart.Text))
            {
                MessageBox.Show("Введите начальный пункт маршрута.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbStart.Focus();
                return;
            }

            // Валидация конечного пункта
            if (string.IsNullOrWhiteSpace(tbEnd.Text))
            {
                MessageBox.Show("Введите конечный пункт маршрута.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbEnd.Focus();
                return;
            }

            // Валидация цены
            if (nudPrice.Value <= 0)
            {
                MessageBox.Show("Стоимость проезда должна быть больше нуля.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudPrice.Focus();
                return;
            }

            try
            {
                var route = _context.Routes.Find(_routeId);

                if (route != null)
                {
                    // Обновляем данные маршрута
                    route.RouteNumber = mtbNumberRoute.Text.Trim();
                    route.StartPoint = tbStart.Text.Trim();
                    route.EndPoint = tbEnd.Text.Trim();
                    route.BasePrice = nudPrice.Value;

                    _context.SaveChanges();

                    MessageBox.Show("Маршрут успешно обновлён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}