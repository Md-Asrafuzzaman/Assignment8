using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWindowsFormsApp.BLL;
using MyWindowsFormsApp.Model;
namespace MyWindowsFormsApp
{
    public partial class CustomerUI : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        public CustomerUI()
        {
            InitializeComponent();
        }

        //addButton_Click Action
        private void addButton_Click(object sender, EventArgs e)
        {
            //Check UNIQUE
            if (_customerManager.IsNameExists(customerNameTextBox.Text))
            {
                MessageBox.Show(customerNameTextBox.Text + " Already Exists!");
                return;
            }
            bool isAdded = _customerManager.AddCustomerInfo(customerNameTextBox.Text, customerAddressTextBox.Text, contactTextBox.Text);
            if (isAdded)
            {
                MessageBox.Show("Saved");
                showDataGridView.DataSource = _customerManager.Display();
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
        }

        //addButton_Click Action 
        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.Display();
        }

        //updateButton_Click Action
        private void updateButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(customerIdTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            if (_customerManager.UpdateCustomerInfo(Convert.ToInt16(customerIdTextBox.Text), customerNameTextBox.Text, customerAddressTextBox.Text, contactTextBox.Text))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _customerManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }
        //searchButton_Click Action
        private void searchButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.SearchCustomerInfo(customerNameTextBox.Text);
        }

        //deleteButton_Click Action
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(customerIdTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            //Delete
            if (_customerManager.DeleteCustomerInfo(Convert.ToInt32(customerIdTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            showDataGridView.DataSource = _customerManager.Display();
        }
    }
}
