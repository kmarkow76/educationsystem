
namespace drivingschool6.Forms
{
    partial class EditStudentForm
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
            this.txbFio = new System.Windows.Forms.TextBox();
            this.mtxbPhone = new System.Windows.Forms.MaskedTextBox();
            this.ckbksStudent = new System.Windows.Forms.CheckBox();
            this.txbCode = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbFio
            // 
            this.txbFio.Location = new System.Drawing.Point(127, 43);
            this.txbFio.Name = "txbFio";
            this.txbFio.Size = new System.Drawing.Size(125, 27);
            this.txbFio.TabIndex = 0;
            // 
            // mtxbPhone
            // 
            this.mtxbPhone.Location = new System.Drawing.Point(127, 83);
            this.mtxbPhone.Mask = "(999) 000-00-000";
            this.mtxbPhone.Name = "mtxbPhone";
            this.mtxbPhone.Size = new System.Drawing.Size(125, 27);
            this.mtxbPhone.TabIndex = 1;
            // 
            // ckbksStudent
            // 
            this.ckbksStudent.AutoSize = true;
            this.ckbksStudent.Location = new System.Drawing.Point(127, 171);
            this.ckbksStudent.Name = "ckbksStudent";
            this.ckbksStudent.Size = new System.Drawing.Size(84, 24);
            this.ckbksStudent.TabIndex = 2;
            this.ckbksStudent.Text = "Студент";
            this.ckbksStudent.UseVisualStyleBackColor = true;
            // 
            // txbCode
            // 
            this.txbCode.Location = new System.Drawing.Point(127, 122);
            this.txbCode.Name = "txbCode";
            this.txbCode.Size = new System.Drawing.Size(125, 27);
            this.txbCode.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(45, 217);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(207, 29);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Добавить ученика";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "ФИО:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Телефон:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Код семьи:";
            // 
            // EditStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 283);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txbCode);
            this.Controls.Add(this.ckbksStudent);
            this.Controls.Add(this.mtxbPhone);
            this.Controls.Add(this.txbFio);
            this.Name = "EditStudentForm";
            this.Text = "EditStudentForm";
            this.Load += new System.EventHandler(this.EditStudentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbFio;
        private System.Windows.Forms.MaskedTextBox mtxbPhone;
        private System.Windows.Forms.CheckBox ckbksStudent;
        private System.Windows.Forms.TextBox txbCode;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}