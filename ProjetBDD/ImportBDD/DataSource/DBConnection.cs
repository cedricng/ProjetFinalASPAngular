
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportBDD.DataSource
{
    class DBConnection
    {
        public static SqlConnection Connection()
        {
            string connectionString = @"Data Source=DESKTOP-D82CEGJ;Initial Catalog=projet-hopital-db;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
        public static void Connecting()
        {
            try
            {
                SqlConnection connection = Connection();
                connection.Open();
                Console.WriteLine("successful connection");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("connection failed !");
                Console.WriteLine(ex.Message);
            }
        }

    }
}
