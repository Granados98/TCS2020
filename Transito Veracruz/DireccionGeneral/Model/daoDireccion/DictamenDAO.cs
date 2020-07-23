using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DireccionGeneral.Model.dbDireccion;
using DireccionGeneral.Model.pocosDireccion;

namespace DireccionGeneral.Model.daoDireccion
{
    class DictamenDAO
    {
        public static int verificaDictamen(int folio)
        {
            int folioAux = 0;
            Dictamen dictamen = null;
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conexion != null)
                {
                    String query = String.Format("SELECT " +
                        "x.idDictamen, " +
                        "x.folio " +
                        "FROM dbo.Dictamen x " +
                        "WHERE x.folio='{0}';", folio);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        dictamen = new Dictamen();
                        dictamen.IdDictamen = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        dictamen.Folio = (!rd.IsDBNull(1)) ? rd.GetInt32(1) : 0;
                    }
                    rd.Close();
                    command.Dispose();
                    Console.WriteLine(dictamen);

                    folioAux = dictamen.Folio;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("No se encontro el Conductor");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
            return folioAux;
        }
        public static void guardarDictamen(Dictamen dictamen)
        {
            String query = "";
                query = "INSERT INTO dbo.Dictamen (folio,descripcion,fechaCreacion,idPersonal) " +
                           "VALUES(@folio,@descripcion,@fechaCreacion,@idPersonal);";
            

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
                    command.Parameters.AddWithValue("@numeroLicencia", dictamen.Folio);
                    command.Parameters.AddWithValue("@apellidos", dictamen.Descripcion);
                    command.Parameters.AddWithValue("@nombre", dictamen.FechaDictamen);
                    command.Parameters.AddWithValue("@fechaNacimineto", dictamen.IdPersonal);

                    command.Parameters.AddWithValue("@idDictamen", dictamen.IdDictamen);


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
