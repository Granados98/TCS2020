using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Transito_Veracruz.Model.db;
using Transito_Veracruz.Model.pocos;

namespace Transito_Veracruz.Model.dao
{
    class ConductorDAO
    {
        public static int getIdConductor(String numeroLicencia)
        {
            int idConductor = 0;
            Conductor conductor = null;
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conexion != null)
                {
                    String query = String.Format("SELECT " +
                        "x.idConductor, " +
                        "x.numeroLicencia " +
                        "FROM dbo.Conductor x " +
                        "WHERE x.numeroLicencia='{0}';", numeroLicencia);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        conductor = new Conductor();
                        conductor.IdConductor = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        conductor.NumeroLicencia = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                    }
                    rd.Close();
                    command.Dispose();
                    Console.WriteLine(conductor);

                    idConductor = conductor.IdConductor;
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
            return idConductor;
        }

        public static List<Conductor> obtenerConductores()
        {
            List<Conductor> list = new List<Conductor>();
            SqlConnection conn = null;

            try
            {
                conn = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conn != null) {
                    String query = String.Format("SELECT " +
                                                 "x.idConductor," +
                                                 "x.numeroLicencia," +
                                                 "x.apellidos," +
                                                 "x.nombre, " +
                                                 "x.fechaNacimiento, " +
                                                 "x.telefono " +
                                                 "FROM dbo.Conductor x ");
                    Console.WriteLine(query);
                    command = new SqlCommand(query,conn);
                    rd = command.ExecuteReader();
                    
                    while (rd.Read())
                    {
                        Conductor conductor = new Conductor();
                        conductor.IdConductor = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        conductor.NumeroLicencia = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        conductor.Apellidos = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        conductor.Nombre = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        conductor.FechaNacimiento = (!rd.IsDBNull(4)) ? rd.GetDateTime(4) : new DateTime();
                        conductor.Telefono = (!rd.IsDBNull(5)) ? rd.GetString(5) : "";

                        list.Add(conductor);
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

        public static Conductor getInformacionSeleccionada(String numeroLicencia)
        {
            Conductor conductor = null;
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conexion != null)
                {
                    String query = String.Format("SELECT " +
                        "x.idConductor, " +
                        "x.numeroLicencia, " +
                        "x.apellidos, " +
                        "x.nombre, " +
                        "x.fechaNacimiento, " +
                        "x.telefono, " +
                        "x.usuario " +
                        "FROM dbo.Conductor x " +
                        "WHERE x.numeroLicencia='{0}';", numeroLicencia);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        conductor = new Conductor();
                        conductor.IdConductor = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        conductor.NumeroLicencia = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        conductor.Apellidos = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        conductor.Nombre = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        conductor.FechaNacimiento = (!rd.IsDBNull(4)) ? rd.GetDateTime(4) : new DateTime();
                        conductor.Telefono = (!rd.IsDBNull(5)) ? rd.GetString(5) : "";
                        conductor.Usuario = (!rd.IsDBNull(6)) ? rd.GetString(6) : "";
                    }
                    rd.Close();
                    command.Dispose();
                    Console.WriteLine(conductor);
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
            return conductor;
        }

    public static void agregarConductor(Conductor conductor)
        {
            String query = "";
            
            query = "INSERT INTO dbo.Conductor (numeroLicencia,apellidos,nombre,fechaNacimiento,telefono,usuario,contrasena) " +
                       "VALUES(@numeroLicencia,@apellidos,@nombre,GETDATE(),@telefono,@usuario,@contrasena);";
                
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
                    command.Parameters.AddWithValue("@numeroLicencia", conductor.NumeroLicencia);
                    command.Parameters.AddWithValue("@apellidos", conductor.Apellidos);
                    command.Parameters.AddWithValue("@nombre", conductor.Nombre);
                    command.Parameters.AddWithValue("@fechaNacimineto", conductor.FechaNacimiento);
                    command.Parameters.AddWithValue("@telefono", conductor.Telefono);
                    command.Parameters.AddWithValue("@usuario", conductor.Usuario);
                    command.Parameters.AddWithValue("@contrasena", conductor.Contrasenia);
                    
                    command.Parameters.AddWithValue("@idConductor", conductor.IdConductor);


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
