using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public CustomerUI()
        {
            InitializeComponent();
        }

        Customer customer = new Customer();
        CustomerManager _customerManager = new CustomerManager();
        private void SaveButton_Click(object sender, EventArgs e)
        {

            districtComboBox.DataSource = _customerManager.DistrictCombobox();
            //Code Existing Checking
            customer.Code = codeTextBox.Text;
            if (_customerManager.CodeFieldConditionCheck(customer))
            {
                MessageBox.Show(codeTextBox.Text + " Already Exists!");
                return;
            }
            //Contct Existing Checking
            customer.Contact = contactTextBox.Text;
            if (_customerManager.ContactFieldConditionCheck(customer))
            {
                MessageBox.Show(contactTextBox.Text + " Already Exists!");
                return;
            }
            //Code Length and Not null Checking
            if ((codeTextBox.Text.Length == 4) && (!String.IsNullOrEmpty(codeTextBox.Text)))
            {
                if ((contactTextBox.Text.Length == 11) && (!String.IsNullOrEmpty(contactTextBox.Text)))
                {
                    //Name Not Null Cheking 
                    customer.Name = nameTextBox.Text;
                    if ((!String.IsNullOrEmpty(nameTextBox.Text)))
                    {
                        customer.Address = addressTextBox.Text;
                        customer.District = districtComboBox.Text;
                        //Add Info Request to DB
                        if (saveButton.Text.Equals("Save"))   
                        {
                            bool isAdded = _customerManager.Add(customer);
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
                        else if(_customerManager.Update(customer))
                        {
                            MessageBox.Show("Updated");
                            showDataGridView.DataSource = _customerManager.Display();                          
                        }

                        
                    }
                    else
                    {
                        MessageBox.Show("Name Mandatory Provide");
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Contact Must be 11 Charecter and Mandatory Provide");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Customer Code Must be 4 Charecter and Mandatory Provide");
                return;
            }
        }
        private void CustomerUI_Load(object sender, EventArgs e)
        {
            districtComboBox.SelectedItem = "--Select--";
            districtComboBox.DataSource = _customerManager.DistrictCombobox();
        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(codeTextBox.Text))
            {
                customer.Code = codeTextBox.Text;
                showDataGridView.DataSource = _customerManager.Search(customer);
                //MessageBox.Show("Code Can not be Empty!!!");
                //return;
            }
            else if (!String.IsNullOrEmpty(contactTextBox.Text))
            {
                customer.Contact = contactTextBox.Text;
                showDataGridView.DataSource = _customerManager.Search(customer);
            }
            else
            {
                MessageBox.Show("Provide Code or Contact For searching you !!!");
                return;
            }

            //showDataGridView.DataSource = _customerManager.Display();
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            string button = "Update";
            i = showDataGridView.SelectedCells[0].RowIndex;
            codeTextBox.Text = showDataGridView.Rows[i].Cells[2].Value.ToString();
            nameTextBox.Text = showDataGridView.Rows[i].Cells[3].Value.ToString();
            addressTextBox.Text = showDataGridView.Rows[i].Cells[4].Value.ToString();
            contactTextBox.Text = showDataGridView.Rows[i].Cells[5].Value.ToString();
            districtComboBox.Text = showDataGridView.Rows[i].Cells[6].Value.ToString();
            saveButton.Text = button;
        }
    }
}


