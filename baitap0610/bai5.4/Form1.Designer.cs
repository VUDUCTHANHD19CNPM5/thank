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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            tvDepartments = new TreeView();
            lsvEmployees = new ListView();
            colMaNV = new ColumnHeader();
            colHoTen = new ColumnHeader();
            colChucVu = new ColumnHeader();
            colNgayVaoLam = new ColumnHeader();
            imgList = new ImageList(components);
            lblViewMode = new Label();
            cboViewMode = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tvDepartments);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lsvEmployees);
            splitContainer1.Panel2.Controls.Add(lblViewMode);
            splitContainer1.Panel2.Controls.Add(cboViewMode);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // tvDepartments
            // 
            tvDepartments.Dock = DockStyle.Fill;
            tvDepartments.Location = new Point(0, 0);
            tvDepartments.Name = "tvDepartments";
            tvDepartments.Size = new Size(266, 450);
            tvDepartments.TabIndex = 0;
            tvDepartments.AfterSelect += tvDepartments_AfterSelect;
            // 
            // lsvEmployees
            // 
            lsvEmployees.Columns.AddRange(new ColumnHeader[] { colMaNV, colHoTen, colChucVu, colNgayVaoLam });
            lsvEmployees.FullRowSelect = true;
            lsvEmployees.GridLines = true;
            lsvEmployees.HideSelection = true;
            lsvEmployees.LargeImageList = imgList;
            lsvEmployees.Location = new Point(3, 35);
            lsvEmployees.Name = "lsvEmployees";
            lsvEmployees.Size = new Size(524, 412);
            lsvEmployees.SmallImageList = imgList;
            lsvEmployees.TabIndex = 2;
            lsvEmployees.UseCompatibleStateImageBehavior = false;
            // 
            // colMaNV
            // 
            colMaNV.Text = "Mã NV";
            colMaNV.Width = 80;
            // 
            // colHoTen
            // 
            colHoTen.Text = "Họ tên";
            colHoTen.Width = 180;
            // 
            // colChucVu
            // 
            colChucVu.Text = "Chức vụ";
            colChucVu.Width = 150;
            // 
            // colNgayVaoLam
            // 
            colNgayVaoLam.Text = "Ngày vào làm";
            colNgayVaoLam.Width = 130;
            // 
            // imgList
            // 
            imgList.ColorDepth = ColorDepth.Depth32Bit;
            imgList.ImageSize = new Size(16, 16);
            imgList.TransparentColor = Color.Transparent;
            // 
            // lblViewMode
            // 
            lblViewMode.AutoSize = true;
            lblViewMode.Location = new Point(3, 9);
            lblViewMode.Name = "lblViewMode";
            lblViewMode.Size = new Size(73, 15);
            lblViewMode.TabIndex = 1;
            lblViewMode.Text = "Chế độ xem:";
            // 
            // cboViewMode
            // 
            cboViewMode.FormattingEnabled = true;
            cboViewMode.Location = new Point(82, 6);
            cboViewMode.Name = "cboViewMode";
            cboViewMode.Size = new Size(436, 23);
            cboViewMode.TabIndex = 0;
            cboViewMode.SelectedIndexChanged += cboViewMode_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView tvDepartments;
        private ComboBox cboViewMode;
        private ListView lsvEmployees;
        private ColumnHeader colMaNV;
        private ColumnHeader colHoTen;
        private ColumnHeader colChucVu;
        private ColumnHeader colNgayVaoLam;
        private Label lblViewMode;
        private ImageList imgList;
    }
}
