using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
using System.Threading;
using Transito_Veracruz.Model.interfaz;

namespace Transito_Veracruz.Delegacion
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class MenuDelegacion : Window, InterfaceMenu
    {

        Socket socketCliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint direccionConexion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
        
        private String mensaje = "";
        private String mensajeRecibido = "";

        private List<Conductor> listConductores { get; set; }
        private List<Reporte> listReporte { get; set; }

        private Personal usuarioIniciado { get; set; }
        public MenuDelegacion(Personal personal)
        {
            InitializeComponent();
            this.usuarioIniciado = personal;
            cargarTablaConductores();
            cargarTablaVehiculos();
            nombre_Usuario.Content = usuarioIniciado.Usuario;
            
            //el cliente se conecta con el servidor
            socketCliente.Connect(direccionConexion);
            Console.WriteLine("Conectado con exito al servidor...");
            
            int id = usuarioIniciado.IdPersonal;
            string idU=Convert.ToString(id);
            byte[] bufferIdUsuario = Encoding.Default.GetBytes(idU);
            socketCliente.Send(bufferIdUsuario, 0, bufferIdUsuario.Length, 0);

            recibeMensajes();
            cargarReportes();
        }

        /*
        private void mostrarMensaje()
        {
            string mensaje = "";
            string info = "";

            byte[] ByRec = new byte[255];
            int datos = socketClienteRemoto.Receive(ByRec, 0, ByRec.Length, 0);
            Array.Resize(ref ByRec, datos);
            mensaje = Encoding.Default.GetString(ByRec);
            info += mensaje + "\n";

            block_Chat.Items.Add(mensaje);
        }*/


        private void cargarReportes()
        {
            //listReporte = ReporteDAO.getReportes(usuarioIniciado.IdPersonal);
            listReporte = ReporteDAO.getReportes();
            dg_Reportes.ItemsSource = listReporte;
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
            LevantaReporte reporte = new LevantaReporte(this);
            reporte.Show();
        }

        private void btn_EnviarMensaje_Click(object sender, RoutedEventArgs e)
        {
            byte[] msjEnviar = Encoding.Default.GetBytes(txt_Mensaje.Text);
            socketCliente.Send(msjEnviar, 0, msjEnviar.Length, 0);

            block_Chat.Items.Add("Tu: "+txt_Mensaje.Text);
            
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
                    String query = String.Format("SELECT numeroPlacas,marca,modelo,año,color,nombreAseguradora,numeroPolizaSeguro FROM Vehiculo");
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
                    String query = String.Format("SELECT numeroPlacas,marca,modelo,año,color,nombreAseguradora,numeroPolizaSeguro FROM Vehiculo");
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

        private void txt_Mensaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (Validacion.oprimeEnter(e))
            {
                byte[] msjEnviar = Encoding.Default.GetBytes(txt_Mensaje.Text);
                socketCliente.Send(msjEnviar, 0, msjEnviar.Length, 0);

                block_Chat.Items.Add("Tu: "+txt_Mensaje.Text);
            }
        }

        private void recibeMensajes()
        {
            byte[] recibeBytes = new byte[255];
            int datos = socketCliente.Receive(recibeBytes, 0, recibeBytes.Length, 0);
            Array.Resize(ref recibeBytes, datos);
            mensajeRecibido = Encoding.Default.GetString(recibeBytes);

            block_Chat.Items.Add(mensajeRecibido);
            block_Chat.UpdateLayout();
            Console.WriteLine(mensajeRecibido);
        }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.usuarioIniciado.Estado = "Desconectado";
            PersonalDAO.actualizarEstadoUsuario(usuarioIniciado);
            this.Close();
        }

        private void dg_Reportes_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            int index = dg_Reportes.SelectedIndex;
            if (index>=0)
            {
                Reporte reporte = listReporte[index];
                if (reporte.FolioDictamen == 0)
                {
                    MessageBox.Show("Aun no hay dictamen");
                }
                else
                {
                    int folioFila = reporte.FolioDictamen;
                    Console.WriteLine(folioFila);
                    Dictamen detalleDictamen = new Dictamen(folioFila);
                    detalleDictamen.Show();
                    /*
                    DictamenC dictamenEncontrado = DictamenDAO.getInformacionDictamen(folioFila);
                    MessageBox.Show("El folio del dictamen es: "+ dictamenEncontrado.Folio+" Descripcion: "+ dictamenEncontrado.Descripcion+
                        " Elaborado: "+ dictamenEncontrado.FechaDictamen);*/
                }
            }
        }

        public void actualizar(int numeroReporte, string estatus, string nombreDelegacion, string direccion)
        {
            MessageBox.Show($", Numero Reporte: {numeroReporte}, estatus: {estatus}, Nombre Delegacion: {nombreDelegacion}, Direccion: {direccion}");
            cargarReportes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            block_Chat.Items.Add(mensajeRecibido);
        }
    }
}
