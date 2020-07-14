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
    class ReporteDAO
    {
        public static List<Reporte> getReportes()
        {
            List<Reporte> list = new List<Reporte>();
            SqlConnection conn = null;
            try
            {
                conn = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conn != null)
                {
                    String query = String.Format("SELECT " +
                        "x.idReporte, " +
                        "x.numeroReporte, " +
                        "x.estatus, " +
                        "x.nombreDelegacion, " +
                        "x.folioDictamen, " +
                        "x.direccion, " +
                        "x.fechaCreacion " +
                        "FROM dbo.Reporte x ");
                    //"WHERE x.idUsuario = {0} AND eliminado = 'N';", idPersonal);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        Reporte m = new Reporte();
                        //m.IdReporte = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        m.NumeroReporte = (!rd.IsDBNull(1)) ? rd.GetInt32(1) : 0;
                        m.Estatus = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        m.NombreDelegacion = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        m.FolioDictamen = (!rd.IsDBNull(4)) ? rd.GetInt32(4) : 0;
                        m.Direccion = (!rd.IsDBNull(5)) ? rd.GetString(5) : "";
                        m.FechaCreacion = (!rd.IsDBNull(6)) ? rd.GetDateTime(6) : new DateTime();

                        list.Add(m);
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
