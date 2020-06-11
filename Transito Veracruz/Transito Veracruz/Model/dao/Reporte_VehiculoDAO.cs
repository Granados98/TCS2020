﻿using System;
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
    public class Reporte_VehiculoDAO
    {
        public static void guardarReporteVehiculo(Reporte_Vehiculo reporteVvehiculo)
        {

            String query = "";

            query = "INSERT INTO dbo.Reporte_Vehiculo (idVehiculo, numeroReporte) " +
                       "VALUES(@idVehiculo,@numeroReporte);";



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
                    command.Parameters.AddWithValue("@idVehiculo", reporteVvehiculo.IdVehiculo);
                    command.Parameters.AddWithValue("@numeroReporte", reporteVvehiculo.NumeroReporte);

                    command.Parameters.AddWithValue("@idReporte_Vehiculo", reporteVvehiculo.IdReporte_Vehiculo);

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
