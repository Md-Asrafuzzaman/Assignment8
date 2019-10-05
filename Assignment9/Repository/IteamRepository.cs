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
    public class IteamRepository
    {
        Item item = new Item();
        public bool Add(Item item)
        {
            bool isAdded = false;
            try
            {
                //Connection
                string connectionString = @"Server=PC-301-05\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"INSERT INTO Items (Name, Price) Values ('" + item.Name + "', " + item.Price + ")";
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
        public bool IsNameExists(Item item)
        {
            bool exists = false;
            try
            {
                //Connection
                string connectionString = @"Server=PC-301-05\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Items WHERE Name='" + item.Name + "'";
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

        public bool Delete(Item item)
        {
            try
            {
                //Connection
                string connectionString = @"Server=PC-301-05\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //DELETE FROM Items WHERE ID = 3
                string commandString = @"DELETE FROM Items WHERE ID = " + item.Id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Delete
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
               // MessageBox.Show(exeption.Message);
            }

            return false;
        }

        public bool Update(Item item)
        {
            try
            {
                //Connection
                string connectionString = @"Server=PC-301-05\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //UPDATE Items SET Name =  'Hot' , Price = 130 WHERE ID = 1
                string commandString = @"UPDATE Items SET Name =  '" + item.Name + "' , Price = " + item.Price + " WHERE ID = " + item.Id + "";
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

        public List<Item> Display()
        {
                //Connection
                string connectionString = @"Server=PC-301-05\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"select * from Items";
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
            //}
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Item> items = new List<Item>();
            while (sqlDataReader.Read())
            {
                item.Id = Convert.ToInt16(sqlDataReader["Id"]);
                item.Name = sqlDataReader["Name"].ToString();
                item.Price = Convert.ToDouble(sqlDataReader["Price"]);

                items.Add(item);
            }
            //Close
            sqlConnection.Close();
                return items;
        }

        public Item Search(Item item)
        {
            
                //Connection
                string connectionString = @"Server=PC-301-05\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            //string commandString = @"SELECT * FROM Items WHERE Name='" + item.Name + "'";
            string commandString = @"SELECT * FROM Items WHERE Name='" + item.Name + "'";
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

            //Close
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                item.Id = Convert.ToInt16(sqlDataReader["Id"]);
                item.Name = sqlDataReader["Name"].ToString();
                item.Price = Convert.ToDouble(sqlDataReader["Price"]);

            }

            sqlConnection.Close();
                return item;

        }

        public DataTable ItemCombobox()
        {
            //Connection
            string connectionString = @"Server=PC-301-05\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT Id,Name FROM Items";
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
    }
}
