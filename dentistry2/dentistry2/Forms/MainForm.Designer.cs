
namespace dentistry2.Forms
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.bntNewAppointment = new System.Windows.Forms.Button();
            this.btnViewDoctors = new System.Windows.Forms.Button();
            this.btnViewVisits = new System.Windows.Forms.Button();
            this.btnDisc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(735, 188);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(26, 232);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(191, 29);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить пациента";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(26, 279);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(191, 29);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Редактировать пациента";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(26, 328);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(191, 29);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Удалить пациента";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // bntNewAppointment
            // 
            this.bntNewAppointment.Location = new System.Drawing.Point(244, 279);
            this.bntNewAppointment.Name = "bntNewAppointment";
            this.bntNewAppointment.Size = new System.Drawing.Size(185, 29);
            this.bntNewAppointment.TabIndex = 4;
            this.bntNewAppointment.Text = "Записать на прием";
            this.bntNewAppointment.UseVisualStyleBackColor = true;
            this.bntNewAppointment.Click += new System.EventHandler(this.bntNewAppointment_Click);
            // 
            // btnViewDoctors
            // 
            this.btnViewDoctors.Location = new System.Drawing.Point(511, 232);
            this.btnViewDoctors.Name = "btnViewDoctors";
            this.btnViewDoctors.Size = new System.Drawing.Size(250, 29);
            this.btnViewDoctors.TabIndex = 6;
            this.btnViewDoctors.Text = "Просмотр врачей";
            this.btnViewDoctors.UseVisualStyleBackColor = true;
            this.btnViewDoctors.Click += new System.EventHandler(this.btnViewDoctors_Click);
            // 
            // btnViewVisits
            // 
            this.btnViewVisits.Location = new System.Drawing.Point(244, 232);
            this.btnViewVisits.Name = "btnViewVisits";
            this.btnViewVisits.Size = new System.Drawing.Size(185, 29);
            this.btnViewVisits.TabIndex = 7;
            this.btnViewVisits.Text = "Посмотреть визиты пациена";
            this.btnViewVisits.UseVisualStyleBackColor = true;
            this.btnViewVisits.Click += new System.EventHandler(this.btnViewVisits_Click);
            // 
            // btnDisc
            // 
            this.btnDisc.Location = new System.Drawing.Point(511, 279);
            this.btnDisc.Name = "btnDisc";
            this.btnDisc.Size = new System.Drawing.Size(250, 29);
            this.btnDisc.TabIndex = 8;
            this.btnDisc.Text = "Посмотреть скидку пациента";
            this.btnDisc.UseVisualStyleBackColor = true;
            this.btnDisc.Click += new System.EventHandler(this.btnDisc_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDisc);
            this.Controls.Add(this.btnViewVisits);
            this.Controls.Add(this.btnViewDoctors);
            this.Controls.Add(this.bntNewAppointment);
            this.Controls.Add(this.btnDelete);
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
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button bntNewAppointment;
        private System.Windows.Forms.Button btnViewDoctors;
        private System.Windows.Forms.Button btnViewVisits;
        private System.Windows.Forms.Button btnDisc;
    }
}