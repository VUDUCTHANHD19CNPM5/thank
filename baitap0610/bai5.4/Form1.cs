using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bai5._4
{
    public partial class Form1 : Form
    {
        List<Employee> employees = new List<Employee>();

        public Form1()
        {
            InitializeComponent();
            cboViewMode.Items.Add("Details");
            cboViewMode.Items.Add("SmallIcon");
            cboViewMode.Items.Add("LargeIcon");
            cboViewMode.Items.Add("Tile");

            cboViewMode.SelectedIndex = 0;
            CreateTree();
            CreateEmployees();
            lsvEmployees.View = View.Details;
            lsvEmployees.FullRowSelect = true;
            lsvEmployees.GridLines = true;
            lsvEmployees.HideSelection = false;
            lsvEmployees.SmallImageList = imgList;
            lsvEmployees.LargeImageList = imgList;
        }
        private void CreateTree()
        {
            tvDepartments.Nodes.Clear();

            TreeNode company = new TreeNode("Công ty");

            TreeNode kinhDoanh = new TreeNode("Phòng Kinh doanh");
            kinhDoanh.Nodes.Add("Nhóm Sales");
            kinhDoanh.Nodes.Add("Nhóm Marketing");

            TreeNode kyThuat = new TreeNode("Phòng Kỹ thuật");
            kyThuat.Nodes.Add("Nhóm Backend");
            kyThuat.Nodes.Add("Nhóm Frontend");

            TreeNode nhanSu = new TreeNode("Phòng Nhân sự");
            nhanSu.Nodes.Add("Nhóm Tuyển dụng");
            nhanSu.Nodes.Add("Nhóm C&B");

            company.Nodes.Add(kinhDoanh);
            company.Nodes.Add(kyThuat);
            company.Nodes.Add(nhanSu);

            tvDepartments.Nodes.Add(company);

            company.Expand();
        }
        private void CreateEmployees()
        {
            employees.Add(new Employee
            {
                MaNV = "NV001",
                HoTen = "Nguyễn Văn An",
                ChucVu = "Nhân viên",
                NgayVaoLam = "01/01/2023",
                PhongBan = "Phòng Kinh doanh",
                Nhom = "Nhóm Sales"
            });

            employees.Add(new Employee
            {
                MaNV = "NV002",
                HoTen = "Trần Thị Bình",
                ChucVu = "Trưởng nhóm",
                NgayVaoLam = "15/02/2023",
                PhongBan = "Phòng Kinh doanh",
                Nhom = "Nhóm Sales"
            });

            employees.Add(new Employee
            {
                MaNV = "NV003",
                HoTen = "Lê Văn Cường",
                ChucVu = "Nhân viên",
                NgayVaoLam = "20/03/2023",
                PhongBan = "Phòng Kinh doanh",
                Nhom = "Nhóm Marketing"
            });

            employees.Add(new Employee
            {
                MaNV = "NV004",
                HoTen = "Phạm Văn Dũng",
                ChucVu = "Lập trình viên",
                NgayVaoLam = "10/01/2024",
                PhongBan = "Phòng Kỹ thuật",
                Nhom = "Nhóm Backend"
            });

            employees.Add(new Employee
            {
                MaNV = "NV005",
                HoTen = "Nguyễn Thị Hoa",
                ChucVu = "Lập trình viên",
                NgayVaoLam = "05/02/2024",
                PhongBan = "Phòng Kỹ thuật",
                Nhom = "Nhóm Frontend"
            });

            employees.Add(new Employee
            {
                MaNV = "NV006",
                HoTen = "Đỗ Văn Nam",
                ChucVu = "Nhân viên",
                NgayVaoLam = "12/04/2024",
                PhongBan = "Phòng Nhân sự",
                Nhom = "Nhóm Tuyển dụng"
            });

            employees.Add(new Employee
            {
                MaNV = "NV007",
                HoTen = "Vũ Thị Lan",
                ChucVu = "Chuyên viên",
                NgayVaoLam = "20/05/2024",
                PhongBan = "Phòng Nhân sự",
                Nhom = "Nhóm C&B"
            });
        }
        private void tvDepartments_AfterSelect(
            object sender,
            TreeViewEventArgs e)
        {
            string nodeName = e.Node.Text;

            lsvEmployees.Items.Clear();

            foreach (Employee employee in employees)
            {
                bool match = false;
                if (employee.Nhom == nodeName)
                {
                    match = true;
                }
                if (employee.PhongBan == nodeName)
                {
                    match = true;
                }
                if (nodeName == "Công ty")
                {
                    match = true;
                }

                if (match)
                {
                    ListViewItem item = new ListViewItem(employee.MaNV);

                    item.SubItems.Add(employee.HoTen);
                    item.SubItems.Add(employee.ChucVu);
                    item.SubItems.Add(employee.NgayVaoLam);

                    lsvEmployees.Items.Add(item);
                }
            }
        }
        private void cboViewMode_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (cboViewMode.SelectedItem == null)
                return;

            string mode = cboViewMode.SelectedItem.ToString();

            switch (mode)
            {
                case "Details":
                    lsvEmployees.View = View.Details;
                    break;

                case "SmallIcon":
                    lsvEmployees.View = View.SmallIcon;
                    break;

                case "LargeIcon":
                    lsvEmployees.View = View.LargeIcon;
                    break;

                case "Tile":
                    lsvEmployees.View = View.Tile;
                    break;
            }
        }
    }
}
