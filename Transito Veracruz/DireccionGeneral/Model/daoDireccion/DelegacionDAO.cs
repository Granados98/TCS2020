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
    class DelegacionDAO
    {
        public static List<Delegacion> getDelegacion()
        {
            List<Delegacion> list = new List<Delegacion>();
            SqlConnection conn = null;
            try
            {
                conn = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conn != null)
                {
                    String query = String.Format("SELECT " +
                        "x.idDelegacion, " +
                        "x.numeroDelegacion, " +
                        "x.nombre, " +
                        "x.colonia, " +
                        "x.codigoPostal, " +
                        "x.municipio, " +
                        "x.telefono, " +
                        "x.correoElectronico, " +
                        "x.calle, " +
                        "x.numeroDireccion " +
                        "FROM dbo.Delegacion x ");
                    //"WHERE x.idUsuario = {0} AND eliminado = 'N';", idPersonal);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        Delegacion m = new Delegacion();
                        m.IdDelegacion = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        m.NumeroDelegacion = (!rd.IsDBNull(1)) ? rd.GetInt32(1) : 0;
                        m.Nombre = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        m.Colonia = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        m.CodigoPostal = (!rd.IsDBNull(4)) ? rd.GetString(4) : "";
                        m.Municipio = (!rd.IsDBNull(5)) ? rd.GetString(5) : "";
                        m.Telefono = (!rd.IsDBNull(6)) ? rd.GetString(6) : "";
                        m.CorreoElectronico = (!rd.IsDBNull(7)) ? rd.GetString(7) : "";
                        m.Calle = (!rd.IsDBNull(8)) ? rd.GetString(8) : "";
                        m.NumeroDireccion = (!rd.IsDBNull(9)) ? rd.GetString(9) : "";

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

        /* public static int getIdDelegacion(String numeroDelegacion)
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

        } */

        public static void guardaDelegacion(Delegacion delegacion, bool nuevo)
        {

            String query = "";

            query = "INSERT INTO dbo.Vehiculo (numeroDelegacion,nombre,colonia,codigoPostal,municipio,telefono,correoElectronico,calle,numeroDireccion) " +
                       "VALUES(@numeroDelegacion,@nombre,@colonia,@codigoPostal,@municipio,@telefono,@correoElectronico,@calle,@numeroDireccion);";



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
                    command.Parameters.AddWithValue("@numeroDelegacion", delegacion.NumeroDelegacion);
                    command.Parameters.AddWithValue("@nombre", delegacion.Nombre);
                    command.Parameters.AddWithValue("@colonia", delegacion.Colonia);
                    command.Parameters.AddWithValue("@codigoPostal", delegacion.CodigoPostal);
                    command.Parameters.AddWithValue("@municipio", delegacion.Municipio);
                    command.Parameters.AddWithValue("@telefono", delegacion.Telefono);
                    command.Parameters.AddWithValue("@correoElectronico", delegacion.CorreoElectronico);
                    command.Parameters.AddWithValue("@calle", delegacion.Calle);
                    command.Parameters.AddWithValue("@numeroDireccion", delegacion.NumeroDireccion);

                    command.Parameters.AddWithValue("@idVehiculo", delegacion.IdDelegacion);

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




