
namespace cyberclub14.Forms
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
            this.btnOpenSession = new System.Windows.Forms.Button();
            this.btnCloseSession = new System.Windows.Forms.Button();
            this.btnEditSession = new System.Windows.Forms.Button();
            this.btnDeleteSession = new System.Windows.Forms.Button();
            this.btnHistorySession = new System.Windows.Forms.Button();
            this.btnViewBar = new System.Windows.Forms.Button();
            this.btnClubMembers = new System.Windows.Forms.Button();
            this.btnViewTariff = new System.Windows.Forms.Button();
            this.btnViewPlaces = new System.Windows.Forms.Button();
            this.btnViewZone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(777, 188);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnOpenSession
            // 
            this.btnOpenSession.Location = new System.Drawing.Point(12, 225);
            this.btnOpenSession.Name = "btnOpenSession";
            this.btnOpenSession.Size = new System.Drawing.Size(356, 29);
            this.btnOpenSession.TabIndex = 1;
            this.btnOpenSession.Text = "Открытие сессии";
            this.btnOpenSession.UseVisualStyleBackColor = true;
            this.btnOpenSession.Click += new System.EventHandler(this.btnOpenSession_Click);
            // 
            // btnCloseSession
            // 
            this.btnCloseSession.Location = new System.Drawing.Point(12, 260);
            this.btnCloseSession.Name = "btnCloseSession";
            this.btnCloseSession.Size = new System.Drawing.Size(356, 29);
            this.btnCloseSession.TabIndex = 2;
            this.btnCloseSession.Text = "Закрытие сессии";
            this.btnCloseSession.UseVisualStyleBackColor = true;
            this.btnCloseSession.Click += new System.EventHandler(this.btnCloseSession_Click);
            // 
            // btnEditSession
            // 
            this.btnEditSession.Location = new System.Drawing.Point(12, 295);
            this.btnEditSession.Name = "btnEditSession";
            this.btnEditSession.Size = new System.Drawing.Size(356, 29);
            this.btnEditSession.TabIndex = 3;
            this.btnEditSession.Text = "Редактирование сессии";
            this.btnEditSession.UseVisualStyleBackColor = true;
            this.btnEditSession.Click += new System.EventHandler(this.btnEditSession_Click);
            // 
            // btnDeleteSession
            // 
            this.btnDeleteSession.Location = new System.Drawing.Point(12, 330);
            this.btnDeleteSession.Name = "btnDeleteSession";
            this.btnDeleteSession.Size = new System.Drawing.Size(356, 29);
            this.btnDeleteSession.TabIndex = 4;
            this.btnDeleteSession.Text = "Удаление сессии";
            this.btnDeleteSession.UseVisualStyleBackColor = true;
            this.btnDeleteSession.Click += new System.EventHandler(this.btnDeleteSession_Click);
            // 
            // btnHistorySession
            // 
            this.btnHistorySession.Location = new System.Drawing.Point(12, 365);
            this.btnHistorySession.Name = "btnHistorySession";
            this.btnHistorySession.Size = new System.Drawing.Size(356, 30);
            this.btnHistorySession.TabIndex = 5;
            this.btnHistorySession.Text = "История сессий";
            this.btnHistorySession.UseVisualStyleBackColor = true;
            this.btnHistorySession.Click += new System.EventHandler(this.btnHistorySession_Click);
            // 
            // btnViewBar
            // 
            this.btnViewBar.Location = new System.Drawing.Point(425, 225);
            this.btnViewBar.Name = "btnViewBar";
            this.btnViewBar.Size = new System.Drawing.Size(363, 29);
            this.btnViewBar.TabIndex = 6;
            this.btnViewBar.Text = "Просмотр бара";
            this.btnViewBar.UseVisualStyleBackColor = true;
            this.btnViewBar.Click += new System.EventHandler(this.btnViewBar_Click);
            // 
            // btnClubMembers
            // 
            this.btnClubMembers.Location = new System.Drawing.Point(425, 260);
            this.btnClubMembers.Name = "btnClubMembers";
            this.btnClubMembers.Size = new System.Drawing.Size(363, 29);
            this.btnClubMembers.TabIndex = 7;
            this.btnClubMembers.Text = "Просмотр членов клуба";
            this.btnClubMembers.UseVisualStyleBackColor = true;
            this.btnClubMembers.Click += new System.EventHandler(this.btnClubMembers_Click);
            // 
            // btnViewTariff
            // 
            this.btnViewTariff.Location = new System.Drawing.Point(425, 295);
            this.btnViewTariff.Name = "btnViewTariff";
            this.btnViewTariff.Size = new System.Drawing.Size(363, 29);
            this.btnViewTariff.TabIndex = 8;
            this.btnViewTariff.Text = "Просмотр тарифов";
            this.btnViewTariff.UseVisualStyleBackColor = true;
            this.btnViewTariff.Click += new System.EventHandler(this.btnViewTariff_Click);
            // 
            // btnViewPlaces
            // 
            this.btnViewPlaces.Location = new System.Drawing.Point(425, 330);
            this.btnViewPlaces.Name = "btnViewPlaces";
            this.btnViewPlaces.Size = new System.Drawing.Size(363, 29);
            this.btnViewPlaces.TabIndex = 9;
            this.btnViewPlaces.Text = "Просмотр игровых мест";
            this.btnViewPlaces.UseVisualStyleBackColor = true;
            this.btnViewPlaces.Click += new System.EventHandler(this.btnViewPlaces_Click);
            // 
            // btnViewZone
            // 
            this.btnViewZone.Location = new System.Drawing.Point(425, 365);
            this.btnViewZone.Name = "btnViewZone";
            this.btnViewZone.Size = new System.Drawing.Size(363, 29);
            this.btnViewZone.TabIndex = 10;
            this.btnViewZone.Text = "Просмотр игровых зон";
            this.btnViewZone.UseVisualStyleBackColor = true;
            this.btnViewZone.Click += new System.EventHandler(this.btnViewZone_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 427);
            this.Controls.Add(this.btnViewZone);
            this.Controls.Add(this.btnViewPlaces);
            this.Controls.Add(this.btnViewTariff);
            this.Controls.Add(this.btnClubMembers);
            this.Controls.Add(this.btnViewBar);
            this.Controls.Add(this.btnHistorySession);
            this.Controls.Add(this.btnDeleteSession);
            this.Controls.Add(this.btnEditSession);
            this.Controls.Add(this.btnCloseSession);
            this.Controls.Add(this.btnOpenSession);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOpenSession;
        private System.Windows.Forms.Button btnCloseSession;
        private System.Windows.Forms.Button btnEditSession;
        private System.Windows.Forms.Button btnDeleteSession;
        private System.Windows.Forms.Button btnHistorySession;
        private System.Windows.Forms.Button btnViewBar;
        private System.Windows.Forms.Button btnClubMembers;
        private System.Windows.Forms.Button btnViewTariff;
        private System.Windows.Forms.Button btnViewPlaces;
        private System.Windows.Forms.Button btnViewZone;
    }
}