
namespace trackingOfRequests12.Forms
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
            this.btnViewEmployee = new System.Windows.Forms.Button();
            this.btnViewDevice = new System.Windows.Forms.Button();
            this.btnViewClient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1051, 188);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 219);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(340, 29);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить заяку";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 254);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(341, 29);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Редактировать заявку";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 289);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(341, 29);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Удалить заяку";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnViewEmployee
            // 
            this.btnViewEmployee.Location = new System.Drawing.Point(730, 289);
            this.btnViewEmployee.Name = "btnViewEmployee";
            this.btnViewEmployee.Size = new System.Drawing.Size(334, 29);
            this.btnViewEmployee.TabIndex = 4;
            this.btnViewEmployee.Text = "Просмотр сотрудников";
            this.btnViewEmployee.UseVisualStyleBackColor = true;
            this.btnViewEmployee.Click += new System.EventHandler(this.btnViewEmployee_Click);
            // 
            // btnViewDevice
            // 
            this.btnViewDevice.Location = new System.Drawing.Point(730, 254);
            this.btnViewDevice.Name = "btnViewDevice";
            this.btnViewDevice.Size = new System.Drawing.Size(334, 29);
            this.btnViewDevice.TabIndex = 5;
            this.btnViewDevice.Text = "Просмотр техники";
            this.btnViewDevice.UseVisualStyleBackColor = true;
            this.btnViewDevice.Click += new System.EventHandler(this.btnViewDevice_Click);
            // 
            // btnViewClient
            // 
            this.btnViewClient.Location = new System.Drawing.Point(730, 219);
            this.btnViewClient.Name = "btnViewClient";
            this.btnViewClient.Size = new System.Drawing.Size(334, 29);
            this.btnViewClient.TabIndex = 6;
            this.btnViewClient.Text = "Просмотр клиентов";
            this.btnViewClient.UseVisualStyleBackColor = true;
            this.btnViewClient.Click += new System.EventHandler(this.btnViewClient_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 332);
            this.Controls.Add(this.btnViewClient);
            this.Controls.Add(this.btnViewDevice);
            this.Controls.Add(this.btnViewEmployee);
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
        private System.Windows.Forms.Button btnViewEmployee;
        private System.Windows.Forms.Button btnViewDevice;
        private System.Windows.Forms.Button btnViewClient;
    }
}