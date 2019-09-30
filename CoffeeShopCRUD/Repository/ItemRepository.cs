using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoffeeShopCRUD.Repository
{
    public class ItemRepository
    {
        string connectionString = @"Server = HABIB; Database = CoffeeShop; Integrated Security = true";

        public bool Add(string name, double price)
        {
            bool isAdd = false;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = "INSERT INTO Items(Name, Price)VALUES('" + name + "', " + price + ")";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    isAdd = true;
                }
                sqlConnection.Close();
            }
            catch (Exception exep)
            {
                //MessageBox.Show(exep.Message);
            }
            return isAdd;
        }
        public bool Update(int id, string name, double price)
        {
            bool isUpdate = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = "UPDATE Items SET Name = '" + name + "', Price = " + price + " WHERE ID = " + id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            int isExecute = sqlCommand.ExecuteNonQuery();

            if (isExecute > 0)
            {
                isUpdate = true;
            }
            sqlConnection.Close();
            return isUpdate;

        }

        public DataTable Display()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"SELECT * FROM Items";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public bool CheckIfNumeric(string input)
        {
            return input.IsNumeric();
        }

        public bool Delete(int id)
        {
            bool isDelete = false;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = "DELETE FROM Items WHERE ID = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                int isExecute = sqlCommand.ExecuteNonQuery();

                if (isExecute > 0)
                {
                    isDelete = true;
                }
                sqlConnection.Close();
            }
            catch (Exception excp)
            {

               // MessageBox.Show(excp.Message);
            }

            return isDelete;
        }

        public bool IsNameExist(string name)
        {
            bool existName = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"SELECT Name FROM Items WHERE Name = '" + name + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);


            if (isFill > 0)
            {
                existName = true;
            }

            return existName;
        }

        public DataTable Search(string name)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"SELECT * FROM Items WHERE Name = '" + name + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }


    public static class StringExtensions
    {
        public static bool IsNumeric(this string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }
    }
}
