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
        public static void eliminarImagenes(int idReporte)
        {
            String query = "";
            query = "DELETE FROM dbo.Imagen WHERE idReporte = @idReporte;";
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
                    command.Parameters.AddWithValue("@idReporte", idReporte);
                    int i = command.ExecuteNonQuery();
                    Console.WriteLine("Rows affected: " + i);
                    command.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }
        public static void guardarImagen(Imagen imagen)
        {
            String query = "";

            query = "INSERT INTO dbo.Imagen (ruta,dato,idReporte,fechaCreacion) " +
                       "VALUES(@ruta,@dato,@idReporte,@fechaCreacion);";

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
                    command.Parameters.AddWithValue("@ruta", imagen.Ruta);
                    command.Parameters.AddWithValue("@dato", imagen.Dato);
                    command.Parameters.AddWithValue("@idReporte", imagen.IdReporte);
                    command.Parameters.AddWithValue("@fechaCreacion", imagen.FechaCreacion);


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
