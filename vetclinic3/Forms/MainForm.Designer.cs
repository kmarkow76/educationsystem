namespace vetclinic3.Forms
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.btnAddApp = new System.Windows.Forms.Button();
            this.btnEditApp = new System.Windows.Forms.Button();
            this.btnDeleteApp = new System.Windows.Forms.Button();
            this.btnCancelApp = new System.Windows.Forms.Button();
            this.dgvAnimals = new System.Windows.Forms.DataGridView();
            this.btnAddAnimal = new System.Windows.Forms.Button();
            this.btnEditAnimal = new System.Windows.Forms.Button();
            this.btnDeleteAnimal = new System.Windows.Forms.Button();
            this.dgvOwners = new System.Windows.Forms.DataGridView();
            this.btnAddOwner = new System.Windows.Forms.Button();
            this.btnEditOwner = new System.Windows.Forms.Button();
            this.btnDeleteOwner = new System.Windows.Forms.Button();
            this.btnAddVet = new System.Windows.Forms.Button();
            this.btnEditVet = new System.Windows.Forms.Button();
            this.btnDeleteVet = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwners)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(23, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1356, 405);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnCancelApp);
            this.tabPage1.Controls.Add(this.btnDeleteApp);
            this.tabPage1.Controls.Add(this.btnEditApp);
            this.tabPage1.Controls.Add(this.btnAddApp);
            this.tabPage1.Controls.Add(this.dgvAppointments);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1348, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Журнал приемов животных";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDeleteAnimal);
            this.tabPage2.Controls.Add(this.btnEditAnimal);
            this.tabPage2.Controls.Add(this.btnAddAnimal);
            this.tabPage2.Controls.Add(this.dgvAnimals);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1348, 372);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Электронные медкарты (Животные)";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnDeleteVet);
            this.tabPage3.Controls.Add(this.btnEditVet);
            this.tabPage3.Controls.Add(this.btnAddVet);
            this.tabPage3.Controls.Add(this.btnDeleteOwner);
            this.tabPage3.Controls.Add(this.btnEditOwner);
            this.tabPage3.Controls.Add(this.btnAddOwner);
            this.tabPage3.Controls.Add(this.dgvOwners);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1348, 372);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Владельцы и Врачебный состав";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Location = new System.Drawing.Point(15, 17);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersWidth = 51;
            this.dgvAppointments.RowTemplate.Height = 29;
            this.dgvAppointments.Size = new System.Drawing.Size(1312, 206);
            this.dgvAppointments.TabIndex = 0;
            this.dgvAppointments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointments_CellContentClick);
            // 
            // btnAddApp
            // 
            this.btnAddApp.Location = new System.Drawing.Point(15, 268);
            this.btnAddApp.Name = "btnAddApp";
            this.btnAddApp.Size = new System.Drawing.Size(260, 29);
            this.btnAddApp.TabIndex = 1;
            this.btnAddApp.Text = "Записать на прием";
            this.btnAddApp.UseVisualStyleBackColor = true;
            this.btnAddApp.Click += new System.EventHandler(this.btnAddApp_Click);
            // 
            // btnEditApp
            // 
            this.btnEditApp.Location = new System.Drawing.Point(322, 268);
            this.btnEditApp.Name = "btnEditApp";
            this.btnEditApp.Size = new System.Drawing.Size(248, 29);
            this.btnEditApp.TabIndex = 2;
            this.btnEditApp.Text = "Редактировать прием";
            this.btnEditApp.UseVisualStyleBackColor = true;
            this.btnEditApp.Click += new System.EventHandler(this.btnEditApp_Click);
            // 
            // btnDeleteApp
            // 
            this.btnDeleteApp.BackColor = System.Drawing.Color.Red;
            this.btnDeleteApp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteApp.Location = new System.Drawing.Point(614, 268);
            this.btnDeleteApp.Name = "btnDeleteApp";
            this.btnDeleteApp.Size = new System.Drawing.Size(209, 29);
            this.btnDeleteApp.TabIndex = 3;
            this.btnDeleteApp.Text = "Удалить запись";
            this.btnDeleteApp.UseVisualStyleBackColor = false;
            this.btnDeleteApp.Click += new System.EventHandler(this.btnDeleteApp_Click);
            // 
            // btnCancelApp
            // 
            this.btnCancelApp.Location = new System.Drawing.Point(871, 268);
            this.btnCancelApp.Name = "btnCancelApp";
            this.btnCancelApp.Size = new System.Drawing.Size(320, 29);
            this.btnCancelApp.TabIndex = 4;
            this.btnCancelApp.Text = "Отменить прием (Смена статуса)";
            this.btnCancelApp.UseVisualStyleBackColor = true;
            this.btnCancelApp.Click += new System.EventHandler(this.btnCancelApp_Click);
            // 
            // dgvAnimals
            // 
            this.dgvAnimals.AllowUserToAddRows = false;
            this.dgvAnimals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnimals.Location = new System.Drawing.Point(17, 19);
            this.dgvAnimals.Name = "dgvAnimals";
            this.dgvAnimals.ReadOnly = true;
            this.dgvAnimals.RowHeadersWidth = 51;
            this.dgvAnimals.RowTemplate.Height = 29;
            this.dgvAnimals.Size = new System.Drawing.Size(1325, 188);
            this.dgvAnimals.TabIndex = 0;
            this.dgvAnimals.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnimals_CellContentClick);
            // 
            // btnAddAnimal
            // 
            this.btnAddAnimal.Location = new System.Drawing.Point(17, 244);
            this.btnAddAnimal.Name = "btnAddAnimal";
            this.btnAddAnimal.Size = new System.Drawing.Size(236, 29);
            this.btnAddAnimal.TabIndex = 1;
            this.btnAddAnimal.Text = "Завести медкарту";
            this.btnAddAnimal.UseVisualStyleBackColor = true;
            this.btnAddAnimal.Click += new System.EventHandler(this.btnAddAnimal_Click);
            // 
            // btnEditAnimal
            // 
            this.btnEditAnimal.Location = new System.Drawing.Point(296, 244);
            this.btnEditAnimal.Name = "btnEditAnimal";
            this.btnEditAnimal.Size = new System.Drawing.Size(250, 29);
            this.btnEditAnimal.TabIndex = 2;
            this.btnEditAnimal.Text = "Изменить данные карты";
            this.btnEditAnimal.UseVisualStyleBackColor = true;
            this.btnEditAnimal.Click += new System.EventHandler(this.btnEditAnimal_Click);
            // 
            // btnDeleteAnimal
            // 
            this.btnDeleteAnimal.Location = new System.Drawing.Point(597, 244);
            this.btnDeleteAnimal.Name = "btnDeleteAnimal";
            this.btnDeleteAnimal.Size = new System.Drawing.Size(209, 29);
            this.btnDeleteAnimal.TabIndex = 3;
            this.btnDeleteAnimal.Text = "Удалить медкарту";
            this.btnDeleteAnimal.UseVisualStyleBackColor = true;
            this.btnDeleteAnimal.Click += new System.EventHandler(this.btnDeleteAnimal_Click);
            // 
            // dgvOwners
            // 
            this.dgvOwners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOwners.Location = new System.Drawing.Point(18, 16);
            this.dgvOwners.Name = "dgvOwners";
            this.dgvOwners.RowHeadersWidth = 51;
            this.dgvOwners.RowTemplate.Height = 29;
            this.dgvOwners.Size = new System.Drawing.Size(1309, 188);
            this.dgvOwners.TabIndex = 0;
            this.dgvOwners.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOwners_CellContentClick);
            // 
            // btnAddOwner
            // 
            this.btnAddOwner.Location = new System.Drawing.Point(18, 232);
            this.btnAddOwner.Name = "btnAddOwner";
            this.btnAddOwner.Size = new System.Drawing.Size(248, 29);
            this.btnAddOwner.TabIndex = 1;
            this.btnAddOwner.Text = "Добавить владельца";
            this.btnAddOwner.UseVisualStyleBackColor = true;
            this.btnAddOwner.Click += new System.EventHandler(this.btnAddOwner_Click);
            // 
            // btnEditOwner
            // 
            this.btnEditOwner.Location = new System.Drawing.Point(18, 279);
            this.btnEditOwner.Name = "btnEditOwner";
            this.btnEditOwner.Size = new System.Drawing.Size(248, 29);
            this.btnEditOwner.TabIndex = 2;
            this.btnEditOwner.Text = "Изменить владельца";
            this.btnEditOwner.UseVisualStyleBackColor = true;
            this.btnEditOwner.Click += new System.EventHandler(this.btnEditOwner_Click);
            // 
            // btnDeleteOwner
            // 
            this.btnDeleteOwner.Location = new System.Drawing.Point(18, 325);
            this.btnDeleteOwner.Name = "btnDeleteOwner";
            this.btnDeleteOwner.Size = new System.Drawing.Size(248, 29);
            this.btnDeleteOwner.TabIndex = 3;
            this.btnDeleteOwner.Text = "Удалить владельца";
            this.btnDeleteOwner.UseVisualStyleBackColor = true;
            this.btnDeleteOwner.Click += new System.EventHandler(this.btnDeleteOwner_Click);
            // 
            // btnAddVet
            // 
            this.btnAddVet.Location = new System.Drawing.Point(400, 232);
            this.btnAddVet.Name = "btnAddVet";
            this.btnAddVet.Size = new System.Drawing.Size(235, 29);
            this.btnAddVet.TabIndex = 4;
            this.btnAddVet.Text = "Добавить врача";
            this.btnAddVet.UseVisualStyleBackColor = true;
            this.btnAddVet.Click += new System.EventHandler(this.btnAddVet_Click);
            // 
            // btnEditVet
            // 
            this.btnEditVet.Location = new System.Drawing.Point(400, 279);
            this.btnEditVet.Name = "btnEditVet";
            this.btnEditVet.Size = new System.Drawing.Size(235, 29);
            this.btnEditVet.TabIndex = 5;
            this.btnEditVet.Text = "Изменить данные врача";
            this.btnEditVet.UseVisualStyleBackColor = true;
            this.btnEditVet.Click += new System.EventHandler(this.btnEditVet_Click);
            // 
            // btnDeleteVet
            // 
            this.btnDeleteVet.Location = new System.Drawing.Point(400, 325);
            this.btnDeleteVet.Name = "btnDeleteVet";
            this.btnDeleteVet.Size = new System.Drawing.Size(235, 29);
            this.btnDeleteVet.TabIndex = 6;
            this.btnDeleteVet.Text = "Удалить врача";
            this.btnDeleteVet.UseVisualStyleBackColor = true;
            this.btnDeleteVet.Click += new System.EventHandler(this.btnDeleteVet_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1391, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Информационная система ветеринарной клиники";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwners)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnCancelApp;
        private System.Windows.Forms.Button btnDeleteApp;

        // Внимание: Здесь изменены типы на явные системные структуры (Решение CS0234)
        private System.Windows.Forms.Button btnEditApp;
        private System.Windows.Forms.Button btnAddApp;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnDeleteAnimal;
        private System.Windows.Forms.Button btnEditAnimal;
        private System.Windows.Forms.Button btnAddAnimal;
        private System.Windows.Forms.DataGridView dgvAnimals;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnDeleteOwner;
        private System.Windows.Forms.Button btnEditOwner;
        private System.Windows.Forms.Button btnAddOwner;
        private System.Windows.Forms.DataGridView dgvOwners;
        private System.Windows.Forms.Button btnDeleteVet;
        private System.Windows.Forms.Button btnEditVet;
        private System.Windows.Forms.Button btnAddVet;
    }
}