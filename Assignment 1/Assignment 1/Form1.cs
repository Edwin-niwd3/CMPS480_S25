using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_1
{
   
    public partial class Form1 : Form
    {
        // Inventory
        List<string> productNames = new List<string>() { "Lego Star Wars", "Cookie" };
        List<double> productPrices = new List<double>() { 25.00, 5.00 };
        List<double> reportTotals = new List<double>();

        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Welcome to Target! Choose the following options:\nCMPS 480: Distributed Internet Computing Spring 2025", "Welcome");
        }

        private void MakePurchase(object sender, EventArgs e)
        {
            List<string> purchaseItems = new List<string>();
            List<double> purchasePrices = new List<double>();

            bool keepGoing = true;

            while (keepGoing)
            {
                string inventoryList = "Item Name\tPrice\n";
                for (int i = 0; i < productNames.Count; i++)
                    inventoryList += $"{productNames[i]}\t${productPrices[i]}\n";

                string input = PromptInput("Which product would you like to purchase?\n" + inventoryList);
                int index = productNames.FindIndex(p => p.Equals(input, StringComparison.OrdinalIgnoreCase));

                if (index != -1)
                {
                    purchaseItems.Add(productNames[index]);
                    purchasePrices.Add(productPrices[index]);
                }
                else
                {
                    MessageBox.Show("Item not found!");
                }

                var result = MessageBox.Show("Anything else?", "Continue?", MessageBoxButtons.YesNo);
                keepGoing = (result == DialogResult.Yes);
            }

            double total = purchasePrices.Sum();
            reportTotals.Add(total);

            MessageBox.Show($"Your Total is ${total}.\nThank you for shopping at Target!");
        }

        private void MakeReturn(object sender, EventArgs e)
        {
            List<string> returnItems = new List<string>();
            List<double> returnPrices = new List<double>();

            bool keepGoing = true;

            while (keepGoing)
            {
                string inventoryList = "Item Name\tPrice\n";
                for (int i = 0; i < productNames.Count; i++)
                    inventoryList += $"{productNames[i]}\t${productPrices[i]}\n";

                string input = PromptInput("Which product would you like to return?\n" + inventoryList);
                int index = productNames.FindIndex(p => p.Equals(input, StringComparison.OrdinalIgnoreCase));

                if (index != -1)
                {
                    returnItems.Add(productNames[index]);
                    returnPrices.Add(productPrices[index]);
                }
                else
                {
                    MessageBox.Show("Item not found!");
                }

                var result = MessageBox.Show("Anything else?", "Continue?", MessageBoxButtons.YesNo);
                keepGoing = (result == DialogResult.Yes);
            }

            double totalReturn = returnPrices.Sum();
            MessageBox.Show($"Your Refund total is ${totalReturn}.\nThank you for shopping at Target!");
            reportTotals[0] = reportTotals[0] - totalReturn;
        }

        private void ManageInventory(object sender, EventArgs e)
        {
            while (true)
            {
                // Build inventory display
                string inventory = "Item Name\tPrice\n";
                for (int i = 0; i < productNames.Count; i++)
                {
                    inventory += $"{productNames[i]}\t${productPrices[i]:F2}\n";
                }

                // Prompt user for next action
                string input = PromptInput(
                    "Manage Inventory\n" +
                    "The following items are currently stored in the system:\n" +
                    inventory + "\n" +
                    "Choose an option:\n- Add New Item\n- Remove Item\n- Main Menu");

                if (input.Equals("Add New Item", StringComparison.OrdinalIgnoreCase))
                {
                    string itemName = PromptInput("Add Item:\nItem Name:");
                    string priceInput = PromptInput("Item Price:");

                    if (double.TryParse(priceInput, out double itemPrice))
                    {
                        productNames.Add(itemName);
                        productPrices.Add(itemPrice);
                        MessageBox.Show("Added Successfully!!");
                    }
                    else
                    {
                        MessageBox.Show("Invalid price. Please try again.");
                    }
                }
                else if (input.Equals("Remove Item", StringComparison.OrdinalIgnoreCase))
                {
                    string itemName = PromptInput("Remove Item:\nItem Name to remove:");
                    int index = productNames.FindIndex(p => p.Equals(itemName, StringComparison.OrdinalIgnoreCase));

                    if (index != -1)
                    {
                        productNames.RemoveAt(index);
                        productPrices.RemoveAt(index);
                        MessageBox.Show("Item Removed Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Item Not Found! Please Try Again!");
                    }
                }
                else if (input.Equals("Main Menu", StringComparison.OrdinalIgnoreCase))
                {
                    break; // exit the loop
                }
                else
                {
                    MessageBox.Show("Invalid option. Please enter exactly: Add New Item, Remove Item, or Main Menu.");
                }
            }

        }

        private void ViewReports(object sender, EventArgs e)
        {
            int customerCount = reportTotals.Count;
            double totalProfit = reportTotals.Sum();

            MessageBox.Show($"Reports:\nTotal Customers: {customerCount}\nTotal Profit: ${totalProfit:F2}\n\nClick OK to return to the main menu.");
        }

        private string PromptInput(string prompt)
        {
            using (var form = new InputBoxForm(prompt))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    return form.InputValue;
            }
            return string.Empty;
        }
    }
}
