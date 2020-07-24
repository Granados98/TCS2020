using System;
using System.Collections.Generic;
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
        public static List<int> obtenerVehiculos(int numeroReporte)
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
                        "x.numeroReporte " +
                        "FROM dbo.Reporte_Vehiculo x " +
                        "WHERE x.numeroReporte ='{0}';", numeroReporte);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        reporte = new Reporte_Vehiculo();
                        reporte.IdReporte_Vehiculo = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        reporte.IdVehiculo = (!rd.IsDBNull(1)) ? rd.GetInt32(1) : 0;
                        reporte.NumeroReporte = (!rd.IsDBNull(2)) ? rd.GetInt32(2) : 0;
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
