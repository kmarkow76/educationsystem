
namespace pharmacy8.Forms
{
    partial class AddSalesForm
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
            this.cbDrug = new System.Windows.Forms.ComboBox();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.mtbSaleDate = new System.Windows.Forms.MaskedTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.Ghtgf = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDrug
            // 
            this.cbDrug.FormattingEnabled = true;
            this.cbDrug.Location = new System.Drawing.Point(148, 18);
            this.cbDrug.Name = "cbDrug";
            this.cbDrug.Size = new System.Drawing.Size(205, 28);
            this.cbDrug.TabIndex = 0;
            // 
            // cbCustomer
            // 
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(148, 52);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(205, 28);
            this.cbCustomer.TabIndex = 1;
            // 
            // nudCount
            // 
            this.nudCount.Location = new System.Drawing.Point(149, 92);
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(204, 27);
            this.nudCount.TabIndex = 2;
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(149, 135);
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(204, 27);
            this.nudPrice.TabIndex = 3;
            // 
            // mtbSaleDate
            // 
            this.mtbSaleDate.Location = new System.Drawing.Point(149, 169);
            this.mtbSaleDate.Mask = "00/00/0000";
            this.mtbSaleDate.Name = "mtbSaleDate";
            this.mtbSaleDate.Size = new System.Drawing.Size(204, 27);
            this.mtbSaleDate.TabIndex = 4;
            this.mtbSaleDate.ValidatingType = typeof(System.DateTime);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(41, 222);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(312, 29);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить продажу";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Ghtgf
            // 
            this.Ghtgf.AutoSize = true;
            this.Ghtgf.Location = new System.Drawing.Point(60, 21);
            this.Ghtgf.Name = "Ghtgf";
            this.Ghtgf.Size = new System.Drawing.Size(80, 20);
            this.Ghtgf.TabIndex = 6;
            this.Ghtgf.Text = "Препарат:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Покупатель:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Количество:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Цена за единицу:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Дата продажи:";
            // 
            // AddSalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 283);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ghtgf);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.mtbSaleDate);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.nudCount);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.cbDrug);
            this.Name = "AddSalesForm";
            this.Text = "AddSalesForm";
            this.Load += new System.EventHandler(this.AddSalesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDrug;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.NumericUpDown nudCount;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.MaskedTextBox mtbSaleDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label Ghtgf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}