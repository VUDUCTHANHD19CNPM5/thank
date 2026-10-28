namespace Bai4_2
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
            lblTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtName = new TextBox();
            txtPhone = new MaskedTextBox();
            dtpBirthDate = new DateTimePicker();
            cboCourse = new ComboBox();
            rdoMale = new RadioButton();
            rdoFemale = new RadioButton();
            chkPaid = new CheckBox();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(200, 51);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(265, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG KÝ HỌC VIÊN";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 122);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 1;
            label1.Text = "Họ tên:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 149);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 2;
            label2.Text = "Số điện thoại:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(102, 178);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 3;
            label3.Text = "Ngày sinh:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(102, 207);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 4;
            label4.Text = "Khóa học:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(102, 233);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 5;
            label5.Text = "Giới tính:";
            // 
            // txtName
            // 
            txtName.Location = new Point(200, 117);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(219, 23);
            txtName.TabIndex = 6;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(200, 144);
            txtPhone.Margin = new Padding(3, 2, 3, 2);
            txtPhone.Mask = "(000) 000-0000";
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(219, 23);
            txtPhone.TabIndex = 7;
            txtPhone.MaskInputRejected += mtxtPhone_MaskInputRejected;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.Location = new Point(200, 173);
            dtpBirthDate.Margin = new Padding(3, 2, 3, 2);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(219, 23);
            dtpBirthDate.TabIndex = 8;
            // 
            // cboCourse
            // 
            cboCourse.FormattingEnabled = true;
            cboCourse.Location = new Point(200, 201);
            cboCourse.Margin = new Padding(3, 2, 3, 2);
            cboCourse.Name = "cboCourse";
            cboCourse.Size = new Size(219, 23);
            cboCourse.TabIndex = 9;
            // 
            // rdoMale
            // 
            rdoMale.AutoSize = true;
            rdoMale.Location = new Point(200, 230);
            rdoMale.Margin = new Padding(3, 2, 3, 2);
            rdoMale.Name = "rdoMale";
            rdoMale.Size = new Size(51, 19);
            rdoMale.TabIndex = 10;
            rdoMale.TabStop = true;
            rdoMale.Text = "Nam";
            rdoMale.UseVisualStyleBackColor = true;
            // 
            // rdoFemale
            // 
            rdoFemale.AutoSize = true;
            rdoFemale.Location = new Point(265, 230);
            rdoFemale.Margin = new Padding(3, 2, 3, 2);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Size = new Size(41, 19);
            rdoFemale.TabIndex = 11;
            rdoFemale.TabStop = true;
            rdoFemale.Text = "Nữ";
            rdoFemale.UseVisualStyleBackColor = true;
            // 
            // chkPaid
            // 
            chkPaid.AutoSize = true;
            chkPaid.Location = new Point(102, 257);
            chkPaid.Margin = new Padding(3, 2, 3, 2);
            chkPaid.Name = "chkPaid";
            chkPaid.Size = new Size(114, 19);
            chkPaid.TabIndex = 12;
            chkPaid.Text = "Đã đóng học phí";
            chkPaid.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(200, 286);
            btnRegister.Margin = new Padding(3, 2, 3, 2);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(82, 22);
            btnRegister.TabIndex = 13;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnRegister);
            Controls.Add(chkPaid);
            Controls.Add(rdoFemale);
            Controls.Add(rdoMale);
            Controls.Add(cboCourse);
            Controls.Add(dtpBirthDate);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtName;
        private MaskedTextBox txtPhone;
        private DateTimePicker dtpBirthDate;
        private ComboBox cboCourse;
        private RadioButton rdoMale;
        private RadioButton rdoFemale;
        private CheckBox chkPaid;
        private Button btnRegister;
    }
}
