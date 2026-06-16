using System;
using System.Linq;
using System.Windows.Forms;
using cyberclub14.Models;

namespace cyberclub14.Forms
{
    public partial class BarForm : Form
    {
        private cyberclubContext _context = new cyberclubContext();

        public BarForm()
        {
            InitializeComponent();
            this.Text = "Учет товаров бара";
        }

        private void BarForm_Load(object sender, EventArgs e)
        {
            try
            {
                var data = _context.BarProducts
                    .Select(bp => new
                    {
                        bp.Id,
                        Наименование = bp.Name,
                        Стоимость = bp.Price,
                        ОстатокНаСкладе = bp.QuantityInStock
                    }).ToList();

                dataGridView1.DataSource = data;

                if (dataGridView1.Columns["Id"] != null)
                    dataGridView1.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки товаров бара: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}