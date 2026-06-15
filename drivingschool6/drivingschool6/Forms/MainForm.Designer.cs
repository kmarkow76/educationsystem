
namespace drivingschool6.Forms
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bntViewStudent = new System.Windows.Forms.Button();
            this.bntViewCourse = new System.Windows.Forms.Button();
            this.btnAddEnrollment = new System.Windows.Forms.Button();
            this.btnViewCar = new System.Windows.Forms.Button();
            this.btnViewInstructor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(776, 188);
            this.dataGridView1.TabIndex = 0;
            // 
            // bntViewStudent
            // 
            this.bntViewStudent.Location = new System.Drawing.Point(480, 227);
            this.bntViewStudent.Name = "bntViewStudent";
            this.bntViewStudent.Size = new System.Drawing.Size(308, 29);
            this.bntViewStudent.TabIndex = 1;
            this.bntViewStudent.Text = "Просмотр учеников";
            this.bntViewStudent.UseVisualStyleBackColor = true;
            this.bntViewStudent.Click += new System.EventHandler(this.bntViewStudent_Click);
            // 
            // bntViewCourse
            // 
            this.bntViewCourse.Location = new System.Drawing.Point(480, 278);
            this.bntViewCourse.Name = "bntViewCourse";
            this.bntViewCourse.Size = new System.Drawing.Size(308, 29);
            this.bntViewCourse.TabIndex = 2;
            this.bntViewCourse.Text = "Просмотр курсов";
            this.bntViewCourse.UseVisualStyleBackColor = true;
            this.bntViewCourse.Click += new System.EventHandler(this.bntViewCourse_Click);
            // 
            // btnAddEnrollment
            // 
            this.btnAddEnrollment.Location = new System.Drawing.Point(12, 227);
            this.btnAddEnrollment.Name = "btnAddEnrollment";
            this.btnAddEnrollment.Size = new System.Drawing.Size(270, 29);
            this.btnAddEnrollment.TabIndex = 3;
            this.btnAddEnrollment.Text = "Зачислить ученика";
            this.btnAddEnrollment.UseVisualStyleBackColor = true;
            this.btnAddEnrollment.Click += new System.EventHandler(this.btnAddEnrollment_Click);
            // 
            // btnViewCar
            // 
            this.btnViewCar.Location = new System.Drawing.Point(480, 331);
            this.btnViewCar.Name = "btnViewCar";
            this.btnViewCar.Size = new System.Drawing.Size(308, 29);
            this.btnViewCar.TabIndex = 4;
            this.btnViewCar.Text = "Просмотр машин";
            this.btnViewCar.UseVisualStyleBackColor = true;
            this.btnViewCar.Click += new System.EventHandler(this.btnViewCar_Click);
            // 
            // btnViewInstructor
            // 
            this.btnViewInstructor.Location = new System.Drawing.Point(480, 381);
            this.btnViewInstructor.Name = "btnViewInstructor";
            this.btnViewInstructor.Size = new System.Drawing.Size(308, 29);
            this.btnViewInstructor.TabIndex = 5;
            this.btnViewInstructor.Text = "Просмотр инструкторов";
            this.btnViewInstructor.UseVisualStyleBackColor = true;
            this.btnViewInstructor.Click += new System.EventHandler(this.btnViewInstructor_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnViewInstructor);
            this.Controls.Add(this.btnViewCar);
            this.Controls.Add(this.btnAddEnrollment);
            this.Controls.Add(this.bntViewCourse);
            this.Controls.Add(this.bntViewStudent);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bntViewStudent;
        private System.Windows.Forms.Button bntViewCourse;
        private System.Windows.Forms.Button btnAddEnrollment;
        private System.Windows.Forms.Button btnViewCar;
        private System.Windows.Forms.Button btnViewInstructor;
    }
}