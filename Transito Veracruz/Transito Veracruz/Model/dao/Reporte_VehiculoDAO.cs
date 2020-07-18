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
    public class Reporte_VehiculoDAO
    {
        public static int idReporte(int idVehiculo)
        {
            int idReporte = 0;
            Reporte_Vehiculo reporte = null;
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conexion != null)
                {
                    String query = String.Format("SELECT " +
                        "x.idReporte_Vehiculo, " +
                        "x.idVehiculo, " +
                        "x.numeroReporte " +
                        "FROM dbo.Reporte_Vehiculo x " +
                        "WHERE x.idVehiculo ='{0}';", idVehiculo);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        reporte = new Reporte_Vehiculo();
                        reporte.IdReporte_Vehiculo = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        reporte.IdVehiculo = (!rd.IsDBNull(1)) ? rd.GetInt32(1) : 0;
                        reporte.NumeroReporte = (!rd.IsDBNull(2)) ? rd.GetInt32(2) : 0;
                    }
                    rd.Close();
                    command.Dispose();
                    Console.WriteLine(reporte);

                    idReporte = reporte.IdReporte_Vehiculo;
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
            return idReporte;
        }
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
