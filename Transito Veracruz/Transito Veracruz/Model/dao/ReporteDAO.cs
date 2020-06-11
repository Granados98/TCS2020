using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transito_Veracruz.Model.db;
using Transito_Veracruz.Model.pocos;

namespace Transito_Veracruz.Model.dao
{
    class ReporteDAO
    {
        public static void guardaReporte(Reporte reporte)
        {

            String query = "";

            query = "INSERT INTO dbo.Reporte (numeroReporte,estatus) " +
                       "VALUES(@numeroReporte,@estatus);";



            SqlConnection conn = null;
            try
            {
                conn = ConnectionUtils.getConnection();
                SqlCommand command;
                if (conn != null)
                {
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@numeroReporte", reporte.NumeroReporte);
                    command.Parameters.AddWithValue("@estatus", reporte.Estatus);
                    //command.Parameters.AddWithValue("@numeroDelegacion", reporte.NumeroDelegacion);

                    command.Parameters.AddWithValue("@idReporte", reporte.IdReporte);

                    int i = command.ExecuteNonQuery();
                    Console.WriteLine("Filas afectadas: " + i);
                    command.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("No se pudo guardar la información...");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
