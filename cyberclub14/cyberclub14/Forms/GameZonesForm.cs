using System;
using System.Linq;
using System.Windows.Forms;
using cyberclub14.Models;

namespace cyberclub14.Forms
{
    public partial class GameZonesForm : Form
    {
        private cyberclubContext _context = new cyberclubContext();

        public GameZonesForm()
        {
            InitializeComponent();
            this.Text = "Игровые зоны клуба";
        }

        private void GameZonesForm_Load(object sender, EventArgs e)
        {
            try
            {
                var data = _context.GameZones
                    .Select(gz => new
                    {
                        gz.Id,
                        НазваниеЗоны = gz.Name,
                        ОписаниеИнфраструктуры = gz.Description
                    }).ToList();

                dataGridView1.DataSource = data;

                if (dataGridView1.Columns["Id"] != null)
                    dataGridView1.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки зон: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}