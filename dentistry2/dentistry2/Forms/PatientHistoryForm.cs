using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using dentistry2.Models;

namespace dentistry.Forms
{
    public partial class PatientHistoryForm : Form
    {
        private dentistry2Context _context = new dentistry2Context();
        private readonly int _patientId;

        public PatientHistoryForm(int patientId)
        {
            InitializeComponent();
            this.Text = "Просмотр истории посещений"; // Изменено под новое ТЗ
            _patientId = patientId;
        }

        private void PatientHistoryForm_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }

        public void LoadHistory()
        {
            // Комментарий по ТЗ: Загрузка истории приёмов и диагнозов напрямую из таблицы приёмов
            var historyData = _context.Appointments
                .Where(a => a.PatientId == _patientId)
                .Select(a => new
                {
                    a.Id,
                    ДатаПриема = a.Date,
                    Врач = a.Doctor.Fio,
                    Диагноз_И_Описание = a.Description
                })
                .OrderByDescending(o => o.ДатаПриема)
                .ToList();

            dataGridView1.DataSource = historyData;

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }
    }
}
