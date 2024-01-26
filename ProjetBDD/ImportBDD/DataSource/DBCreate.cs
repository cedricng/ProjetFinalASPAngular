using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Reflection;


namespace ImportBDD.DataSource
{
    class DBCreate
    {
        private readonly static string dataSource = "DESKTOP-D82CEGJ"; //a modifier
        private readonly static string  nomFichier = "DataSource\\script.sql";
        //private readonly static string fichierSql = "C:\\Users\\DELL\\Documents\\ajc\\C#\\ASP.NET\\ProjetFinalASPAngular\\ProjetBDD\\ImportBDD\\DataSource\\script.sql";

        public static void CreerTableBDD()
        {
            try
            {
               // string nomFichier = "DataSource\\script.sql";

                // Obtenez le chemin du répertoire du fichier exécutable
                string repertoireExecutable = AppDomain.CurrentDomain.BaseDirectory;


                // Obtenez le chemin complet du fichier en joignant le répertoire du fichier exécutable avec le nom du fichier spécifié
                string cheminComplet = Path.Combine(repertoireExecutable, nomFichier);
                // Affichez le chemin complet sans la partie '\bin\Debug\net8.0\'
                string cheminSansPartieDebug = RemoveDebugPathPart(cheminComplet);
                // Console.WriteLine($"Chemin fichier : {cheminComplet}");
                // Console.WriteLine($"Chemin complet sans la partie '\\bin\\Debug\\net8.0\\' : {cheminSansPartieDebug}");

                string sqlConnectionString = @"Data Source=" + dataSource + "; Integrated Security=SSPI;Persist Security Info=False; TrustServerCertificate=True";

                string script = File.ReadAllText(cheminSansPartieDebug);

                SqlConnection conn = new SqlConnection(sqlConnectionString);

                Server server = new Server(new ServerConnection(conn));

                server.ConnectionContext.ExecuteNonQuery(script);
            }

            catch (Exception ex)
            {
                Console.WriteLine("database Import  failed !");
                Console.WriteLine(ex.Message);
            }

        }


        static string RemoveDebugPathPart(string cheminComplet)
        {
            const string debugPathPart = @"bin\Debug\net8.0\";

            int index = cheminComplet.IndexOf(debugPathPart, StringComparison.OrdinalIgnoreCase);
            if (index != -1)
            {
                return cheminComplet.Remove(index, debugPathPart.Length);
            }

            return cheminComplet;
        }
    }
}
