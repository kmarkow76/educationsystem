
namespace educsys.Forms
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbGroup = new System.Windows.Forms.TextBox();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.mtbDate = new System.Windows.Forms.MaskedTextBox();
            this.mtbPhone = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(364, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(224, 35);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Группа";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Дата поступления";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "ФИО";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Телефон";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(366, 265);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(224, 35);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Сохранить студента";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbGroup
            // 
            this.tbGroup.Location = new System.Drawing.Point(365, 211);
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(223, 27);
            this.tbGroup.TabIndex = 14;
            // 
            // tbFullName
            // 
            this.tbFullName.Location = new System.Drawing.Point(365, 109);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(225, 27);
            this.tbFullName.TabIndex = 13;
            // 
            // mtbDate
            // 
            this.mtbDate.Location = new System.Drawing.Point(365, 178);
            this.mtbDate.Name = "mtbDate";
            this.mtbDate.Mask = "00/00/0000";
            this.mtbDate.Size = new System.Drawing.Size(223, 27);
            this.mtbDate.TabIndex = 12;
            // 
            // mtbPhone
            // 
            this.mtbPhone.Location = new System.Drawing.Point(365, 145);
            this.mtbPhone.Name = "mtbPhone";
            this.mtbPhone.Mask = "+373-00-000-000";
            this.mtbPhone.Size = new System.Drawing.Size(223, 27);
            this.mtbPhone.TabIndex = 11;
            // 
            // EditStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbGroup);
            this.Controls.Add(this.tbFullName);
            this.Controls.Add(this.mtbDate);
            this.Controls.Add(this.mtbPhone);
            this.Name = "EditStudentForm";
            this.Text = "EditStudentForm";
            this.Load += new System.EventHandler(this.EditStudentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbGroup;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.MaskedTextBox mtbDate;
        private System.Windows.Forms.MaskedTextBox mtbPhone;
    }
}