using System.Data;
using System.Data.SqlClient;
using ImportBDD.DataSource;

internal class Program
{
    private static void Main(string[] args)
    {
        //DBConnection.Connecting();
        DBCreate.CreerTableBDD();

    }
}