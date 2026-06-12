
namespace educsys.Forms
{
    partial class PaymentsForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.nudHours = new System.Windows.Forms.NumericUpDown();
            this.cmbMaterialType = new System.Windows.Forms.ComboBox();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblCostResult = new System.Windows.Forms.Label();
            this.btnCalculateCost = new System.Windows.Forms.Button();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.tbPaymentName = new System.Windows.Forms.TextBox();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(738, 188);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(33, 545);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(50, 20);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "label1";
            // 
            // cmbCourse
            // 
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(259, 257);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(151, 28);
            this.cmbCourse.TabIndex = 2;
            // 
            // nudHours
            // 
            this.nudHours.Location = new System.Drawing.Point(260, 304);
            this.nudHours.Name = "nudHours";
            this.nudHours.Size = new System.Drawing.Size(150, 27);
            this.nudHours.TabIndex = 3;
            // 
            // cmbMaterialType
            // 
            this.cmbMaterialType.FormattingEnabled = true;
            this.cmbMaterialType.Location = new System.Drawing.Point(260, 352);
            this.cmbMaterialType.Name = "cmbMaterialType";
            this.cmbMaterialType.Size = new System.Drawing.Size(151, 28);
            this.cmbMaterialType.TabIndex = 4;
            // 
            // nudPrice
            // 
            this.nudPrice.Location = new System.Drawing.Point(261, 395);
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(150, 27);
            this.nudPrice.TabIndex = 5;
            // 
            // lblCostResult
            // 
            this.lblCostResult.AutoSize = true;
            this.lblCostResult.Location = new System.Drawing.Point(259, 446);
            this.lblCostResult.Name = "lblCostResult";
            this.lblCostResult.Size = new System.Drawing.Size(83, 20);
            this.lblCostResult.TabIndex = 6;
            this.lblCostResult.Text = "Стоимость";
            // 
            // btnCalculateCost
            // 
            this.btnCalculateCost.Location = new System.Drawing.Point(12, 439);
            this.btnCalculateCost.Name = "btnCalculateCost";
            this.btnCalculateCost.Size = new System.Drawing.Size(222, 35);
            this.btnCalculateCost.TabIndex = 7;
            this.btnCalculateCost.Text = "Рассчитать стоимость";
            this.btnCalculateCost.UseVisualStyleBackColor = true;
            this.btnCalculateCost.Click += new System.EventHandler(this.btnCalculateCost_Click);
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Location = new System.Drawing.Point(521, 390);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(213, 27);
            this.btnAddPayment.TabIndex = 8;
            this.btnAddPayment.Text = "Добавить платёж";
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // tbPaymentName
            // 
            this.tbPaymentName.Location = new System.Drawing.Point(521, 260);
            this.tbPaymentName.Name = "tbPaymentName";
            this.tbPaymentName.Size = new System.Drawing.Size(213, 27);
            this.tbPaymentName.TabIndex = 9;
            // 
            // nudAmount
            // 
            this.nudAmount.Location = new System.Drawing.Point(521, 345);
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(213, 27);
            this.nudAmount.TabIndex = 10;
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Location = new System.Drawing.Point(521, 302);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(213, 27);
            this.dtpPaymentDate.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Выберите курс:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Введите количество часов:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Выберите тип:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 397);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Введите сумму:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // PaymentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 603);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpPaymentDate);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.tbPaymentName);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.btnCalculateCost);
            this.Controls.Add(this.lblCostResult);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.cmbMaterialType);
            this.Controls.Add(this.nudHours);
            this.Controls.Add(this.cmbCourse);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PaymentsForm";
            this.Text = "PaymentsForm";
            this.Load += new System.EventHandler(this.PaymentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.NumericUpDown nudHours;
        private System.Windows.Forms.ComboBox cmbMaterialType;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblCostResult;
        private System.Windows.Forms.Button btnCalculateCost;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.TextBox tbPaymentName;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}