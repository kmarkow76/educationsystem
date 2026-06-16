using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using komunalka11.Models; // Подключаем папку с нашими сгенерированными моделями
using Microsoft.EntityFrameworkCore;

namespace komunalka11.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Событие загрузки формы — здесь мы будем заполнять таблицу
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadAccrualsData();
        }

        /// <summary>
        /// Метод для загрузки и отображения детального списка начислений
        /// </summary>
        public void LoadAccrualsData()
        {
            try
            {
                // Инициализируем контекст БД (Обязательно оберни в using, чтобы не забивать память)
                using (var db = new komunalka_bd_11Context())
                {
                    // Делаем LINQ-запрос, вытягивая данные из связанных таблиц через Navigation Properties
                    var data = db.Accruals
                        .Include(a => a.Account)
                            .ThenInclude(acc => acc.Citizen)
                        .Include(a => a.Service)
                        .Select(a => new
                        {
                            Id = a.Id,
                            CitizenName = a.Account.Citizen.FullName,
                            AccountNumber = a.Account.AccountNumber,
                            ServiceName = a.Service.ServiceName,
                            // Объем ищем в таблице показаний для этого счета и услуги на дату начисления
                            Volume = db.MeterReadings
                                .Where(m => m.AccountId == a.AccountId && m.ServiceId == a.ServiceId && m.ReadingDate.Month == a.AccrualDate.Month)
                                .Select(m => (decimal?)m.Volume)
                                .FirstOrDefault() ?? 0,
                            Tariff = a.Service.Tariff,
                            BaseAmount = a.BaseAmount,
                            Discount = a.DiscountAmount,
                            Penalty = a.PenaltyAmount,
                            FinalAmount = a.FinalAmount,
                            Status = a.IsPaid ? "Оплачено" : "Задолженность"
                        })
                        .ToList();

                    // Привязываем результат к нашей сетке DataGridView
                    dgvMainAccruals.DataSource = data;

                    // Настраиваем красивые заголовки колонок на русском языке
                    dgvMainAccruals.Columns["Id"].Visible = false; // Прячем ID от пользователя
                    dgvMainAccruals.Columns["CitizenName"].HeaderText = "ФИО жильца";
                    dgvMainAccruals.Columns["AccountNumber"].HeaderText = "Л/Счет";
                    dgvMainAccruals.Columns["ServiceName"].HeaderText = "Услуга";
                    dgvMainAccruals.Columns["Volume"].HeaderText = "Объем";
                    dgvMainAccruals.Columns["Tariff"].HeaderText = "Тариф";
                    dgvMainAccruals.Columns["BaseAmount"].HeaderText = "Начислено";
                    dgvMainAccruals.Columns["Discount"].HeaderText = "Льгота (руб.)";
                    dgvMainAccruals.Columns["Penalty"].HeaderText = "Пеня (руб.)";
                    dgvMainAccruals.Columns["FinalAmount"].HeaderText = "Итого к оплате";
                    dgvMainAccruals.Columns["Status"].HeaderText = "Статус";

                    // Автоматическое распределение ширины столбцов по экрану
                    dgvMainAccruals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenCitizens_Click(object sender, EventArgs e)
        {
            // Открываем окно управления жильцами как диалоговое
            CitizensForm citizensForm = new CitizensForm();
            citizensForm.ShowDialog();

            // Когда окно закроется, обновляем главную таблицу, так как данные могли измениться
            LoadAccrualsData();
        }

        private void btnAddAccrual_Click(object sender, EventArgs e)
        {
            // Открываем окно создания нового начисления
            AccrualForm accrualForm = new AccrualForm();
            accrualForm.ShowDialog();

            // Обновляем главную таблицу, чтобы сразу увидеть новое начисление без перезапуска
            LoadAccrualsData();
        }

        private void btnMakePayment_Click(object sender, EventArgs e)
        {
            // 1. Проверяем, выбрана ли строка в нашей главной таблице dgvMainAccruals
            if (dgvMainAccruals.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите начисление из списка для проведения оплаты!",
                                "Строка не выбрана", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Используем динамический тип (dynamic), так как в DataSource лежит анонимный LINQ-тип
                dynamic selectedRow = dgvMainAccruals.CurrentRow.DataBoundItem;
                int accrualId = selectedRow.Id;
                string status = selectedRow.Status;

                // 2. Проверяем, не оплачен ли этот счет уже
                if (status == "Оплачено")
                {
                    MessageBox.Show("Это начисление уже полностью оплачено!",
                                    "Повторная оплата", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Подтверждение оплаты у пользователя
                DialogResult result = MessageBox.Show($"Вы действительно хотите внести оплату в размере {selectedRow.FinalAmount} руб. для счета {selectedRow.AccountNumber} ({selectedRow.CitizenName})?",
                                                      "Подтверждение платежа", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var db = new komunalka_bd_11Context())
                    {
                        // Находим наше начисление в базе данных по ID
                        var accrual = db.Accruals.Find(accrualId);
                        if (accrual != null)
                        {
                            // Меняем статус начисления на "Оплачено"
                            accrual.IsPaid = true;

                            // Создаем новую запись в истории платежей (таблица payments)
                            Payment newPayment = new Payment
                            {
                                AccrualId = accrualId,
                                PaymentDate = DateTime.Today,
                                AmountPaid = accrual.FinalAmount // Оплачиваем полную итоговую сумму
                            };
                            db.Payments.Add(newPayment);

                            // Сохраняем все изменения в PostgreSQL
                            db.SaveChanges();

                            MessageBox.Show("Оплата успешно проведена и внесена в историю платежей!",
                                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 3. Обновляем главную таблицу в реальном времени без перезапуска приложения
                            LoadAccrualsData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проведении платежа: {ex.Message}",
                                "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void dgvMainAccruals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        
    }
}