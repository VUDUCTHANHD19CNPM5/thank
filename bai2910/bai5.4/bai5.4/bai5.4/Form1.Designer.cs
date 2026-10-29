namespace bai5._4
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
            grpPhong = new GroupBox();
            dgvPhong = new DataGridView();
            cbFilterTrangThai = new ComboBox();
            lblTrangThai = new Label();
            cbFilterLoai = new ComboBox();
            lblLoai = new Label();
            pnlRight = new Panel();
            grpCheckOut = new GroupBox();
            btnHoanTatDon = new Button();
            btnCheckOut = new Button();
            lblTongTien = new Label();
            dgvDichVuDaDung = new DataGridView();
            btnGoiDV = new Button();
            nudSoLuongDV = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            cbDichVu = new ComboBox();
            lblCurrentRoom = new Label();
            grpCheckIn = new GroupBox();
            btnCheckIn = new Button();
            txtSDT = new TextBox();
            lblSDT = new Label();
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            txtCCCD = new TextBox();
            lblCCCD = new Label();
            pnlLeft.SuspendLayout();
            grpPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();
            pnlRight.SuspendLayout();
            grpCheckOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDichVuDaDung).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongDV).BeginInit();
            grpCheckIn.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(grpPhong);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(450, 641);
            pnlLeft.TabIndex = 0;
            // 
            // grpPhong
            // 
            grpPhong.Controls.Add(dgvPhong);
            grpPhong.Controls.Add(cbFilterTrangThai);
            grpPhong.Controls.Add(lblTrangThai);
            grpPhong.Controls.Add(cbFilterLoai);
            grpPhong.Controls.Add(lblLoai);
            grpPhong.Dock = DockStyle.Fill;
            grpPhong.Location = new Point(0, 0);
            grpPhong.Name = "grpPhong";
            grpPhong.Size = new Size(450, 641);
            grpPhong.TabIndex = 0;
            grpPhong.TabStop = false;
            grpPhong.Text = "Danh sách & Lọc phòng";
            // 
            // dgvPhong
            // 
            dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhong.Location = new Point(3, 80);
            dgvPhong.Name = "dgvPhong";
            dgvPhong.ReadOnly = true;
            dgvPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhong.Size = new Size(444, 558);
            dgvPhong.TabIndex = 4;
            dgvPhong.CellClick += dgvPhong_CellClick;
            // 
            // cbFilterTrangThai
            // 
            cbFilterTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterTrangThai.FormattingEnabled = true;
            cbFilterTrangThai.Location = new Point(88, 48);
            cbFilterTrangThai.Name = "cbFilterTrangThai";
            cbFilterTrangThai.Size = new Size(121, 23);
            cbFilterTrangThai.TabIndex = 3;
            cbFilterTrangThai.SelectedIndexChanged += ApplyFilter;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(12, 48);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(63, 15);
            lblTrangThai.TabIndex = 2;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // cbFilterLoai
            // 
            cbFilterLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterLoai.FormattingEnabled = true;
            cbFilterLoai.Location = new Point(88, 19);
            cbFilterLoai.Name = "cbFilterLoai";
            cbFilterLoai.Size = new Size(121, 23);
            cbFilterLoai.TabIndex = 1;
            cbFilterLoai.SelectedIndexChanged += ApplyFilter;
            // 
            // lblLoai
            // 
            lblLoai.AutoSize = true;
            lblLoai.Location = new Point(12, 19);
            lblLoai.Name = "lblLoai";
            lblLoai.Size = new Size(70, 15);
            lblLoai.TabIndex = 0;
            lblLoai.Text = "Loại phòng:";
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(grpCheckOut);
            pnlRight.Controls.Add(grpCheckIn);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(450, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(634, 641);
            pnlRight.TabIndex = 1;
            // 
            // grpCheckOut
            // 
            grpCheckOut.Controls.Add(btnHoanTatDon);
            grpCheckOut.Controls.Add(btnCheckOut);
            grpCheckOut.Controls.Add(lblTongTien);
            grpCheckOut.Controls.Add(dgvDichVuDaDung);
            grpCheckOut.Controls.Add(btnGoiDV);
            grpCheckOut.Controls.Add(nudSoLuongDV);
            grpCheckOut.Controls.Add(label2);
            grpCheckOut.Controls.Add(label1);
            grpCheckOut.Controls.Add(cbDichVu);
            grpCheckOut.Controls.Add(lblCurrentRoom);
            grpCheckOut.Dock = DockStyle.Fill;
            grpCheckOut.Location = new Point(0, 170);
            grpCheckOut.Name = "grpCheckOut";
            grpCheckOut.Size = new Size(634, 471);
            grpCheckOut.TabIndex = 1;
            grpCheckOut.TabStop = false;
            grpCheckOut.Text = "Quản lý Dịch vụ & Thanh toán Check-Out";
            // 
            // btnHoanTatDon
            // 
            btnHoanTatDon.Location = new Point(176, 442);
            btnHoanTatDon.Name = "btnHoanTatDon";
            btnHoanTatDon.Size = new Size(111, 23);
            btnHoanTatDon.TabIndex = 9;
            btnHoanTatDon.Text = "Hoàn tất dọn dẹp";
            btnHoanTatDon.UseVisualStyleBackColor = true;
            btnHoanTatDon.Click += btnHoanTatDon_Click;
            // 
            // btnCheckOut
            // 
            btnCheckOut.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnCheckOut.Location = new Point(0, 442);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(157, 23);
            btnCheckOut.TabIndex = 8;
            btnCheckOut.Text = "THANH TOÁN & CHECK-OUT";
            btnCheckOut.UseVisualStyleBackColor = true;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblTongTien.Location = new Point(6, 416);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(107, 13);
            lblTongTien.TabIndex = 7;
            lblTongTien.Text = "TỔNG CỘNG: 0VNĐ";
            // 
            // dgvDichVuDaDung
            // 
            dgvDichVuDaDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDichVuDaDung.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDichVuDaDung.Location = new Point(6, 68);
            dgvDichVuDaDung.Name = "dgvDichVuDaDung";
            dgvDichVuDaDung.ReadOnly = true;
            dgvDichVuDaDung.Size = new Size(622, 345);
            dgvDichVuDaDung.TabIndex = 6;
            // 
            // btnGoiDV
            // 
            btnGoiDV.Location = new Point(378, 39);
            btnGoiDV.Name = "btnGoiDV";
            btnGoiDV.Size = new Size(75, 23);
            btnGoiDV.TabIndex = 5;
            btnGoiDV.Text = "Gọi dịch vụ";
            btnGoiDV.UseVisualStyleBackColor = true;
            btnGoiDV.Click += btnGoiDV_Click;
            // 
            // nudSoLuongDV
            // 
            nudSoLuongDV.Location = new Point(252, 39);
            nudSoLuongDV.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoLuongDV.Name = "nudSoLuongDV";
            nudSoLuongDV.Size = new Size(95, 23);
            nudSoLuongDV.TabIndex = 4;
            nudSoLuongDV.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(189, 42);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Số lượng:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 42);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 2;
            label1.Text = "Dịch vụ:";
            // 
            // cbDichVu
            // 
            cbDichVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDichVu.FormattingEnabled = true;
            cbDichVu.Location = new Point(62, 39);
            cbDichVu.Name = "cbDichVu";
            cbDichVu.Size = new Size(121, 23);
            cbDichVu.TabIndex = 1;
            // 
            // lblCurrentRoom
            // 
            lblCurrentRoom.AutoSize = true;
            lblCurrentRoom.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblCurrentRoom.Location = new Point(6, 19);
            lblCurrentRoom.Name = "lblCurrentRoom";
            lblCurrentRoom.Size = new Size(151, 13);
            lblCurrentRoom.TabIndex = 0;
            lblCurrentRoom.Text = "Đang chọn: Chưa chọn phòng";
            // 
            // grpCheckIn
            // 
            grpCheckIn.Controls.Add(btnCheckIn);
            grpCheckIn.Controls.Add(txtSDT);
            grpCheckIn.Controls.Add(lblSDT);
            grpCheckIn.Controls.Add(txtHoTen);
            grpCheckIn.Controls.Add(lblHoTen);
            grpCheckIn.Controls.Add(txtCCCD);
            grpCheckIn.Controls.Add(lblCCCD);
            grpCheckIn.Dock = DockStyle.Top;
            grpCheckIn.Location = new Point(0, 0);
            grpCheckIn.Name = "grpCheckIn";
            grpCheckIn.Size = new Size(634, 170);
            grpCheckIn.TabIndex = 0;
            grpCheckIn.TabStop = false;
            grpCheckIn.Text = "Thông tin khách hàng & Check-in";
            // 
            // btnCheckIn
            // 
            btnCheckIn.Location = new Point(70, 116);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(143, 23);
            btnCheckIn.TabIndex = 6;
            btnCheckIn.Text = "Nhận phòng (Check-in)";
            btnCheckIn.UseVisualStyleBackColor = true;
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(70, 77);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(100, 23);
            txtSDT.TabIndex = 5;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(6, 80);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(41, 15);
            lblSDT.TabIndex = 4;
            lblSDT.Text = "Số ĐT:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(70, 48);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(100, 23);
            txtHoTen.TabIndex = 3;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(6, 51);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(61, 15);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ và tên:";
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(70, 19);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(100, 23);
            txtCCCD.TabIndex = 1;
            txtCCCD.Leave += txtCCCD_Leave;
            // 
            // lblCCCD
            // 
            lblCCCD.AutoSize = true;
            lblCCCD.Location = new Point(6, 22);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(58, 15);
            lblCCCD.TabIndex = 0;
            lblCCCD.Text = "Số CCCD:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 641);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý khách sạn (Hotel Manager System)";
            Load += Form1_Load;
            pnlLeft.ResumeLayout(false);
            grpPhong.ResumeLayout(false);
            grpPhong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();
            pnlRight.ResumeLayout(false);
            grpCheckOut.ResumeLayout(false);
            grpCheckOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDichVuDaDung).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongDV).EndInit();
            grpCheckIn.ResumeLayout(false);
            grpCheckIn.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
        private GroupBox grpPhong;
        private Label lblLoai;
        private Panel pnlRight;
        private DataGridView dgvPhong;
        private ComboBox cbFilterTrangThai;
        private Label lblTrangThai;
        private ComboBox cbFilterLoai;
        private GroupBox grpCheckIn;
        private Label lblCCCD;
        private GroupBox grpCheckOut;
        private Label lblCurrentRoom;
        private Button btnCheckIn;
        private TextBox txtSDT;
        private Label lblSDT;
        private TextBox txtHoTen;
        private Label lblHoTen;
        private TextBox txtCCCD;
        private DataGridView dgvDichVuDaDung;
        private Button btnGoiDV;
        private NumericUpDown nudSoLuongDV;
        private Label label2;
        private Label label1;
        private ComboBox cbDichVu;
        private Button btnHoanTatDon;
        private Button btnCheckOut;
        private Label lblTongTien;
    }
}
