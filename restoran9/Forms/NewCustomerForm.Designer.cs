
namespace restoran9.Forms
{
    partial class NewCustomerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbIsPermanent = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО нового клиента:";
            // 
            // tbFullName
            // 
            this.tbFullName.Location = new System.Drawing.Point(201, 69);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(298, 27);
            this.tbFullName.TabIndex = 1;
            this.tbFullName.TextChanged += new System.EventHandler(this.tbFullName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Новый посетитель";
            // 
            // chbIsPermanent
            // 
            this.chbIsPermanent.AutoSize = true;
            this.chbIsPermanent.Location = new System.Drawing.Point(12, 118);
            this.chbIsPermanent.Name = "chbIsPermanent";
            this.chbIsPermanent.Size = new System.Drawing.Size(275, 24);
            this.chbIsPermanent.TabIndex = 3;
            this.chbIsPermanent.Text = "Постоянный клиент (+5% к скидке)";
            this.chbIsPermanent.UseVisualStyleBackColor = true;
            this.chbIsPermanent.CheckedChanged += new System.EventHandler(this.chbIsPermanent_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 167);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(195, 29);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Добавить посетителя";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(240, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NewCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chbIsPermanent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFullName);
            this.Controls.Add(this.label1);
            this.Name = "NewCustomerForm";
            this.Text = "NewCustomerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbIsPermanent;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}