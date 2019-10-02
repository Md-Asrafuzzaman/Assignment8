using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp.Repository
{
    public class CustomerRepository
    {
        //Add Operation Method
        public bool AddCustomerInfo(string name,string address,string contact)
        {
            bool isAdded = false;
            try
            { // SQL connection 
                string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //Sql Command

                string commandString = "INSERT INTO Customer(CustomerName,CustomerAddress,CustomerContact) VALUES ('" + name + "','" + address + "','" + contact + "')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    isAdded = true;
                }
                else
                {
                    //MessageBox.Show("Insertion Failed");
                }

                sqlConnection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
            return isAdded;
        }

        public bool IsNameExists(string name)
        {
            bool exists = false;
              //Connection
                string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Customer WHERE CustomerName ='" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    exists = true;
                }
                //Close
                sqlConnection.Close();

            return exists;
        }

        //Update Operation Method
        public bool UpdateCustomerInfo(int id,string name, string address, string contact)
        {
            try
            {// SQL connection 
                string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //Sql Command

                string commandString = @"UPDATE Customer SET CustomerName ='" + name + "', CustomerAddress = '" + address + "',CustomerContact = '" + contact + "' WHERE CustomerId ='" + id + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    return true;
                }
                else
                {
                    //MessageBox.Show("Updated Failed");
                }

                sqlConnection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
            return true;
        }

        //Display Data Operation Method
        public DataTable Display()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM Customer";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                //showDataGridView.DataSource = dataTable;
            }
            else
            {
                // MessageBox.Show("No Data Found");
            }

            //Close
            sqlConnection.Close();
            return dataTable;
        }

        //Delete Operation Method
        public bool DeleteCustomerInfo(int id)
        {
            try
            { // SQL connection 
                string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //Sql Command

                string commandString = "DELETE FROM Customer WHERE CustomerId ='" + id + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                //Execute
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    return true;
                }
                else
                {
                    //MessageBox.Show("Not Deleted");
                }

                sqlConnection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
            return false;
        }

        //Search Operation Method
        public DataTable SearchCustomerInfo(string name)
        {
            // SQL connection 
                string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //Sql Command

                string commandString = "SELECT * FROM Customer WHERE CustomerName ='" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();
                //Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);     
                sqlConnection.Close();
                return dataTable;
        }

    }
}
