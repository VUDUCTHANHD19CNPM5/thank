namespace bai5._5
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
            grpCanhBao = new GroupBox();
            dgvCanhBao = new DataGridView();
            grpVatTu = new GroupBox();
            dgvVatTu = new DataGridView();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            pnlRight = new Panel();
            grpBaoCao = new GroupBox();
            lblTongGiaTriKho = new Label();
            grpLapPhieu = new GroupBox();
            btnLuuPhieu = new Button();
            lblTongTienPhieu = new Label();
            dgvChiTietPhieu = new DataGridView();
            btnThemVatTuVaoPhieu = new Button();
            nudDonGia = new NumericUpDown();
            label6 = new Label();
            nudSoLuong = new NumericUpDown();
            label5 = new Label();
            txtDVTChon = new TextBox();
            label3 = new Label();
            txtTenVatTuChon = new TextBox();
            label2 = new Label();
            txtMaVatTuChon = new TextBox();
            label1 = new Label();
            cbNhaCungCap = new ComboBox();
            lblNhaCungCap = new Label();
            cbLoaiPhieu = new ComboBox();
            lblLoaiPhieu = new Label();
            pnlLeft.SuspendLayout();
            grpCanhBao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCanhBao).BeginInit();
            grpVatTu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVatTu).BeginInit();
            pnlRight.SuspendLayout();
            grpBaoCao.SuspendLayout();
            grpLapPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPhieu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).BeginInit();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(grpCanhBao);
            pnlLeft.Controls.Add(grpVatTu);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(480, 661);
            pnlLeft.TabIndex = 0;
            // 
            // grpCanhBao
            // 
            grpCanhBao.Controls.Add(dgvCanhBao);
            grpCanhBao.Dock = DockStyle.Fill;
            grpCanhBao.Location = new Point(0, 420);
            grpCanhBao.Name = "grpCanhBao";
            grpCanhBao.Size = new Size(480, 241);
            grpCanhBao.TabIndex = 1;
            grpCanhBao.TabStop = false;
            grpCanhBao.Text = "Cảnh báo tồn kho dưới ngưỡng (<=10)";
            // 
            // dgvCanhBao
            // 
            dgvCanhBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCanhBao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCanhBao.Location = new Point(6, 22);
            dgvCanhBao.Name = "dgvCanhBao";
            dgvCanhBao.ReadOnly = true;
            dgvCanhBao.Size = new Size(468, 213);
            dgvCanhBao.TabIndex = 0;
            // 
            // grpVatTu
            // 
            grpVatTu.Controls.Add(dgvVatTu);
            grpVatTu.Controls.Add(txtTimKiem);
            grpVatTu.Controls.Add(lblTimKiem);
            grpVatTu.Dock = DockStyle.Top;
            grpVatTu.Location = new Point(0, 0);
            grpVatTu.Name = "grpVatTu";
            grpVatTu.Size = new Size(480, 420);
            grpVatTu.TabIndex = 0;
            grpVatTu.TabStop = false;
            grpVatTu.Text = "Danh mục Vật tư & Tìm kiếm";
            // 
            // dgvVatTu
            // 
            dgvVatTu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVatTu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVatTu.Location = new Point(3, 45);
            dgvVatTu.Name = "dgvVatTu";
            dgvVatTu.ReadOnly = true;
            dgvVatTu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVatTu.Size = new Size(474, 369);
            dgvVatTu.TabIndex = 2;
            dgvVatTu.CellClick += dgvVatTu_CellClick;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(78, 16);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(100, 23);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(12, 19);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(60, 15);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(grpBaoCao);
            pnlRight.Controls.Add(grpLapPhieu);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(480, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(654, 661);
            pnlRight.TabIndex = 1;
            // 
            // grpBaoCao
            // 
            grpBaoCao.Controls.Add(lblTongGiaTriKho);
            grpBaoCao.Dock = DockStyle.Fill;
            grpBaoCao.Location = new Point(0, 520);
            grpBaoCao.Name = "grpBaoCao";
            grpBaoCao.Size = new Size(654, 141);
            grpBaoCao.TabIndex = 1;
            grpBaoCao.TabStop = false;
            grpBaoCao.Text = "Báo cáo tồn kho";
            // 
            // lblTongGiaTriKho
            // 
            lblTongGiaTriKho.AutoSize = true;
            lblTongGiaTriKho.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblTongGiaTriKho.Location = new Point(6, 19);
            lblTongGiaTriKho.Name = "lblTongGiaTriKho";
            lblTongGiaTriKho.Size = new Size(167, 13);
            lblTongGiaTriKho.TabIndex = 0;
            lblTongGiaTriKho.Text = "TỔNG GIÁ TRỊ TỒN KHO: 0VNĐ";
            // 
            // grpLapPhieu
            // 
            grpLapPhieu.Controls.Add(btnLuuPhieu);
            grpLapPhieu.Controls.Add(lblTongTienPhieu);
            grpLapPhieu.Controls.Add(dgvChiTietPhieu);
            grpLapPhieu.Controls.Add(btnThemVatTuVaoPhieu);
            grpLapPhieu.Controls.Add(nudDonGia);
            grpLapPhieu.Controls.Add(label6);
            grpLapPhieu.Controls.Add(nudSoLuong);
            grpLapPhieu.Controls.Add(label5);
            grpLapPhieu.Controls.Add(txtDVTChon);
            grpLapPhieu.Controls.Add(label3);
            grpLapPhieu.Controls.Add(txtTenVatTuChon);
            grpLapPhieu.Controls.Add(label2);
            grpLapPhieu.Controls.Add(txtMaVatTuChon);
            grpLapPhieu.Controls.Add(label1);
            grpLapPhieu.Controls.Add(cbNhaCungCap);
            grpLapPhieu.Controls.Add(lblNhaCungCap);
            grpLapPhieu.Controls.Add(cbLoaiPhieu);
            grpLapPhieu.Controls.Add(lblLoaiPhieu);
            grpLapPhieu.Dock = DockStyle.Top;
            grpLapPhieu.Location = new Point(0, 0);
            grpLapPhieu.Name = "grpLapPhieu";
            grpLapPhieu.Size = new Size(654, 520);
            grpLapPhieu.TabIndex = 0;
            grpLapPhieu.TabStop = false;
            grpLapPhieu.Text = "Lập phiếu kho (Nhập / Xuất)";
            // 
            // btnLuuPhieu
            // 
            btnLuuPhieu.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnLuuPhieu.Location = new Point(6, 491);
            btnLuuPhieu.Name = "btnLuuPhieu";
            btnLuuPhieu.Size = new Size(110, 23);
            btnLuuPhieu.TabIndex = 18;
            btnLuuPhieu.Text = "LƯU PHIẾU KHO";
            btnLuuPhieu.UseVisualStyleBackColor = true;
            btnLuuPhieu.Click += btnLuuPhieu_Click;
            // 
            // lblTongTienPhieu
            // 
            lblTongTienPhieu.AutoSize = true;
            lblTongTienPhieu.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblTongTienPhieu.Location = new Point(6, 460);
            lblTongTienPhieu.Name = "lblTongTienPhieu";
            lblTongTienPhieu.Size = new Size(116, 13);
            lblTongTienPhieu.TabIndex = 17;
            lblTongTienPhieu.Text = "Tổng tiền phiếu: 0VNĐ";
            // 
            // dgvChiTietPhieu
            // 
            dgvChiTietPhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietPhieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietPhieu.Location = new Point(6, 145);
            dgvChiTietPhieu.Name = "dgvChiTietPhieu";
            dgvChiTietPhieu.Size = new Size(642, 312);
            dgvChiTietPhieu.TabIndex = 16;
            // 
            // btnThemVatTuVaoPhieu
            // 
            btnThemVatTuVaoPhieu.Location = new Point(29, 116);
            btnThemVatTuVaoPhieu.Name = "btnThemVatTuVaoPhieu";
            btnThemVatTuVaoPhieu.Size = new Size(105, 23);
            btnThemVatTuVaoPhieu.TabIndex = 15;
            btnThemVatTuVaoPhieu.Text = "Thêm vào phiếu";
            btnThemVatTuVaoPhieu.UseVisualStyleBackColor = true;
            btnThemVatTuVaoPhieu.Click += btnThemVatTuVaoPhieu_Click;
            // 
            // nudDonGia
            // 
            nudDonGia.Location = new Point(290, 87);
            nudDonGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudDonGia.Name = "nudDonGia";
            nudDonGia.Size = new Size(120, 23);
            nudDonGia.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(233, 89);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 13;
            label6.Text = "Đơn giá:";
            // 
            // nudSoLuong
            // 
            nudSoLuong.Location = new Point(77, 87);
            nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoLuong.Name = "nudSoLuong";
            nudSoLuong.Size = new Size(120, 23);
            nudSoLuong.TabIndex = 12;
            nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 89);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 11;
            label5.Text = "Số lượng:";
            // 
            // txtDVTChon
            // 
            txtDVTChon.Location = new Point(457, 54);
            txtDVTChon.Name = "txtDVTChon";
            txtDVTChon.ReadOnly = true;
            txtDVTChon.Size = new Size(185, 23);
            txtDVTChon.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(419, 57);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 8;
            label3.Text = "ĐVT:";
            // 
            // txtTenVatTuChon
            // 
            txtTenVatTuChon.Location = new Point(233, 54);
            txtTenVatTuChon.Name = "txtTenVatTuChon";
            txtTenVatTuChon.ReadOnly = true;
            txtTenVatTuChon.Size = new Size(180, 23);
            txtTenVatTuChon.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(198, 57);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 6;
            label2.Text = "Tên:";
            // 
            // txtMaVatTuChon
            // 
            txtMaVatTuChon.Location = new Point(77, 54);
            txtMaVatTuChon.Name = "txtMaVatTuChon";
            txtMaVatTuChon.ReadOnly = true;
            txtMaVatTuChon.Size = new Size(100, 23);
            txtMaVatTuChon.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 57);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 4;
            label1.Text = "Mã vật tư:";
            // 
            // cbNhaCungCap
            // 
            cbNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNhaCungCap.FormattingEnabled = true;
            cbNhaCungCap.Location = new Point(375, 16);
            cbNhaCungCap.Name = "cbNhaCungCap";
            cbNhaCungCap.Size = new Size(182, 23);
            cbNhaCungCap.TabIndex = 3;
            // 
            // lblNhaCungCap
            // 
            lblNhaCungCap.AutoSize = true;
            lblNhaCungCap.Location = new Point(285, 19);
            lblNhaCungCap.Name = "lblNhaCungCap";
            lblNhaCungCap.Size = new Size(84, 15);
            lblNhaCungCap.TabIndex = 2;
            lblNhaCungCap.Text = "Nhà cung cấp:";
            // 
            // cbLoaiPhieu
            // 
            cbLoaiPhieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLoaiPhieu.FormattingEnabled = true;
            cbLoaiPhieu.Location = new Point(77, 16);
            cbLoaiPhieu.Name = "cbLoaiPhieu";
            cbLoaiPhieu.Size = new Size(189, 23);
            cbLoaiPhieu.TabIndex = 1;
            cbLoaiPhieu.SelectedIndexChanged += cbLoaiPhieu_SelectedIndexChanged;
            // 
            // lblLoaiPhieu
            // 
            lblLoaiPhieu.AutoSize = true;
            lblLoaiPhieu.Location = new Point(6, 19);
            lblLoaiPhieu.Name = "lblLoaiPhieu";
            lblLoaiPhieu.Size = new Size(65, 15);
            lblLoaiPhieu.TabIndex = 0;
            lblLoaiPhieu.Text = "Loại phiếu:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 661);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý xuất nhập kho nguyên liệu (Inventory Management)";
            Load += Form1_Load;
            pnlLeft.ResumeLayout(false);
            grpCanhBao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCanhBao).EndInit();
            grpVatTu.ResumeLayout(false);
            grpVatTu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVatTu).EndInit();
            pnlRight.ResumeLayout(false);
            grpBaoCao.ResumeLayout(false);
            grpBaoCao.PerformLayout();
            grpLapPhieu.ResumeLayout(false);
            grpLapPhieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPhieu).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
        private GroupBox grpVatTu;
        private TextBox txtTimKiem;
        private Label lblTimKiem;
        private Panel pnlRight;
        private DataGridView dgvVatTu;
        private GroupBox grpCanhBao;
        private DataGridView dgvCanhBao;
        private GroupBox grpLapPhieu;
        private ComboBox cbLoaiPhieu;
        private Label lblLoaiPhieu;
        private TextBox txtTenVatTuChon;
        private Label label2;
        private TextBox txtMaVatTuChon;
        private Label label1;
        private ComboBox cbNhaCungCap;
        private Label lblNhaCungCap;
        private TextBox txtDVTChon;
        private Label label3;
        private DataGridView dgvChiTietPhieu;
        private Button btnThemVatTuVaoPhieu;
        private NumericUpDown nudDonGia;
        private Label label6;
        private NumericUpDown nudSoLuong;
        private Label label5;
        private GroupBox grpBaoCao;
        private Label lblTongGiaTriKho;
        private Button btnLuuPhieu;
        private Label lblTongTienPhieu;
    }
}
