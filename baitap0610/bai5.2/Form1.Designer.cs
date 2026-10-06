namespace bai5._2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblCategory = new Label();
            lblTotalTitle = new Label();
            lblTotal = new Label();
            lblDiscountTitle = new Label();
            lblDiscount = new Label();
            lblPaymentTitle = new Label();
            lblPayment = new Label();
            cboCategory = new ComboBox();
            lstAvailableServices = new ListBox();
            lstSelectedServices = new ListBox();
            btnSelect = new Button();
            btnRemove = new Button();
            btnClearAll = new Button();
            lblAvailable = new Label();
            lblSelected = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(184, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(147, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BẢNG TÍNH TIỀN DỊCH VỤ";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(64, 50);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(74, 15);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "Loại dịch vụ:";
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Location = new Point(64, 216);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(120, 15);
            lblTotalTitle.TabIndex = 2;
            lblTotalTitle.Text = "Tổng tiền chưa giảm:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(198, 216);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(40, 15);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "0 VNĐ";
            // 
            // lblDiscountTitle
            // 
            lblDiscountTitle.AutoSize = true;
            lblDiscountTitle.Location = new Point(64, 250);
            lblDiscountTitle.Name = "lblDiscountTitle";
            lblDiscountTitle.Size = new Size(93, 15);
            lblDiscountTitle.TabIndex = 4;
            lblDiscountTitle.Text = "Tỷ lệ chiết khấu:";
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(198, 250);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(23, 15);
            lblDiscount.TabIndex = 5;
            lblDiscount.Text = "0%";
            // 
            // lblPaymentTitle
            // 
            lblPaymentTitle.AutoSize = true;
            lblPaymentTitle.Location = new Point(64, 290);
            lblPaymentTitle.Name = "lblPaymentTitle";
            lblPaymentTitle.Size = new Size(128, 15);
            lblPaymentTitle.TabIndex = 6;
            lblPaymentTitle.Text = "Thành tiền thanh toán:";
            // 
            // lblPayment
            // 
            lblPayment.AutoSize = true;
            lblPayment.Location = new Point(198, 290);
            lblPayment.Name = "lblPayment";
            lblPayment.Size = new Size(40, 15);
            lblPayment.TabIndex = 7;
            lblPayment.Text = "0 VNĐ";
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(155, 47);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(121, 23);
            cboCategory.TabIndex = 10;
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            // 
            // lstAvailableServices
            // 
            lstAvailableServices.FormattingEnabled = true;
            lstAvailableServices.Location = new Point(64, 98);
            lstAvailableServices.Name = "lstAvailableServices";
            lstAvailableServices.Size = new Size(174, 94);
            lstAvailableServices.TabIndex = 11;
            // 
            // lstSelectedServices
            // 
            lstSelectedServices.FormattingEnabled = true;
            lstSelectedServices.Location = new Point(356, 98);
            lstSelectedServices.Name = "lstSelectedServices";
            lstSelectedServices.Size = new Size(174, 94);
            lstSelectedServices.TabIndex = 12;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(261, 98);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(75, 23);
            btnSelect.TabIndex = 13;
            btnSelect.Text = ">";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(261, 127);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 14;
            btnRemove.Text = "<";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnClearAll
            // 
            btnClearAll.Location = new Point(261, 156);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(75, 23);
            btnClearAll.TabIndex = 15;
            btnClearAll.Text = "<<";
            btnClearAll.UseVisualStyleBackColor = true;
            btnClearAll.Click += btnClearAll_Click;
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.Location = new Point(100, 80);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(84, 15);
            lblAvailable.TabIndex = 16;
            lblAvailable.Text = "Dịch vụ có sẵn";
            // 
            // lblSelected
            // 
            lblSelected.AutoSize = true;
            lblSelected.Location = new Point(396, 80);
            lblSelected.Name = "lblSelected";
            lblSelected.Size = new Size(93, 15);
            lblSelected.TabIndex = 17;
            lblSelected.Text = "Dịch vụ đã chọn";
            lblSelected.Click += lblSelected_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblSelected);
            Controls.Add(lblAvailable);
            Controls.Add(btnClearAll);
            Controls.Add(btnRemove);
            Controls.Add(btnSelect);
            Controls.Add(lstSelectedServices);
            Controls.Add(lstAvailableServices);
            Controls.Add(cboCategory);
            Controls.Add(lblPayment);
            Controls.Add(lblPaymentTitle);
            Controls.Add(lblDiscount);
            Controls.Add(lblDiscountTitle);
            Controls.Add(lblTotal);
            Controls.Add(lblTotalTitle);
            Controls.Add(lblCategory);
            Controls.Add(lblTitle);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCategory;
        private Label lblTotalTitle;
        private Label lblTotal;
        private Label lblDiscountTitle;
        private Label lblDiscount;
        private Label lblPaymentTitle;
        private Label lblPayment;
        private ComboBox cboCategory;
        private ListBox lstAvailableServices;
        private ListBox lstSelectedServices;
        private Button btnSelect;
        private Button btnRemove;
        private Button btnClearAll;
        private Label lblAvailable;
        private Label lblSelected;
    }
}
