
namespace cyberclub14.Forms
{
    partial class OpenSessionForm
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
            this.cbMembers = new System.Windows.Forms.ComboBox();
            this.cbPlaces = new System.Windows.Forms.ComboBox();
            this.cbTariffs = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbMembers
            // 
            this.cbMembers.FormattingEnabled = true;
            this.cbMembers.Location = new System.Drawing.Point(136, 48);
            this.cbMembers.Name = "cbMembers";
            this.cbMembers.Size = new System.Drawing.Size(205, 28);
            this.cbMembers.TabIndex = 0;
            // 
            // cbPlaces
            // 
            this.cbPlaces.FormattingEnabled = true;
            this.cbPlaces.Location = new System.Drawing.Point(136, 87);
            this.cbPlaces.Name = "cbPlaces";
            this.cbPlaces.Size = new System.Drawing.Size(205, 28);
            this.cbPlaces.TabIndex = 1;
            // 
            // cbTariffs
            // 
            this.cbTariffs.FormattingEnabled = true;
            this.cbTariffs.Location = new System.Drawing.Point(136, 131);
            this.cbTariffs.Name = "cbTariffs";
            this.cbTariffs.Size = new System.Drawing.Size(205, 28);
            this.cbTariffs.TabIndex = 2;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(53, 182);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(201, 29);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Открыть сессию";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Клиент:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Игровое место:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Тариф:";
            // 
            // OpenSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 266);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.cbTariffs);
            this.Controls.Add(this.cbPlaces);
            this.Controls.Add(this.cbMembers);
            this.Name = "OpenSessionForm";
            this.Text = "OpenSessionForm";
            this.Load += new System.EventHandler(this.OpenSessionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMembers;
        private System.Windows.Forms.ComboBox cbPlaces;
        private System.Windows.Forms.ComboBox cbTariffs;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}