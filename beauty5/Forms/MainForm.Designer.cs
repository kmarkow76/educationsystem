
namespace beauty5.Forms
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
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.btnShowAppointments = new System.Windows.Forms.Button();
            this.btnShowClients = new System.Windows.Forms.Button();
            this.btnShowMasters = new System.Windows.Forms.Button();
            this.btnShowServices = new System.Windows.Forms.Button();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.btnEditAppointment = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(12, 77);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersWidth = 51;
            this.dgvMain.RowTemplate.Height = 29;
            this.dgvMain.Size = new System.Drawing.Size(1106, 188);
            this.dgvMain.TabIndex = 0;
            // 
            // btnShowAppointments
            // 
            this.btnShowAppointments.Location = new System.Drawing.Point(12, 24);
            this.btnShowAppointments.Name = "btnShowAppointments";
            this.btnShowAppointments.Size = new System.Drawing.Size(192, 29);
            this.btnShowAppointments.TabIndex = 1;
            this.btnShowAppointments.Text = "Журнал записей";
            this.btnShowAppointments.UseVisualStyleBackColor = true;
            this.btnShowAppointments.Click += new System.EventHandler(this.btnShowAppointments_Click);
            // 
            // btnShowClients
            // 
            this.btnShowClients.Location = new System.Drawing.Point(233, 24);
            this.btnShowClients.Name = "btnShowClients";
            this.btnShowClients.Size = new System.Drawing.Size(208, 29);
            this.btnShowClients.TabIndex = 2;
            this.btnShowClients.Text = "Клиенты";
            this.btnShowClients.UseVisualStyleBackColor = true;
            this.btnShowClients.Click += new System.EventHandler(this.btnShowClients_Click);
            // 
            // btnShowMasters
            // 
            this.btnShowMasters.Location = new System.Drawing.Point(475, 24);
            this.btnShowMasters.Name = "btnShowMasters";
            this.btnShowMasters.Size = new System.Drawing.Size(94, 29);
            this.btnShowMasters.TabIndex = 3;
            this.btnShowMasters.Text = "Мастера";
            this.btnShowMasters.UseVisualStyleBackColor = true;
            this.btnShowMasters.Click += new System.EventHandler(this.btnShowMasters_Click);
            // 
            // btnShowServices
            // 
            this.btnShowServices.Location = new System.Drawing.Point(599, 24);
            this.btnShowServices.Name = "btnShowServices";
            this.btnShowServices.Size = new System.Drawing.Size(150, 29);
            this.btnShowServices.TabIndex = 4;
            this.btnShowServices.Text = "Услуги (Прайс)";
            this.btnShowServices.UseVisualStyleBackColor = true;
            this.btnShowServices.Click += new System.EventHandler(this.btnShowServices_Click);
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Location = new System.Drawing.Point(12, 308);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(211, 29);
            this.btnAddAppointment.TabIndex = 5;
            this.btnAddAppointment.Text = "Добавить запись";
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // btnEditAppointment
            // 
            this.btnEditAppointment.Location = new System.Drawing.Point(259, 308);
            this.btnEditAppointment.Name = "btnEditAppointment";
            this.btnEditAppointment.Size = new System.Drawing.Size(247, 29);
            this.btnEditAppointment.TabIndex = 6;
            this.btnEditAppointment.Text = "Редактировать запись";
            this.btnEditAppointment.UseVisualStyleBackColor = true;
            this.btnEditAppointment.Click += new System.EventHandler(this.btnEditAppointment_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(12, 367);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(494, 29);
            this.btnSaveChanges.TabIndex = 7;
            this.btnSaveChanges.Text = "Сохранить изменения справочника";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Visible = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 450);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnEditAppointment);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.btnShowServices);
            this.Controls.Add(this.btnShowMasters);
            this.Controls.Add(this.btnShowClients);
            this.Controls.Add(this.btnShowAppointments);
            this.Controls.Add(this.dgvMain);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Button btnShowAppointments;
        private System.Windows.Forms.Button btnShowClients;
        private System.Windows.Forms.Button btnShowMasters;
        private System.Windows.Forms.Button btnShowServices;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Button btnEditAppointment;
        private System.Windows.Forms.Button btnSaveChanges;
    }
}