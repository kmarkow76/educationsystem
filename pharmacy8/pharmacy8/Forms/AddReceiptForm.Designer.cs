
namespace pharmacy8.Forms
{
    partial class AddReceiptForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ghtgf = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.mtbDate = new System.Windows.Forms.MaskedTextBox();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.cbSuppler = new System.Windows.Forms.ComboBox();
            this.cbDrug = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Дата поступления:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Цена:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Количество:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Поставщик:";
            // 
            // Ghtgf
            // 
            this.Ghtgf.AutoSize = true;
            this.Ghtgf.Location = new System.Drawing.Point(67, 22);
            this.Ghtgf.Name = "Ghtgf";
            this.Ghtgf.Size = new System.Drawing.Size(80, 20);
            this.Ghtgf.TabIndex = 17;
            this.Ghtgf.Text = "Препарат:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(48, 223);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(312, 29);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Сохранить поступление";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // mtbDate
            // 
            this.mtbDate.Location = new System.Drawing.Point(156, 170);
            this.mtbDate.Mask = "00/00/0000";
            this.mtbDate.Name = "mtbDate";
            this.mtbDate.Size = new System.Drawing.Size(204, 27);
            this.mtbDate.TabIndex = 15;
            this.mtbDate.ValidatingType = typeof(System.DateTime);
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(156, 136);
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(204, 27);
            this.nudPrice.TabIndex = 14;
            // 
            // nudCount
            // 
            this.nudCount.Location = new System.Drawing.Point(156, 93);
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(204, 27);
            this.nudCount.TabIndex = 13;
            // 
            // cbSuppler
            // 
            this.cbSuppler.FormattingEnabled = true;
            this.cbSuppler.Location = new System.Drawing.Point(155, 53);
            this.cbSuppler.Name = "cbSuppler";
            this.cbSuppler.Size = new System.Drawing.Size(205, 28);
            this.cbSuppler.TabIndex = 12;
            // 
            // cbDrug
            // 
            this.cbDrug.FormattingEnabled = true;
            this.cbDrug.Location = new System.Drawing.Point(155, 19);
            this.cbDrug.Name = "cbDrug";
            this.cbDrug.Size = new System.Drawing.Size(205, 28);
            this.cbDrug.TabIndex = 11;
            // 
            // AddReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 295);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ghtgf);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.mtbDate);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.nudCount);
            this.Controls.Add(this.cbSuppler);
            this.Controls.Add(this.cbDrug);
            this.Name = "AddReceiptForm";
            this.Text = "AddReceiptForm";
            this.Load += new System.EventHandler(this.AddReceiptForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Ghtgf;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.MaskedTextBox mtbDate;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.NumericUpDown nudCount;
        private System.Windows.Forms.ComboBox cbSuppler;
        private System.Windows.Forms.ComboBox cbDrug;
    }
}