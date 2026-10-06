using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bai5._2
{
    public partial class Form1 : Form
    {
        Dictionary<string, List<string>> services =
            new Dictionary<string, List<string>>()
            {
                {
                    "Khám bệnh",
                    new List<string>()
                    {
                        "Khám tổng quát - 200000",
                        "Khám chuyên khoa - 300000"
                    }
                },
                {
                    "Xét nghiệm",
                    new List<string>()
                    {
                        "Xét nghiệm máu - 150000",
                        "Xét nghiệm nước tiểu - 100000"
                    }
                },
                {
                    "Chụp X-Quang",
                    new List<string>()
                    {
                        "X-Quang phổi - 250000",
                        "X-Quang xương - 300000"
                    }
                },
                {
                    "Vắc-xin",
                    new List<string>()
                    {
                        "Vắc-xin cúm - 300000",
                        "Vắc-xin viêm gan B - 250000"
                    }
                }
            };

        public Form1()
        {
            InitializeComponent();

            cboCategory.Items.Add("Khám bệnh");
            cboCategory.Items.Add("Xét nghiệm");
            cboCategory.Items.Add("Chụp X-Quang");
            cboCategory.Items.Add("Vắc-xin");

            cboCategory.SelectedIndex = 0;
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAvailableServices.Items.Clear();

            string category = cboCategory.SelectedItem.ToString();

            foreach (string service in services[category])
            {
                lstAvailableServices.Items.Add(service);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstAvailableServices.SelectedItem != null)
            {
                lstSelectedServices.Items.Add(
                    lstAvailableServices.SelectedItem
                );

                lstAvailableServices.Items.Remove(
                    lstAvailableServices.SelectedItem
                );

                CalculateTotal();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelectedServices.SelectedItem != null)
            {
                lstAvailableServices.Items.Add(
                    lstSelectedServices.SelectedItem
                );

                lstSelectedServices.Items.Remove(
                    lstSelectedServices.SelectedItem
                );

                CalculateTotal();
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            lstSelectedServices.Items.Clear();

            CalculateTotal();
        }

        private void lstAvailableServices_DoubleClick(object sender, EventArgs e)
        {
            if (lstAvailableServices.SelectedItem != null)
            {
                lstSelectedServices.Items.Add(
                    lstAvailableServices.SelectedItem
                );

                lstAvailableServices.Items.Remove(
                    lstAvailableServices.SelectedItem
                );

                CalculateTotal();
            }
        }

        private void CalculateTotal()
        {
            double total = 0;

            foreach (string service in lstSelectedServices.Items)
            {
                string[] parts = service.Split('-');

                string priceText = parts[parts.Length - 1].Trim();

                double price;

                if (double.TryParse(priceText, out price))
                {
                    total += price;
                }
            }

            lblTotal.Text = total.ToString("N0") + " VNĐ";

            double discount = 0;

            if (total >= 1000000)
            {
                discount = 10;
            }
            else if (total >= 500000)
            {
                discount = 5;
            }

            lblDiscount.Text = discount + "%";

            double payment = total - total * discount / 100;

            lblPayment.Text = payment.ToString("N0") + " VNĐ";
        }

        private void lblSelected_Click(object sender, EventArgs e)
        {

        }
    }
}
