namespace restoran9.Forms
{
    partial class OrderForm
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
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.btnAddNewCustomer = new System.Windows.Forms.Button(); // ДОБАВИЛИ ОБЪЯВЛЕНИЕ КНОПКИ ПЛЮС
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDish = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddDish = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFinalAmount = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите клиента:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(198, 33);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(260, 28);
            this.cmbCustomer.TabIndex = 1;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.Location = new System.Drawing.Point(469, 32); // Встанет аккуратно справа от cmbCustomer
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(40, 30);
            this.btnAddNewCustomer.TabIndex = 23;
            this.btnAddNewCustomer.Text = "+";
            this.btnAddNewCustomer.UseVisualStyleBackColor = true;
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click); // Связали событие с кодом логики!
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Столик №:";
            // 
            // cmbTable
            // 
            this.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(198, 84);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(260, 28);
            this.cmbTable.TabIndex = 3;
            this.cmbTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Обслуживающий официант:";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(239, 138);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(274, 28);
            this.cmbEmployee.TabIndex = 5;
            this.cmbEmployee.SelectedIndexChanged += new System.EventHandler(this.cmbEmployee_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Выберите блюдо из меню:";
            // 
            // cmbDish
            // 
            this.cmbDish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDish.FormattingEnabled = true;
            this.cmbDish.Location = new System.Drawing.Point(239, 189);
            this.cmbDish.Name = "cmbDish";
            this.cmbDish.Size = new System.Drawing.Size(274, 28);
            this.cmbDish.TabIndex = 7;
            this.cmbDish.SelectedIndexChanged += new System.EventHandler(this.cmbDish_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Количество:";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(239, 234);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(150, 27);
            this.numQuantity.TabIndex = 9;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            // 
            // btnAddDish
            // 
            this.btnAddDish.Location = new System.Drawing.Point(12, 286);
            this.btnAddDish.Name = "btnAddDish";
            this.btnAddDish.Size = new System.Drawing.Size(227, 29);
            this.btnAddDish.TabIndex = 10;
            this.btnAddDish.Text = "Добавить в чек";
            this.btnAddDish.UseVisualStyleBackColor = true;
            this.btnAddDish.Click += new System.EventHandler(this.btnAddDish_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(620, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Содержимое заказа:";
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(620, 73);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.RowHeadersWidth = 51;
            this.dgvOrderItems.RowTemplate.Height = 29;
            this.dgvOrderItems.Size = new System.Drawing.Size(729, 144);
            this.dgvOrderItems.TabIndex = 12;
            this.dgvOrderItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItems_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(620, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Текущий статус заказа:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Создан",
            "",
            "Готовится",
            "",
            "Выполнен",
            "",
            "Оплачен"});
            this.cmbStatus.Location = new System.Drawing.Point(829, 234);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(157, 28);
            this.cmbStatus.TabIndex = 14;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(620, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Стоимость заказа (руб.):";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(829, 286);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(157, 27);
            this.txtTotalAmount.TabIndex = 16;
            this.txtTotalAmount.TextChanged += new System.EventHandler(this.txtTotalAmount_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(620, 348);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(183, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "Рассчитанная скидка (%):";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(829, 348);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(157, 27);
            this.txtDiscount.TabIndex = 18;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(620, 397);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "Итого к оплате (руб.):";
            // 
            // txtFinalAmount
            // 
            this.txtFinalAmount.Location = new System.Drawing.Point(829, 397);
            this.txtFinalAmount.Name = "txtFinalAmount";
            this.txtFinalAmount.ReadOnly = true;
            this.txtFinalAmount.Size = new System.Drawing.Size(157, 27);
            this.txtFinalAmount.TabIndex = 20;
            this.txtFinalAmount.TextChanged += new System.EventHandler(this.txtFinalAmount_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(620, 462);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(216, 29);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Сохранить заказ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(864, 462);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 29);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 547);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFinalAmount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAddDish);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDish);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddNewCustomer); // ДОБАВИЛИ КНОПКУ НА ЭКРАН
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label1);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnAddNewCustomer; // ДОБАВИЛИ ПОЛЕ КНОПКИ
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDish;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddDish;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFinalAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}