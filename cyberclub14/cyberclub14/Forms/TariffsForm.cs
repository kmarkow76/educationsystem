using System;
using System.Linq;
using System.Windows.Forms;
using cyberclub14.Models;

namespace cyberclub14.Forms
{
    public partial class TariffsForm : Form
    {
        private cyberclubContext _context = new cyberclubContext();

        public TariffsForm()
        {
            InitializeComponent();
            this.Text = "Справочник тарифов клуба";
        }

        private void TariffsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var data = _context.Tariffs
                    .Select(t => new
                    {
                        t.Id,
                        НазваниеТарифа = t.Name,
                        ЦенаЗаЧас = t.PricePerHour,
                        НочнойПакет = t.IsNightPackage.GetValueOrDefault() ? "Да (Фикс. скидка 40%)" : "Нет"
                    }).ToList();

                dataGridView1.DataSource = data;

                if (dataGridView1.Columns["Id"] != null)
                    dataGridView1.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки тарифов: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}