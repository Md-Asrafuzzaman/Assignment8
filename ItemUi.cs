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
    public partial class ItemUi : Form
    { 
        IteamManager _iteamManager = new IteamManager();
         public ItemUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Check UNIQUE
            if (_iteamManager.IsNameExists(nameTextBox.Text))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exists!");
                return;
            }

            //Set Price as Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }

            //Add/Insert Item
            bool isAdded = _iteamManager.Add(nameTextBox.Text, Convert.ToDouble(priceTextBox.Text));

            if (isAdded)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

            showDataGridView.DataSource =_iteamManager.Display();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _iteamManager.Display();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            //Delete
            if (_iteamManager.Delete(Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            showDataGridView.DataSource = _iteamManager.Display();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _iteamManager.Search(nameTextBox.Text);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }

            if (_iteamManager.Update(nameTextBox.Text, Convert.ToDouble(priceTextBox.Text), Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _iteamManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }
        //Method
    }
}
