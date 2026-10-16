using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClinicAppointmentManager
{
    public class FormMain : Form
    {
        private readonly BindingList<LichHen> danhSachLichHen = new BindingList<LichHen>();
        private readonly BindingSource bsLichHen = new BindingSource();
        private readonly ErrorProvider errorProvider1 = new ErrorProvider();

        private TextBox txtMaLich = new TextBox();
        private TextBox txtHoTen = new TextBox();
        private TextBox txtSDT = new TextBox();
        private TextBox txtLyDo = new TextBox();
        private TextBox txtTimKiem = new TextBox();
        private DateTimePicker dtpNgayGio = new DateTimePicker();
        private DateTimePicker dtpLocNgay = new DateTimePicker();
        private ComboBox cboBacSi = new ComboBox();
        private ComboBox cboTrangThai = new ComboBox();
        private ComboBox cboLocTrangThai = new ComboBox();
        private CheckBox chkLocNgay = new CheckBox();
        private CheckBox chkLocTrangThai = new CheckBox();
        private DataGridView dgvLichHen = new DataGridView();
        private ToolStripStatusLabel lblSoLuong = new ToolStripStatusLabel();
        private bool dangNapDuLieu;

        private readonly string[] cacTrangThai = { "Chờ khám", "Đang khám", "Hoàn tất", "Đã hủy" };
        private readonly string[] cacBacSi = { "BS. Nguyễn Minh Anh", "BS. Trần Quốc Bảo", "BS. Lê Thu Hà", "BS. Phạm Hoàng Nam" };

        public FormMain()
        {
            Text = "Clinic Appointment Manager";
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(1050, 680);
            Size = new Size(1280, 800);
            Font = new Font("Segoe UI", 9F);
            BuildInterface();
            ConfigureBinding();
            AddSampleData();
            ApplyFilters();
            ClearInputs();
        }

        private void BuildInterface()
        {
            var menu = new MenuStrip();
            var menuFile = new ToolStripMenuItem("Tệp");
            var menuExport = new ToolStripMenuItem("Xuất danh sách đang hiển thị ra CSV");
            var menuExit = new ToolStripMenuItem("Thoát");
            menuExport.Click += (s, e) => ExportCsv();
            menuExit.Click += (s, e) => Close();
            menuFile.DropDownItems.Add(menuExport);
            menuFile.DropDownItems.Add(new ToolStripSeparator());
            menuFile.DropDownItems.Add(menuExit);
            menu.Items.Add(menuFile);
            MainMenuStrip = menu;

            var status = new StatusStrip();
            lblSoLuong.Text = "Số lịch hẹn: 0";
            status.Items.Add(lblSoLuong);

            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(10),
                BackColor = Color.White
            };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            var title = new Label
            {
                Text = "QUẢN LÝ LỊCH HẸN PHÒNG KHÁM",
                Dock = DockStyle.Fill,
                AutoSize = true,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(25, 91, 130),
                Padding = new Padding(0, 5, 0, 12)
            };

            var inputGroup = new GroupBox
            {
                Text = "Thông tin lịch hẹn",
                Dock = DockStyle.Top,
                AutoSize = true,
                Padding = new Padding(10)
            };
            var inputLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 4,
                RowCount = 4
            };
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16));
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34));
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16));
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34));

            txtMaLich = MakeTextBox();
            txtHoTen = MakeTextBox();
            txtSDT = MakeTextBox();
            txtLyDo = MakeTextBox();
            txtLyDo.Multiline = true;
            txtLyDo.Height = 48;
            dtpNgayGio = new DateTimePicker
            {
                Dock = DockStyle.Fill,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy HH:mm",
                ShowUpDown = true,
                Value = DateTime.Now.AddHours(1)
            };
            cboBacSi = MakeCombo(cacBacSi);
            cboTrangThai = MakeCombo(cacTrangThai);
            cboTrangThai.SelectedIndex = 0;

            AddField(inputLayout, 0, 0, "Mã lịch hẹn:", txtMaLich);
            AddField(inputLayout, 0, 2, "Họ tên bệnh nhân:", txtHoTen);
            AddField(inputLayout, 1, 0, "Số điện thoại:", txtSDT);
            AddField(inputLayout, 1, 2, "Ngày giờ hẹn:", dtpNgayGio);
            AddField(inputLayout, 2, 0, "Bác sĩ:", cboBacSi);
            AddField(inputLayout, 2, 2, "Trạng thái:", cboTrangThai);
            AddField(inputLayout, 3, 0, "Lý do khám:", txtLyDo);
            inputLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            inputLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            inputLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            inputLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            inputGroup.Controls.Add(inputLayout);

            var buttons = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0, 8, 0, 8),
                WrapContents = true
            };
            var btnThem = MakeButton("Thêm lịch hẹn");
            var btnCapNhat = MakeButton("Cập nhật");
            var btnXoa = MakeButton("Xóa");
            var btnLamMoi = MakeButton("Làm mới");
            btnThem.Click += (s, e) => AddAppointment();
            btnCapNhat.Click += (s, e) => UpdateAppointment();
            btnXoa.Click += (s, e) => DeleteAppointment();
            btnLamMoi.Click += (s, e) => ClearInputs();
            buttons.Controls.AddRange(new Control[] { btnThem, btnCapNhat, btnXoa, btnLamMoi });

            var filterGroup = new GroupBox
            {
                Text = "Tìm kiếm và lọc",
                Dock = DockStyle.Top,
                AutoSize = true,
                Padding = new Padding(8)
            };
            var filterLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 6,
                RowCount = 1
            };
            filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));
            filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24));
            filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));

            txtTimKiem = MakeTextBox();
            txtTimKiem.PlaceholderText = "Nhập tên hoặc số điện thoại...";
            txtTimKiem.TextChanged += (s, e) => ApplyFilters();

            chkLocNgay = new CheckBox { Text = "Lọc ngày:", AutoSize = true, Anchor = AnchorStyles.Left };
            dtpLocNgay = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Short, Enabled = false };
            chkLocNgay.CheckedChanged += (s, e) => { dtpLocNgay.Enabled = chkLocNgay.Checked; ApplyFilters(); };
            dtpLocNgay.ValueChanged += (s, e) => ApplyFilters();

            chkLocTrangThai = new CheckBox { Text = "Trạng thái:", AutoSize = true, Anchor = AnchorStyles.Left };
            cboLocTrangThai = MakeCombo(new[] { "Tất cả" }.Concat(cacTrangThai).ToArray());
            cboLocTrangThai.SelectedIndex = 0;
            cboLocTrangThai.Enabled = false;
            chkLocTrangThai.CheckedChanged += (s, e) => { cboLocTrangThai.Enabled = chkLocTrangThai.Checked; ApplyFilters(); };
            cboLocTrangThai.SelectedIndexChanged += (s, e) => ApplyFilters();

            filterLayout.Controls.Add(new Label { Text = "Tìm kiếm:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 0);
            filterLayout.Controls.Add(txtTimKiem, 1, 0);
            filterLayout.Controls.Add(chkLocNgay, 2, 0);
            filterLayout.Controls.Add(dtpLocNgay, 3, 0);
            filterLayout.Controls.Add(chkLocTrangThai, 4, 0);
            filterLayout.Controls.Add(cboLocTrangThai, 5, 0);
            filterGroup.Controls.Add(filterLayout);

            dgvLichHen = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D
            };
            dgvLichHen.Columns.Add(MakeColumn("Mã lịch", nameof(LichHen.MaLichHen), 80));
            dgvLichHen.Columns.Add(MakeColumn("Họ tên bệnh nhân", nameof(LichHen.HoTen), 150));
            dgvLichHen.Columns.Add(MakeColumn("Số điện thoại", nameof(LichHen.SoDienThoai), 110));
            dgvLichHen.Columns.Add(MakeColumn("Ngày giờ hẹn", nameof(LichHen.NgayGioHen), 130, "dd/MM/yyyy HH:mm"));
            dgvLichHen.Columns.Add(MakeColumn("Bác sĩ", nameof(LichHen.BacSi), 140));
            dgvLichHen.Columns.Add(MakeColumn("Lý do khám", nameof(LichHen.LyDoKham), 160));
            dgvLichHen.Columns.Add(MakeColumn("Trạng thái", nameof(LichHen.TrangThai), 100));
            dgvLichHen.SelectionChanged += (s, e) => LoadSelectedAppointment();

            root.Controls.Add(title, 0, 0);
            root.Controls.Add(inputGroup, 0, 1);
            var middle = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 1, RowCount = 2 };
            middle.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            middle.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            middle.Controls.Add(buttons, 0, 0);
            middle.Controls.Add(filterGroup, 0, 1);
            root.Controls.Add(middle, 0, 2);
            root.Controls.Add(dgvLichHen, 0, 3);

            Controls.Add(root);
            Controls.Add(status);
            Controls.Add(menu);
        }

        private void ConfigureBinding()
        {
            bsLichHen.DataSource = danhSachLichHen;
            dgvLichHen.DataSource = bsLichHen;
            errorProvider1.ContainerControl = this;
            danhSachLichHen.ListChanged += (s, e) => UpdateCount();
        }

        private void AddSampleData()
        {
            danhSachLichHen.Add(new LichHen
            {
                MaLichHen = "LH001",
                HoTen = "Nguyễn Văn An",
                SoDienThoai = "0912345678",
                NgayGioHen = DateTime.Now.AddHours(2),
                BacSi = cacBacSi[0],
                LyDoKham = "Khám tổng quát",
                TrangThai = "Chờ khám"
            });
            danhSachLichHen.Add(new LichHen
            {
                MaLichHen = "LH002",
                HoTen = "Trần Thị Bình",
                SoDienThoai = "0987654321",
                NgayGioHen = DateTime.Now.AddHours(4),
                BacSi = cacBacSi[1],
                LyDoKham = "Tái khám",
                TrangThai = "Đang khám"
            });
        }

        private TextBox MakeTextBox()
        {
            return new TextBox { Dock = DockStyle.Fill, Margin = new Padding(4), MinimumSize = new Size(80, 26) };
        }

        private ComboBox MakeCombo(string[] values)
        {
            var combo = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Margin = new Padding(4)
            };
            combo.Items.AddRange(values);
            if (combo.Items.Count > 0) combo.SelectedIndex = 0;
            return combo;
        }

        private Button MakeButton(string text)
        {
            return new Button
            {
                Text = text,
                AutoSize = true,
                MinimumSize = new Size(105, 34),
                Margin = new Padding(4),
                Padding = new Padding(7, 3, 7, 3)
            };
        }

        private void AddField(TableLayoutPanel layout, int row, int labelColumn, string label, Control control)
        {
            var lbl = new Label
            {
                Text = label,
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(4, 8, 4, 4)
            };
            layout.Controls.Add(lbl, labelColumn, row);
            layout.Controls.Add(control, labelColumn + 1, row);
        }

        private DataGridViewTextBoxColumn MakeColumn(string header, string property, float fill, string format = null)
        {
            var column = new DataGridViewTextBoxColumn
            {
                HeaderText = header,
                DataPropertyName = property,
                FillWeight = fill,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
            if (!string.IsNullOrEmpty(format)) column.DefaultCellStyle.Format = format;
            return column;
        }

        private bool ValidateInputs(LichHen existing = null)
        {
            errorProvider1.Clear();
            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtMaLich.Text))
            {
                errorProvider1.SetError(txtMaLich, "Vui lòng nhập mã lịch hẹn.");
                valid = false;
            }
            else if (danhSachLichHen.Any(x => !ReferenceEquals(x, existing) &&
                         string.Equals(x.MaLichHen.Trim(), txtMaLich.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtMaLich, "Mã lịch hẹn đã tồn tại.");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                errorProvider1.SetError(txtHoTen, "Vui lòng nhập họ tên bệnh nhân.");
                valid = false;
            }

            if (!Regex.IsMatch(txtSDT.Text.Trim(), @"^0\d{9}$"))
            {
                errorProvider1.SetError(txtSDT, "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0.");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLyDo.Text))
            {
                errorProvider1.SetError(txtLyDo, "Vui lòng nhập lý do khám.");
                valid = false;
            }

            if (dtpNgayGio.Value < DateTime.Now)
            {
                errorProvider1.SetError(dtpNgayGio, "Ngày giờ hẹn không được nằm trong quá khứ.");
                valid = false;
            }

            if (cboBacSi.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboBacSi, "Vui lòng chọn bác sĩ.");
                valid = false;
            }

            if (cboTrangThai.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboTrangThai, "Vui lòng chọn trạng thái.");
                valid = false;
            }

            return valid;
        }

        private LichHen ReadInputs()
        {
            return new LichHen
            {
                MaLichHen = txtMaLich.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                NgayGioHen = dtpNgayGio.Value,
                BacSi = cboBacSi.Text,
                LyDoKham = txtLyDo.Text.Trim(),
                TrangThai = cboTrangThai.Text
            };
        }

        private void AddAppointment()
        {
            if (!ValidateInputs()) return;
            danhSachLichHen.Add(ReadInputs());
            ApplyFilters();
            ClearInputs();
            MessageBox.Show("Đã thêm lịch hẹn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateAppointment()
        {
            var selected = GetSelectedAppointment();
            if (selected == null)
            {
                MessageBox.Show("Anh hãy chọn lịch hẹn cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs(selected)) return;
            var updated = ReadInputs();
            selected.MaLichHen = updated.MaLichHen;
            selected.HoTen = updated.HoTen;
            selected.SoDienThoai = updated.SoDienThoai;
            selected.NgayGioHen = updated.NgayGioHen;
            selected.BacSi = updated.BacSi;
            selected.LyDoKham = updated.LyDoKham;
            selected.TrangThai = updated.TrangThai;
            bsLichHen.ResetBindings(false);
            ApplyFilters();
            ClearInputs();
            MessageBox.Show("Đã cập nhật lịch hẹn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteAppointment()
        {
            var selected = GetSelectedAppointment();
            if (selected == null)
            {
                MessageBox.Show("Anh hãy chọn lịch hẹn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Anh có chắc muốn xóa lịch hẹn " + selected.MaLichHen + " của " + selected.HoTen + "?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;
            danhSachLichHen.Remove(selected);
            ApplyFilters();
            ClearInputs();
        }

        private LichHen GetSelectedAppointment()
        {
            if (dgvLichHen.SelectedRows.Count == 0) return null;
            return dgvLichHen.SelectedRows[0].DataBoundItem as LichHen;
        }

        private void LoadSelectedAppointment()
        {
            if (dangNapDuLieu) return;
            var item = GetSelectedAppointment();
            if (item == null) return;

            dangNapDuLieu = true;
            txtMaLich.Text = item.MaLichHen;
            txtHoTen.Text = item.HoTen;
            txtSDT.Text = item.SoDienThoai;
            dtpNgayGio.Value = item.NgayGioHen < dtpNgayGio.MinDate ? dtpNgayGio.MinDate : item.NgayGioHen;
            cboBacSi.SelectedItem = item.BacSi;
            cboTrangThai.SelectedItem = item.TrangThai;
            txtLyDo.Text = item.LyDoKham;
            errorProvider1.Clear();
            dangNapDuLieu = false;
        }

        private void ClearInputs()
        {
            dangNapDuLieu = true;
            errorProvider1.Clear();
            txtMaLich.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtLyDo.Clear();
            dtpNgayGio.Value = DateTime.Now.AddHours(1);
            if (cboBacSi.Items.Count > 0) cboBacSi.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
            dgvLichHen.ClearSelection();
            dangNapDuLieu = false;
            txtMaLich.Focus();
        }

        private void ApplyFilters()
        {
            string keyword = txtTimKiem.Text.Trim();
            bool filterDate = chkLocNgay.Checked;
            DateTime selectedDate = dtpLocNgay.Value.Date;
            bool filterStatus = chkLocTrangThai.Checked;
            string status = cboLocTrangThai.Text;

            var filtered = danhSachLichHen.Where(x =>
                (keyword.Length == 0 ||
                 x.HoTen.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 x.SoDienThoai.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) &&
                (!filterDate || x.NgayGioHen.Date == selectedDate) &&
                (!filterStatus || status == "Tất cả" || x.TrangThai == status))
                .ToList();

            bsLichHen.DataSource = new BindingList<LichHen>(filtered);
            dgvLichHen.DataSource = bsLichHen;
            UpdateCount();
        }

        private void UpdateCount()
        {
            if (lblSoLuong == null) return;
            lblSoLuong.Text = "Số lịch hẹn đang hiển thị: " + dgvLichHen.Rows.Count;
        }

        private void ExportCsv()
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Xuất danh sách lịch hẹn";
                dialog.Filter = "CSV UTF-8 (*.csv)|*.csv";
                dialog.FileName = "DanhSachLichHen.csv";
                dialog.DefaultExt = "csv";
                dialog.AddExtension = true;

                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                var sb = new StringBuilder();
                sb.AppendLine("MaLichHen,HoTen,SoDienThoai,NgayGioHen,BacSi,LyDoKham,TrangThai");

                foreach (DataGridViewRow row in dgvLichHen.Rows)
                {
                    if (row.IsNewRow) continue;
                    var item = row.DataBoundItem as LichHen;
                    if (item == null) continue;

                    sb.AppendLine(string.Join(",", new[]
                    {
                        CsvEscape(item.MaLichHen),
                        CsvEscape(item.HoTen),
                        CsvEscape(item.SoDienThoai),
                        CsvEscape(item.NgayGioHen.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)),
                        CsvEscape(item.BacSi),
                        CsvEscape(item.LyDoKham),
                        CsvEscape(item.TrangThai)
                    }));
                }

                File.WriteAllText(dialog.FileName, "\uFEFF" + sb.ToString(), new UTF8Encoding(true));
                MessageBox.Show("Đã xuất danh sách đang hiển thị ra CSV.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string CsvEscape(string value)
        {
            value = value ?? "";
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }
    }
}
