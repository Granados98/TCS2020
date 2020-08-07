using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transito_Veracruz.Model.db;
using Transito_Veracruz.Model.pocos;

namespace Transito_Veracruz.Model.dao
{
    class DelegacionDAO
    {
        public static DelegacionMunicipal getInformacionDelegacion(String nombreDelegacion)
        {
            DelegacionMunicipal delegacion = null;
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conexion != null)
                {
                    String query = String.Format("SELECT " +
                        "x.idDelegacion, " +
                        "x.nombre, " +
                        "x.colonia, " +
                        "x.codigoPostal, " +
                        "x.municipio, " +
                        "x.telefono, " +
                        "x.correoElectronico, " +
                        "x.calle, " +
                        "x.numeroDireccion " +
                        "FROM dbo.Delegacion x " +
                        "WHERE x.nombre = '{0}';",nombreDelegacion);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        delegacion = new DelegacionMunicipal();
                        delegacion.IdDelegacion = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        delegacion.Nombre = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        delegacion.Colonia = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        delegacion.CodigoPostal = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        delegacion.Municipio = (!rd.IsDBNull(4)) ? rd.GetString(4) : "";
                        delegacion.Telefono = (!rd.IsDBNull(5)) ? rd.GetString(5) : "";
                        delegacion.Correo = (!rd.IsDBNull(6)) ? rd.GetString(6) : "";
                        delegacion.Calle = (!rd.IsDBNull(7)) ? rd.GetString(7) : "";
                        delegacion.Numero = (!rd.IsDBNull(8)) ? rd.GetString(8) : "";
                    }
                    rd.Close();
                    command.Dispose();
                    Console.WriteLine(delegacion);
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
            return delegacion;

        }
    }
}
