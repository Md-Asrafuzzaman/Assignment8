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
    public partial class OrdersUI : Form
    {
        OrderManager _orderManager = new OrderManager();
        Order order = new Order();
        public OrdersUI()
        {
            InitializeComponent();
        }
        
        private void addButton_Click(object sender, EventArgs e)
        {
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(orderQuantityTextBox.Text) && String.IsNullOrEmpty(totalOrderPriceTextBox.Text))
            {
                MessageBox.Show("Quantity And Total Price Field Required!!!");
                return;
            }
            else
            {
                //Check UNIQUE Customer Name
                if (_orderManager.IsCustomerNameAndIteamNameExists(customerNameComboBox.Text,itemNameComboBox.Text))
                {
                    MessageBox.Show(" Already Exists!");
                    return;
                }
                else
                {
                    
                    order.IteamName = itemNameComboBox.Text;
                    order.CustomerName = customerNameComboBox.Text;
                    order.OrderQuantity = Convert.ToInt16(orderQuantityTextBox.Text);
                    order .TotalPrice = Convert.ToDouble(totalOrderPriceTextBox.Text);
                       bool isAdded = _orderManager.AddOrderInfo(order);

                        if (isAdded)
                        {
                            MessageBox.Show("Saved");
                        }
                        else
                        {
                            MessageBox.Show("Not Saved");
                        }
                }    
               

            }


            //Check ItemName UNIQUE
            //if (_orderManager.IsItemNameExists(iteamNameTextBox.Text))
            //{
            //    MessageBox.Show(iteamNameTextBox.Text + " Already Exists!");
            //    return;
            //}
            //Add/Insert Item

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowOrderList();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateOrderInfo();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchOrder();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteOrder();
        }

        
        private void ShowOrderList()
        {
            try
            { // SQL connection 
                string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //Sql Command

                string commandString = "SELECT * FROM Orders";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                //Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    showDataGridView.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Data Set Empty");
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateOrderInfo()
        {
            try
            {// SQL connection 
                string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //Sql Command

                string commandString = @"UPDATE Orders SET CustomerName ='" + customerNameComboBox.Text + "', IteamName = '" + itemNameComboBox.Text + "',OrderQuantity = '" + orderQuantityTextBox.Text + "', TotalPrice = '" + totalOrderPriceTextBox.Text + "' WHERE  OrderId='" + orderIdTextBox.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    MessageBox.Show("Successfully Updated");
                }
                else
                {
                    MessageBox.Show("Updated Failed");
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SearchOrder()
        {
            try
            {// SQL connection 
                string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //Sql Command

                string commandString = "SELECT * FROM Orders WHERE OrderId ='" + orderIdTextBox.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                //Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Search Match");
                    showDataGridView.DataSource = dataTable;

                }
                else
                {
                    MessageBox.Show("Search Data Not Match");
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteOrder()
        {
            try
            { // SQL connection 
                string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //Sql Command

                string commandString = "DELETE FROM Orders WHERE OrderId ='" + orderIdTextBox.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                //Execute
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    MessageBox.Show("Successfully Deleted");
                }
                else
                {
                    MessageBox.Show("Not Deleted");
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void orderIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
