using System.ComponentModel;
using System.Text;

namespace LabEquipmentCheckout;

public class Form1 : Form
{
    private readonly BindingList<PhieuMuon> danhSach = new();
    private readonly BindingSource bsPhieuMuon = new();
    private readonly ErrorProvider errors = new();

    private readonly TextBox txtMaPhieu = new();
    private readonly TextBox txtMaSV = new();
    private readonly TextBox txtHoTen = new();
    private readonly ComboBox cboThietBi = new();
    private readonly NumericUpDown nudSoLuong = new();
    private readonly DateTimePicker dtpNgayMuon = new();
    private readonly DateTimePicker dtpHanTra = new();
    private readonly DateTimePicker dtpNgayTra = new();
    private readonly TextBox txtTimKiem = new();
    private readonly ComboBox cboLocTrangThai = new();
    private readonly DataGridView dgv = new();
    private readonly ToolStripStatusLabel lblTong = new("Tổng số phiếu: 0");
    private readonly ToolStripStatusLabel lblQuaHan = new("Số phiếu quá hạn: 0");

    private PhieuMuon? phieuDangChon;
    private bool dangNapDuLieu;

    public Form1()
    {
        Text = "Lab Equipment Checkout - Quản lý mượn trả thiết bị";
        MinimumSize = new Size(1050, 650);
        Size = new Size(1250, 780);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Segoe UI", 9F);

        errors.ContainerControl = this;
        bsPhieuMuon.DataSource = danhSach;
        BuildUi();
        ConfigureGrid();
        WireEvents();
        LoadSampleData();
        ApplyFilter();
        ClearInputs();
    }

    private void BuildUi()
    {
        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            Padding = new Padding(10)
        };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        Controls.Add(root);

        var group = new GroupBox
        {
            Text = "Thông tin phiếu mượn",
            Dock = DockStyle.Top,
            AutoSize = true,
            Padding = new Padding(10)
        };
        var fields = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            ColumnCount = 4,
            RowCount = 4
        };
        for (int i = 0; i < 4; i++)
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
        for (int i = 0; i < 4; i++)
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        ConfigureTextBox(txtMaPhieu);
        ConfigureTextBox(txtMaSV);
        ConfigureTextBox(txtHoTen);
        ConfigureTextBox(txtTimKiem);

        cboThietBi.DropDownStyle = ComboBoxStyle.DropDownList;
        cboThietBi.Items.AddRange(new object[]
        {
            "Máy tính", "Máy chiếu", "Arduino", "Bộ cảm biến", "Đồng hồ vạn năng"
        });
        cboThietBi.Dock = DockStyle.Fill;

        nudSoLuong.Minimum = 1;
        nudSoLuong.Maximum = 10000;
        nudSoLuong.Value = 1;
        nudSoLuong.Dock = DockStyle.Left;
        nudSoLuong.Width = 140;

        ConfigureDatePicker(dtpNgayMuon);
        ConfigureDatePicker(dtpHanTra);
        ConfigureDatePicker(dtpNgayTra);
        dtpNgayTra.ShowCheckBox = true;
        dtpNgayTra.Checked = false;

        AddField(fields, "Mã phiếu", txtMaPhieu, 0, 0);
        AddField(fields, "Mã sinh viên", txtMaSV, 1, 0);
        AddField(fields, "Họ tên sinh viên", txtHoTen, 2, 0);
        AddField(fields, "Thiết bị", cboThietBi, 3, 0);
        AddField(fields, "Số lượng", nudSoLuong, 0, 1);
        AddField(fields, "Ngày mượn", dtpNgayMuon, 1, 1);
        AddField(fields, "Hạn trả", dtpHanTra, 2, 1);
        AddField(fields, "Ngày trả thực tế (tích chọn nếu có)", dtpNgayTra, 3, 1);

        var buttonPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoSize = true,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = true,
            Padding = new Padding(0, 8, 0, 0)
        };
        buttonPanel.Controls.Add(MakeButton("Thêm", (_, _) => AddRecord()));
        buttonPanel.Controls.Add(MakeButton("Cập nhật", (_, _) => UpdateRecord()));
        buttonPanel.Controls.Add(MakeButton("Xóa", (_, _) => DeleteRecord()));
        buttonPanel.Controls.Add(MakeButton("Đánh dấu đã trả", (_, _) => MarkReturned()));
        buttonPanel.Controls.Add(MakeButton("Làm mới", (_, _) => ClearInputs()));
        buttonPanel.Controls.Add(MakeButton("Xuất CSV", (_, _) => ExportCsv()));
        fields.Controls.Add(buttonPanel, 0, 2);
        fields.SetColumnSpan(buttonPanel, 4);

        var searchPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoSize = true,
            ColumnCount = 4,
            RowCount = 1,
            Padding = new Padding(0, 8, 0, 0)
        };
        searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
        searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
        searchPanel.Controls.Add(new Label { Text = "Tìm mã sinh viên / thiết bị:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 0);
        searchPanel.Controls.Add(txtTimKiem, 1, 0);
        searchPanel.Controls.Add(new Label { Text = "Lọc trạng thái:", AutoSize = true, Anchor = AnchorStyles.Left, Padding = new Padding(10, 5, 0, 0) }, 2, 0);
        cboLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLocTrangThai.Items.AddRange(new object[] { "Tất cả", "Đang mượn", "Quá hạn", "Đã trả" });
        cboLocTrangThai.SelectedIndex = 0;
        cboLocTrangThai.Dock = DockStyle.Fill;
        searchPanel.Controls.Add(cboLocTrangThai, 3, 0);
        fields.Controls.Add(searchPanel, 0, 3);
        fields.SetColumnSpan(searchPanel, 4);

        group.Controls.Add(fields);
        root.Controls.Add(group, 0, 0);

        dgv.Dock = DockStyle.Fill;
        dgv.Margin = new Padding(0, 10, 0, 10);
        root.Controls.Add(dgv, 0, 1);

        var status = new StatusStrip();
        status.Items.Add(lblTong);
        status.Items.Add(new ToolStripStatusLabel { Spring = true });
        status.Items.Add(lblQuaHan);
        root.Controls.Add(status, 0, 2);
    }

    private static void ConfigureTextBox(TextBox box) => box.Dock = DockStyle.Fill;

    private static void ConfigureDatePicker(DateTimePicker picker)
    {
        picker.Format = DateTimePickerFormat.Custom;
        picker.CustomFormat = "dd/MM/yyyy";
        picker.Dock = DockStyle.Fill;
    }

    private static void AddField(TableLayoutPanel panel, string label, Control control, int column, int row)
    {
        var container = new TableLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, ColumnCount = 1, RowCount = 2, Padding = new Padding(4) };
        container.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        container.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        container.Controls.Add(new Label { Text = label, AutoSize = true, Padding = new Padding(0, 0, 0, 3) }, 0, 0);
        control.Margin = new Padding(0, 2, 0, 2);
        container.Controls.Add(control, 0, 1);
        panel.Controls.Add(container, column, row);
    }

    private static Button MakeButton(string text, EventHandler handler)
    {
        var button = new Button { Text = text, AutoSize = true, Padding = new Padding(8, 4, 8, 4), Margin = new Padding(3) };
        button.Click += handler;
        return button;
    }

    private void ConfigureGrid()
    {
        dgv.AutoGenerateColumns = false;
        dgv.AllowUserToAddRows = false;
        dgv.ReadOnly = true;
        dgv.MultiSelect = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.RowHeadersVisible = false;
        dgv.DataSource = bsPhieuMuon;

        AddColumn(nameof(PhieuMuon.MaPhieu), "Mã phiếu");
        AddColumn(nameof(PhieuMuon.MaSV), "Mã sinh viên");
        AddColumn(nameof(PhieuMuon.HoTen), "Họ tên");
        AddColumn(nameof(PhieuMuon.ThietBi), "Thiết bị");
        AddColumn(nameof(PhieuMuon.SoLuong), "Số lượng");
        AddColumn(nameof(PhieuMuon.NgayMuon), "Ngày mượn", "dd/MM/yyyy");
        AddColumn(nameof(PhieuMuon.HanTra), "Hạn trả", "dd/MM/yyyy");
        AddColumn(nameof(PhieuMuon.NgayTraThucTe), "Ngày trả", "dd/MM/yyyy");
        AddColumn(nameof(PhieuMuon.TrangThai), "Trạng thái");
    }

    private void AddColumn(string property, string header, string? format = null)
    {
        var col = new DataGridViewTextBoxColumn { DataPropertyName = property, HeaderText = header, Name = property };
        if (format != null) col.DefaultCellStyle.Format = format;
        dgv.Columns.Add(col);
    }

    private void WireEvents()
    {
        dgv.SelectionChanged += (_, _) =>
        {
            if (dangNapDuLieu) return;
            if (dgv.CurrentRow?.DataBoundItem is PhieuMuon p)
                ShowRecord(p);
        };
        txtTimKiem.TextChanged += (_, _) => ApplyFilter();
        cboLocTrangThai.SelectedIndexChanged += (_, _) => ApplyFilter();
    }

    private void LoadSampleData()
    {
        danhSach.Add(new PhieuMuon
        {
            MaPhieu = "PM001", MaSV = "SV001", HoTen = "Nguyễn Minh Anh",
            ThietBi = "Arduino", SoLuong = 1, NgayMuon = DateTime.Today.AddDays(-10),
            HanTra = DateTime.Today.AddDays(-3)
        });
        danhSach.Add(new PhieuMuon
        {
            MaPhieu = "PM002", MaSV = "SV002", HoTen = "Trần Quốc Bảo",
            ThietBi = "Máy chiếu", SoLuong = 1, NgayMuon = DateTime.Today.AddDays(-2),
            HanTra = DateTime.Today.AddDays(5)
        });
        danhSach.Add(new PhieuMuon
        {
            MaPhieu = "PM003", MaSV = "SV003", HoTen = "Lê Thu Hà",
            ThietBi = "Bộ cảm biến", SoLuong = 2, NgayMuon = DateTime.Today.AddDays(-8),
            HanTra = DateTime.Today.AddDays(-1), NgayTraThucTe = DateTime.Today
        });
    }

    private bool ValidateInput()
    {
        errors.Clear();
        bool valid = true;
        string ma = txtMaPhieu.Text.Trim();

        if (string.IsNullOrWhiteSpace(ma))
        {
            errors.SetError(txtMaPhieu, "Mã phiếu không được để trống.");
            valid = false;
        }
        else if (danhSach.Any(p => p.MaPhieu.Equals(ma, StringComparison.OrdinalIgnoreCase)
                                   && !ReferenceEquals(p, phieuDangChon)))
        {
            errors.SetError(txtMaPhieu, "Mã phiếu đã tồn tại.");
            valid = false;
        }

        if (string.IsNullOrWhiteSpace(txtMaSV.Text))
        {
            errors.SetError(txtMaSV, "Mã sinh viên không được để trống.");
            valid = false;
        }
        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        {
            errors.SetError(txtHoTen, "Họ tên sinh viên không được để trống.");
            valid = false;
        }
        if (cboThietBi.SelectedIndex < 0)
        {
            errors.SetError(cboThietBi, "Vui lòng chọn thiết bị.");
            valid = false;
        }
        if (nudSoLuong.Value <= 0)
        {
            errors.SetError(nudSoLuong, "Số lượng phải lớn hơn 0.");
            valid = false;
        }
        if (dtpHanTra.Value.Date < dtpNgayMuon.Value.Date)
        {
            errors.SetError(dtpHanTra, "Hạn trả không được trước ngày mượn.");
            valid = false;
        }
        if (dtpNgayTra.Checked && dtpNgayTra.Value.Date < dtpNgayMuon.Value.Date)
        {
            errors.SetError(dtpNgayTra, "Ngày trả thực tế không được trước ngày mượn.");
            valid = false;
        }
        return valid;
    }

    private PhieuMuon ReadInputs() => new()
    {
        MaPhieu = txtMaPhieu.Text.Trim(),
        MaSV = txtMaSV.Text.Trim(),
        HoTen = txtHoTen.Text.Trim(),
        ThietBi = cboThietBi.Text,
        SoLuong = (int)nudSoLuong.Value,
        NgayMuon = dtpNgayMuon.Value.Date,
        HanTra = dtpHanTra.Value.Date,
        NgayTraThucTe = dtpNgayTra.Checked ? dtpNgayTra.Value.Date : null
    };

    private void AddRecord()
    {
        phieuDangChon = null;
        if (!ValidateInput()) return;
        danhSach.Add(ReadInputs());
        ApplyFilter();
        UpdateStatus();
        ClearInputs();
        MessageBox.Show("Đã thêm phiếu mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void UpdateRecord()
    {
        if (phieuDangChon == null)
        {
            MessageBox.Show("Vui lòng chọn phiếu cần cập nhật.");
            return;
        }
        if (!ValidateInput()) return;
        var updated = ReadInputs();
        phieuDangChon.MaPhieu = updated.MaPhieu;
        phieuDangChon.MaSV = updated.MaSV;
        phieuDangChon.HoTen = updated.HoTen;
        phieuDangChon.ThietBi = updated.ThietBi;
        phieuDangChon.SoLuong = updated.SoLuong;
        phieuDangChon.NgayMuon = updated.NgayMuon;
        phieuDangChon.HanTra = updated.HanTra;
        phieuDangChon.NgayTraThucTe = updated.NgayTraThucTe;
        bsPhieuMuon.ResetBindings(false);
        ApplyFilter();
        UpdateStatus();
        MessageBox.Show("Đã cập nhật phiếu mượn.");
    }

    private void DeleteRecord()
    {
        if (phieuDangChon == null)
        {
            MessageBox.Show("Vui lòng chọn phiếu cần xóa.");
            return;
        }
        if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu này?", "Xác nhận xóa",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

        danhSach.Remove(phieuDangChon);
        phieuDangChon = null;
        ApplyFilter();
        UpdateStatus();
        ClearInputs();
    }

    private void MarkReturned()
    {
        if (phieuDangChon == null)
        {
            MessageBox.Show("Vui lòng chọn phiếu cần đánh dấu đã trả.");
            return;
        }
        if (phieuDangChon.NgayTraThucTe.HasValue)
        {
            MessageBox.Show("Phiếu này đã được trả.");
            return;
        }
        if (DateTime.Today < phieuDangChon.NgayMuon.Date)
        {
            MessageBox.Show("Ngày trả không được trước ngày mượn.");
            return;
        }

        phieuDangChon.NgayTraThucTe = DateTime.Today;
        bsPhieuMuon.ResetBindings(false);
        ApplyFilter();
        UpdateStatus();
        ShowRecord(phieuDangChon);
        MessageBox.Show("Đã cập nhật ngày trả thực tế và trạng thái.");
    }

    private void ShowRecord(PhieuMuon p)
    {
        phieuDangChon = p;
        dangNapDuLieu = true;
        txtMaPhieu.Text = p.MaPhieu;
        txtMaSV.Text = p.MaSV;
        txtHoTen.Text = p.HoTen;
        cboThietBi.SelectedItem = p.ThietBi;
        nudSoLuong.Value = Math.Max(nudSoLuong.Minimum, Math.Min(nudSoLuong.Maximum, p.SoLuong));
        dtpNgayMuon.Value = p.NgayMuon;
        dtpHanTra.Value = p.HanTra;
        dtpNgayTra.Checked = p.NgayTraThucTe.HasValue;
        if (p.NgayTraThucTe.HasValue) dtpNgayTra.Value = p.NgayTraThucTe.Value;
        errors.Clear();
        dangNapDuLieu = false;
    }

    private void ClearInputs()
    {
        dangNapDuLieu = true;
        phieuDangChon = null;
        txtMaPhieu.Clear();
        txtMaSV.Clear();
        txtHoTen.Clear();
        cboThietBi.SelectedIndex = -1;
        nudSoLuong.Value = 1;
        dtpNgayMuon.Value = DateTime.Today;
        dtpHanTra.Value = DateTime.Today.AddDays(7);
        dtpNgayTra.Value = DateTime.Today;
        dtpNgayTra.Checked = false;
        errors.Clear();
        dgv.ClearSelection();
        dangNapDuLieu = false;
    }

    private void ApplyFilter()
    {
        string keyword = txtTimKiem.Text.Trim();
        string status = cboLocTrangThai.SelectedItem?.ToString() ?? "Tất cả";
        var filtered = danhSach.Where(p =>
            (p.MaSV.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
             p.ThietBi.Contains(keyword, StringComparison.OrdinalIgnoreCase)) &&
            (status == "Tất cả" || p.TrangThai == status)).ToList();

        dangNapDuLieu = true;
        bsPhieuMuon.DataSource = new BindingList<PhieuMuon>(filtered);
        dgv.DataSource = bsPhieuMuon;
        dangNapDuLieu = false;
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        lblTong.Text = $"Tổng số phiếu: {danhSach.Count}";
        lblQuaHan.Text = $"Số phiếu quá hạn: {danhSach.Count(p => p.TrangThai == "Quá hạn")}";
    }

    private void ExportCsv()
    {
        using var dialog = new SaveFileDialog
        {
            Filter = "CSV (*.csv)|*.csv",
            FileName = "PhieuMuon.csv",
            Title = "Xuất các phiếu đang hiển thị"
        };
        if (dialog.ShowDialog() != DialogResult.OK) return;

        var visible = bsPhieuMuon.List.Cast<PhieuMuon>().ToList();
        using var writer = new StreamWriter(dialog.FileName, false, new UTF8Encoding(true));
        writer.WriteLine("MaPhieu,MaSV,HoTen,ThietBi,SoLuong,NgayMuon,HanTra,NgayTraThucTe,TrangThai");

        foreach (var p in visible)
        {
            var values = new[]
            {
                p.MaPhieu, p.MaSV, p.HoTen, p.ThietBi, p.SoLuong.ToString(),
                p.NgayMuon.ToString("dd/MM/yyyy"), p.HanTra.ToString("dd/MM/yyyy"),
                p.NgayTraThucTe?.ToString("dd/MM/yyyy") ?? "", p.TrangThai
            };
            writer.WriteLine(string.Join(",", values.Select(EscapeCsv)));
        }
        MessageBox.Show($"Đã xuất {visible.Count} phiếu ra CSV.", "Xuất dữ liệu",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private static string EscapeCsv(string value) => "\"" + value.Replace("\"", "\"\"") + "\"";
}
