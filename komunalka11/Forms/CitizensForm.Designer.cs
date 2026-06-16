
namespace komunalka11.Forms
{
    partial class CitizensForm
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
            this.dgvCitizens = new System.Windows.Forms.DataGridView();
            this.gbManage = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSaveCitizen = new System.Windows.Forms.Button();
            this.chkHasPrivilege = new System.Windows.Forms.CheckBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitizens)).BeginInit();
            this.gbManage.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(511, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Список лицевых счетов и жильцов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Зарегистрированные жильцы и счета:";
            // 
            // dgvCitizens
            // 
            this.dgvCitizens.AllowUserToAddRows = false;
            this.dgvCitizens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitizens.Location = new System.Drawing.Point(12, 124);
            this.dgvCitizens.Name = "dgvCitizens";
            this.dgvCitizens.ReadOnly = true;
            this.dgvCitizens.RowHeadersWidth = 51;
            this.dgvCitizens.RowTemplate.Height = 29;
            this.dgvCitizens.Size = new System.Drawing.Size(653, 188);
            this.dgvCitizens.TabIndex = 2;
            this.dgvCitizens.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCitizens_CellContentClick);
            // 
            // gbManage
            // 
            this.gbManage.Controls.Add(this.btnBack);
            this.gbManage.Controls.Add(this.btnSaveCitizen);
            this.gbManage.Controls.Add(this.chkHasPrivilege);
            this.gbManage.Controls.Add(this.txtAddress);
            this.gbManage.Controls.Add(this.label5);
            this.gbManage.Controls.Add(this.txtAccountNumber);
            this.gbManage.Controls.Add(this.label4);
            this.gbManage.Controls.Add(this.txtFullName);
            this.gbManage.Controls.Add(this.label3);
            this.gbManage.Location = new System.Drawing.Point(724, 80);
            this.gbManage.Name = "gbManage";
            this.gbManage.Size = new System.Drawing.Size(558, 326);
            this.gbManage.TabIndex = 3;
            this.gbManage.TabStop = false;
            this.gbManage.Text = "Данные жильца и счета";
            this.gbManage.Enter += new System.EventHandler(this.gbManage_Enter);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(289, 256);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(182, 29);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Назад на главную";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSaveCitizen
            // 
            this.btnSaveCitizen.Location = new System.Drawing.Point(6, 256);
            this.btnSaveCitizen.Name = "btnSaveCitizen";
            this.btnSaveCitizen.Size = new System.Drawing.Size(236, 29);
            this.btnSaveCitizen.TabIndex = 7;
            this.btnSaveCitizen.Text = "Сохранить данные";
            this.btnSaveCitizen.UseVisualStyleBackColor = true;
            this.btnSaveCitizen.Click += new System.EventHandler(this.btnSaveCitizen_Click);
            // 
            // chkHasPrivilege
            // 
            this.chkHasPrivilege.AutoSize = true;
            this.chkHasPrivilege.Location = new System.Drawing.Point(6, 198);
            this.chkHasPrivilege.Name = "chkHasPrivilege";
            this.chkHasPrivilege.Size = new System.Drawing.Size(236, 24);
            this.chkHasPrivilege.TabIndex = 6;
            this.chkHasPrivilege.Text = "Наличие льготы (скидка 25%)";
            this.chkHasPrivilege.UseVisualStyleBackColor = true;
            this.chkHasPrivilege.CheckedChanged += new System.EventHandler(this.chkHasPrivilege_CheckedChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(181, 150);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(353, 27);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Адрес проживания:";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(132, 95);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(402, 27);
            this.txtAccountNumber.TabIndex = 3;
            this.txtAccountNumber.TextChanged += new System.EventHandler(this.txtAccountNumber_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Номер Л/Счета:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(130, 44);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(404, 27);
            this.txtFullName.TabIndex = 1;
            this.txtFullName.TextChanged += new System.EventHandler(this.txtFullName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "ФИО Жильца:";
            // 
            // CitizensForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 450);
            this.Controls.Add(this.gbManage);
            this.Controls.Add(this.dgvCitizens);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CitizensForm";
            this.Text = "CitizensForm";
            this.Load += new System.EventHandler(this.CitizensForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitizens)).EndInit();
            this.gbManage.ResumeLayout(false);
            this.gbManage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCitizens;
        private System.Windows.Forms.GroupBox gbManage;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSaveCitizen;
        private System.Windows.Forms.CheckBox chkHasPrivilege;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label3;
    }
}