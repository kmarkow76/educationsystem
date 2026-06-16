
namespace pharmacy8.Forms
{
    partial class AddDrugForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbIs = new System.Windows.Forms.CheckBox();
            this.mtbData = new System.Windows.Forms.MaskedTextBox();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.tbManufactor = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.tbName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(100, 253);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(274, 29);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Сохранить препарат";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Категория:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Производитель:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Цена:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Количество:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Дата срока годности:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Название:";
            // 
            // ckbIs
            // 
            this.ckbIs.AutoSize = true;
            this.ckbIs.Location = new System.Drawing.Point(186, 222);
            this.ckbIs.Name = "ckbIs";
            this.ckbIs.Size = new System.Drawing.Size(104, 24);
            this.ckbIs.TabIndex = 20;
            this.ckbIs.Text = "В наличии";
            this.ckbIs.UseVisualStyleBackColor = true;
            // 
            // mtbData
            // 
            this.mtbData.Location = new System.Drawing.Point(184, 180);
            this.mtbData.Mask = "00/00/0000";
            this.mtbData.Name = "mtbData";
            this.mtbData.Size = new System.Drawing.Size(190, 27);
            this.mtbData.TabIndex = 19;
            this.mtbData.ValidatingType = typeof(System.DateTime);
            // 
            // nudCount
            // 
            this.nudCount.Location = new System.Drawing.Point(186, 147);
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(188, 27);
            this.nudCount.TabIndex = 18;
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(186, 114);
            this.nudPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(188, 27);
            this.nudPrice.TabIndex = 17;
            // 
            // tbManufactor
            // 
            this.tbManufactor.Location = new System.Drawing.Point(186, 81);
            this.tbManufactor.Name = "tbManufactor";
            this.tbManufactor.Size = new System.Drawing.Size(188, 27);
            this.tbManufactor.TabIndex = 16;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(186, 47);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(188, 28);
            this.cbCategory.TabIndex = 15;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(186, 14);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(188, 27);
            this.tbName.TabIndex = 14;
            // 
            // AddDrugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 323);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckbIs);
            this.Controls.Add(this.mtbData);
            this.Controls.Add(this.nudCount);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.tbManufactor);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.tbName);
            this.Name = "AddDrugForm";
            this.Text = "AddDrugForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbIs;
        private System.Windows.Forms.MaskedTextBox mtbData;
        private System.Windows.Forms.NumericUpDown nudCount;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.TextBox tbManufactor;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox tbName;
    }
}