using System;
using System.Linq;
using System.Windows.Forms;
using cyberclub14.Models;

namespace cyberclub14.Forms
{
    public partial class ClubMembersForm : Form
    {
        private cyberclubContext _context = new cyberclubContext();

        public ClubMembersForm()
        {
            InitializeComponent();
            this.Text = "Постоянные участники клуба";
        }

        private void ClubMembersForm_Load(object sender, EventArgs e)
        {
            try
            {
                var data = _context.ClubMembers
                    .Select(m => new
                    {
                        m.Id,
                        ИгровойНикнейм = m.Nickname,
                        ФИО = m.FullName,
                        НомерТелефона = m.Phone,
                        КлубнаяКарта = m.HasClubCard.GetValueOrDefault() ? "Есть (Скидка 10%)" : "Отсутствует"
                    }).ToList();

                dataGridView1.DataSource = data;

                if (dataGridView1.Columns["Id"] != null)
                    dataGridView1.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки участников: {ex.Message}", "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}