
namespace dentistry.Forms
{
    partial class EditPatientForm
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
            this.bntSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mtxbDateof = new System.Windows.Forms.MaskedTextBox();
            this.mtxbPolicy = new System.Windows.Forms.MaskedTextBox();
            this.mtxbPhone = new System.Windows.Forms.MaskedTextBox();
            this.txbAddress = new System.Windows.Forms.TextBox();
            this.txbFio = new System.Windows.Forms.TextBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bntSave
            // 
            this.bntSave.Location = new System.Drawing.Point(172, 388);
            this.bntSave.Name = "bntSave";
            this.bntSave.Size = new System.Drawing.Size(198, 29);
            this.bntSave.TabIndex = 28;
            this.bntSave.Text = "Сохранить пациента";
            this.bntSave.UseVisualStyleBackColor = true;
            this.bntSave.Click += new System.EventHandler(this.bntSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Введите полис:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Введите адрес:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Введите номер телефона:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Введите пол:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Введите дату рождения:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Введите ФИО:";
            // 
            // mtxbDateof
            // 
            this.mtxbDateof.Location = new System.Drawing.Point(266, 130);
            this.mtxbDateof.Mask = "00/00/0000";
            this.mtxbDateof.Name = "mtxbDateof";
            this.mtxbDateof.Size = new System.Drawing.Size(161, 27);
            this.mtxbDateof.TabIndex = 21;
            this.mtxbDateof.ValidatingType = typeof(System.DateTime);
            // 
            // mtxbPolicy
            // 
            this.mtxbPolicy.Location = new System.Drawing.Point(266, 339);
            this.mtxbPolicy.Mask = "00000000-99999999";
            this.mtxbPolicy.Name = "mtxbPolicy";
            this.mtxbPolicy.Size = new System.Drawing.Size(161, 27);
            this.mtxbPolicy.TabIndex = 20;
            // 
            // mtxbPhone
            // 
            this.mtxbPhone.Location = new System.Drawing.Point(266, 233);
            this.mtxbPhone.Mask = "(999) 000-00-000";
            this.mtxbPhone.Name = "mtxbPhone";
            this.mtxbPhone.Size = new System.Drawing.Size(161, 27);
            this.mtxbPhone.TabIndex = 19;
            // 
            // txbAddress
            // 
            this.txbAddress.Location = new System.Drawing.Point(266, 287);
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(161, 27);
            this.txbAddress.TabIndex = 18;
            // 
            // txbFio
            // 
            this.txbFio.Location = new System.Drawing.Point(266, 79);
            this.txbFio.Name = "txbFio";
            this.txbFio.Size = new System.Drawing.Size(161, 27);
            this.txbFio.TabIndex = 16;
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(266, 186);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(161, 28);
            this.cmbGender.TabIndex = 29;
            // 
            // EditPatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 498);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.bntSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtxbDateof);
            this.Controls.Add(this.mtxbPolicy);
            this.Controls.Add(this.mtxbPhone);
            this.Controls.Add(this.txbAddress);
            this.Controls.Add(this.txbFio);
            this.Name = "EditPatientForm";
            this.Text = "EditPatientForm";
            this.Load += new System.EventHandler(this.EditPatientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxbDateof;
        private System.Windows.Forms.MaskedTextBox mtxbPolicy;
        private System.Windows.Forms.MaskedTextBox mtxbPhone;
        private System.Windows.Forms.TextBox txbAddress;
        private System.Windows.Forms.TextBox txbFio;
        private System.Windows.Forms.ComboBox cmbGender;
    }
}