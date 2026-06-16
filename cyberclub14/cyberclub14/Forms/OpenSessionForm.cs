using System;
using System.Linq;
using System.Windows.Forms;
using cyberclub14.Models;

namespace cyberclub14.Forms
{
    public partial class OpenSessionForm : Form
    {
        private cyberclubContext _context = new cyberclubContext();
        private MainForm _parent;

        public OpenSessionForm(MainForm parent)
        {
            InitializeComponent();
            _parent = parent;
            this.Text = "Новая сессия";
        }

        private void OpenSessionForm_Load(object sender, EventArgs e)
        {
            // Загрузка участников клуба
            cbMembers.DataSource = _context.ClubMembers.ToList();
            cbMembers.DisplayMember = "Nickname";
            cbMembers.ValueMember = "Id";

            // ИСПРАВЛЕНО: Используем сравнение != true, которое EF Core легко переводит в SQL
            cbPlaces.DataSource = _context.GamingPlaces.Where(p => p.IsOccupied != true).ToList();
            cbPlaces.DisplayMember = "PlaceNumber";
            cbPlaces.ValueMember = "Id";

            // Загрузка тарифов
            cbTariffs.DataSource = _context.Tariffs.ToList();
            cbTariffs.DisplayMember = "Name";
            cbTariffs.ValueMember = "Id";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (cbMembers.SelectedValue == null || cbPlaces.SelectedValue == null || cbTariffs.SelectedValue == null)
            {
                MessageBox.Show("Заполните все обязательные поля формы.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int placeId = (int)cbPlaces.SelectedValue;

            try
            {
                // Проверка в реальном времени: занято ли место
                var place = _context.GamingPlaces.Find(placeId);

                // Тут метод Find уже вытащил объект в оперативную память C#, 
                // поэтому здесь GetValueOrDefault() или просто == true сработает отлично
                if (place != null && place.IsOccupied.GetValueOrDefault())
                {
                    MessageBox.Show(
                        "Этот компьютер или консоль уже заняты другим игроком!",
                        "Место занято",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var session = new GameSession
                {
                    MemberId = (int)cbMembers.SelectedValue,
                    PlaceId = placeId,
                    TariffId = (int)cbTariffs.SelectedValue,
                    StartTime = DateTime.Now,
                    Status = "Активна"
                };

                // Меняем статус занятости устройства в БД
                if (place != null) place.IsOccupied = true;

                _context.GameSessions.Add(session);
                _context.SaveChanges();

                // Обновляем сетку на главной форме без перезапуска
                _parent.LoadSessions();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании сессии: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}