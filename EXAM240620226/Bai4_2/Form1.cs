using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
                "\nSố điện thoại: " + mtxtPhone.Text +
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
            string gender;

            if (rdoMale.Checked)
                gender = "Nam";
            else if (rdoFemale.Checked)
                gender = "Nữ";
            else
                gender = "Chưa chọn";

            string paid = chkPaid.Checked ? "Đã đóng" : "Chưa đóng";

            string info =
                "Họ tên: " + txtName.Text +
                "\nSố điện thoại: " + mtxtPhone.Text +
                "\nNgày sinh: " + dtpBirthDate.Value.ToString("dd/MM/yyyy") +
                "\nKhóa học: " + cboCourse.Text +
                "\nGiới tính: " + gender +
                "\nHọc phí: " + paid;

            MessageBox.Show(
                info,
                "Đăng ký thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void mtxtPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}