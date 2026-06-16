
namespace pharmacy8.Forms
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
            this.btnViewReceipt = new System.Windows.Forms.Button();
            this.btnViewSale = new System.Windows.Forms.Button();
            this.btnViewSupplier = new System.Windows.Forms.Button();
            this.btnViewEmployee = new System.Windows.Forms.Button();
            this.btnViewCustomer = new System.Windows.Forms.Button();
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
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 207);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(197, 29);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить препарат";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 243);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(198, 29);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Редактировать препарат";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(13, 279);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(197, 29);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Удалить препарат";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnViewReceipt
            // 
            this.btnViewReceipt.Location = new System.Drawing.Point(235, 207);
            this.btnViewReceipt.Name = "btnViewReceipt";
            this.btnViewReceipt.Size = new System.Drawing.Size(194, 29);
            this.btnViewReceipt.TabIndex = 4;
            this.btnViewReceipt.Text = "Поступление";
            this.btnViewReceipt.UseVisualStyleBackColor = true;
            this.btnViewReceipt.Click += new System.EventHandler(this.btnViewReceipt_Click);
            // 
            // btnViewSale
            // 
            this.btnViewSale.Location = new System.Drawing.Point(235, 243);
            this.btnViewSale.Name = "btnViewSale";
            this.btnViewSale.Size = new System.Drawing.Size(194, 29);
            this.btnViewSale.TabIndex = 5;
            this.btnViewSale.Text = "Продажа";
            this.btnViewSale.UseVisualStyleBackColor = true;
            this.btnViewSale.Click += new System.EventHandler(this.btnViewSale_Click);
            // 
            // btnViewSupplier
            // 
            this.btnViewSupplier.Location = new System.Drawing.Point(589, 208);
            this.btnViewSupplier.Name = "btnViewSupplier";
            this.btnViewSupplier.Size = new System.Drawing.Size(199, 29);
            this.btnViewSupplier.TabIndex = 6;
            this.btnViewSupplier.Text = "Просмотр поставщиков";
            this.btnViewSupplier.UseVisualStyleBackColor = true;
            this.btnViewSupplier.Click += new System.EventHandler(this.btnViewSupplier_Click);
            // 
            // btnViewEmployee
            // 
            this.btnViewEmployee.Location = new System.Drawing.Point(589, 243);
            this.btnViewEmployee.Name = "btnViewEmployee";
            this.btnViewEmployee.Size = new System.Drawing.Size(199, 29);
            this.btnViewEmployee.TabIndex = 7;
            this.btnViewEmployee.Text = "Просмотр сотрудников";
            this.btnViewEmployee.UseVisualStyleBackColor = true;
            this.btnViewEmployee.Click += new System.EventHandler(this.btnViewEmployee_Click);
            // 
            // btnViewCustomer
            // 
            this.btnViewCustomer.Location = new System.Drawing.Point(589, 279);
            this.btnViewCustomer.Name = "btnViewCustomer";
            this.btnViewCustomer.Size = new System.Drawing.Size(199, 29);
            this.btnViewCustomer.TabIndex = 8;
            this.btnViewCustomer.Text = "Просмотр покупателей";
            this.btnViewCustomer.UseVisualStyleBackColor = true;
            this.btnViewCustomer.Click += new System.EventHandler(this.btnViewCustomer_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 334);
            this.Controls.Add(this.btnViewCustomer);
            this.Controls.Add(this.btnViewEmployee);
            this.Controls.Add(this.btnViewSupplier);
            this.Controls.Add(this.btnViewSale);
            this.Controls.Add(this.btnViewReceipt);
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
        private System.Windows.Forms.Button btnViewReceipt;
        private System.Windows.Forms.Button btnViewSale;
        private System.Windows.Forms.Button btnViewSupplier;
        private System.Windows.Forms.Button btnViewEmployee;
        private System.Windows.Forms.Button btnViewCustomer;
    }
}