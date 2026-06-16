
namespace trackingOfRequests12.Forms
{
    partial class EditRequestForm
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
            this.tbWorkList = new System.Windows.Forms.TextBox();
            this.tbFaultDescription = new System.Windows.Forms.TextBox();
            this.nudBasePrice = new System.Windows.Forms.NumericUpDown();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.cbDevice = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chbIsUrgent = new System.Windows.Forms.CheckBox();
            this.mtbCreated = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnManageParts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudBasePrice)).BeginInit();
            this.SuspendLayout();
            // 
            // tbWorkList
            // 
            this.tbWorkList.Location = new System.Drawing.Point(255, 170);
            this.tbWorkList.Multiline = true;
            this.tbWorkList.Name = "tbWorkList";
            this.tbWorkList.Size = new System.Drawing.Size(206, 27);
            this.tbWorkList.TabIndex = 36;
            // 
            // tbFaultDescription
            // 
            this.tbFaultDescription.Location = new System.Drawing.Point(255, 131);
            this.tbFaultDescription.Multiline = true;
            this.tbFaultDescription.Name = "tbFaultDescription";
            this.tbFaultDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbFaultDescription.Size = new System.Drawing.Size(206, 34);
            this.tbFaultDescription.TabIndex = 35;
            // 
            // nudBasePrice
            // 
            this.nudBasePrice.DecimalPlaces = 2;
            this.nudBasePrice.Location = new System.Drawing.Point(255, 206);
            this.nudBasePrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudBasePrice.Name = "nudBasePrice";
            this.nudBasePrice.Size = new System.Drawing.Size(206, 27);
            this.nudBasePrice.TabIndex = 34;
            // 
            // cbClient
            // 
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(255, 22);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(206, 28);
            this.cbClient.TabIndex = 33;
            // 
            // cbEmployee
            // 
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(255, 93);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(206, 28);
            this.cbEmployee.TabIndex = 32;
            // 
            // cbDevice
            // 
            this.cbDevice.FormattingEnabled = true;
            this.cbDevice.Location = new System.Drawing.Point(254, 59);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(207, 28);
            this.cbDevice.TabIndex = 31;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(255, 272);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(206, 28);
            this.cbStatus.TabIndex = 30;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(153, 394);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(308, 29);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Сохранить заявку";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chbIsUrgent
            // 
            this.chbIsUrgent.AutoSize = true;
            this.chbIsUrgent.Location = new System.Drawing.Point(255, 239);
            this.chbIsUrgent.Name = "chbIsUrgent";
            this.chbIsUrgent.Size = new System.Drawing.Size(160, 24);
            this.chbIsUrgent.TabIndex = 28;
            this.chbIsUrgent.Text = "Срочный заказ      ";
            this.chbIsUrgent.UseVisualStyleBackColor = true;
            // 
            // mtbCreated
            // 
            this.mtbCreated.Location = new System.Drawing.Point(255, 306);
            this.mtbCreated.Mask = "00/00/0000";
            this.mtbCreated.Name = "mtbCreated";
            this.mtbCreated.Size = new System.Drawing.Size(206, 27);
            this.mtbCreated.TabIndex = 27;
            this.mtbCreated.ValidatingType = typeof(System.DateTime);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(125, 309);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 20);
            this.label9.TabIndex = 26;
            this.label9.Text = "Дата создания:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Статус:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Цена:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(101, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Перечень работы:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Описание неисправностей:";
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(153, 96);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(85, 20);
            this.Label.TabIndex = 21;
            this.Label.Text = "Сотрудник:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Техника:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Клиент:";
            // 
            // btnManageParts
            // 
            this.btnManageParts.Location = new System.Drawing.Point(153, 349);
            this.btnManageParts.Name = "btnManageParts";
            this.btnManageParts.Size = new System.Drawing.Size(308, 29);
            this.btnManageParts.TabIndex = 37;
            this.btnManageParts.Text = "Выбрать дополнительные детали";
            this.btnManageParts.UseVisualStyleBackColor = true;
            this.btnManageParts.Click += new System.EventHandler(this.btnManageParts_Click);
            // 
            // EditRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 455);
            this.Controls.Add(this.btnManageParts);
            this.Controls.Add(this.tbWorkList);
            this.Controls.Add(this.tbFaultDescription);
            this.Controls.Add(this.nudBasePrice);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.cbEmployee);
            this.Controls.Add(this.cbDevice);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chbIsUrgent);
            this.Controls.Add(this.mtbCreated);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditRequestForm";
            this.Text = "EditRequestForm";
            this.Load += new System.EventHandler(this.EditRequestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudBasePrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbWorkList;
        private System.Windows.Forms.TextBox tbFaultDescription;
        private System.Windows.Forms.NumericUpDown nudBasePrice;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.ComboBox cbDevice;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chbIsUrgent;
        private System.Windows.Forms.MaskedTextBox mtbCreated;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManageParts;
    }
}