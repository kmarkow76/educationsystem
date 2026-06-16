using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using cyberclub14.Models;

namespace cyberclub14.Forms
{
    public partial class MainForm : Form
    {
        // Инициализируем контекст базы данных для киберспортивного клуба
        private cyberclubContext _context = new cyberclubContext();

        // Флаг для переключения режима: true - смотрим историю, false - только активные
        private bool _showHistory = false;

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Управление киберклубом — Сессии";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSessions();
        }

        /// <summary>
        /// Метод загрузки данных в DataGridView с автоматическим расчетом по ТЗ
        /// </summary>
        public void LoadSessions()
        {
            try
            {
                // Формируем базовый LINQ-запрос с подгрузкой связанных таблиц через точки
                var query = _context.GameSessions.AsQueryable();

                if (_showHistory)
                {
                    // Показываем завершенные сессии
                    query = query.Where(s => s.Status == "Завершена");
                    this.Text = "Архив завершенных игровых сессий";
                }
                else
                {
                    // Показываем только активные или на паузе
                    query = query.Where(s => s.Status == "Активна" || s.Status == "Пауза");
                    this.Text = "Мониторинг активных мест";
                }

                // Проектируем данные в красивый плоский вид для оператора
                var data = query.Select(s => new
                {
                    s.Id,
                    Никнейм = s.Member.Nickname,
                    НомерПК = s.Place.PlaceNumber,
                    Тариф = s.Tariff.Name,
                    Старт = s.StartTime.ToString("dd.MM HH:mm"),
                    Конец = s.EndTime.HasValue ? s.EndTime.Value.ToString("dd.MM HH:mm") : "В игре",
                    База = s.BasePrice,
                    Скидка = s.DiscountPercent + "%",
                    Итого = s.TotalPrice,
                    Статус = s.Status
                }).ToList();

                dataGridView1.DataSource = data;

                // Скрываем первичный ключ Id сессии
                if (dataGridView1.Columns["Id"] != null)
                    dataGridView1.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выводе списка сессий: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // КНОПКА: Открыть новую сессию (Добавление)
        private void btnOpenSession_Click(object sender, EventArgs e)
        {
            // Передаем ссылку на текущую форму (this), чтобы дочернее окно могло вызвать LoadSessions()
            var openForm = new OpenSessionForm(this);
            openForm.ShowDialog();
        }

        // КНОПКА: Завершить сессию (Расчет стоимости и освобождение ПК)
        private void btnCloseSession_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите активную сессию для закрытия.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sessionId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

            // Открываем форму закрытия сессии, куда передаем ID
            var closeForm = new CloseSessionForm(this, sessionId);
            closeForm.ShowDialog();
        }

        // КНОПКА: Редактировать сессию
        private void btnEditSession_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите сессию для изменения.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sessionId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

            var editForm = new EditSessionForm(this, sessionId);
            editForm.ShowDialog();
        }

        // КНОПКА: Удалить сессию (С каскадным освобождением места при необходимости)
        private void btnDeleteSession_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите запись для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите безвозвратно удалить сессию?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            int sessionId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

            try
            {
                var session = _context.GameSessions.Include(s => s.Place).FirstOrDefault(s => s.Id == sessionId);
                if (session != null)
                {
                    // Если удаляется живая активная сессия — делаем компьютер снова свободным
                    if (session.Status == "Активна" && session.Place != null)
                    {
                        session.Place.IsOccupied = false;
                    }

                    _context.GameSessions.Remove(session);
                    _context.SaveChanges();

                    LoadSessions(); // Мгновенно обновляем интерфейс
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось удалить запись: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // КНОПКА: Переключение между Историей и Активными сессиями
        private void btnHistorySession_Click(object sender, EventArgs e)
        {
            _showHistory = !_showHistory; // Инвертируем флаг

            // Меняем текст на кнопке для наглядности UI
            btnHistorySession.Text = _showHistory ? "Показать активные" : "История сессий";

            LoadSessions();
        }

        // =========================================================================
        // НАВИГАЦИЯ ПО ОСТАЛЬНЫМ КНОПКАМ УПРАВЛЕНИЯ СПРАВОЧНИКАМИ КЛУБА
        // =========================================================================

        private void btnClubMembers_Click(object sender, EventArgs e)
        {
            var membersForm = new ClubMembersForm();
            membersForm.ShowDialog();
        }

        private void btnViewTariff_Click(object sender, EventArgs e)
        {
            var tariffsForm = new TariffsForm();
            tariffsForm.ShowDialog();
        }

        private void btnViewPlaces_Click(object sender, EventArgs e)
        {
            var placesForm = new GamingPlacesForm();
            placesForm.ShowDialog();
        }

        private void btnViewZone_Click(object sender, EventArgs e)
        {
            var zonesForm = new GameZonesForm();
            zonesForm.ShowDialog();
        }

        private void btnViewBar_Click(object sender, EventArgs e)
        {
            var barForm = new BarForm();
            barForm.ShowDialog();
        }
    }
}