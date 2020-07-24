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
    class VehiculoDAO
    {
        public static string getMatricula(int idVehiculo)
        {
            string matricula="";
            Vehiculo vehiculo = null;
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conexion != null)
                {
                    String query = String.Format("SELECT " +
                        "x.idVehiculo, " +
                        "x.numeroPlacas " +
                        "FROM dbo.Vehiculo x " +
                        "WHERE x.idVehiculo ='{0}';", idVehiculo);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        vehiculo = new Vehiculo();
                        vehiculo.IdVehiculo = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        vehiculo.NumeroPlacas = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                    }
                    rd.Close();
                    command.Dispose();
                    Console.WriteLine(vehiculo);
                    matricula = vehiculo.NumeroPlacas;

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
            return matricula;

        }
    }
}
