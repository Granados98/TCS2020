using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DireccionGeneral.Model.dbDireccion;
using DireccionGeneral.Model.pocosDireccion;
using DireccionGeneral.Model.securityDireccion;

namespace DireccionGeneral.Model.daoDireccion
{
    class PersonalDAO
    {
        public static void eliminarPersonal(int idPersonal)
        {
            String query = "";
            query = "DELETE FROM dbo.Personal WHERE idPersonal = @idPersonal;";
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
                    command.Parameters.AddWithValue("@idPersonal", idPersonal);
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
        public static int getIdPersonal(string nombreUsuario)
        {

            int idPersonal = 0;
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
                        "x.usuario " +
                        "FROM dbo.Personal x " +
                        "WHERE x.usuario='{0}';", nombreUsuario);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        personal = new Personal();
                        personal.IdPersonal = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        personal.Usuario = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                    }
                    rd.Close();
                    command.Dispose();
                    Console.WriteLine(personal);

                    idPersonal = personal.IdPersonal;
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
            return idPersonal;
        }
        public static List<Personal> getPersonal()
        {
            List<Personal> list = new List<Personal>();
            SqlConnection conn = null;
            try
            {
                conn = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conn != null)
                {
                    String query = String.Format("SELECT " +
                        "x.idPersonal, " +
                        "x.tipoPersonal, " +
                        "x.apellidos, " +
                        "x.nombre, " +
                        "x.cargo, " +
                        "x.usuario, " +
                        "x.contrasena, " +
                        "x.nombreDelegacion " +
                        "FROM dbo.Personal x ");
                    //"WHERE x.idUsuario = {0} AND eliminado = 'N';", idPersonal);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        Personal m = new Personal();
                        m.IdPersonal = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        m.TipoPersonal = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        m.Apellidos = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        m.Nombre = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        m.Cargo = (!rd.IsDBNull(4)) ? rd.GetString(4) : "";
                        m.Usuario = (!rd.IsDBNull(5)) ? rd.GetString(5) : "";

                        m.Contrasenia = (!rd.IsDBNull(6)) ? rd.GetString(6) : "";

                        m.NombreDelegacion = (!rd.IsDBNull(7)) ? rd.GetString(7) : "";

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
                        personal.Usuario = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        personal.Contrasenia = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        personal.Estado = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
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
        public static void guardarUsuario(Personal personal, bool nuevo)
        {
            String query = "";
            if (nuevo)
            {
                query = "INSERT INTO dbo.Personal (tipoPersonal,apellidos,nombre,cargo,usuario,contrasena,nombreDelegacion,estado) " +
                       "VALUES(@tipoPersonal,@apellidos,@nombre,@cargo,@usuario,@contrasena,@nombreDelegacion,@estado);";
            }
            else
            {
                query = "UPDATE dbo.Personal SET " +
                        "tipoPersonal = @tipoPersonal, " +
                        "apellidos = @apellidos, " +
                        "nombre = @nombre, " +
                        "cargo = @cargo, " +
                        "usuario = @usuario, " +
                        "contrasena = @contrasena, " +
                        "nombreDelegacion = @nombreDelegacion, " +
                        "estado = @estado " +
                        "WHERE idPersonal = @idPersonal;";

            }


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
                    command.Parameters.AddWithValue("@tipoPersonal", personal.TipoPersonal);
                    command.Parameters.AddWithValue("@apellidos", personal.Apellidos);
                    command.Parameters.AddWithValue("@nombre", personal.Nombre);
                    command.Parameters.AddWithValue("@cargo", personal.Cargo);
                    command.Parameters.AddWithValue("@usuario", personal.Usuario);
                    command.Parameters.AddWithValue("@contrasena", personal.Contrasenia);
                    command.Parameters.AddWithValue("@nombreDelegacion", personal.NombreDelegacion);
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
