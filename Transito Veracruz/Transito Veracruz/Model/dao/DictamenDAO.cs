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
    class DictamenDAO
    {
        
        public static DictamenC getInformacionDictamen(int idDictamen)
        {
            DictamenC dictamen = null;
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conexion != null)
                {
                    String query = String.Format("SELECT " +
                        "x.idDictamen, " +
                        "x.descripcion, " +
                        "x.fechaDictamen, " +
                        "x.idPersonal " +
                        "FROM dbo.Dictamen x " +
                        "WHERE x.folio = '{0}';", idDictamen);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())           
                    {
                        dictamen = new DictamenC();
                        dictamen.IdDictamen = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        dictamen.Descripcion = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        dictamen.FechaDictamen = (!rd.IsDBNull(2)) ? rd.GetDateTime(2) : new DateTime();
                        dictamen.IdPersonal = (!rd.IsDBNull(3)) ? rd.GetInt32(3) : 0;
                    }
                    rd.Close();
                    command.Dispose();
                    Console.WriteLine(dictamen);
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
            return dictamen;
        }
    }
}
