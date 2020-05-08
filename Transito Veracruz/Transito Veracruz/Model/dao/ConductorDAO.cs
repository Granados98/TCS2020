using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transito_Veracruz.Model.db;
using Transito_Veracruz.Model.pocos;

namespace Transito_Veracruz.Model.dao
{
    class ConductorDAO
    {
        public static Conductor getLogin(String usuario, String contrasenia)
        {
            Conductor conductor = null;
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conexion!=null)
                {
                    String query = String.Format("SELECT " +
                        "idConductor, " +
                        "numeroLicencia, " +
                        "apellidos, " +
                        "nombre, " +
                        "fechaNacimiento, " +
                        "telefono, " +
                        "usuario, " +
                        "contrasena, "+
                        "FROM dbo.Conductor x"+
                        "WHERE x.usuario = '{0}' AND z.contrasena='{1}';", usuario, contrasenia);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while(rd.Read())
                    {
                        conductor = new Conductor();
                        conductor.IdConductor = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        conductor.NumeroLicencia = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        conductor.Apellidos = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        conductor.Nombre = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        conductor.FechaNacimiento = (!rd.IsDBNull(4)) ? rd.GetDateTime(4) : new DateTime();
                        conductor.Telefono = (!rd.IsDBNull(5)) ? rd.GetString(5) : "";
                        conductor.Usuario = (!rd.IsDBNull(6)) ? rd.GetString(6) : "";
                        conductor.Contrasenia = (!rd.IsDBNull(7)) ? rd.GetString(7) : "";
                    }
                    rd.Close();
                    command.Dispose();
                    Console.WriteLine(conductor);
                }

            }
            catch(Exception e)
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
            return conductor;
        }
    }
}
