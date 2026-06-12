using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using educsys.Models;

namespace educsys.Forms
{
    public partial class TeachersForm : Form
    {
        private educContext _context;

        public TeachersForm()
        {
            InitializeComponent();
            this.Text = "Список преподавателей";
        }

        // Вместо Load используем Shown — это решает проблему пустой сетки при открытии
        private void TeachersForm_Load(object sender, EventArgs e)
        {
            AutoRefreshTeachers();
        }

        public void AutoRefreshTeachers()
        {
            try
            {
                // 1. Принудительно пересоздаем контекст, чтобы очистить кэш EF Core
                _context?.Dispose();
                _context = new educContext();

                //// 2. Сбрасываем старый источник данных таблицы
                //dataGridView1.DataSource = null;
                //dataGridView1.AutoGenerateColumns = true;

                // 3. Загружаем свежие данные из базы PostgreSQL
                var data = _context.Teachers
                    .Select(s => new
                    {
                        s.Id,
                        ФИО = s.FullName,
                        Предмет = s.Subject
                    })
                    .ToList();

                // 4. Привязываем данные к таблице
                dataGridView1.DataSource = data;

                // 5. Безопасно скрываем колонку Id по индексу
                if (dataGridView1.Columns.Count > 0)
                    dataGridView1.Columns[0].Visible = false;

                // 6. Форсируем мгновенную отрисовку интерфейса
                dataGridView1.Invalidate();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка автоматической загрузки: {ex.Message}");
            }
        }

        // Кнопку «Обновить» можно оставить как ручной вариант, она просто вызывает тот же метод
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AutoRefreshTeachers();
        }

    }
}