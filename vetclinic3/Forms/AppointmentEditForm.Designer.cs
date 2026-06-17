
namespace vetclinic3.Forms
{
    partial class AppointmentEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbAnimal = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbVet = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDiagnosis = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTreatment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numServicesCost = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numMedsCost = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numServicesCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMedsCost)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пациент (Владелец):";
            // 
            // cbAnimal
            // 
            this.cbAnimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnimal.FormattingEnabled = true;
            this.cbAnimal.Location = new System.Drawing.Point(217, 33);
            this.cbAnimal.Name = "cbAnimal";
            this.cbAnimal.Size = new System.Drawing.Size(302, 28);
            this.cbAnimal.TabIndex = 1;
            this.cbAnimal.SelectedIndexChanged += new System.EventHandler(this.cbAnimal_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Назначаемый врач:";
            // 
            // cbVet
            // 
            this.cbVet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVet.FormattingEnabled = true;
            this.cbVet.Location = new System.Drawing.Point(217, 92);
            this.cbVet.Name = "cbVet";
            this.cbVet.Size = new System.Drawing.Size(302, 28);
            this.cbVet.TabIndex = 3;
            this.cbVet.SelectedIndexChanged += new System.EventHandler(this.cbVet_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата и время приема:";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(217, 152);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(302, 27);
            this.dtpDate.TabIndex = 5;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Диагноз / Первичные симптомы:";
            // 
            // tbDiagnosis
            // 
            this.tbDiagnosis.Location = new System.Drawing.Point(291, 215);
            this.tbDiagnosis.Multiline = true;
            this.tbDiagnosis.Name = "tbDiagnosis";
            this.tbDiagnosis.Size = new System.Drawing.Size(228, 34);
            this.tbDiagnosis.TabIndex = 7;
            this.tbDiagnosis.TextChanged += new System.EventHandler(this.tbDiagnosis_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Назначенное лечение / Процедуры:";
            // 
            // tbTreatment
            // 
            this.tbTreatment.Location = new System.Drawing.Point(291, 288);
            this.tbTreatment.Multiline = true;
            this.tbTreatment.Name = "tbTreatment";
            this.tbTreatment.Size = new System.Drawing.Size(228, 34);
            this.tbTreatment.TabIndex = 9;
            this.tbTreatment.TextChanged += new System.EventHandler(this.tbTreatment_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Стоимость услуг клиники (руб.):";
            // 
            // numServicesCost
            // 
            this.numServicesCost.DecimalPlaces = 2;
            this.numServicesCost.Location = new System.Drawing.Point(291, 354);
            this.numServicesCost.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numServicesCost.Name = "numServicesCost";
            this.numServicesCost.Size = new System.Drawing.Size(228, 27);
            this.numServicesCost.TabIndex = 11;
            this.numServicesCost.ValueChanged += new System.EventHandler(this.numServicesCost_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 421);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Стоимость медикаментов (руб.):";
            // 
            // numMedsCost
            // 
            this.numMedsCost.DecimalPlaces = 2;
            this.numMedsCost.Location = new System.Drawing.Point(291, 421);
            this.numMedsCost.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numMedsCost.Name = "numMedsCost";
            this.numMedsCost.Size = new System.Drawing.Size(228, 27);
            this.numMedsCost.TabIndex = 13;
            this.numMedsCost.ValueChanged += new System.EventHandler(this.numMedsCost_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 491);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Текущий статус приема:";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Запланирован",
            "Проведен",
            "Отменен"});
            this.cbStatus.Location = new System.Drawing.Point(291, 491);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(228, 28);
            this.cbStatus.TabIndex = 15;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 553);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(189, 29);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Сохранить запись";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(229, 553);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AppointmentEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 607);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numMedsCost);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numServicesCost);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbTreatment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDiagnosis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbVet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbAnimal);
            this.Controls.Add(this.label1);
            this.Name = "AppointmentEditForm";
            this.Text = "AppointmentEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.numServicesCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMedsCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAnimal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbVet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDiagnosis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTreatment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numServicesCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numMedsCost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}