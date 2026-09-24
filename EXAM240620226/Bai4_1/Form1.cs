namespace Bai4_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool valid = true;
            if (txtUsername.Text.Trim() == "")
            {
                errorProvider1.SetError(txtUsername, "Vui lòng nhập tên đăng nhập.");
                valid = false;
            }
            if (txtPassword.Text.Trim() == "")
            {
                errorProvider1.SetError(txtPassword, "Vui lòng nhập mật khẩu.");
                valid = false;
            }
            if (valid)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}