// AddRouteForm.cs
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
    public partial class AddRouteForm : Form
    {
        private routetrackingContext _context = new routetrackingContext();

        public AddRouteForm()
        {
            InitializeComponent();
            this.Text = "Добавление маршрута";
        }

        private void AddRouteForm_Load(object sender, EventArgs e)
        {
            nudPrice.DecimalPlaces = 2;
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
                // Сохраняем новый маршрут в БД
                var route = new Route
                {
                    RouteNumber = mtbNumberRoute.Text.Trim(),
                    StartPoint = tbStart.Text.Trim(),
                    EndPoint = tbEnd.Text.Trim(),
                    BasePrice = nudPrice.Value
                };

                _context.Routes.Add(route);
                _context.SaveChanges();

                MessageBox.Show("Маршрут успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}