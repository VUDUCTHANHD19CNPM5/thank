using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace RepairServiceTracker
{
    public class MainForm : Form
    {
        private readonly BindingList<RepairOrder> _orders = new();
        private readonly BindingSource _source = new();
        private readonly ErrorProvider _errors = new();

        private TextBox txtMaDon = new();
        private TextBox txtTenKhachHang = new();
        private TextBox txtSoDienThoai = new();
        private ComboBox cboLoaiThietBi = new();
        private TextBox txtMoTaLoi = new();
        private DateTimePicker dtpNgayTiepNhan = new();
        private TextBox txtChiPhiDuKien = new();
        private ComboBox cboTrangThai = new();
        private TextBox txtTimKiem = new();
        private ComboBox cboLocTrangThai = new();
        private PictureBox picThietBi = new();
        private DataGridView dgvDonSuaChua = new();
        private ToolStripStatusLabel lblSoDon = new();
        private ToolStripStatusLabel lblTongChiPhi = new();
        private string _currentImagePath = "";

        private readonly string[] _statuses =
        {
            "Mới tiếp nhận", "Đang sửa", "Chờ linh kiện", "Hoàn tất", "Đã hủy"
        };

        public MainForm()
        {
            Text = "Repair Service Tracker";
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(1050, 680);
            Size = new Size(1280, 800);
            Font = new Font("Segoe UI", 9F);
            BuildInterface();
            ConfigureGrid();
            BindData();
            RefreshStatus();
        }

        private void BuildInterface()
        {
            var menu = new MenuStrip();
            var fileMenu = new ToolStripMenuItem("Tệp");
            var exportItem = new ToolStripMenuItem("Xuất danh sách đang hiển thị ra CSV");
            exportItem.Click += (_, _) => ExportCsv();
            var exitItem = new ToolStripMenuItem("Thoát");
            exitItem.Click += (_, _) => Close();
            fileMenu.DropDownItems.Add(exportItem);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(exitItem);
            menu.Items.Add(fileMenu);
            MainMenuStrip = menu;
            Controls.Add(menu);

            var statusStrip = new StatusStrip();
            lblSoDon.Text = "Số đơn: 0";
            lblTongChiPhi.Text = "Tổng chi phí chưa hoàn tất: 0";
            statusStrip.Items.Add(lblSoDon);
            statusStrip.Items.Add(new ToolStripStatusLabel { Spring = true });
            statusStrip.Items.Add(lblTongChiPhi);
            Controls.Add(statusStrip);

            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(10),
                AutoSize = false
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39));
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61));
            Controls.Add(root);
            root.BringToFront();
            menu.BringToFront();
            statusStrip.BringToFront();

            var left = new TableLayoutPanel
            {
                Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 11,
                AutoScroll = true, Padding = new Padding(4)
            };
            left.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
            left.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
            left.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
            var heading = new Label
            {
                Text = "THÔNG TIN ĐƠN SỬA CHỮA", Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            left.Controls.Add(heading, 0, 0);
            left.SetColumnSpan(heading, 2);

            txtMaDon = NewTextBox();
            txtTenKhachHang = NewTextBox();
            txtSoDienThoai = NewTextBox();
            cboLoaiThietBi = NewCombo("Điện thoại", "Laptop", "Máy tính bảng", "Máy tính để bàn", "Thiết bị khác");
            txtMoTaLoi = new TextBox { Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Vertical };
            dtpNgayTiepNhan = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Short };
            txtChiPhiDuKien = NewTextBox();
            cboTrangThai = NewCombo(_statuses);
            AddField(left, "Mã đơn *", txtMaDon, 1);
            AddField(left, "Tên khách hàng *", txtTenKhachHang, 2);
            AddField(left, "Số điện thoại *", txtSoDienThoai, 3);
            AddField(left, "Loại thiết bị", cboLoaiThietBi, 4);
            AddField(left, "Mô tả lỗi *", txtMoTaLoi, 5, 70);
            AddField(left, "Ngày tiếp nhận", dtpNgayTiepNhan, 6);
            AddField(left, "Chi phí dự kiến", txtChiPhiDuKien, 7);
            AddField(left, "Trạng thái", cboTrangThai, 8);

            picThietBi = new PictureBox
            {
                Dock = DockStyle.Fill, Height = 125, BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.WhiteSmoke
            };
            var imagePanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight, WrapContents = false };
            var btnChonAnh = new Button { Text = "Chọn ảnh...", AutoSize = true };
            btnChonAnh.Click += (_, _) => ChooseImage();
            var btnBoAnh = new Button { Text = "Bỏ ảnh", AutoSize = true };
            btnBoAnh.Click += (_, _) => ClearImage();
            imagePanel.Controls.Add(btnChonAnh);
            imagePanel.Controls.Add(btnBoAnh);
            left.Controls.Add(new Label { Text = "Ảnh thiết bị", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, 9);
            var imageStack = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2 };
            imageStack.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
            imageStack.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            imageStack.Controls.Add(imagePanel, 0, 0);
            imageStack.Controls.Add(picThietBi, 0, 1);
            left.Controls.Add(imageStack, 1, 9);

            var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, WrapContents = true };
            var btnThem = new Button { Text = "Thêm", Width = 82, Height = 32 };
            var btnCapNhat = new Button { Text = "Cập nhật", Width = 90, Height = 32 };
            var btnXoa = new Button { Text = "Xóa", Width = 82, Height = 32 };
            var btnMoi = new Button { Text = "Làm mới", Width = 90, Height = 32 };
            btnThem.Click += (_, _) => AddOrder();
            btnCapNhat.Click += (_, _) => UpdateOrder();
            btnXoa.Click += (_, _) => DeleteOrder();
            btnMoi.Click += (_, _) => ClearForm();
            buttons.Controls.AddRange(new Control[] { btnThem, btnCapNhat, btnXoa, btnMoi });
            left.Controls.Add(buttons, 0, 10);
            left.SetColumnSpan(buttons, 2);
            for (int i = 1; i <= 10; i++)
                if (left.RowStyles.Count <= i) left.RowStyles.Add(new RowStyle(SizeType.Absolute, i == 5 ? 70 : i == 9 ? 170 : 38));

            var right = new TableLayoutPanel
            {
                Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3, Padding = new Padding(8, 4, 4, 4)
            };
            right.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
            right.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
            right.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            right.Controls.Add(new Label
            {
                Text = "DANH SÁCH ĐƠN SỬA CHỮA", Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);

            var searchPanel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4, RowCount = 1 };
            searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 76));
            searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
            searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75));
            searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
            txtTimKiem = NewTextBox();
            txtTimKiem.PlaceholderText = "Mã đơn, tên hoặc số điện thoại...";
            cboLocTrangThai = NewCombo(new[] { "Tất cả trạng thái" }.Concat(_statuses).ToArray());
            cboLocTrangThai.SelectedIndex = 0;
            searchPanel.Controls.Add(new Label { Text = "Tìm kiếm", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, 0);
            searchPanel.Controls.Add(txtTimKiem, 1, 0);
            searchPanel.Controls.Add(new Label { Text = "Lọc trạng thái", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 2, 0);
            searchPanel.Controls.Add(cboLocTrangThai, 3, 0);
            txtTimKiem.TextChanged += (_, _) => ApplyFilter();
            cboLocTrangThai.SelectedIndexChanged += (_, _) => ApplyFilter();
            right.Controls.Add(searchPanel, 0, 1);

            dgvDonSuaChua = new DataGridView
            {
                Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
                AllowUserToDeleteRows = false, AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false, RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            dgvDonSuaChua.SelectionChanged += (_, _) => LoadSelectedOrder();
            right.Controls.Add(dgvDonSuaChua, 0, 2);

            root.Controls.Add(left, 0, 0);
            root.Controls.Add(right, 1, 0);
            _errors.ContainerControl = this;
        }

        private static TextBox NewTextBox() => new() { Dock = DockStyle.Fill };
        private static ComboBox NewCombo(params string[] items)
        {
            var combo = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            combo.Items.AddRange(items);
            if (combo.Items.Count > 0) combo.SelectedIndex = 0;
            return combo;
        }

        private static void AddField(TableLayoutPanel panel, string label, Control control, int row, int height = 38)
        {
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
            panel.Controls.Add(new Label { Text = label, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, row);
            panel.Controls.Add(control, 1, row);
        }

        private void ConfigureGrid()
        {
            dgvDonSuaChua.Columns.Clear();
            AddColumn("MaDon", "Mã đơn", "MaDon", 75);
            AddColumn("TenKhachHang", "Khách hàng", "TenKhachHang", 125);
            AddColumn("SoDienThoai", "Số điện thoại", "SoDienThoai", 100);
            AddColumn("LoaiThietBi", "Thiết bị", "LoaiThietBi", 95);
            AddColumn("NgayTiepNhan", "Ngày nhận", "NgayTiepNhan", 85, "dd/MM/yyyy");
            AddColumn("ChiPhiDuKien", "Chi phí", "ChiPhiDuKien", 90, "N0");
            AddColumn("TrangThai", "Trạng thái", "TrangThai", 100);
        }

        private void AddColumn(string name, string header, string property, int minWidth, string format = "")
        {
            dgvDonSuaChua.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name, HeaderText = header, DataPropertyName = property,
                MinimumWidth = minWidth, FillWeight = minWidth,
                DefaultCellStyle = { Format = format }
            });
        }

        private void BindData()
        {
            _source.DataSource = _orders;
            dgvDonSuaChua.DataSource = _source;
            _orders.Add(new RepairOrder
            {
                MaDon = "SC001", TenKhachHang = "Nguyễn Minh Anh", SoDienThoai = "0912345678",
                LoaiThietBi = "Laptop", MoTaLoi = "Máy không lên nguồn", NgayTiepNhan = DateTime.Today.AddDays(-1),
                ChiPhiDuKien = 850000, TrangThai = "Đang sửa"
            });
            _orders.Add(new RepairOrder
            {
                MaDon = "SC002", TenKhachHang = "Trần Quốc Huy", SoDienThoai = "0987654321",
                LoaiThietBi = "Điện thoại", MoTaLoi = "Màn hình bị nứt", NgayTiepNhan = DateTime.Today,
                ChiPhiDuKien = 1200000, TrangThai = "Mới tiếp nhận"
            });
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            var keyword = txtTimKiem.Text.Trim();
            var status = cboLocTrangThai.SelectedItem?.ToString() ?? "Tất cả trạng thái";
            var visible = _orders.Where(o =>
                (status == "Tất cả trạng thái" || o.TrangThai == status) &&
                (o.MaDon.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                 o.TenKhachHang.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                 o.SoDienThoai.Contains(keyword, StringComparison.OrdinalIgnoreCase))).ToList();

            _source.DataSource = new BindingList<RepairOrder>(visible);
            dgvDonSuaChua.DataSource = _source;
            RefreshStatus(visible);
        }

        private void RefreshStatus(List<RepairOrder> visible = null)
        {
            visible ??= _orders.Where(o =>
                (cboLocTrangThai.SelectedItem?.ToString() ?? "Tất cả trạng thái") == "Tất cả trạng thái" ||
                o.TrangThai == cboLocTrangThai.SelectedItem?.ToString()).Where(o =>
                {
                    var key = txtTimKiem.Text.Trim();
                    return o.MaDon.Contains(key, StringComparison.OrdinalIgnoreCase) ||
                           o.TenKhachHang.Contains(key, StringComparison.OrdinalIgnoreCase) ||
                           o.SoDienThoai.Contains(key, StringComparison.OrdinalIgnoreCase);
                }).ToList();
            lblSoDon.Text = $"Số đơn đang hiển thị: {visible.Count}";
            var total = _orders.Where(o => o.TrangThai != "Hoàn tất" && o.TrangThai != "Đã hủy")
                                .Sum(o => o.ChiPhiDuKien);
            lblTongChiPhi.Text = $"Tổng chi phí chưa hoàn tất: {total.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))} VNĐ";
        }

        private bool ValidateForm(bool checkDuplicate)
        {
            _errors.Clear();
            bool valid = true;
            if (string.IsNullOrWhiteSpace(txtMaDon.Text))
            { _errors.SetError(txtMaDon, "Vui lòng nhập mã đơn."); valid = false; }
            else if (checkDuplicate && _orders.Any(o => o.MaDon.Equals(txtMaDon.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            { _errors.SetError(txtMaDon, "Mã đơn đã tồn tại."); valid = false; }

            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            { _errors.SetError(txtTenKhachHang, "Vui lòng nhập tên khách hàng."); valid = false; }
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            { _errors.SetError(txtSoDienThoai, "Vui lòng nhập số điện thoại."); valid = false; }
            if (string.IsNullOrWhiteSpace(txtMoTaLoi.Text))
            { _errors.SetError(txtMoTaLoi, "Mô tả lỗi là bắt buộc."); valid = false; }
            if (!decimal.TryParse(txtChiPhiDuKien.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out var cost) &&
                !decimal.TryParse(txtChiPhiDuKien.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out cost))
            { _errors.SetError(txtChiPhiDuKien, "Chi phí phải là số."); valid = false; }
            else if (cost < 0)
            { _errors.SetError(txtChiPhiDuKien, "Chi phí không được âm."); valid = false; }
            return valid;
        }

        private RepairOrder ReadForm() => new()
        {
            MaDon = txtMaDon.Text.Trim(),
            TenKhachHang = txtTenKhachHang.Text.Trim(),
            SoDienThoai = txtSoDienThoai.Text.Trim(),
            LoaiThietBi = cboLoaiThietBi.Text,
            MoTaLoi = txtMoTaLoi.Text.Trim(),
            NgayTiepNhan = dtpNgayTiepNhan.Value.Date,
            ChiPhiDuKien = decimal.Parse(txtChiPhiDuKien.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture),
            TrangThai = cboTrangThai.Text,
            DuongDanAnh = _currentImagePath
        };

        private void AddOrder()
        {
            if (!ValidateForm(true)) return;
            _orders.Add(ReadForm());
            ClearForm();
            ApplyFilter();
        }

        private void UpdateOrder()
        {
            if (dgvDonSuaChua.CurrentRow?.DataBoundItem is not RepairOrder selected)
            { MessageBox.Show("Hãy chọn một đơn cần cập nhật."); return; }

            _errors.Clear();
            bool valid = true;
            if (string.IsNullOrWhiteSpace(txtMaDon.Text)) { _errors.SetError(txtMaDon, "Vui lòng nhập mã đơn."); valid = false; }
            else if (_orders.Any(o => !ReferenceEquals(o, selected) && o.MaDon.Equals(txtMaDon.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            { _errors.SetError(txtMaDon, "Mã đơn đã tồn tại."); valid = false; }
            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text)) { _errors.SetError(txtTenKhachHang, "Vui lòng nhập tên khách hàng."); valid = false; }
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text)) { _errors.SetError(txtSoDienThoai, "Vui lòng nhập số điện thoại."); valid = false; }
            if (string.IsNullOrWhiteSpace(txtMoTaLoi.Text)) { _errors.SetError(txtMoTaLoi, "Mô tả lỗi là bắt buộc."); valid = false; }
            if (!decimal.TryParse(txtChiPhiDuKien.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out var cost) &&
                !decimal.TryParse(txtChiPhiDuKien.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out cost))
            { _errors.SetError(txtChiPhiDuKien, "Chi phí phải là số."); valid = false; }
            else if (cost < 0) { _errors.SetError(txtChiPhiDuKien, "Chi phí không được âm."); valid = false; }
            if (!valid) return;

            var updated = ReadForm();
            selected.MaDon = updated.MaDon;
            selected.TenKhachHang = updated.TenKhachHang;
            selected.SoDienThoai = updated.SoDienThoai;
            selected.LoaiThietBi = updated.LoaiThietBi;
            selected.MoTaLoi = updated.MoTaLoi;
            selected.NgayTiepNhan = updated.NgayTiepNhan;
            selected.ChiPhiDuKien = updated.ChiPhiDuKien;
            selected.TrangThai = updated.TrangThai;
            selected.DuongDanAnh = updated.DuongDanAnh;
            _source.ResetBindings(false);
            ApplyFilter();
        }

        private void DeleteOrder()
        {
            if (dgvDonSuaChua.CurrentRow?.DataBoundItem is not RepairOrder selected)
            { MessageBox.Show("Hãy chọn một đơn cần xóa."); return; }
            if (MessageBox.Show($"Bạn có chắc muốn xóa đơn {selected.MaDon}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            _orders.Remove(selected);
            ClearForm();
            ApplyFilter();
        }

        private void LoadSelectedOrder()
        {
            if (dgvDonSuaChua.CurrentRow?.DataBoundItem is not RepairOrder order) return;
            txtMaDon.Text = order.MaDon;
            txtTenKhachHang.Text = order.TenKhachHang;
            txtSoDienThoai.Text = order.SoDienThoai;
            cboLoaiThietBi.SelectedItem = order.LoaiThietBi;
            if (cboLoaiThietBi.SelectedIndex < 0) cboLoaiThietBi.SelectedIndex = 0;
            txtMoTaLoi.Text = order.MoTaLoi;
            dtpNgayTiepNhan.Value = order.NgayTiepNhan;
            txtChiPhiDuKien.Text = order.ChiPhiDuKien.ToString("0.##", CultureInfo.CurrentCulture);
            cboTrangThai.SelectedItem = order.TrangThai;
            _currentImagePath = order.DuongDanAnh ?? "";
            ShowImage(_currentImagePath);
            _errors.Clear();
        }

        private void ClearForm()
        {
            _errors.Clear();
            txtMaDon.Clear();
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtMoTaLoi.Clear();
            txtChiPhiDuKien.Text = "0";
            cboLoaiThietBi.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;
            dtpNgayTiepNhan.Value = DateTime.Today;
            _currentImagePath = "";
            ShowImage("");
            dgvDonSuaChua.ClearSelection();
            txtMaDon.Focus();
        }

        private void ChooseImage()
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Chọn ảnh thiết bị",
                Filter = "Tệp ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả tệp|*.*",
                Multiselect = false
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            _currentImagePath = dialog.FileName;
            ShowImage(_currentImagePath);
        }

        private void ClearImage()
        {
            _currentImagePath = "";
            ShowImage("");
        }

        private void ShowImage(string path)
        {
            var old = picThietBi.Image;
            picThietBi.Image = null;
            old?.Dispose();
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
            {
                try
                {
                    using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using var temp = Image.FromStream(stream);
                    picThietBi.Image = new Bitmap(temp);
                }
                catch { picThietBi.Image = null; }
            }
        }

        private void ExportCsv()
        {
            var visible = new List<RepairOrder>();
            foreach (DataGridViewRow row in dgvDonSuaChua.Rows)
                if (row.DataBoundItem is RepairOrder order) visible.Add(order);

            using var dialog = new SaveFileDialog
            {
                Title = "Xuất danh sách đơn sửa chữa",
                Filter = "CSV (*.csv)|*.csv",
                FileName = "DanhSachDonSuaChua.csv",
                DefaultExt = "csv",
                AddExtension = true
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            var sb = new StringBuilder();
            sb.AppendLine("MaDon,TenKhachHang,SoDienThoai,LoaiThietBi,MoTaLoi,NgayTiepNhan,ChiPhiDuKien,TrangThai,DuongDanAnh");
            foreach (var o in visible)
            {
                sb.AppendLine(string.Join(",", new[]
                {
                    Csv(o.MaDon), Csv(o.TenKhachHang), Csv(o.SoDienThoai), Csv(o.LoaiThietBi),
                    Csv(o.MoTaLoi), Csv(o.NgayTiepNhan.ToString("yyyy-MM-dd")),
                    Csv(o.ChiPhiDuKien.ToString(CultureInfo.InvariantCulture)), Csv(o.TrangThai), Csv(o.DuongDanAnh)
                }));
            }
            File.WriteAllText(dialog.FileName, "\uFEFF" + sb.ToString(), new UTF8Encoding(true));
            MessageBox.Show("Đã xuất danh sách CSV thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static string Csv(string value) => "\"" + (value ?? "").Replace("\"", "\"\"") + "\"";
    }
}
