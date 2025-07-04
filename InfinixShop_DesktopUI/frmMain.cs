﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using InfinixShop_BusinessLogic;
using InfinixShop_Common;

namespace InfinixShop_Desktop
{
    public partial class frmMain : Form
    {
        private static string[] phoneCategories = { "Entry Level Phones", "Mid-range Phones", "High-end Phones" };
        private static Dictionary<string, string[]> phonesByCategory = new Dictionary<string, string[]>
        {
            { "Entry Level Phones", new string[] { "Infinix Hot 50i 8GB RAM", "Infinix Smart 9 8GB RAM", "Infinix Note 40s 8GB RAM" } },
            { "Mid-range Phones", new string[] { "Infinix Note 40 5G 20GB RAM", "Infinix GT 20 Pro 5G 20GB RAM" } },
            { "High-end Phones", new string[] { "Infinix Zero Flip 32GB RAM" } }
        };

        public frmMain()
        {
            InitializeComponent();
            pnlWelcome.Visible = true;
            pnlMainContent.Visible = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            PopulateCategories();
        }

        private void btnViewShop_Click(object sender, EventArgs e)
        {
            pnlWelcome.Visible = false;
            pnlMainContent.Visible = true;
            tabControlMain.SelectedTab = tabPageShop;
            PopulateCategories();
            PopulateCartItems();
        }

        private void btnNoThanks_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for visiting! Have a great day!", "Goodbye", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void PopulateCategories()
        {
            lbCategories.Items.Clear();
            foreach (var category in phoneCategories)
            {
                lbCategories.Items.Add(category);
            }
            if (lbCategories.Items.Count > 0)
            {
                lbCategories.SelectedIndex = 0;
            }
        }

        private void lbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbAvailablePhones.Items.Clear();
            if (lbCategories.SelectedItem != null)
            {
                string selectedCategory = lbCategories.SelectedItem.ToString();
                if (phonesByCategory.ContainsKey(selectedCategory))
                {
                    foreach (var phone in phonesByCategory[selectedCategory])
                    {
                        lbAvailablePhones.Items.Add(phone);
                    }
                }
            }
        }

        private void btnAddSelectedToCart_Click(object sender, EventArgs e)
        {
            if (lbAvailablePhones.SelectedItem != null)
            {
                string selectedPhone = lbAvailablePhones.SelectedItem.ToString();
                PhoneItem addedItem = InfinixShopLogic.AddToCart(selectedPhone);

                if (addedItem != null)
                {
                    MessageBox.Show($"{selectedPhone} added to cart!", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopulateCartItems();
                }
                else
                {
                    MessageBox.Show("Item is already in the cart or failed to add!", "Duplicate/Failed Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a phone to add to cart.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void PopulateCartItems()
        {
            lbCartItems.Items.Clear();
            List<string> cartItemNames = InfinixShopLogic.GetCartItemNames();

            if (cartItemNames.Any())
            {
                foreach (var item in cartItemNames)
                {
                    lbCartItems.Items.Add(item);
                }
            }
            else
            {
                lbCartItems.Items.Add("Your cart is empty!");
            }
        }

        private void btnRemoveSelectedFromCart_Click(object sender, EventArgs e)
        {
            if (lbCartItems.SelectedItem != null && lbCartItems.SelectedItem.ToString() != "Your cart is empty!")
            {
                string itemToRemove = lbCartItems.SelectedItem.ToString();
                DialogResult confirmResult = MessageBox.Show($"Are you sure you want to remove '{itemToRemove}' from your cart?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    PhoneItem removedItem = InfinixShopLogic.RemoveFromCart(itemToRemove);

                    if (removedItem != null)
                    {
                        MessageBox.Show($"{itemToRemove} removed from cart!", "Item Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PopulateCartItems();
                    }
                    else
                    {
                        MessageBox.Show("Failed to remove the item from the cart (item not found or removal failed).", "Removal Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to remove from the cart.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabPageCart)
            {
                PopulateCartItems();
            }
        }
        private void btnExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}