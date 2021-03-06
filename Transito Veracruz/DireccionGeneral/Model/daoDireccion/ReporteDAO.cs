﻿using System;
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
    class ReporteDAO
    {
        public static List<Reporte> getReportesAvanzada(string delegacion, string estatus)
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
                        "x.idReporte, " +
                        "x.estatus, " +
                        "x.nombreDelegacion, " +
                        "x.direccion, " +
                        "x.fechaCreacion, " +
                        "x.idDictamen " +
                        "FROM dbo.Reporte x " +
                        "WHERE x.nombreDelegacion='{0}' AND estatus='{1}';", delegacion,estatus);
                    //"WHERE x.idUsuario = {0} AND eliminado = 'N';", idPersonal);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        Reporte m = new Reporte();
                        m.IdReporte = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        m.Estatus = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        m.NombreDelegacion = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        m.Direccion = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        m.FechaCreacion = (!rd.IsDBNull(4)) ? rd.GetString(4) : "";
                        m.FolioDictamen = (!rd.IsDBNull(5)) ? rd.GetInt32(5) : 0;

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
        public static List<Reporte> getReportesDelegacion(string delegacion)
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
                        "x.idReporte, " +
                        "x.estatus, " +
                        "x.nombreDelegacion, " +
                        "x.direccion, " +
                        "x.fechaCreacion, " +
                        "x.idDictamen " +
                        "FROM dbo.Reporte x " +
                        "WHERE x.nombreDelegacion='{0}';", delegacion);
                    //"WHERE x.idUsuario = {0} AND eliminado = 'N';", idPersonal);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        Reporte m = new Reporte();
                        m.IdReporte = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        m.Estatus = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        m.NombreDelegacion = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        m.Direccion = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        m.FechaCreacion = (!rd.IsDBNull(4)) ? rd.GetString(4) : "";
                        m.FolioDictamen = (!rd.IsDBNull(5)) ? rd.GetInt32(5) : 0;

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
        public static List<Reporte> getReportesEstatus(string estatus)
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
                        "x.idReporte, " +
                        "x.estatus, " +
                        "x.nombreDelegacion, " +
                        "x.direccion, " +
                        "x.fechaCreacion, " +
                        "x.idDictamen " +
                        "FROM dbo.Reporte x " +
                        "WHERE x.estatus='{0}';", estatus);
                    //"WHERE x.idUsuario = {0} AND eliminado = 'N';", idPersonal);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        Reporte m = new Reporte();
                        m.IdReporte = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        m.Estatus = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        m.NombreDelegacion = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        m.Direccion = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        m.FechaCreacion = (!rd.IsDBNull(4)) ? rd.GetString(4) : "";
                        m.FolioDictamen = (!rd.IsDBNull(5)) ? rd.GetInt32(5) : 0;

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
        public static int verificaExistenciaDictamen(int idReporte)
        {

            int idDictamen = 0;
            Reporte reporte = null;
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                SqlDataReader rd;
                if (conexion != null)
                {
                    String query = String.Format("SELECT " +
                        "x.idReporte, " +
                        "x.idDictamen " +
                        "FROM dbo.Reporte x " +
                        "WHERE x.idReporte='{0}';", idReporte);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conexion);
                    rd = command.ExecuteReader();

                    while (rd.Read())
                    {
                        reporte = new Reporte();
                        reporte.IdReporte = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        reporte.FolioDictamen = (!rd.IsDBNull(1)) ? rd.GetInt32(1) : 0;
                    }
                    rd.Close();
                    command.Dispose();

                    idDictamen = reporte.FolioDictamen;
                    Console.WriteLine(idDictamen);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("No se encontro el dictamen");
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
            return idDictamen;
        }
        public static void asociarDictamen(Reporte reporte)
        {
            String query = "";

            query = "UPDATE dbo.Reporte SET " +
                       "estatus = @estatus, " +
                       "idDictamen = @idDictamen " +
                       "WHERE idReporte = @idReporte;";

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
                    command.Parameters.AddWithValue("@idDictamen", reporte.FolioDictamen);

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
                        "x.idReporte, " +
                        "x.estatus, " +
                        "x.nombreDelegacion, " +
                        "x.direccion, " +
                        "x.fechaCreacion, " +
                        "x.idDictamen " +
                        "FROM dbo.Reporte x ");
                    //"WHERE x.idUsuario = {0} AND eliminado = 'N';", idPersonal);
                    Console.WriteLine(query);
                    command = new SqlCommand(query, conn);
                    rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        Reporte m = new Reporte();
                        m.IdReporte = (!rd.IsDBNull(0)) ? rd.GetInt32(0) : 0;
                        m.Estatus = (!rd.IsDBNull(1)) ? rd.GetString(1) : "";
                        m.NombreDelegacion = (!rd.IsDBNull(2)) ? rd.GetString(2) : "";
                        m.Direccion = (!rd.IsDBNull(3)) ? rd.GetString(3) : "";
                        m.FechaCreacion = (!rd.IsDBNull(4)) ? rd.GetString(4) : "";
                        m.FolioDictamen = (!rd.IsDBNull(5)) ? rd.GetInt32(5) : 0;

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
    }
}
