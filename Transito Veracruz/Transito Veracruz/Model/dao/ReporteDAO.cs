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
    class ReporteDAO
    {
        public static List<Reporte> getReportes()
        {
            List<Reporte> list = new List<Reporte>();
            SqlConnection conn = null;
            try
            {
                conn = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conn != null)
                {
                    String query = String.Format("SELECT " +
                                                 "x.idReporte," +
                                                 "x.numeroReporte," +
                                                 "x.estatus," +
                                                 "x.nombreDelegacion," +
                                                 "x.folioDictamen, " +
                                                 "x.direccion " +
                                                 "FROM dbo.Reporte x " );
                                                 //"WHERE x.idUsuario = {0} AND eliminado = 'N';", idPersonal);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        Reporte m = new Reporte();
                        m.IdReporte = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        m.NumeroReporte = (!rd.IsDBNull(1)) ? rd.GetInt32(1) : 0;
                        m.Estatus = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        m.NombreDelegacion = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        m.FolioDictamen = (!rd.IsDBNull(4)) ? rd.GetInt32(4) : 0;
                        m.Direccion = (!rd.IsDBNull(5)) ? rd.GetString(5) : "";

                        list.Add(m);
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

        public static void guardaReporte(Reporte reporte)
        {

            String query = "";

            query = "INSERT INTO dbo.Reporte (numeroReporte,estatus,nombreDelegacion,direccion) " +
                       "VALUES(@numeroReporte,@estatus,@nombreDelegacion,@direccion);";



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
                    command.Parameters.AddWithValue("@numeroReporte", reporte.NumeroReporte);
                    command.Parameters.AddWithValue("@estatus", reporte.Estatus);
                    command.Parameters.AddWithValue("@nombreDelegacion", reporte.NombreDelegacion);
                    command.Parameters.AddWithValue("@direccion", reporte.Direccion);

                    command.Parameters.AddWithValue("@idReporte", reporte.IdReporte);

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
