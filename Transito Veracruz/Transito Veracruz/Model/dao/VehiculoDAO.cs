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
        public static int getIdVehiculo(int idConductor)
        {
            int idVehiculo = 0;
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
                        "x.numeroPlacas, " +
                        "x.idConductor " +
                        "FROM dbo.Vehiculo x " +
                        "WHERE x.idConductor='{0}';", idConductor);
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

                    idVehiculo = vehiculo.IdVehiculo;
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
            return idVehiculo;

        }
        public static void eliminarVehiculo(int idConductor)
        {
            String query = "";
            query = "DELETE FROM dbo.Vehiculo WHERE idConductor = @idConductor;";
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
                    command.Parameters.AddWithValue("@idConductor", idConductor);
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
        public static List<Vehiculo> obtenerVehiculos()
        {
            List<Vehiculo> list = new List<Vehiculo>();
            SqlConnection conn = null;

            try
            {
                conn = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conn != null)
                {
                    String query = String.Format("SELECT " +
                        "x.idVehiculo, " +
                        "x.numeroPlacas, " +
                        "x.marca, " +
                        "x.modelo, " +
                        "x.año, " +
                        "x.color, " +
                        "x.nombreAseguradora, " +
                        "x.numeroPolizaSeguro, " +
                        "x.idConductor " +
                        "FROM dbo.Vehiculo x ");
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        Vehiculo vehiculo = new Vehiculo();
                        vehiculo.IdVehiculo = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        vehiculo.NumeroPlacas = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        vehiculo.Marca = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        vehiculo.Modelo = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        vehiculo.Anio = (!rd.IsDBNull(4)) ? rd.GetString(4) : "";
                        vehiculo.Color = (!rd.IsDBNull(5)) ? rd.GetString(5) : "";
                        vehiculo.NombreAseguradora = (!rd.IsDBNull(6)) ? rd.GetString(6) : "";
                        vehiculo.NumeroPolizaSeguro = (!rd.IsDBNull(7)) ? rd.GetString(7) : "";
                        vehiculo.IdConductor = (!rd.IsDBNull(8)) ? rd.GetInt32(8) : 0;

                        list.Add(vehiculo);
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
        public static int getIdVehiculo(String numeroPlacas)
        {
            int idVehiculo = 0;
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
                        "WHERE x.numeroPlacas='{0}';", numeroPlacas);
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

                    idVehiculo = vehiculo.IdVehiculo;
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
            return idVehiculo;

        }
        public static Vehiculo getVehiculoConductor(String numeroPlacas)
        {
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
                        "x.numeroPlacas, " +
                        "x.marca, " +
                        "x.modelo, " +
                        "x.año, " +
                        "x.color " +
                        "FROM dbo.Vehiculo x " +
                        "WHERE x.numeroPlacas='{0}';", numeroPlacas);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        vehiculo = new Vehiculo();
                        vehiculo.IdVehiculo = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        vehiculo.NumeroPlacas = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        vehiculo.Marca = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        vehiculo.Modelo = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        vehiculo.Anio = (!rd.IsDBNull(4)) ? rd.GetString(4) : "";
                        vehiculo.Color = (!rd.IsDBNull(5)) ? rd.GetString(5) : "";
                    }
                    rd.Close();
                    command.Dispose();
                    Console.WriteLine(vehiculo);
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
            return vehiculo;
        }
        public static void guardaVehiculo(Vehiculo vehiculo, bool nuevo)
        {

            String query = "";
            if (nuevo)
            {
                query = "INSERT INTO dbo.Vehiculo (numeroPlacas,marca,modelo,año,color,nombreAseguradora,numeroPolizaSeguro,idConductor) " +
                          "VALUES(@numeroPlacas,@marca,@modelo,@año,@color,@nombreAseguradora,@numeroPolizaSeguro,@idConductor);";

            }
            else
            {
                query = "UPDATE dbo.Vehiculo SET " +
                        "numeroPlacas = @numeroPlacas," +
                        "marca = @marca, " +
                        "modelo = @modelo, " +
                        "año = @año, " +
                        "color = @color, " +
                        "nombreAseguradora = @nombreAseguradora, " +
                        "numeroPolizaSeguro = @numeroPolizaSeguro " +
                        "WHERE idVehiculo = @idVehiculo;";
            }


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

                    if (nuevo)
                    {
                        command.Parameters.AddWithValue("@idConductor", vehiculo.IdConductor);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@idVehiculo", vehiculo.IdVehiculo);
                    }


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
