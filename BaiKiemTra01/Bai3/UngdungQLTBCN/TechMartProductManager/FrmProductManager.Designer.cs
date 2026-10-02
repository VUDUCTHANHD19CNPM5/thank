namespace TechMartProductManager;

partial class FrmProductManager
{
    private System.ComponentModel.IContainer components = null!;

    private MenuStrip menuStrip1 = null!;
    private ToolStripMenuItem fileToolStripMenuItem = null!;
    private ToolStripMenuItem exportCsvToolStripMenuItem = null!;
    private ToolStripMenuItem exitToolStripMenuItem = null!;
    private StatusStrip statusStrip1 = null!;
    private ToolStripStatusLabel lblStatus = null!;
    private TableLayoutPanel mainLayout = null!;
    private Panel leftPanel = null!;
    private Panel leftContentPanel = null!;
    private Panel rightPanel = null!;

    private Label lblTitle = null!;
    private Label lblProductId = null!;
    private Label lblProductName = null!;
    private Label lblUnitPrice = null!;
    private Label lblQuantity = null!;
    private Label lblCategory = null!;
    private Label lblSearch = null!;

    private TextBox txtProductId = null!;
    private TextBox txtProductName = null!;
    private TextBox txtUnitPrice = null!;
    private TextBox txtQuantity = null!;
    private ComboBox cboCategory = null!;
    private PictureBox picAvatar = null!;
    private Button btnChooseImage = null!;
    private Button btnAdd = null!;
    private Button btnUpdate = null!;
    private Button btnDelete = null!;
    private TextBox txtSearch = null!;
    private DataGridView dgvProducts = null!;
    private ErrorProvider errorProvider = null!;

    private DataGridViewTextBoxColumn colProductId = null!;
    private DataGridViewTextBoxColumn colProductName = null!;
    private DataGridViewTextBoxColumn colCategory = null!;
    private DataGridViewTextBoxColumn colUnitPrice = null!;
    private DataGridViewTextBoxColumn colQuantity = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        exportCsvToolStripMenuItem = new ToolStripMenuItem();
        exitToolStripMenuItem = new ToolStripMenuItem();
        statusStrip1 = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();
        mainLayout = new TableLayoutPanel();
        leftPanel = new Panel();
        leftContentPanel = new Panel();
        rightPanel = new Panel();
        lblTitle = new Label();
        lblProductId = new Label();
        lblProductName = new Label();
        lblUnitPrice = new Label();
        lblQuantity = new Label();
        lblCategory = new Label();
        lblSearch = new Label();
        txtProductId = new TextBox();
        txtProductName = new TextBox();
        txtUnitPrice = new TextBox();
        txtQuantity = new TextBox();
        cboCategory = new ComboBox();
        picAvatar = new PictureBox();
        btnChooseImage = new Button();
        btnAdd = new Button();
        btnUpdate = new Button();
        btnDelete = new Button();
        txtSearch = new TextBox();
        dgvProducts = new DataGridView();
        colProductId = new DataGridViewTextBoxColumn();
        colProductName = new DataGridViewTextBoxColumn();
        colCategory = new DataGridViewTextBoxColumn();
        colUnitPrice = new DataGridViewTextBoxColumn();
        colQuantity = new DataGridViewTextBoxColumn();
        errorProvider = new ErrorProvider(components);

        menuStrip1.SuspendLayout();
        statusStrip1.SuspendLayout();
        mainLayout.SuspendLayout();
        leftPanel.SuspendLayout();
        leftContentPanel.SuspendLayout();
        rightPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();

        // menuStrip1
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1000, 24);
        menuStrip1.TabIndex = 0;

        // fileToolStripMenuItem
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportCsvToolStripMenuItem, exitToolStripMenuItem });
        fileToolStripMenuItem.Text = "File";

        // exportCsvToolStripMenuItem
        exportCsvToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
        exportCsvToolStripMenuItem.Text = "Export CSV";
        exportCsvToolStripMenuItem.Click += exportCsvToolStripMenuItem_Click;

        // exitToolStripMenuItem
        exitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
        exitToolStripMenuItem.Text = "Exit";
        exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;

        // statusStrip1
        statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
        statusStrip1.Location = new Point(0, 598);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(1000, 22);
        statusStrip1.TabIndex = 2;

        // lblStatus
        lblStatus.Text = "Tổng số sản phẩm: 0";

        // mainLayout
        mainLayout.ColumnCount = 2;
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
        mainLayout.Controls.Add(leftPanel, 0, 0);
        mainLayout.Controls.Add(rightPanel, 1, 0);
        mainLayout.Dock = DockStyle.Fill;
        mainLayout.Location = new Point(0, 24);
        mainLayout.Name = "mainLayout";
        mainLayout.RowCount = 1;
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainLayout.Size = new Size(1000, 574);
        mainLayout.TabIndex = 1;

        // leftPanel
        leftPanel.AutoScroll = true;
        leftPanel.Controls.Add(leftContentPanel);
        leftPanel.Dock = DockStyle.Fill;
        leftPanel.Location = new Point(3, 3);
        leftPanel.Name = "leftPanel";
        leftPanel.Padding = new Padding(6);
        leftPanel.Size = new Size(344, 568);
        leftPanel.TabIndex = 0;

        // leftContentPanel
        // Chiếm toàn bộ cột trái 35%. Các ô nhập bên trong được Anchor trái/phải
        // để co giãn theo chiều ngang khi Form được phóng to.
        leftContentPanel.Dock = DockStyle.Fill;
        leftContentPanel.Controls.Add(lblTitle);
        leftContentPanel.Controls.Add(lblProductId);
        leftContentPanel.Controls.Add(lblProductName);
        leftContentPanel.Controls.Add(lblUnitPrice);
        leftContentPanel.Controls.Add(lblQuantity);
        leftContentPanel.Controls.Add(lblCategory);
        leftContentPanel.Controls.Add(txtProductId);
        leftContentPanel.Controls.Add(txtProductName);
        leftContentPanel.Controls.Add(txtUnitPrice);
        leftContentPanel.Controls.Add(txtQuantity);
        leftContentPanel.Controls.Add(cboCategory);
        leftContentPanel.Controls.Add(picAvatar);
        leftContentPanel.Controls.Add(btnChooseImage);
        leftContentPanel.Controls.Add(btnAdd);
        leftContentPanel.Controls.Add(btnUpdate);
        leftContentPanel.Controls.Add(btnDelete);
        leftContentPanel.Location = new Point(6, 6);
        leftContentPanel.Name = "leftContentPanel";
        leftContentPanel.Size = new Size(326, 556);
        leftContentPanel.TabIndex = 0;

        // lblTitle
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblTitle.Location = new Point(18, 18);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(224, 25);
        lblTitle.Text = "THÔNG TIN SẢN PHẨM";

        // lblProductId
        lblProductId.AutoSize = true;
        lblProductId.Location = new Point(18, 69);
        lblProductId.Name = "lblProductId";
        lblProductId.Text = "Mã SP";

        // txtProductId
        txtProductId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtProductId.Location = new Point(105, 65);
        txtProductId.Name = "txtProductId";
        txtProductId.Size = new Size(190, 23);

        // lblProductName
        lblProductName.AutoSize = true;
        lblProductName.Location = new Point(18, 109);
        lblProductName.Name = "lblProductName";
        lblProductName.Text = "Tên SP";

        // txtProductName
        txtProductName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtProductName.Location = new Point(105, 105);
        txtProductName.Name = "txtProductName";
        txtProductName.Size = new Size(190, 23);

        // lblUnitPrice
        lblUnitPrice.AutoSize = true;
        lblUnitPrice.Location = new Point(18, 149);
        lblUnitPrice.Name = "lblUnitPrice";
        lblUnitPrice.Text = "Đơn giá";

        // txtUnitPrice
        txtUnitPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtUnitPrice.Location = new Point(105, 145);
        txtUnitPrice.Name = "txtUnitPrice";
        txtUnitPrice.Size = new Size(190, 23);

        // lblQuantity
        lblQuantity.AutoSize = true;
        lblQuantity.Location = new Point(18, 189);
        lblQuantity.Name = "lblQuantity";
        lblQuantity.Text = "Số lượng";

        // txtQuantity
        txtQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtQuantity.Location = new Point(105, 185);
        txtQuantity.Name = "txtQuantity";
        txtQuantity.Size = new Size(190, 23);

        // lblCategory
        lblCategory.AutoSize = true;
        lblCategory.Location = new Point(18, 228);
        lblCategory.Name = "lblCategory";
        lblCategory.Text = "Danh mục";

        // cboCategory
        cboCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCategory.FormattingEnabled = true;
        cboCategory.Location = new Point(105, 224);
        cboCategory.Name = "cboCategory";
        cboCategory.Size = new Size(190, 23);

        // picAvatar
        picAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        picAvatar.BorderStyle = BorderStyle.FixedSingle;
        picAvatar.Location = new Point(22, 270);
        picAvatar.Name = "picAvatar";
        picAvatar.Size = new Size(273, 150);
        picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        picAvatar.TabStop = false;

        // btnChooseImage
        btnChooseImage.Location = new Point(22, 430);
        btnChooseImage.Name = "btnChooseImage";
        btnChooseImage.Size = new Size(85, 32);
        btnChooseImage.Text = "Chọn ảnh";
        btnChooseImage.UseVisualStyleBackColor = true;
        btnChooseImage.Click += btnChooseImage_Click;

        // btnAdd
        btnAdd.Location = new Point(22, 485);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(85, 34);
        btnAdd.Text = "Thêm mới";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;

        // btnUpdate
        btnUpdate.Location = new Point(116, 485);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new Size(85, 34);
        btnUpdate.Text = "Cập nhật";
        btnUpdate.UseVisualStyleBackColor = true;
        btnUpdate.Click += btnUpdate_Click;

        // btnDelete
        btnDelete.Location = new Point(210, 485);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(85, 34);
        btnDelete.Text = "Xóa";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;

        // rightPanel
        rightPanel.Controls.Add(lblSearch);
        rightPanel.Controls.Add(txtSearch);
        rightPanel.Controls.Add(dgvProducts);
        rightPanel.Dock = DockStyle.Fill;
        rightPanel.Location = new Point(353, 3);
        rightPanel.Name = "rightPanel";
        rightPanel.Padding = new Padding(10);
        rightPanel.Size = new Size(644, 568);
        rightPanel.TabIndex = 1;

        // lblSearch
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(10, 14);
        lblSearch.Name = "lblSearch";
        lblSearch.Text = "Tìm kiếm:";

        // txtSearch
        txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtSearch.Location = new Point(80, 10);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(554, 23);
        txtSearch.TextChanged += txtSearch_TextChanged;

        // dgvProducts
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvProducts.AutoGenerateColumns = false;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colProductId, colProductName, colCategory, colUnitPrice, colQuantity });
        dgvProducts.Location = new Point(10, 48);
        dgvProducts.MultiSelect = false;
        dgvProducts.Name = "dgvProducts";
        dgvProducts.ReadOnly = true;
        dgvProducts.RowHeadersVisible = false;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.Size = new Size(624, 510);
        dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
        dgvProducts.MouseDown += dgvProducts_MouseDown;

        // colProductId
        colProductId.DataPropertyName = "ProductId";
        colProductId.FillWeight = 15F;
        colProductId.HeaderText = "Mã SP";
        colProductId.MinimumWidth = 70;
        colProductId.Name = "colProductId";
        colProductId.ReadOnly = true;

        // colProductName
        colProductName.DataPropertyName = "ProductName";
        colProductName.FillWeight = 30F;
        colProductName.HeaderText = "Tên SP";
        colProductName.MinimumWidth = 130;
        colProductName.Name = "colProductName";
        colProductName.ReadOnly = true;

        // colCategory
        colCategory.DataPropertyName = "Category";
        colCategory.FillWeight = 18F;
        colCategory.HeaderText = "Danh mục";
        colCategory.MinimumWidth = 95;
        colCategory.Name = "colCategory";
        colCategory.ReadOnly = true;

        // colUnitPrice
        colUnitPrice.DataPropertyName = "UnitPrice";
        colUnitPrice.DefaultCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleRight,
            Format = "#,##0 'VND'"
        };
        colUnitPrice.FillWeight = 22F;
        colUnitPrice.HeaderText = "Đơn giá";
        colUnitPrice.MinimumWidth = 120;
        colUnitPrice.Name = "colUnitPrice";
        colUnitPrice.ReadOnly = true;

        // colQuantity
        colQuantity.DataPropertyName = "Quantity";
        colQuantity.DefaultCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter
        };
        colQuantity.FillWeight = 15F;
        colQuantity.HeaderText = "Số lượng";
        colQuantity.MinimumWidth = 80;
        colQuantity.Name = "colQuantity";
        colQuantity.ReadOnly = true;

        // errorProvider
        errorProvider.ContainerControl = this;

        // FrmProductManager
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 620);
        Controls.Add(mainLayout);
        Controls.Add(statusStrip1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        MinimumSize = new Size(900, 560);
        Name = "FrmProductManager";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "TechMart Product Manager";

        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        mainLayout.ResumeLayout(false);
        leftPanel.ResumeLayout(false);
        leftContentPanel.ResumeLayout(false);
        leftContentPanel.PerformLayout();
        rightPanel.ResumeLayout(false);
        rightPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
