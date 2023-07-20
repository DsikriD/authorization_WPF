using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;

namespace AppWorkWithBD
{
    internal class Use_BD
    {

        public static string USER_NAME = default;
        public static int USER_ID;
        static string Table_User = "USERS";
        static string Table_Product = "Product";
        static string Table_Order = "Order";
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BaseDate;Integrated Security=True";

        static public bool Avtorization(string login,string password) {
            string sql =  $"SELECT id FROM {Table_User} WHERE [login] = '{login}' AND [password] = '{password}' ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();

                    SqlCommand cmd = new SqlCommand(sql, connection);
                    USER_ID = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();

                    if (USER_ID != null)
                        USER_NAME = login;
                    return (USER_ID != null);
            }
        }

        static public bool Registration (string login,string password)
        {
            bool resault_Registation=false; 
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                string sql = $"SELECT COUNT(1) FROM {Table_User} WHERE login = '{login}'";
                SqlCommand sqlCom = new SqlCommand(sql, connection);
                int countUser = Convert.ToInt32(sqlCom.ExecuteScalar());
                if (countUser == 0)
                {
                    sql = $"INSERT INTO {Table_User} (login,password) VALUES ('{login}','{password}')";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.CommandType = System.Data.CommandType.Text;

                    command.ExecuteNonQuery();
                    MessageBox.Show("Вы успешно зарегестрированы");

                    resault_Registation = true;
                }
                else MessageBox.Show("Пользователь с таким именим уже существует");
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally { connection.Close(); }
    
            return resault_Registation;
        }


        static public void Get_Product() {
            string sql = $"SELECT * FROM {Table_Product}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Products.ProductAdd(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToDecimal(reader[2]));
                }
                reader.Close();
                connection.Close();
            }

        }



        public static void Get_Order() {
            string sql = $"SELECT OrdId, (SELECT [name] FROM {Table_Product} WHERE [Order].Product_id = Product.id),Amount FROM [{Table_Order}] " +
                $"\r\nWHERE [User_id] = (SELECT id FROM {Table_User} WHERE [login] = '{USER_NAME}')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Orders.AddElemToList(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToInt32(reader[2]));
                }
                reader.Close();
                connection.Close();
            }
        }


        public static void Make_Order(int Product_id,int Amount) {

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                string sql = $"INSERT INTO [{Table_Order}] (User_id,Product_id,Amount) VALUES ('{USER_ID}','{Product_id}','{Amount}')";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = System.Data.CommandType.Text;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

    }
}

