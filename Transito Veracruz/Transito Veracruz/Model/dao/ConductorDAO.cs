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
        public static void agregarConductor(Conductor conductor)
        {
            String query = "";
            
            query = "INSERT INTO dbo.Conductor (numeroLicencia,apellidos,nombre,fechanNacimiento,telefono,usuario,contrasenia) " +
                       "VALUES(@numeroLicencia,@apellidos,@nombre,GETDATE(),@telefono,@usuario,@contrasenia);";
                
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
                    command.Parameters.AddWithValue("@contrasenia", conductor.Contrasenia);
                    
                    command.Parameters.AddWithValue("@idEgresado", conductor.IdConductor);


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
        
        public static List<Conductor> getConductores()
        {
            List<Conductor> list = new List<Conductor>();
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
                        "FROM dbo.Conductor x " ;
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        Conductor cond = new Conductor();
                        cond.Apellidos = (!rd.IsDBNull(0)) ? rd.GetString(0) : "";
                        cond.Nombre = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        cond.FechaNacimiento = (!rd.IsDBNull(2)) ? rd.GetDateTime(2) : new DateTime();
                        cond.Telefono = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";

                        list.Add(cond);
                    }
                    rd.Close();
                    command.Dispose();

                }
            } catch (Exception e)
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
            return list;
        }
    }
}
