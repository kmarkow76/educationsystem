using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using komunalka11.Models; // Подключаем модели
using Microsoft.EntityFrameworkCore;

namespace komunalka11.Forms
{
    public partial class AccrualForm : Form
    {
        public AccrualForm()
        {
            InitializeComponent();
        }

        // При загрузке формы заполняем выпадающие списки данными из базы
        private void AccrualForm_Load(object sender, EventArgs e)
        {
            LoadDataToComboBoxes();
        }

        /// <summary>
        /// Комментарий: Логика первоначальной загрузки списков лицевых счетов и услуг из PostgreSQL
        /// </summary>
        private void LoadDataToComboBoxes()
        {
            try
            {
                using (var db = new komunalka_bd_11Context())
                {
                    // Загружаем лицевые счета с именами жильцов
                    var accounts = db.Accounts
                        .Include(a => a.Citizen)
                        .Select(a => new
                        {
                            Id = a.Id,
                            DisplayText = $"Л/С: {a.AccountNumber} - {a.Citizen.FullName}"
                        })
                        .ToList();

                    cmbAccounts.DataSource = accounts;
                    cmbAccounts.DisplayMember = "DisplayText";
                    cmbAccounts.ValueMember = "Id";

                    // Загружаем услуги
                    var services = db.Services
                        .Select(s => new
                        {
                            Id = s.Id,
                            DisplayText = $"{s.ServiceName} (Тариф: {s.Tariff} руб.)"
                        })
                        .ToList();

                    cmbServices.DataSource = services;
                    cmbServices.DisplayMember = "DisplayText";
                    cmbServices.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подготовке списков: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Рассчитать и Сохранить
        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Встроенная обработка ошибок ввода (Валидация)
            if (cmbAccounts.SelectedValue == null || cmbServices.SelectedValue == null)
            {
                MessageBox.Show("Необходимо выбрать лицевой счет и коммунальную услугу!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal previous = numPrevious.Value;
            decimal current = numCurrent.Value;

            if (current < previous)
            {
                MessageBox.Show("Текущие показания счетчика не могут быть меньше предыдущих!", "Некорректные показания", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Начинаем процесс расчета и сохранения
            try
            {
                int accountId = (int)cmbAccounts.SelectedValue;
                int serviceId = (int)cmbServices.SelectedValue;

                using (var db = new komunalka_bd_11Context())
                {
                    // Ищем выбранную услугу и счет с жильцом
                    var service = db.Services.Find(serviceId);
                    var account = db.Accounts.Include(a => a.Citizen).FirstOrDefault(a => a.Id == accountId);

                    if (service == null || account == null) return;

                    // Вызываем функцию расчета
                    CalculateBill(previous, current, service.Tariff, account.Citizen.HasPrivilege, out decimal baseAmount, out decimal discountAmount, out decimal penaltyAmount, out decimal finalAmount);

                    // 2. Сначала фиксируем показания приборов учета в БД
                    MeterReading newReading = new MeterReading
                    {
                        AccountId = accountId,
                        ServiceId = serviceId,
                        ReadingDate = DateTime.Today,
                        PreviousReading = previous,
                        CurrentReading = current
                        // Поле volume посчитается на стороне СУБД (GENERATED ALWAYS AS)
                    };
                    db.MeterReadings.Add(newReading);

                    // 3. Формируем запись начисления
                    Accrual newAccrual = new Accrual
                    {
                        AccountId = accountId,
                        ServiceId = serviceId,
                        AccrualDate = DateTime.Today,
                        BaseAmount = baseAmount,
                        DiscountAmount = discountAmount,
                        PenaltyAmount = penaltyAmount,
                        FinalAmount = finalAmount,
                        IsPaid = false // По умолчанию создается как неоплаченный долг
                    };
                    db.Accruals.Add(newAccrual);

                    db.SaveChanges(); // Сохраняем все в PostgreSQL одним махом

                    MessageBox.Show($"Начисление успешно создано!\n\nБазовая сумма: {baseAmount} руб.\nЛьготы/Скидки: {discountAmount} руб.\nПеня: {penaltyAmount}  руб.\nИтого к оплате: {finalAmount} руб.",
                                    "Расчет завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close(); // Закрываем форму после успешного сохранения
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения начисления: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Задание № 2: Функция расчета начислений, скидок и пени
        /// </summary>
        private void CalculateBill(decimal prev, decimal curr, decimal tariff, bool hasPrivilege, out decimal baseAmount, out decimal discountAmount, out decimal penaltyAmount, out decimal finalAmount)
        {
            // Объем потребления
            decimal volume = curr - prev;

            // Базовая сумма на основании тарифа и объема
            baseAmount = volume * tariff;

            decimal totalDiscountPercent = 0;

            // При наличии льготы жильца предоставляется скидка 25%
            if (hasPrivilege)
            {
                totalDiscountPercent += 25;
            }

            // При своевременной оплате начисляется скидка 5%
            if (chkOnTime.Checked)
            {
                totalDiscountPercent += 5;
            }

            // Считаем сумму скидки
            discountAmount = baseAmount * (totalDiscountPercent / 100);

            // При наличии задолженности более одного месяца начисляется пеня 10% от суммы долга
            penaltyAmount = 0;
            if (numDebtMonths.Value > 1)
            {
                penaltyAmount = baseAmount * 0.10m; // 10% от базовой суммы долга
            }

            // Итоговая сумма к оплате
            finalAmount = baseAmount - discountAmount + penaltyAmount;

            // Округляем для красоты
            baseAmount = Math.Round(baseAmount, 2);
            discountAmount = Math.Round(discountAmount, 2);
            penaltyAmount = Math.Round(penaltyAmount, 2);
            finalAmount = Math.Round(finalAmount, 2);
        }

        // Кнопка Отмена/Назад
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Оставляем пустые заглушки для дизайнера
        private void cmbAccounts_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbServices_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numPrevious_ValueChanged(object sender, EventArgs e) { }
        private void numCurrent_ValueChanged(object sender, EventArgs e) { }
        private void numDebtMonths_ValueChanged(object sender, EventArgs e) { }
    }
}