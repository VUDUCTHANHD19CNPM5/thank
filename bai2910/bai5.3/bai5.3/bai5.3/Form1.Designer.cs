namespace bai5._3
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
            pnlLeft = new Panel();
            flpTable = new FlowLayoutPanel();
            pnlRight = new Panel();
            btnQuanLyMenu = new Button();
            btnThanhToan = new Button();
            txtTongTien = new TextBox();
            label4 = new Label();
            dgvBill = new DataGridView();
            btnAddMon = new Button();
            nudSoLuong = new NumericUpDown();
            label3 = new Label();
            cbMonAn = new ComboBox();
            label2 = new Label();
            cbCategory = new ComboBox();
            label1 = new Label();
            lblTableTitle = new Label();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBill).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).BeginInit();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(flpTable);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(200, 611);
            pnlLeft.TabIndex = 0;
            // 
            // flpTable
            // 
            flpTable.AutoScroll = true;
            flpTable.Dock = DockStyle.Fill;
            flpTable.Location = new Point(0, 0);
            flpTable.Name = "flpTable";
            flpTable.Size = new Size(200, 611);
            flpTable.TabIndex = 0;
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(btnQuanLyMenu);
            pnlRight.Controls.Add(btnThanhToan);
            pnlRight.Controls.Add(txtTongTien);
            pnlRight.Controls.Add(label4);
            pnlRight.Controls.Add(dgvBill);
            pnlRight.Controls.Add(btnAddMon);
            pnlRight.Controls.Add(nudSoLuong);
            pnlRight.Controls.Add(label3);
            pnlRight.Controls.Add(cbMonAn);
            pnlRight.Controls.Add(label2);
            pnlRight.Controls.Add(cbCategory);
            pnlRight.Controls.Add(label1);
            pnlRight.Controls.Add(lblTableTitle);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(200, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(784, 611);
            pnlRight.TabIndex = 1;
            // 
            // btnQuanLyMenu
            // 
            btnQuanLyMenu.BackColor = Color.LightGray;
            btnQuanLyMenu.Location = new Point(697, 576);
            btnQuanLyMenu.Name = "btnQuanLyMenu";
            btnQuanLyMenu.Size = new Size(75, 23);
            btnQuanLyMenu.TabIndex = 13;
            btnQuanLyMenu.Text = "Quản lý Menu";
            btnQuanLyMenu.UseVisualStyleBackColor = false;
            btnQuanLyMenu.Click += btnQuanLyMenu_Click;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = SystemColors.Control;
            btnThanhToan.Font = new Font("Microsoft Sans Serif", 10F);
            btnThanhToan.Location = new Point(6, 576);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(115, 23);
            btnThanhToan.TabIndex = 12;
            btnThanhToan.Text = "THANH TOÁN";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // txtTongTien
            // 
            txtTongTien.Font = new Font("Microsoft Sans Serif", 12F);
            txtTongTien.ForeColor = Color.Red;
            txtTongTien.Location = new Point(105, 551);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.ReadOnly = true;
            txtTongTien.Size = new Size(100, 26);
            txtTongTien.TabIndex = 10;
            txtTongTien.Text = "0 VNĐ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11F);
            label4.Location = new Point(6, 555);
            label4.Name = "label4";
            label4.Size = new Size(93, 18);
            label4.TabIndex = 9;
            label4.Text = "TỔNG TIỀN:";
            // 
            // dgvBill
            // 
            dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBill.Location = new Point(6, 179);
            dgvBill.Name = "dgvBill";
            dgvBill.Size = new Size(766, 366);
            dgvBill.TabIndex = 8;
            // 
            // btnAddMon
            // 
            btnAddMon.BackColor = SystemColors.Control;
            btnAddMon.Location = new Point(36, 150);
            btnAddMon.Name = "btnAddMon";
            btnAddMon.Size = new Size(75, 23);
            btnAddMon.TabIndex = 7;
            btnAddMon.Text = "Thêm món";
            btnAddMon.UseVisualStyleBackColor = false;
            btnAddMon.Click += btnAddMon_Click;
            // 
            // nudSoLuong
            // 
            nudSoLuong.Location = new Point(77, 109);
            nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoLuong.Name = "nudSoLuong";
            nudSoLuong.Size = new Size(120, 23);
            nudSoLuong.TabIndex = 6;
            nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 109);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 5;
            label3.Text = "Số lượng:";
            // 
            // cbMonAn
            // 
            cbMonAn.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMonAn.FormattingEnabled = true;
            cbMonAn.Location = new Point(77, 72);
            cbMonAn.Name = "cbMonAn";
            cbMonAn.Size = new Size(121, 23);
            cbMonAn.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 72);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "Món ăn:";
            // 
            // cbCategory
            // 
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(77, 32);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(121, 23);
            cbCategory.TabIndex = 2;
            cbCategory.SelectedIndexChanged += cbCategory_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 35);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 1;
            label1.Text = "Danh mục:";
            // 
            // lblTableTitle
            // 
            lblTableTitle.AutoSize = true;
            lblTableTitle.Font = new Font("Microsoft Sans Serif", 12F);
            lblTableTitle.Location = new Point(6, 9);
            lblTableTitle.Name = "lblTableTitle";
            lblTableTitle.Size = new Size(203, 20);
            lblTableTitle.TabIndex = 0;
            lblTableTitle.Text = "Đang chọn: Chưa chọn bàn";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 611);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống quản lý POS Cafe";
            Load += Form1_Load;
            pnlLeft.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBill).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
        private FlowLayoutPanel flpTable;
        private Panel pnlRight;
        private ComboBox cbCategory;
        private Label label1;
        private Label lblTableTitle;
        private ComboBox cbMonAn;
        private Label label2;
        private Button btnAddMon;
        private NumericUpDown nudSoLuong;
        private Label label3;
        private Button btnThanhToan;
        private TextBox txtTongTien;
        private Label label4;
        private DataGridView dgvBill;
        private Button btnQuanLyMenu;
    }
}
