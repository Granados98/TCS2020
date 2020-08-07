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
    class PersonalDAO
    {
        public static Personal getInformacionPersonal(int idPersonal)
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
                        "x.idPersonal, " +
                        "x.tipoPersonal, " +
                        "x.apellidos, " +
                        "x.nombre " +
                        "FROM dbo.Personal x " +
                        "WHERE x.idPersonal = '{0}';", idPersonal);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        personal = new Personal();
                        personal.IdPersonal = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        personal.TipoPersonal = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        personal.Apellidos = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        personal.Nombre = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
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
                        "x.idPersonal, " +
                        "x.tipoPersonal, " +
                        "x.apellidos, " +
                        "x.nombre, " +
                        "x.cargo, " +
                        "x.usuario, " +
                        "x.contrasena, " +
                        "x.estado " +
                        "FROM dbo.Personal x " +
                        "WHERE x.usuario = '{0}' AND x.contrasena='{1}';", usuario, contrasenia);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        personal = new Personal();
                        personal.IdPersonal = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        personal.TipoPersonal = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        personal.Apellidos = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        personal.Nombre = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        personal.Cargo = (!rd.IsDBNull(4)) ? rd.GetString(4) : "";
                        personal.Usuario = (!rd.IsDBNull(5)) ? rd.GetString(5) : "";
                        personal.Contrasenia = (!rd.IsDBNull(6)) ? rd.GetString(6) : "";
                        personal.Estado = (!rd.IsDBNull(7)) ? rd.GetString(7) : "";
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

        public static void actualizarEstadoUsuario(Personal personal)
        {
            String query = "";

            query = "UPDATE dbo.Personal SET " +
                        "estado= @estado " +
                        "WHERE idPersonal=@idPersonal;";

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
                    command.Parameters.AddWithValue("@estado", personal.Estado);

                    command.Parameters.AddWithValue("@idPersonal", personal.IdPersonal);

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
