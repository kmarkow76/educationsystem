
namespace komunalka11.Forms
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMakePayment = new System.Windows.Forms.Button();
            this.btnAddAccrual = new System.Windows.Forms.Button();
            this.btnOpenCitizens = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvMainAccruals = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainAccruals)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(180, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Учет коммунальных платежей";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMakePayment);
            this.groupBox1.Controls.Add(this.btnAddAccrual);
            this.groupBox1.Controls.Add(this.btnOpenCitizens);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 232);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление и Навигация";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnMakePayment
            // 
            this.btnMakePayment.Location = new System.Drawing.Point(6, 169);
            this.btnMakePayment.Name = "btnMakePayment";
            this.btnMakePayment.Size = new System.Drawing.Size(190, 40);
            this.btnMakePayment.TabIndex = 2;
            this.btnMakePayment.Text = "Внести оплату";
            this.btnMakePayment.UseVisualStyleBackColor = true;
            this.btnMakePayment.Click += new System.EventHandler(this.btnMakePayment_Click);
            // 
            // btnAddAccrual
            // 
            this.btnAddAccrual.Location = new System.Drawing.Point(6, 106);
            this.btnAddAccrual.Name = "btnAddAccrual";
            this.btnAddAccrual.Size = new System.Drawing.Size(190, 40);
            this.btnAddAccrual.TabIndex = 1;
            this.btnAddAccrual.Text = "Новое начисление";
            this.btnAddAccrual.UseVisualStyleBackColor = true;
            this.btnAddAccrual.Click += new System.EventHandler(this.btnAddAccrual_Click);
            // 
            // btnOpenCitizens
            // 
            this.btnOpenCitizens.Location = new System.Drawing.Point(6, 44);
            this.btnOpenCitizens.Name = "btnOpenCitizens";
            this.btnOpenCitizens.Size = new System.Drawing.Size(190, 40);
            this.btnOpenCitizens.TabIndex = 0;
            this.btnOpenCitizens.Text = "Жильцы и Счета";
            this.btnOpenCitizens.UseVisualStyleBackColor = true;
            this.btnOpenCitizens.Click += new System.EventHandler(this.btnOpenCitizens_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(356, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Мониторинг начислений и задолженностей ЖКХ:";
            // 
            // dgvMainAccruals
            // 
            this.dgvMainAccruals.AllowUserToAddRows = false;
            this.dgvMainAccruals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMainAccruals.Location = new System.Drawing.Point(343, 110);
            this.dgvMainAccruals.Name = "dgvMainAccruals";
            this.dgvMainAccruals.ReadOnly = true;
            this.dgvMainAccruals.RowHeadersWidth = 51;
            this.dgvMainAccruals.RowTemplate.Height = 29;
            this.dgvMainAccruals.Size = new System.Drawing.Size(1284, 188);
            this.dgvMainAccruals.TabIndex = 3;
            this.dgvMainAccruals.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMainAccruals_CellContentClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1661, 360);
            this.Controls.Add(this.dgvMainAccruals);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainAccruals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMakePayment;
        private System.Windows.Forms.Button btnAddAccrual;
        private System.Windows.Forms.Button btnOpenCitizens;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvMainAccruals;
    }
}