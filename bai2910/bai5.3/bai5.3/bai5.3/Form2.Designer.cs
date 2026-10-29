namespace bai5._3
{
    partial class Form2
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
            groupBox1 = new GroupBox();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtDonGia = new TextBox();
            label4 = new Label();
            cbDanhMuc = new ComboBox();
            label3 = new Label();
            txtTenMon = new TextBox();
            label2 = new Label();
            txtMaMon = new TextBox();
            label1 = new Label();
            dgvMonAn = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonAn).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(txtDonGia);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cbDanhMuc);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtTenMon);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtMaMon);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.MinimumSize = new Size(0, 180);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(734, 180);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin món ăn";
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(183, 151);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 23);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa món";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(102, 151);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 23);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa món";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(21, 151);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 23);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm món";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(77, 111);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(100, 23);
            txtDonGia.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 114);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 6;
            label4.Text = "Đơn giá:";
            // 
            // cbDanhMuc
            // 
            cbDanhMuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDanhMuc.FormattingEnabled = true;
            cbDanhMuc.Location = new Point(77, 77);
            cbDanhMuc.Name = "cbDanhMuc";
            cbDanhMuc.Size = new Size(100, 23);
            cbDanhMuc.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 77);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 4;
            label3.Text = "Danh mục:";
            // 
            // txtTenMon
            // 
            txtTenMon.Location = new Point(77, 45);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.Size = new Size(100, 23);
            txtTenMon.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 46);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Tên món:";
            // 
            // txtMaMon
            // 
            txtMaMon.Location = new Point(77, 16);
            txtMaMon.Name = "txtMaMon";
            txtMaMon.ReadOnly = true;
            txtMaMon.Size = new Size(100, 23);
            txtMaMon.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã món:";
            // 
            // dgvMonAn
            // 
            dgvMonAn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonAn.Dock = DockStyle.Fill;
            dgvMonAn.Location = new Point(0, 180);
            dgvMonAn.MultiSelect = false;
            dgvMonAn.Name = "dgvMonAn";
            dgvMonAn.ReadOnly = true;
            dgvMonAn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonAn.Size = new Size(734, 281);
            dgvMonAn.TabIndex = 1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 461);
            Controls.Add(dgvMonAn);
            Controls.Add(groupBox1);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý thực đơn (Menu)";
            Load += Form2_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonAn).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtTenMon;
        private Label label2;
        private TextBox txtMaMon;
        private Label label1;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private TextBox txtDonGia;
        private Label label4;
        private ComboBox cbDanhMuc;
        private Label label3;
        private DataGridView dgvMonAn;
    }
}