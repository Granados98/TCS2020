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
    class ConductorDAO
    {
        public static List<Conductor> getConductores()
        {
            List<Conductor> list = new List<Conductor>();
            SqlConnection conn = null;
            try
            {
                conn = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conn != null)
                {
                    String query = String.Format("SELECT " +
                                                 "x.idConductor, " +
                        "x.numeroLicencia, " +
                        "x.apellidos, " +
                        "x.nombre, " +
                        "x.fechaNacimiento, " +
                        "x.telefono " +
                        "FROM dbo.Personal x ");
                    //"WHERE x.idUsuario = {0} AND eliminado = 'N';", idPersonal);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        Conductor m = new Conductor();
                        m.IdConductor = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        m.NumeroLicencia = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        m.Apellidos = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        m.Nombre = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        m.FechaNacimiento = (!rd.IsDBNull(4)) ? rd.GetDateTime(4) : new DateTime();
                        m.Telefono = (!rd.IsDBNull(5)) ? rd.GetString(5) : "";

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
