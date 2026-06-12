
namespace educsys.Forms
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnGrades = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnTeachers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(37, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(723, 188);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(44, 229);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(238, 29);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить студента";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(44, 275);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(238, 29);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Редактировать студента";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnGrades
            // 
            this.btnGrades.Location = new System.Drawing.Point(44, 319);
            this.btnGrades.Name = "btnGrades";
            this.btnGrades.Size = new System.Drawing.Size(238, 29);
            this.btnGrades.TabIndex = 3;
            this.btnGrades.Text = "История оценок";
            this.btnGrades.UseVisualStyleBackColor = true;
            this.btnGrades.Click += new System.EventHandler(this.btnGrades_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.Location = new System.Drawing.Point(298, 229);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(238, 29);
            this.btnPayments.TabIndex = 4;
            this.btnPayments.Text = "История платежей";
            this.btnPayments.UseVisualStyleBackColor = true;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // btnTeachers
            // 
            this.btnTeachers.Location = new System.Drawing.Point(298, 275);
            this.btnTeachers.Name = "btnTeachers";
            this.btnTeachers.Size = new System.Drawing.Size(238, 29);
            this.btnTeachers.TabIndex = 5;
            this.btnTeachers.Text = "Преподователи";
            this.btnTeachers.UseVisualStyleBackColor = true;
            this.btnTeachers.Click += new System.EventHandler(this.btnTeachers_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 369);
            this.Controls.Add(this.btnTeachers);
            this.Controls.Add(this.btnPayments);
            this.Controls.Add(this.btnGrades);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnGrades;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnTeachers;
    }
}