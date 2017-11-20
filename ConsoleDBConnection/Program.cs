using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sqlserverconnect
{
    public class connectToDB
    {
        private static void connect()
        {
            try
            {
                //Get Server Name
                Console.WriteLine("Enter Server Name: ");
                string serverName = null;
                serverName = Console.ReadLine();

                //Get Database Name
                Console.WriteLine("Enter Database Name: ");
                string dbName = null;
                dbName = Console.ReadLine();

                //Get username
                Console.WriteLine("Username: ");
                string username = null;
                username = Console.ReadLine();

                //Get users password hide the input
                Console.WriteLine("Password: ");
                string password = null;
                while (true)
                {
                    var key = System.Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    password += key.KeyChar;
                }

                String str = "Data Source=" +serverName + ";Initial Catalog= " + dbName + ";User id= " + username + "; password=" + password + ";";
                String query = "select * from Amazon.Customer";

                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT * FROM Amazon.Customer";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetSqlString(reader.GetOrdinal("email")));
                }


                Console.ReadKey();
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);

            }
        }

        static void Main()
        {
            connect();
        }
    }


}