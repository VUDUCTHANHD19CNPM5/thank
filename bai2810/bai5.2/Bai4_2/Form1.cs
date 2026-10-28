using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bai4_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadCourses();
        }
        class Course
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
        }

        private void LoadCourses()
        {
            List<Course> courses = new List<Course>()
            {
                new Course { Id = 1, Name = "Lập trình C#" },
                new Course { Id = 2, Name = "Java" },
                new Course { Id = 3, Name = "Thiết kế Web" },
                new Course { Id = 4, Name = "Cơ sở dữ liệu" }
            };

            cboCourse.DataSource = courses;
            cboCourse.DisplayMember = "Name";
            cboCourse.ValueMember = "Id";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string gender = "";

            if (rdoMale.Checked)
            {
                gender = "Nam";
            }
            else if (rdoFemale.Checked)
            {
                gender = "Nữ";
            }
            else
            {
                gender = "Chưa chọn";
            }

            string paid;

            if (chkPaid.Checked)
            {
                paid = "Đã đóng";
            }
            else
            {
                paid = "Chưa đóng";
            }

            string info =
                "Họ tên: " + txtName.Text +
                "\nSố điện thoại: " + txtPhone.Text +
                "\nNgày sinh: " + dtpBirthDate.Value.ToString("dd/MM/yyyy") +
                "\nKhóa học: " + cboCourse.Text +
                "\nGiới tính: " + gender +
                "\nHọc phí: " + paid;

            MessageBox.Show(
                info,
                "Thông tin đăng ký",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            string hoTen = txtName.Text.Trim();
            string sdt = txtPhone.Text.Trim();
            DateTime ngaySinh = dtpBirthDate.Value;
            string khoaHoc = cboCourse.Text;
            string gioiTinh = "Chưa chọn";
            if (rdoMale.Checked) gioiTinh = "Nam";
            else if (rdoFemale.Checked) gioiTinh = "Nữ";

            bool daDongHocPhi = chkPaid.Checked;
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên học viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string connString = "Server=localhost;Database=ql_hocvien;Uid=root;Pwd=Thanhbuco12@;Port=3307;";
            string query = "INSERT INTO HocVien (ho_ten, sdt, ngay_sinh, khoa_hoc, gioi_tinh, da_dong_hoc_phi) " +
                           "VALUES (@hoTen, @sdt, @ngaySinh, @khoaHoc, @gioiTinh, @daDongHocPhi)";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Gán giá trị vào tham số
                        cmd.Parameters.AddWithValue("@hoTen", hoTen);
                        cmd.Parameters.AddWithValue("@sdt", sdt);
                        cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@khoaHoc", khoaHoc);
                        cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@daDongHocPhi", daDongHocPhi ? 1 : 0);

                        // Thực thi câu lệnh
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Đăng ký thành công và đã lưu vào CSDL MySQL!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối/lưu CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mtxtPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}