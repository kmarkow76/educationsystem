
namespace komunalka11.Forms
{
    partial class AccrualForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAccounts = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbServices = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numPrevious = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numCurrent = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numDebtMonths = new System.Windows.Forms.NumericUpDown();
            this.chkOnTime = new System.Windows.Forms.CheckBox();
            this.btnSaveAccrual = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDebtMonths)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Начисление платежей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Выберите лицевой счет:";
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccounts.FormattingEnabled = true;
            this.cmbAccounts.Location = new System.Drawing.Point(224, 77);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.Size = new System.Drawing.Size(384, 28);
            this.cmbAccounts.TabIndex = 2;
            this.cmbAccounts.SelectedIndexChanged += new System.EventHandler(this.cmbAccounts_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Выберите коммунальную услугу:";
            // 
            // cmbServices
            // 
            this.cmbServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServices.FormattingEnabled = true;
            this.cmbServices.Location = new System.Drawing.Point(276, 135);
            this.cmbServices.Name = "cmbServices";
            this.cmbServices.Size = new System.Drawing.Size(332, 28);
            this.cmbServices.TabIndex = 4;
            this.cmbServices.SelectedIndexChanged += new System.EventHandler(this.cmbServices_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Предыдущее показание счетчика:";
            // 
            // numPrevious
            // 
            this.numPrevious.Location = new System.Drawing.Point(276, 194);
            this.numPrevious.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPrevious.Name = "numPrevious";
            this.numPrevious.Size = new System.Drawing.Size(255, 27);
            this.numPrevious.TabIndex = 6;
            this.numPrevious.ValueChanged += new System.EventHandler(this.numPrevious_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Текущее показание счетчика:";
            // 
            // numCurrent
            // 
            this.numCurrent.Location = new System.Drawing.Point(276, 250);
            this.numCurrent.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numCurrent.Name = "numCurrent";
            this.numCurrent.Size = new System.Drawing.Size(255, 27);
            this.numCurrent.TabIndex = 8;
            this.numCurrent.ValueChanged += new System.EventHandler(this.numCurrent_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(345, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Количество месяцев задолженности (для пени):";
            // 
            // numDebtMonths
            // 
            this.numDebtMonths.Location = new System.Drawing.Point(381, 303);
            this.numDebtMonths.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numDebtMonths.Name = "numDebtMonths";
            this.numDebtMonths.Size = new System.Drawing.Size(150, 27);
            this.numDebtMonths.TabIndex = 10;
            this.numDebtMonths.ValueChanged += new System.EventHandler(this.numDebtMonths_ValueChanged);
            // 
            // chkOnTime
            // 
            this.chkOnTime.AutoSize = true;
            this.chkOnTime.Location = new System.Drawing.Point(12, 347);
            this.chkOnTime.Name = "chkOnTime";
            this.chkOnTime.Size = new System.Drawing.Size(279, 24);
            this.chkOnTime.TabIndex = 11;
            this.chkOnTime.Text = "Своевременная оплата (скидка 5%)";
            this.chkOnTime.UseVisualStyleBackColor = true;
            // 
            // btnSaveAccrual
            // 
            this.btnSaveAccrual.Location = new System.Drawing.Point(12, 408);
            this.btnSaveAccrual.Name = "btnSaveAccrual";
            this.btnSaveAccrual.Size = new System.Drawing.Size(373, 29);
            this.btnSaveAccrual.TabIndex = 12;
            this.btnSaveAccrual.Text = "Рассчитать и сохранить начисление";
            this.btnSaveAccrual.UseVisualStyleBackColor = true;
            this.btnSaveAccrual.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(417, 408);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AccrualForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveAccrual);
            this.Controls.Add(this.chkOnTime);
            this.Controls.Add(this.numDebtMonths);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numCurrent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numPrevious);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbServices);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAccounts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AccrualForm";
            this.Text = "AccrualForm";
            this.Load += new System.EventHandler(this.AccrualForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDebtMonths)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAccounts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbServices;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPrevious;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numCurrent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numDebtMonths;
        private System.Windows.Forms.CheckBox chkOnTime;
        private System.Windows.Forms.Button btnSaveAccrual;
        private System.Windows.Forms.Button btnCancel;
    }
}