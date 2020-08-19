using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneral.Model.dbDireccion
{
    class ConnectionUtils
    {
        private static String SERVER = "localhost";
        private static String PORT = "1433";
        private static String DATABASE = "SistemaTransito";
        private static String USER = "sa";
        private static String PASSWORD = "12345";

        public static SqlConnection getConnection()
        {
            SqlConnection conn = null;
            try
            {
                String urlconn = String.Format("Data Source={0},{1};" +
                                               "Network Library=DBMSSOCN;" +
                                               "Initial Catalog={2};" +
                                               "User ID={3};" +
                                               "Password={4};",
                                               SERVER, PORT, DATABASE, USER, PASSWORD);
                conn = new SqlConnection(urlconn);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("ERROR BASE DE DATOS");
            }
            return conn;
        }
    }
}
