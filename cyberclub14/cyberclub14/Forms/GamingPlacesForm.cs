using System;
using System.Linq;
using System.Windows.Forms;
using cyberclub14.Models;

namespace cyberclub14.Forms
{
    public partial class GamingPlacesForm : Form
    {
        private cyberclubContext _context = new cyberclubContext();

        public GamingPlacesForm()
        {
            InitializeComponent();
            this.Text = "Состояние игровых мест (ПК и Консоли)";
        }

        private void GamingPlacesForm_Load(object sender, EventArgs e)
        {
            try
            {
                var data = _context.GamingPlaces
                    .Select(gp => new
                    {
                        gp.Id,
                        НомерМеста = gp.PlaceNumber,
                        ИгроваяЗона = gp.Zone.Name,
                        СпецификацияЖелеза = gp.HardwareSpec,
                        СтатусЗанятости = gp.IsOccupied.GetValueOrDefault() ? "Занято" : "Свободно"
                    }).ToList();

                dataGridView1.DataSource = data;

                if (dataGridView1.Columns["Id"] != null)
                    dataGridView1.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка мест: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}