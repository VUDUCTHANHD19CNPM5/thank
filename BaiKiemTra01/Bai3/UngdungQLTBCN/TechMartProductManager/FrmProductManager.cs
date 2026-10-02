using System.ComponentModel;
using System.Text;

namespace TechMartProductManager;

public partial class FrmProductManager : Form
{
    private readonly BindingList<Product> _products = new();
    private readonly BindingSource _source = new();
    private Product? _selectedProduct;
    private string _selectedImagePath = string.Empty;
    private bool _suppressSelectionChanged;

    public FrmProductManager()
    {
        InitializeComponent();
        InitializeData();
    }

    private void InitializeData()
    {
        cboCategory.DisplayMember = nameof(CategoryItem.Text);
        cboCategory.ValueMember = nameof(CategoryItem.Value);
        cboCategory.DataSource = new List<CategoryItem>
        {
            new() { Value = "PHONE", Text = "Điện thoại" },
            new() { Value = "LAPTOP", Text = "Laptop" },
            new() { Value = "ACCESSORY", Text = "Phụ kiện" }
        };

        _source.DataSource = _products;
        dgvProducts.DataSource = _source;
        UpdateStatus();
    }

    private bool ValidateInput()
    {
        errorProvider.Clear();
        bool valid = true;

        if (string.IsNullOrWhiteSpace(txtProductName.Text))
        {
            errorProvider.SetError(txtProductName, "Tên sản phẩm không được để trống.");
            valid = false;
        }

        if (!decimal.TryParse(txtUnitPrice.Text, out var price) || price <= 0)
        {
            errorProvider.SetError(txtUnitPrice, "Đơn giá phải lớn hơn 0.");
            valid = false;
        }

        if (!int.TryParse(txtQuantity.Text, out var quantity) || quantity < 0)
        {
            errorProvider.SetError(txtQuantity, "Số lượng phải lớn hơn hoặc bằng 0.");
            valid = false;
        }

        return valid;
    }

    private Product ReadProductFromForm()
    {
        return new Product
        {
            ProductId = txtProductId.Text.Trim(),
            ProductName = txtProductName.Text.Trim(),
            Category = cboCategory.Text,
            UnitPrice = decimal.Parse(txtUnitPrice.Text),
            Quantity = int.Parse(txtQuantity.Text),
            ImagePath = _selectedImagePath
        };
    }

    private void btnAdd_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        _suppressSelectionChanged = true;
        try
        {
            _products.Add(ReadProductFromForm());
            _source.ResetBindings(false);
            UpdateStatus();

            // Sau khi thêm xong, reset form để nhập sản phẩm mới.
            ClearForm();
            dgvProducts.ClearSelection();
            dgvProducts.CurrentCell = null;
        }
        finally
        {
            _suppressSelectionChanged = false;
        }
    }

    private void btnUpdate_Click(object? sender, EventArgs e)
    {
        if (_selectedProduct is null)
        {
            MessageBox.Show("Hãy chọn sản phẩm cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (!ValidateInput()) return;

        _selectedProduct.ProductId = txtProductId.Text.Trim();
        _selectedProduct.ProductName = txtProductName.Text.Trim();
        _selectedProduct.Category = cboCategory.Text;
        _selectedProduct.UnitPrice = decimal.Parse(txtUnitPrice.Text);
        _selectedProduct.Quantity = int.Parse(txtQuantity.Text);
        _selectedProduct.ImagePath = _selectedImagePath;

        _source.ResetBindings(false);
        UpdateStatus();
    }

    private void btnDelete_Click(object? sender, EventArgs e)
    {
        if (_selectedProduct is null)
        {
            MessageBox.Show("Hãy chọn sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var result = MessageBox.Show(
            $"Bạn có chắc muốn xóa sản phẩm '{_selectedProduct.ProductName}'?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            _products.Remove(_selectedProduct);
            _selectedProduct = null;
            _source.ResetBindings(false);
            UpdateStatus();
            ClearForm();
        }
    }

    private void btnChooseImage_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Title = "Chọn ảnh sản phẩm",
            Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif|All Files|*.*"
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                using var temp = Image.FromFile(dialog.FileName);
                picAvatar.Image?.Dispose();
                picAvatar.Image = new Bitmap(temp);
                _selectedImagePath = dialog.FileName;
            }
            catch
            {
                MessageBox.Show(
                    "File ảnh không đúng định dạng hoặc không được hỗ trợ.\nHãy dùng ảnh PNG/JPG hợp lệ.",
                    "Không thể mở ảnh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }

    private void dgvProducts_SelectionChanged(object? sender, EventArgs e)
    {
        if (_suppressSelectionChanged) return;
        if (dgvProducts.CurrentRow?.DataBoundItem is not Product product) return;

        _selectedProduct = product;
        txtProductId.Text = product.ProductId;
        txtProductName.Text = product.ProductName;
        cboCategory.Text = product.Category;
        txtUnitPrice.Text = product.UnitPrice.ToString("0");
        txtQuantity.Text = product.Quantity.ToString();
        _selectedImagePath = product.ImagePath;

        picAvatar.Image?.Dispose();
        picAvatar.Image = null;

        if (!string.IsNullOrWhiteSpace(product.ImagePath) && File.Exists(product.ImagePath))
        {
            try
            {
                using var temp = Image.FromFile(product.ImagePath);
                picAvatar.Image = new Bitmap(temp);
            }
            catch
            {
                // Giữ PictureBox trống nếu file ảnh đã bị lỗi hoặc không còn hợp lệ.
            }
        }
    }

    private void ClearSelectionAndForm()
    {
        _suppressSelectionChanged = true;
        try
        {
            dgvProducts.ClearSelection();
            dgvProducts.CurrentCell = null;
            ClearForm();
        }
        finally
        {
            _suppressSelectionChanged = false;
        }
    }

    private void dgvProducts_MouseDown(object? sender, MouseEventArgs e)
    {
        var hit = dgvProducts.HitTest(e.X, e.Y);

        // Bấm vào vùng trống của bảng để bỏ chọn sản phẩm hiện tại.
        if (hit.Type == DataGridViewHitTestType.None)
        {
            ClearSelectionAndForm();
        }
    }

    private void txtSearch_TextChanged(object? sender, EventArgs e)
    {
        string keyword = txtSearch.Text.Trim();
        if (keyword.Length == 0)
        {
            _source.DataSource = _products;
        }
        else
        {
            var result = _products
                .Where(p => p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
            _source.DataSource = result;
        }
        dgvProducts.DataSource = _source;
    }

    private void exportCsvToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog
        {
            Filter = "CSV file|*.csv",
            FileName = "products.csv"
        };

        if (dialog.ShowDialog() != DialogResult.OK) return;

        var sb = new StringBuilder();
        sb.AppendLine("ProductId,ProductName,Category,UnitPrice,Quantity");
        foreach (var p in _products)
        {
            string name = p.ProductName.Replace("\"", "\"\"");
            sb.AppendLine($"\"{p.ProductId}\",\"{name}\",\"{p.Category}\",{p.UnitPrice},{p.Quantity}");
        }
        File.WriteAllText(dialog.FileName, sb.ToString(), Encoding.UTF8);
        MessageBox.Show("Xuất CSV thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void exitToolStripMenuItem_Click(object? sender, EventArgs e) => Close();

    private void ClearForm()
    {
        txtProductId.Clear();
        txtProductName.Clear();
        txtUnitPrice.Clear();
        txtQuantity.Clear();
        cboCategory.SelectedIndex = 0;
        picAvatar.Image?.Dispose();
        picAvatar.Image = null;
        _selectedImagePath = string.Empty;
        _selectedProduct = null;
        errorProvider.Clear();
    }

    private void UpdateStatus() => lblStatus.Text = $"Tổng số sản phẩm: {_products.Count}";
}
