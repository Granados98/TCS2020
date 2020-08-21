using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DireccionGeneral.Model.dbDireccion;
using DireccionGeneral.Model.pocosDireccion;

namespace DireccionGeneral.Model.daoDireccion
{
    class ImagenDAO
    {

        public static List<string> getImagenes(int id)
        {
            List<string> list = new List<string>();
            Imagen img = null;
            SqlConnection conn = null;
            try
            {
                conn = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conn != null)
                {
                    String query = String.Format("SELECT " +
                        "x.idImagen, " +
                        "x.ruta, " +
                        "x.idReporte " +
                        "FROM dbo.Imagen x " +
                        "WHERE x.idReporte='{0}';", id);
                    //"WHERE x.idUsuario = {0} AND eliminado = 'N';", idPersonal);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        img = new Imagen(); ;
                        img.IdImagen = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        img.Ruta = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        img.IdReporte = (!rd.IsDBNull(2)) ? rd.GetInt32(2) : 0;

                        list.Add(img.Ruta);
                    }
                    rd.Close();
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
            return list;
        }
    }
}
