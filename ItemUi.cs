using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        Item item = new Item();
        public ItemUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
            item.Name = nameTextBox.Text;
            //Check UNIQUE
            if (_iteamManager.IsNameExists(item))
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
            item.Price = Convert.ToDouble(priceTextBox.Text);
            //Add/Insert Item
            bool isAdded = _iteamManager.Add(item);

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
            //if (String.IsNullOrEmpty(idTextBox.Text))
            //{
            //    MessageBox.Show("Id Can not be Empty!!!");
            //    return;
            //}
            MessageBox.Show("Name : "+itemComboBox.Text + " Id : "+itemComboBox.SelectedValue);
            item.Id = Convert.ToInt16(itemComboBox.SelectedValue);
            //Delete
            if (_iteamManager.Delete(item))
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
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                 return;
            }
            item.Name = nameTextBox.Text;
            showDataGridView.DataSource = _iteamManager.Search(item);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            //if (String.IsNullOrEmpty(idTextBox.Text))
            //{
            //    MessageBox.Show("Id Can not be Empty!!!");
            //    return;
            //}
            MessageBox.Show("Name : " + itemComboBox.Text + " Id : " + itemComboBox.SelectedValue);
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }

            item.Name = nameTextBox.Text;
            item.Id = Convert.ToInt16(itemComboBox.SelectedValue);
            item.Price = Convert.ToDouble(priceTextBox.Text);
            if (_iteamManager.Update(item))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _iteamManager.Display();
                itemComboBox.DataSource = _iteamManager.ItemCombobox();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

        private void ItemUi_Load(object sender, EventArgs e)
        {
            itemComboBox.DataSource = _iteamManager.ItemCombobox();
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = showDataGridView.SelectedCells[0].RowIndex;
            nameTextBox.Text = showDataGridView.Rows[i].Cells[1].Value.ToString();
            priceTextBox.Text = showDataGridView.Rows[i].Cells[2].Value.ToString();
        }
        //Method
    }
}
