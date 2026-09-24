using System;
using System.Windows.Forms;

namespace Bai4_3
{
    public partial class Form1 : Form
    {
        double firstNumber = 0;
        string operation = "";
        bool newNumber = false;

        public Form1()
        {
            InitializeComponent();

            // 10 nút số dùng chung 1 event
            btn0.Click += NumberButton_Click;
            btn1.Click += NumberButton_Click;
            btn2.Click += NumberButton_Click;
            btn3.Click += NumberButton_Click;
            btn4.Click += NumberButton_Click;
            btn5.Click += NumberButton_Click;
            btn6.Click += NumberButton_Click;
            btn7.Click += NumberButton_Click;
            btn8.Click += NumberButton_Click;
            btn9.Click += NumberButton_Click;

            // Các nút phép toán dùng chung event
            btnAdd.Click += OperatorButton_Click;
            btnSubtract.Click += OperatorButton_Click;
            btnMultiply.Click += OperatorButton_Click;
            btnDivide.Click += OperatorButton_Click;

            // Nút = và C
            btnEqual.Click += btnEqual_Click;
            btnClear.Click += btnClear_Click;
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (newNumber)
            {
                txtDisplay.Clear();
                newNumber = false;
            }

            txtDisplay.Text += btn.Text;
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (txtDisplay.Text == "")
                return;

            firstNumber = double.Parse(txtDisplay.Text);
            operation = btn.Text;

            newNumber = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "" || operation == "")
                return;

            double secondNumber = double.Parse(txtDisplay.Text);
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;

                case "-":
                    result = firstNumber - secondNumber;
                    break;

                case "*":
                    result = firstNumber * secondNumber;
                    break;

                case "/":
                    if (secondNumber == 0)
                    {
                        MessageBox.Show(
                            "Không thể chia cho 0!",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        return;
                    }

                    result = firstNumber / secondNumber;
                    break;
            }

            txtDisplay.Text = result.ToString();

            operation = "";
            newNumber = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();

            firstNumber = 0;
            operation = "";
            newNumber = false;
        }
    }
}