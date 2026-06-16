
namespace routetracking10.Forms
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
            this.bntAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnViewSchedule = new System.Windows.Forms.Button();
            this.btnViewDrivers = new System.Windows.Forms.Button();
            this.btnViewPassenger = new System.Windows.Forms.Button();
            this.btnViewCars = new System.Windows.Forms.Button();
            this.btnViewTickets = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(752, 188);
            this.dataGridView1.TabIndex = 0;
            // 
            // bntAdd
            // 
            this.bntAdd.Location = new System.Drawing.Point(23, 244);
            this.bntAdd.Name = "bntAdd";
            this.bntAdd.Size = new System.Drawing.Size(229, 29);
            this.bntAdd.TabIndex = 1;
            this.bntAdd.Text = "Добавить маршрут";
            this.bntAdd.UseVisualStyleBackColor = true;
            this.bntAdd.Click += new System.EventHandler(this.bntAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(23, 279);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(229, 29);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Редактировать маршрут";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(23, 314);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(229, 29);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Удалить маршрут";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnViewSchedule
            // 
            this.btnViewSchedule.Location = new System.Drawing.Point(525, 244);
            this.btnViewSchedule.Name = "btnViewSchedule";
            this.btnViewSchedule.Size = new System.Drawing.Size(250, 29);
            this.btnViewSchedule.TabIndex = 4;
            this.btnViewSchedule.Text = " Просмотр расписания";
            this.btnViewSchedule.UseVisualStyleBackColor = true;
            this.btnViewSchedule.Click += new System.EventHandler(this.btnViewSchedule_Click);
            // 
            // btnViewDrivers
            // 
            this.btnViewDrivers.Location = new System.Drawing.Point(525, 279);
            this.btnViewDrivers.Name = "btnViewDrivers";
            this.btnViewDrivers.Size = new System.Drawing.Size(250, 29);
            this.btnViewDrivers.TabIndex = 5;
            this.btnViewDrivers.Text = "Просмотр водителей";
            this.btnViewDrivers.UseVisualStyleBackColor = true;
            this.btnViewDrivers.Click += new System.EventHandler(this.btnViewDrivers_Click);
            // 
            // btnViewPassenger
            // 
            this.btnViewPassenger.Location = new System.Drawing.Point(525, 314);
            this.btnViewPassenger.Name = "btnViewPassenger";
            this.btnViewPassenger.Size = new System.Drawing.Size(250, 29);
            this.btnViewPassenger.TabIndex = 6;
            this.btnViewPassenger.Text = "Просмотр пассажиров";
            this.btnViewPassenger.UseVisualStyleBackColor = true;
            this.btnViewPassenger.Click += new System.EventHandler(this.btnViewPassenger_Click);
            // 
            // btnViewCars
            // 
            this.btnViewCars.Location = new System.Drawing.Point(525, 349);
            this.btnViewCars.Name = "btnViewCars";
            this.btnViewCars.Size = new System.Drawing.Size(250, 29);
            this.btnViewCars.TabIndex = 7;
            this.btnViewCars.Text = "Просмотр транспортных средств";
            this.btnViewCars.UseVisualStyleBackColor = true;
            this.btnViewCars.Click += new System.EventHandler(this.btnViewCars_Click);
            // 
            // btnViewTickets
            // 
            this.btnViewTickets.Location = new System.Drawing.Point(271, 244);
            this.btnViewTickets.Name = "btnViewTickets";
            this.btnViewTickets.Size = new System.Drawing.Size(234, 29);
            this.btnViewTickets.TabIndex = 8;
            this.btnViewTickets.Text = "Просмотр билетов";
            this.btnViewTickets.UseVisualStyleBackColor = true;
            this.btnViewTickets.Click += new System.EventHandler(this.btnViewTickets_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 397);
            this.Controls.Add(this.btnViewTickets);
            this.Controls.Add(this.btnViewCars);
            this.Controls.Add(this.btnViewPassenger);
            this.Controls.Add(this.btnViewDrivers);
            this.Controls.Add(this.btnViewSchedule);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.bntAdd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bntAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnViewSchedule;
        private System.Windows.Forms.Button btnViewDrivers;
        private System.Windows.Forms.Button btnViewPassenger;
        private System.Windows.Forms.Button btnViewCars;
        private System.Windows.Forms.Button btnViewTickets;
    }
}