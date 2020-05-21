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
