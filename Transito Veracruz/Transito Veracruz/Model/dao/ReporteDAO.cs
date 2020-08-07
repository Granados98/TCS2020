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
        public static void eliminarReporte(int idReporte)
        {
            String query = "";
            query = "DELETE FROM dbo.Reporte WHERE idReporte = @idReporte;";
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
                    command.Parameters.AddWithValue("@idReporte", idReporte);
                    int i = command.ExecuteNonQuery();
                    Console.WriteLine("Rows affected: " + i);
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
        }
        public static int consultaReporteNuevo(DateTime fechaCreacion)
        {
            int idReporteAux = 0;
            Reporte reporte = null;
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
                                                 "x.direccion, " +
                                                 "x.fechaCreacion " +
                                                 "FROM dbo.Reporte x " +
                                                 "WHERE x.fechaCreacion = {0};", fechaCreacion);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    rd = command.ExecuteReader();
                    
                    while (rd.Read())
                    {
                        reporte = new Reporte();
                        reporte.IdReporte = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        reporte.IdDictamen = (!rd.IsDBNull(1)) ? rd.GetInt32(1) : 0;
                        reporte.Direccion = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        reporte.FechaCreacion = (!rd.IsDBNull(3)) ? rd.GetDateTime(3) : new DateTime();

                    }
                    rd.Close();
                    command.Dispose();
                    Console.WriteLine(reporte);

                    idReporteAux = reporte.IdReporte;
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
            return idReporteAux;
        }
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
                                                 "x.estatus," +
                                                 "x.nombreDelegacion," +
                                                 "x.direccion, " +
                                                 "x.idDictamen " +
                                                 "FROM dbo.Reporte x " );
                                                 //"WHERE x.idUsuario = {0} AND eliminado = 'N';", idPersonal);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        Reporte m = new Reporte();
                        m.IdReporte = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        m.Estatus = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        m.NombreDelegacion = (!rd.IsDBNull(2)) ? rd.GetString(3) : "";
                        m.Direccion = (!rd.IsDBNull(4)) ? rd.GetString(4) : "";
                        m.IdDictamen = (!rd.IsDBNull(5)) ? rd.GetInt32(5) : 0;

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

            query = "INSERT INTO dbo.Reporte (estatus,nombreDelegacion,direccion) " +
                       "VALUES(@estatus,@nombreDelegacion,@direccion);";



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
