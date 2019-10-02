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
    public class OrderRepository
    {
        public bool AddOrderInfo(Order order)
        {
            try
            { // SQL connection 
                string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //Sql Command

                string commandString = "INSERT INTO Orders(CustomerName,IteamName,OrderQuantity,TotalPrice) VALUES ('" + order.CustomerName + "','" + order.IteamName + "',"+ order.OrderQuantity +","+ order.TotalPrice +")";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    //MessageBox.Show("Successfully Inserted");
                    return true;
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
            return false;
        }

        public bool IsCustomerNameAndIteamNameExists(string Customername,string itemName)
        {
            bool exists = false;
            //Connection
            string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM Orders WHERE CustomerName ='" + Customername + "' AND IteamName ='" + itemName + "'";
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
    }
}
