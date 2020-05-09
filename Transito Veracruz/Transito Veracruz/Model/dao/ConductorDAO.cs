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
                        "FROM dbo.Personal x "+
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


        public static bool agregarConductor(Conductor conductor, bool nuevo)
        {
            String query = "";
            if (nuevo)
            {/*
                query = "INSERT INTO dbo.Conductor (numeroLicencia,apellidos,nombre,fechanNacimiento,telefono,usuario,contrasenia) " +
                       "VALUES(@numeroLicencia,@apellidos,@nombre,GETDATE(),@telefono,@usuario,@contrasenia);";
                */
                Console.WriteLine("Se guardo la infomacion");
            }
            else
            {
                Console.WriteLine("No es nuevo");
            }
            /*
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
                    command.Parameters.AddWithValue("@sexo", conductor.IdConductor);
                    command.Parameters.AddWithValue("@nacionalidad", conductor.NumeroLicencia);
                    command.Parameters.AddWithValue("@telefono", conductor.Apellidos);
                    command.Parameters.AddWithValue("@email", conductor.Nombre);
                    command.Parameters.AddWithValue("@calle", conductor.FechaNacimiento);
                    command.Parameters.AddWithValue("@numeroCasa", conductor.Telefono);
                    command.Parameters.AddWithValue("@colonia", conductor.Usuario);
                    command.Parameters.AddWithValue("@ciudad", conductor.Contrasenia);

                    if (nuevo)
                    {
                        command.Parameters.AddWithValue("@idEgresado", conductor.IdConductor);
                    }
                    else
                    {
                        Console.WriteLine("No es nuevo");
                    }


                    int i = command.ExecuteNonQuery();
                    Console.WriteLine("Filas afectadas: " + i);
                    if (i > 0)
                    {
                        return true;
                    }
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
            } */
            return false; 
        }
    }

}
