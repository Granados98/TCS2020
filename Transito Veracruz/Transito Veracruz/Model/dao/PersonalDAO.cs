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
    class PersonalDAO
    {
        public static Personal getLogin(String usuario, String contrasenia)
        {
            Personal personal = null;
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conexion != null)
                {
                    String query = String.Format("SELECT " +
                        "idPersonal, " +
                        "numeroPersonal, " +
                        "tipoPersonal, " +
                        "apellidos, " +
                        "nombre, " +
                        "cargo, " +
                        "usuario, " +
                        "contrasena, " +
                        "FROM dbo.Personal x " +
                        "WHERE x.usuario = '{0}' AND z.contrasena='{1}';", usuario, contrasenia);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        personal = new Personal();
                        personal.IdPersonal = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        personal.NumeroPersonal = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        personal.TipoPersonal = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        personal.Apellidos = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        personal.Nombre = (!rd.IsDBNull(4)) ? rd.GetString(4) : "";
                        personal.Cargo = (!rd.IsDBNull(5)) ? rd.GetString(5) : "";
                        personal.Usuario = (!rd.IsDBNull(6)) ? rd.GetString(6) : "";
                        personal.Contrasenia = (!rd.IsDBNull(7)) ? rd.GetString(7) : "";
                    }
                    rd.Close();
                    command.Dispose();
                    Console.WriteLine(personal);
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
            return personal;
        }
    }
}
