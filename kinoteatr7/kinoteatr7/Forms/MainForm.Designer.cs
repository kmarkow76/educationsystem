
namespace kinoteatr7.Forms
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
            this.btnShowTickets = new System.Windows.Forms.Button();
            this.btnShowSessions = new System.Windows.Forms.Button();
            this.btnShowMovies = new System.Windows.Forms.Button();
            this.btnShowHalls = new System.Windows.Forms.Button();
            this.btnShowEmployees = new System.Windows.Forms.Button();
            this.btnShowClients = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.btnEditRecord = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowTickets
            // 
            this.btnShowTickets.Location = new System.Drawing.Point(12, 29);
            this.btnShowTickets.Name = "btnShowTickets";
            this.btnShowTickets.Size = new System.Drawing.Size(173, 29);
            this.btnShowTickets.TabIndex = 0;
            this.btnShowTickets.Text = "Журнал билетов";
            this.btnShowTickets.UseVisualStyleBackColor = true;
            this.btnShowTickets.Click += new System.EventHandler(this.btnShowTickets_Click);
            // 
            // btnShowSessions
            // 
            this.btnShowSessions.Location = new System.Drawing.Point(227, 29);
            this.btnShowSessions.Name = "btnShowSessions";
            this.btnShowSessions.Size = new System.Drawing.Size(94, 29);
            this.btnShowSessions.TabIndex = 1;
            this.btnShowSessions.Text = "Сеансы";
            this.btnShowSessions.UseVisualStyleBackColor = true;
            this.btnShowSessions.Click += new System.EventHandler(this.btnShowSessions_Click);
            // 
            // btnShowMovies
            // 
            this.btnShowMovies.Location = new System.Drawing.Point(363, 29);
            this.btnShowMovies.Name = "btnShowMovies";
            this.btnShowMovies.Size = new System.Drawing.Size(94, 29);
            this.btnShowMovies.TabIndex = 2;
            this.btnShowMovies.Text = "Фильмы";
            this.btnShowMovies.UseVisualStyleBackColor = true;
            this.btnShowMovies.Click += new System.EventHandler(this.btnShowMovies_Click);
            // 
            // btnShowHalls
            // 
            this.btnShowHalls.Location = new System.Drawing.Point(496, 29);
            this.btnShowHalls.Name = "btnShowHalls";
            this.btnShowHalls.Size = new System.Drawing.Size(94, 29);
            this.btnShowHalls.TabIndex = 3;
            this.btnShowHalls.Text = "Кинозалы";
            this.btnShowHalls.UseVisualStyleBackColor = true;
            this.btnShowHalls.Click += new System.EventHandler(this.btnShowHalls_Click);
            // 
            // btnShowEmployees
            // 
            this.btnShowEmployees.Location = new System.Drawing.Point(686, 29);
            this.btnShowEmployees.Name = "btnShowEmployees";
            this.btnShowEmployees.Size = new System.Drawing.Size(223, 29);
            this.btnShowEmployees.TabIndex = 4;
            this.btnShowEmployees.Text = "Сотрудники";
            this.btnShowEmployees.UseVisualStyleBackColor = true;
            this.btnShowEmployees.Click += new System.EventHandler(this.btnShowEmployees_Click);
            // 
            // btnShowClients
            // 
            this.btnShowClients.Location = new System.Drawing.Point(686, 76);
            this.btnShowClients.Name = "btnShowClients";
            this.btnShowClients.Size = new System.Drawing.Size(223, 29);
            this.btnShowClients.TabIndex = 5;
            this.btnShowClients.Text = "Клиенты";
            this.btnShowClients.UseVisualStyleBackColor = true;
            this.btnShowClients.Click += new System.EventHandler(this.btnShowClients_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(12, 133);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersWidth = 51;
            this.dgvMain.RowTemplate.Height = 29;
            this.dgvMain.Size = new System.Drawing.Size(1058, 188);
            this.dgvMain.TabIndex = 6;
            this.dgvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellContentClick);
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(12, 373);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(94, 29);
            this.btnAddRecord.TabIndex = 7;
            this.btnAddRecord.Text = "Добавить";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // btnEditRecord
            // 
            this.btnEditRecord.Location = new System.Drawing.Point(141, 373);
            this.btnEditRecord.Name = "btnEditRecord";
            this.btnEditRecord.Size = new System.Drawing.Size(198, 29);
            this.btnEditRecord.TabIndex = 8;
            this.btnEditRecord.Text = "Редактировать";
            this.btnEditRecord.UseVisualStyleBackColor = true;
            this.btnEditRecord.Click += new System.EventHandler(this.btnEditRecord_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(378, 373);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(324, 29);
            this.btnSaveChanges.TabIndex = 9;
            this.btnSaveChanges.Text = "Сохранить изменения справочника";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 553);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnEditRecord);
            this.Controls.Add(this.btnAddRecord);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.btnShowClients);
            this.Controls.Add(this.btnShowEmployees);
            this.Controls.Add(this.btnShowHalls);
            this.Controls.Add(this.btnShowMovies);
            this.Controls.Add(this.btnShowSessions);
            this.Controls.Add(this.btnShowTickets);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowTickets;
        private System.Windows.Forms.Button btnShowSessions;
        private System.Windows.Forms.Button btnShowMovies;
        private System.Windows.Forms.Button btnShowHalls;
        private System.Windows.Forms.Button btnShowEmployees;
        private System.Windows.Forms.Button btnShowClients;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Button btnEditRecord;
        private System.Windows.Forms.Button btnSaveChanges;
    }
}