namespace Bai4_4
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
            lblTotal = new Label();
            Menu = new ListBox();
            DaChon = new ListBox();
            btnAdd = new Button();
            btn2 = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AccessibleName = "lblTitle";
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(192, 52);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(404, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐẶT HÀNG FASTFOOD";
            // 
            // lblTotal
            // 
            lblTotal.AccessibleName = "lblTotal";
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(152, 317);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(75, 20);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Tổng tiền:";
            // 
            // Menu
            // 
            Menu.AccessibleName = "lstMenu";
            Menu.FormattingEnabled = true;
            Menu.Location = new Point(152, 148);
            Menu.Name = "Menu";
            Menu.Size = new Size(150, 104);
            Menu.TabIndex = 2;
            // 
            // DaChon
            // 
            DaChon.AccessibleName = "lstSelected";
            DaChon.FormattingEnabled = true;
            DaChon.Location = new Point(488, 148);
            DaChon.Name = "DaChon";
            DaChon.Size = new Size(150, 104);
            DaChon.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(347, 165);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 4;
            btnAdd.Text = ">";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btn2
            // 
            btn2.AccessibleName = "btnRemove";
            btn2.Location = new Point(347, 210);
            btn2.Name = "btn2";
            btn2.Size = new Size(94, 29);
            btn2.TabIndex = 5;
            btn2.Text = "<";
            btn2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn2);
            Controls.Add(btnAdd);
            Controls.Add(DaChon);
            Controls.Add(Menu);
            Controls.Add(lblTotal);
            Controls.Add(lblTitle);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblTotal;
        private ListBox Menu;
        private ListBox DaChon;
        private Button btnAdd;
        private Button btn2;
    }
}
