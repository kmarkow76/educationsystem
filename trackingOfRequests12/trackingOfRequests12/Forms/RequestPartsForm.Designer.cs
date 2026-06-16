
namespace trackingOfRequests12.Forms
{
    partial class RequestPartsForm
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
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.btnDeletePart = new System.Windows.Forms.Button();
            this.cbSpareParts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvParts
            // 
            this.dgvParts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParts.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParts.Location = new System.Drawing.Point(12, 12);
            this.dgvParts.Name = "dgvParts";
            this.dgvParts.RowHeadersWidth = 51;
            this.dgvParts.RowTemplate.Height = 29;
            this.dgvParts.Size = new System.Drawing.Size(406, 188);
            this.dgvParts.TabIndex = 0;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(215, 258);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(150, 27);
            this.nudQuantity.TabIndex = 1;
            // 
            // btnAddPart
            // 
            this.btnAddPart.Location = new System.Drawing.Point(214, 296);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(204, 29);
            this.btnAddPart.TabIndex = 2;
            this.btnAddPart.Text = "Добавить деталь";
            this.btnAddPart.UseVisualStyleBackColor = true;
            this.btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            // 
            // btnDeletePart
            // 
            this.btnDeletePart.Location = new System.Drawing.Point(4, 296);
            this.btnDeletePart.Name = "btnDeletePart";
            this.btnDeletePart.Size = new System.Drawing.Size(204, 29);
            this.btnDeletePart.TabIndex = 3;
            this.btnDeletePart.Text = "Удалить деталь";
            this.btnDeletePart.UseVisualStyleBackColor = true;
            this.btnDeletePart.Click += new System.EventHandler(this.btnDeletePart_Click);
            // 
            // cbSpareParts
            // 
            this.cbSpareParts.FormattingEnabled = true;
            this.cbSpareParts.Location = new System.Drawing.Point(214, 217);
            this.cbSpareParts.Name = "cbSpareParts";
            this.cbSpareParts.Size = new System.Drawing.Size(151, 28);
            this.cbSpareParts.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Выберите деталь:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Введите количество:";
            // 
            // RequestPartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 350);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSpareParts);
            this.Controls.Add(this.btnDeletePart);
            this.Controls.Add(this.btnAddPart);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.dgvParts);
            this.Name = "RequestPartsForm";
            this.Text = "RequestPartsForm";
            this.Load += new System.EventHandler(this.RequestPartsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvParts;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.Button btnDeletePart;
        private System.Windows.Forms.ComboBox cbSpareParts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}