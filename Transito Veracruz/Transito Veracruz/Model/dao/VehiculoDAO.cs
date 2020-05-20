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
    class VehiculoDAO
    {
        public static void guardaVehiculo(Vehiculo vehiculo)
        {

            String query = "";

            query = "INSERT INTO dbo.Vehiculo (numeroPlacas,marca,modelo,año,color,nombreAseguradora,numeroPolizaSeguro,numeroLicencia) " +
                       "VALUES(@numeroPlacas,@marca,@modelo,@año,@color,@nombreAseguradora,@numeroPolizaSeguro,@numeroLicencia);";


            
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
                    command.Parameters.AddWithValue("@numeroPlacas", vehiculo.NumeroPlacas);
                    command.Parameters.AddWithValue("@marca", vehiculo.Marca);
                    command.Parameters.AddWithValue("@modelo", vehiculo.Modelo);
                    command.Parameters.AddWithValue("@año", vehiculo.Anio);
                    command.Parameters.AddWithValue("@color", vehiculo.Color);
                    command.Parameters.AddWithValue("@nombreAseguradora", vehiculo.NombreAseguradora);
                    command.Parameters.AddWithValue("@numeroPolizaSeguro", vehiculo.NumeroPolizaSeguro);

                    command.Parameters.AddWithValue("@idVehiculo", vehiculo.NumeroLicencia);

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
