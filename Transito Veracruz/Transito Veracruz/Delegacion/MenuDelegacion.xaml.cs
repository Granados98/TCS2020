using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Transito_Veracruz.Model;
using Transito_Veracruz.Model.dao;
using Transito_Veracruz.Model.db;
using Transito_Veracruz.Model.pocos;
using Transito_Veracruz.Model.security;

namespace Transito_Veracruz.Delegacion
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class MenuDelegacion : Window
    {

        Socket socketCliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint direccionConexion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
        private List<Conductor> listConductores { get; set; }
        private Personal usuarioIniciado { get; set; }
        public MenuDelegacion(Personal personal)
        {
            InitializeComponent();
            this.usuarioIniciado = personal;
            cargarTablaConductores();
            cargarTablaVehiculos();

            socketCliente.Connect(direccionConexion);
            Console.WriteLine("Conectado con exito al servidor...");

        }

        private void btn_AgregarConductor_Click(object sender, RoutedEventArgs e)
        {
            RegistroConductor conductor = new RegistroConductor();
            conductor.Show();
        }

        private void btn_AgregarVehiculo_Click(object sender, RoutedEventArgs e)
        {
            AgregarVehiculo vehiculo = new AgregarVehiculo();
            vehiculo.Show();
        }

        private void btn_AgregarReporte_Click(object sender, RoutedEventArgs e)
        {
            LevantaReporte reporte = new LevantaReporte();
            reporte.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_EnviarMensaje_Click(object sender, RoutedEventArgs e)
        {
            byte[] msjEnviar = Encoding.Default.GetBytes(txt_Mensaje.Text);
            socketCliente.Send(msjEnviar, 0, msjEnviar.Length, 0);

            block_Chat.Items.Add(txt_Mensaje.Text);

        }

        private void cargarTablaConductores()
        {
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                if (conexion != null)
                {
                    String query = String.Format("SELECT numeroLicencia,apellidos,nombre,fechaNacimiento,telefono FROM Conductor");
                    command = new SqlCommand(query, conexion);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                    DataTable dt = new DataTable("Condustor");
                    dataAdp.Fill(dt);
                    dg_Conductores.ItemsSource = dt.DefaultView;
                    dataAdp.Update(dt);

                    command.Dispose();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("No se encontro los Conductores");
            }
        }
        
        private void btn_CargarConductores_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                if (conexion != null)
                {
                    String query = String.Format("SELECT numeroLicencia,apellidos,nombre,fechaNacimiento,telefono FROM Conductor");
                    command = new SqlCommand(query, conexion);
                    command.ExecuteNonQuery();

                    SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                    DataTable dt = new DataTable("Conductor");
                    dataAdp.Fill(dt);
                    dg_Conductores.ItemsSource = dt.DefaultView;
                    dataAdp.Update(dt);

                    command.Dispose();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("No se encontro los Conductores");
            }
        }

        private void cargarTablaVehiculos()
        {
            SqlConnection conexion = null;
            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                if (conexion != null)
                {
                    String query = String.Format("SELECT numeroPlacas,marca,modelo,año,color,nombreAseguradora,numeroPolizaSeguro,numeroLicencia FROM Vehiculo");
                    command = new SqlCommand(query, conexion);
                    command.ExecuteNonQuery();

                    SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                    DataTable dt = new DataTable("Vehiculo");
                    dataAdp.Fill(dt);
                    dg_Vehiculos.ItemsSource = dt.DefaultView;
                    dataAdp.Update(dt);

                    command.Dispose();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("No se encontro los vehiculos");
            }

        }

        private void btn_CargarVehiculos_Click(object sender, RoutedEventArgs e)
        { 
            SqlConnection conexion = null;
            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                if (conexion != null)
                {
                    String query = String.Format("SELECT numeroPlacas,marca,modelo,año,color,nombreAseguradora,numeroPolizaSeguro,numeroLicencia FROM Vehiculo");
                    command = new SqlCommand(query, conexion);
                    command.ExecuteNonQuery();

                    SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                    DataTable dt = new DataTable("Vehiculo");
                    dataAdp.Fill(dt);

                    command.Dispose();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("No se encontro los vehiculos");
            }
        }

        private void txt_Mensaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (Validacion.oprimeEnter(e))
            {
                byte[] msjEnviar = Encoding.Default.GetBytes(txt_Mensaje.Text);
                socketCliente.Send(msjEnviar, 0, msjEnviar.Length, 0);

                block_Chat.Items.Add(txt_Mensaje.Text);
            }
        }
    }
}
