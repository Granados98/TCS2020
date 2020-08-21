using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DireccionGeneral.Model.dbDireccion;
using DireccionGeneral.Model.pocosDireccion;

namespace DireccionGeneral.Model.daoDireccion
{
    class Reporte_VehiculoDAO
    {
        public static void asociarReporteVehiculo(Reporte_Vehiculo reporteVehiculo)
        {
            String query = "";

            query = "UPDATE dbo.Reporte_Vehiculo SET " +
                       "idReporte = @idReporte " +
                       "WHERE idReporte_Vehiculo = @idReporte_Vehiculo;";

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
                    command.Parameters.AddWithValue("@idReporte", reporteVehiculo.IdReporte);
                    command.Parameters.AddWithValue("@idReporte_Vehiculo", reporteVehiculo.IdReporte_Vehiculo);



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
        public static List<int> obtenerVehiculos(int idReporte)
        {
            List<int> vehiculos = new List<int>();
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
                        "x.idReporte " +
                        "FROM dbo.Reporte_Vehiculo x " +
                        "WHERE x.idReporte ='{0}';", idReporte);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        reporte = new Reporte_Vehiculo();
                        reporte.IdReporte_Vehiculo = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        reporte.IdVehiculo = (!rd.IsDBNull(1)) ? rd.GetInt32(1) : 0;
                        reporte.IdReporte = (!rd.IsDBNull(2)) ? rd.GetInt32(2) : 0;
                        vehiculos.Add(reporte.IdVehiculo);
                    }
                    rd.Close();
                    command.Dispose();
                    Console.WriteLine(reporte);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("No se encontro el Reporte asociado");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
            return vehiculos;
        }
    }
}
