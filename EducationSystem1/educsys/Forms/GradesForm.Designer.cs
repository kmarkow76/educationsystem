
namespace educsys.Forms
{
    partial class GradesForm
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
            this.lblAverage = new System.Windows.Forms.Label();
            this.lblAccess = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(44, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(729, 188);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(93, 251);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(50, 20);
            this.lblAverage.TabIndex = 1;
            this.lblAverage.Text = "label1";
            // 
            // lblAccess
            // 
            this.lblAccess.AutoSize = true;
            this.lblAccess.Location = new System.Drawing.Point(93, 290);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(50, 20);
            this.lblAccess.TabIndex = 2;
            this.lblAccess.Text = "label1";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(93, 344);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(163, 27);
            this.dtpFrom.TabIndex = 3;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(295, 344);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(159, 27);
            this.dtpTo.TabIndex = 4;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(93, 386);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(361, 30);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.Text = "Рассчитать средний балл за период";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(540, 386);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(233, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // GradesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblAccess);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GradesForm";
            this.Text = "GradesForm";
            this.Load += new System.EventHandler(this.GradesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.Label lblAccess;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClose;
    }
}