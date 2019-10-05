using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using  System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using MyWindowsFormsApp.Model;
namespace MyWindowsFormsApp.Repository
{
    public class CustomerRepository
    {
        public bool Add(Customer customer)
        {
            bool isAdded = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"INSERT INTO CustomerModify (Code,Name,Address,Contact,District) Values ('" + customer.Code + "','" + customer.Name + "','" + customer.Address + "','" + customer.Contact + "','" + customer.District + "')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }

                //if (!isNameExists(nameTextBox.Text))
                //{
                //    //Insert
                //    int isExecuted = sqlCommand.ExecuteNonQuery();
                //    if (isExecuted > 0)
                //    {
                //        isAdded = true;
                //    }

                //}
                //else
                //{
                //    MessageBox.Show(nameTextBox.Text + "Already Exists!");
                //}


                //Close
                sqlConnection.Close();


            }
            catch (Exception)
            {
                // MessageBox.Show(exeption.Message);
            }

            return isAdded;
        }
        public bool CodeFieldConditionCheck(Customer customer)
        {

            bool exists = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM CustomerModify WHERE Code ='" + customer.Code + "'";
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

            }
            catch (Exception)
            {
                // MessageBox.Show(exeption.Message);
            }

            return exists;
        }

        public bool ContactFieldConditionCheck(Customer customer)
        {

            bool exists = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM CustomerModify WHERE Code ='" + customer.Contact + "'";
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

            }
            catch (Exception)
            {
                // MessageBox.Show(exeption.Message);
            }

            return exists;
        }

        public List<District> DistrictCombobox()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT Id,DIS FROM District";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            //DataTable dataTable = new DataTable();
            //sqlDataAdapter.Fill(dataTable);
            //if (dataTable.Rows.Count > 0)
            //{
            //    //showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //    // MessageBox.Show("No Data Found");
            //}
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<District> districts = new List<District>();
            while (sqlDataReader.Read())
            {
                District district = new District();
                district.Id = Convert.ToInt16(sqlDataReader["Id"]);
                district.DIS = sqlDataReader["DIS"].ToString();
                districts.Add(district);
            }

            //Close
            sqlConnection.Close();
            return districts;

        }
        public List<Customer> Display()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"select * from CustomerModify";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            //DataTable dataTable = new DataTable();
            //sqlDataAdapter.Fill(dataTable);
            //if (dataTable.Rows.Count > 0)
            //{
            //    //showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //   // MessageBox.Show("No Data Found");
            //
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            int i = 1;
            while (sqlDataReader.Read())
            {
                Customer customer = new Customer();
                customer.Id = Convert.ToInt16(sqlDataReader["Id"]);
                customer.Code = sqlDataReader["Code"].ToString();
                customer.Name = sqlDataReader["Name"].ToString();
                customer.Address = sqlDataReader["Address"].ToString();
                customer.Contact = sqlDataReader["Contact"].ToString();
                customer.District = sqlDataReader["District"].ToString();
                customer.SL = i;
                customers.Add(customer);
                i++;
            }
            //Close
            sqlConnection.Close();
            return customers;
        }

        public bool Update(Customer customer)
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //UPDATE Items SET Name =  'Hot' , Price = 130 WHERE ID = 1
                string commandString = @"UPDATE CustomerModify SET Code ='" + customer.Code + "', Name =" + customer.Name +",Address ='" + customer.Address + "', Contact = " + customer.Contact + " , District = " + customer.District + "  WHERE ID = " + customer.Id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }
                //Close
                sqlConnection.Close();


            }
            catch (Exception)
            {
                //MessageBox.Show(exeption.Message);
            }
            return false;
        }


        public List<Customer> Search(Customer customer)
        {

            //Connection
            string connectionString = @"Server=DESKTOP-FJFQ4S2\SQLSERVER; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM CustomerModify WHERE Code='" + customer.Code + "' OR Contact='" + customer.Contact + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            //DataTable dataTable = new DataTable();
            //sqlDataAdapter.Fill(dataTable);
            //if (dataTable.Rows.Count > 0)
            //{
            //    //showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //    //MessageBox.Show("No Data Found");
            //}
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            int i = 1;    
            while (sqlDataReader.Read())
            {          
                customer.Id = Convert.ToInt16(sqlDataReader["Id"]);
                customer.Code = sqlDataReader["Code"].ToString();
                customer.Name = sqlDataReader["Name"].ToString();
                customer.Address = sqlDataReader["Address"].ToString();
                customer.Contact = sqlDataReader["Contact"].ToString();
                customer.District = sqlDataReader["District"].ToString();
                customer.SL = i;
                customers.Add(customer);
                //i++;
            }
            //Close
            sqlConnection.Close();
            return customers;

        }
    }
}
