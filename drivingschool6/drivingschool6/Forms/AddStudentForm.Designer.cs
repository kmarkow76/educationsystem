
namespace drivingschool6.Forms
{
    partial class AddStudentForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txbCode = new System.Windows.Forms.TextBox();
            this.ckbksStudent = new System.Windows.Forms.CheckBox();
            this.mtxbPhone = new System.Windows.Forms.MaskedTextBox();
            this.txbFio = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Код семьи:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Телефон:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "ФИО:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(47, 200);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(207, 29);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Добавить ученика";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txbCode
            // 
            this.txbCode.Location = new System.Drawing.Point(129, 105);
            this.txbCode.Name = "txbCode";
            this.txbCode.Size = new System.Drawing.Size(125, 27);
            this.txbCode.TabIndex = 11;
            // 
            // ckbksStudent
            // 
            this.ckbksStudent.AutoSize = true;
            this.ckbksStudent.Location = new System.Drawing.Point(129, 154);
            this.ckbksStudent.Name = "ckbksStudent";
            this.ckbksStudent.Size = new System.Drawing.Size(84, 24);
            this.ckbksStudent.TabIndex = 10;
            this.ckbksStudent.Text = "Студент";
            this.ckbksStudent.UseVisualStyleBackColor = true;
            // 
            // mtxbPhone
            // 
            this.mtxbPhone.Location = new System.Drawing.Point(129, 66);
            this.mtxbPhone.Mask = "(999) 000-00-000";
            this.mtxbPhone.Name = "mtxbPhone";
            this.mtxbPhone.Size = new System.Drawing.Size(125, 27);
            this.mtxbPhone.TabIndex = 9;
            // 
            // txbFio
            // 
            this.txbFio.Location = new System.Drawing.Point(129, 26);
            this.txbFio.Name = "txbFio";
            this.txbFio.Size = new System.Drawing.Size(125, 27);
            this.txbFio.TabIndex = 8;
            // 
            // AddStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 266);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txbCode);
            this.Controls.Add(this.ckbksStudent);
            this.Controls.Add(this.mtxbPhone);
            this.Controls.Add(this.txbFio);
            this.Name = "AddStudentForm";
            this.Text = "AddStudentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txbCode;
        private System.Windows.Forms.CheckBox ckbksStudent;
        private System.Windows.Forms.MaskedTextBox mtxbPhone;
        private System.Windows.Forms.TextBox txbFio;
    }
}