namespace bai5_3
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
            grpProductInfo = new GroupBox();
            cboCategory = new ComboBox();
            txtUnitPrice = new TextBox();
            txtQuantity = new TextBox();
            txtProductName = new TextBox();
            txtProductId = new TextBox();
            lblCategory = new Label();
            lblQuantity = new Label();
            lblUnitPrice = new Label();
            lblProductName = new Label();
            lblProductId = new Label();
            lblTitle = new Label();
            grpFunctions = new GroupBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            dgvProducts = new DataGridView();
            colProductId = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            bsProducts = new BindingSource(components);
            grpProductInfo.SuspendLayout();
            grpFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsProducts).BeginInit();
            SuspendLayout();
            // 
            // grpProductInfo
            // 
            grpProductInfo.Controls.Add(cboCategory);
            grpProductInfo.Controls.Add(txtUnitPrice);
            grpProductInfo.Controls.Add(txtQuantity);
            grpProductInfo.Controls.Add(txtProductName);
            grpProductInfo.Controls.Add(txtProductId);
            grpProductInfo.Controls.Add(lblCategory);
            grpProductInfo.Controls.Add(lblQuantity);
            grpProductInfo.Controls.Add(lblUnitPrice);
            grpProductInfo.Controls.Add(lblProductName);
            grpProductInfo.Controls.Add(lblProductId);
            grpProductInfo.Location = new Point(23, 32);
            grpProductInfo.Name = "grpProductInfo";
            grpProductInfo.Size = new Size(410, 160);
            grpProductInfo.TabIndex = 0;
            grpProductInfo.TabStop = false;
            grpProductInfo.Text = "Thông tin sản phẩm";
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(94, 131);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(310, 23);
            cboCategory.TabIndex = 9;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(94, 72);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(310, 23);
            txtUnitPrice.TabIndex = 8;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(94, 101);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(310, 23);
            txtQuantity.TabIndex = 7;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(94, 43);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(310, 23);
            txtProductName.TabIndex = 6;
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(94, 16);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(310, 23);
            txtProductId.TabIndex = 5;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(6, 134);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(65, 15);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Danh mục:";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(6, 104);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(57, 15);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "Số lượng:";
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(6, 75);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(51, 15);
            lblUnitPrice.TabIndex = 2;
            lblUnitPrice.Text = "Đơn giá:";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(6, 46);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(84, 15);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Tên sản phẩm:";
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Location = new Point(6, 19);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(82, 15);
            lblProductId.TabIndex = 0;
            lblProductId.Text = "Mã sản phẩm:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(185, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(120, 15);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "QUẢN LÝ SẢN PHẨM";
            // 
            // grpFunctions
            // 
            grpFunctions.Controls.Add(txtSearch);
            grpFunctions.Controls.Add(btnSearch);
            grpFunctions.Controls.Add(btnDelete);
            grpFunctions.Controls.Add(btnEdit);
            grpFunctions.Controls.Add(btnAdd);
            grpFunctions.Location = new Point(439, 32);
            grpFunctions.Name = "grpFunctions";
            grpFunctions.Size = new Size(349, 119);
            grpFunctions.TabIndex = 2;
            grpFunctions.TabStop = false;
            grpFunctions.Text = "Chức năng";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(6, 76);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(256, 23);
            txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(268, 75);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(268, 22);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(140, 22);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(6, 22);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colProductId, colProductName, colUnitPrice, colQuantity, colCategory });
            dgvProducts.DataSource = bsProducts;
            dgvProducts.Location = new Point(12, 198);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(776, 240);
            dgvProducts.TabIndex = 3;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // colProductId
            // 
            colProductId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colProductId.DataPropertyName = "ProductId";
            colProductId.HeaderText = "Mã SP";
            colProductId.Name = "colProductId";
            // 
            // colProductName
            // 
            colProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colProductName.DataPropertyName = "ProductName";
            colProductName.HeaderText = "Tên SP";
            colProductName.Name = "colProductName";
            // 
            // colUnitPrice
            // 
            colUnitPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colUnitPrice.DataPropertyName = "UnitPrice";
            colUnitPrice.HeaderText = "Đơn giá";
            colUnitPrice.Name = "colUnitPrice";
            // 
            // colQuantity
            // 
            colQuantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Số lượng";
            colQuantity.Name = "colQuantity";
            // 
            // colCategory
            // 
            colCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCategory.DataPropertyName = "Category";
            colCategory.HeaderText = "Danh mục";
            colCategory.Name = "colCategory";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvProducts);
            Controls.Add(grpFunctions);
            Controls.Add(lblTitle);
            Controls.Add(grpProductInfo);
            Name = "Form1";
            Text = "Form1";
            grpProductInfo.ResumeLayout(false);
            grpProductInfo.PerformLayout();
            grpFunctions.ResumeLayout(false);
            grpFunctions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpProductInfo;
        private ComboBox cboCategory;
        private TextBox txtUnitPrice;
        private TextBox txtQuantity;
        private TextBox txtProductName;
        private TextBox txtProductId;
        private Label lblCategory;
        private Label lblQuantity;
        private Label lblUnitPrice;
        private Label lblProductName;
        private Label lblProductId;
        private Label lblTitle;
        private GroupBox grpFunctions;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private DataGridView dgvProducts;
        private BindingSource bsProducts;
        private DataGridViewTextBoxColumn colProductId;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colCategory;
    }
}
