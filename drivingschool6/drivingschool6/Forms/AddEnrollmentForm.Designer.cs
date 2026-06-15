
namespace drivingschool6.Forms
{
    partial class AddEnrollmentForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbStudent = new System.Windows.Forms.ComboBox();
            this.cbInstructor = new System.Windows.Forms.ComboBox();
            this.cbCar = new System.Windows.Forms.ComboBox();
            this.cbCourse = new System.Windows.Forms.ComboBox();
            this.cbPaymentType = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ученик: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Инструктор:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Автомобиль:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Курс:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Дата начала:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Тип оплаты:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(97, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Статус:";
            // 
            // cbStudent
            // 
            this.cbStudent.FormattingEnabled = true;
            this.cbStudent.Location = new System.Drawing.Point(182, 26);
            this.cbStudent.Name = "cbStudent";
            this.cbStudent.Size = new System.Drawing.Size(200, 28);
            this.cbStudent.TabIndex = 7;
            // 
            // cbInstructor
            // 
            this.cbInstructor.FormattingEnabled = true;
            this.cbInstructor.Location = new System.Drawing.Point(182, 60);
            this.cbInstructor.Name = "cbInstructor";
            this.cbInstructor.Size = new System.Drawing.Size(200, 28);
            this.cbInstructor.TabIndex = 8;
            // 
            // cbCar
            // 
            this.cbCar.FormattingEnabled = true;
            this.cbCar.Location = new System.Drawing.Point(182, 95);
            this.cbCar.Name = "cbCar";
            this.cbCar.Size = new System.Drawing.Size(200, 28);
            this.cbCar.TabIndex = 9;
            // 
            // cbCourse
            // 
            this.cbCourse.FormattingEnabled = true;
            this.cbCourse.Location = new System.Drawing.Point(182, 129);
            this.cbCourse.Name = "cbCourse";
            this.cbCourse.Size = new System.Drawing.Size(200, 28);
            this.cbCourse.TabIndex = 10;
            // 
            // cbPaymentType
            // 
            this.cbPaymentType.FormattingEnabled = true;
            this.cbPaymentType.Location = new System.Drawing.Point(182, 196);
            this.cbPaymentType.Name = "cbPaymentType";
            this.cbPaymentType.Size = new System.Drawing.Size(200, 28);
            this.cbPaymentType.TabIndex = 11;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(182, 230);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(200, 28);
            this.cbStatus.TabIndex = 12;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(182, 163);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 27);
            this.dtpStartDate.TabIndex = 13;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(61, 264);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(259, 29);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Добавить зачисление";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddEnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 338);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbPaymentType);
            this.Controls.Add(this.cbCourse);
            this.Controls.Add(this.cbCar);
            this.Controls.Add(this.cbInstructor);
            this.Controls.Add(this.cbStudent);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEnrollmentForm";
            this.Text = "AddEnrollmentForm";
            this.Load += new System.EventHandler(this.AddEnrollmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbStudent;
        private System.Windows.Forms.ComboBox cbInstructor;
        private System.Windows.Forms.ComboBox cbCar;
        private System.Windows.Forms.ComboBox cbCourse;
        private System.Windows.Forms.ComboBox cbPaymentType;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnAdd;
    }
}