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
    class ImagenDAO
    {
        public static void guardarImagen(Imagen imagen)
        {
            String query = "";

            query = "INSERT INTO dbo.Imagen (dato,numeroReporte) " +
                       "VALUES(@dato,@numeroReporte);";

            Console.WriteLine("Se guardo la infomacion");

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
                    command.Parameters.AddWithValue("@dato", imagen.Dato);
                    command.Parameters.AddWithValue("@numeroReporte", imagen.NumeroReporte);

                    command.Parameters.AddWithValue("@idImagen", imagen.IdImagen);


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
