﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transito_Veracruz.Delegacion;
using Transito_Veracruz.Model.db;

namespace Transito_Veracruz.Model.dao
{
    class DictamenDAO
    {
        /*
        public static Dictamen getInformacionDictamen(int folio)
        {
            Dictamen dictamen = null;
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
                        "x.folio, " +
                        "x.descripcion, " +
                        "x.fechaDictamne, " +
                        "x.horaDictamen " +
                        "FROM dbo.Dictamen x " +
                        "WHERE x.folio = '{0}';", folio);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())           
                    {
                        dictamen = new Dictamen();
                        dictamen. = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        dictamen.NumeroPersonal = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        dictamen.TipoPersonal = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        dictamen.Apellidos = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        dictamen.Nombre = (!rd.IsDBNull(4)) ? rd.GetString(4) : "";
                    }
                    rd.Close();
                    command.Dispose();
                    Console.WriteLine(personal);
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
            return personal;
        }*/
    }
}
