using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bai4_4
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> prices = new Dictionary<string, int>()
        {
            { "Hamburger - 50k", 50000 },
            { "Pizza - 120k", 120000 },
            { "Gà Rán - 35k", 35000 },
            { "Pepsi - 15k", 15000 }
        };

        public Form1()
        {
            InitializeComponent();

            LoadMenu();

            // Gán sự kiện cho 2 nút
            btnAdd.Click += btnAdd_Click;
            btn2.Click += btn2_Click;
        }

        private void LoadMenu()
        {
            // Xóa mấy chữ Menu / DaChon anh đã nhập sẵn trong Items
            Menu.Items.Clear();
            DaChon.Items.Clear();

            // Danh sách món ăn
            Menu.Items.Add("Hamburger - 50k");
            Menu.Items.Add("Pizza - 120k");
            Menu.Items.Add("Gà Rán - 35k");
            Menu.Items.Add("Pepsi - 15k");

            UpdateTotal();
        }

        // Nút >
        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (Menu.SelectedItem != null)
            {
                string food = Menu.SelectedItem.ToString()!;

                DaChon.Items.Add(food);

                UpdateTotal();
            }
        }

        // Nút <
        private void btn2_Click(object? sender, EventArgs e)
        {
            if (DaChon.SelectedItem != null)
            {
                DaChon.Items.Remove(DaChon.SelectedItem);

                UpdateTotal();
            }
        }

        // Tính tổng tiền
        private void UpdateTotal()
        {
            int total = 0;

            foreach (var item in DaChon.Items)
            {
                string food = item.ToString()!;

                if (prices.ContainsKey(food))
                {
                    total += prices[food];
                }
            }

            lblTotal.Text = "Tổng tiền: " +
                            total.ToString("N0") +
                            " VNĐ";
        }
    }
}