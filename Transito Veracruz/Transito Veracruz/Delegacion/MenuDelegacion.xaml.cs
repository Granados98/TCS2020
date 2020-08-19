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
using Transito_Veracruz.Clases;
using Newtonsoft.Json;

namespace Transito_Veracruz.Delegacion
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class MenuDelegacion : Window, InterfaceMenu
    {

        private Socket socketCliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //IPEndPoint direccionConexion = new IPEndPoint(IPAddress.Any, 1234);


        private string mensaje = "";
        private string usuarioEmisor = "";
        //private String mensajeRecibido = "";

        private List<string> listaConectados = new List<string>();

        byte[] receivedBuf = new byte[1024];
        Mensaje envioMensaje = new Mensaje();

        private List<Conductor> listConductores { get; set; }
        private List<Reporte> listReporte { get; set; }
        private List<Vehiculo> listVehiculo { get; set; }

        private Personal usuarioIniciado { get; set; }
        public MenuDelegacion(Personal personal)
        {
            InitializeComponent();
            this.usuarioIniciado = personal;
            usuarioEmisor = personal.Usuario;
            cargarTablaConductores();
            cargarTablaVehiculos();
            nombre_Usuario.Content = usuarioIniciado.Usuario;
            
            cargarReportes();
            //conectarServidor();
        }


        private void cargarReportes()
        {
            listReporte = ReporteDAO.getReportes();
            dg_Reportes.ItemsSource = listReporte;
        }

        private void btn_AgregarConductor_Click(object sender, RoutedEventArgs e)
        {
            Conductor nuevoConductor = new Conductor();
            RegistroConductor conductor = new RegistroConductor(this,true,nuevoConductor);
            conductor.Show();
        }

        private void btn_AgregarVehiculo_Click(object sender, RoutedEventArgs e)
        {
            Vehiculo nuevoVehiculo = new Vehiculo();
            AgregarVehiculo vehiculo = new AgregarVehiculo(this,true,nuevoVehiculo);
            vehiculo.Show();
        }

        private void btn_AgregarReporte_Click(object sender, RoutedEventArgs e)
        {
            LevantaReporte reporte = new LevantaReporte(this);
            reporte.Show();
        }

        private void btn_EnviarMensaje_Click(object sender, RoutedEventArgs e)
        {
            enviarMensaje();
        }

        public void recibirMensaje(string mensajeRecibido, string usuarioEmisor)
        {
            string mensajeFinal= Convert.ToString(usuarioEmisor+" "+mensajeRecibido);
            block_Chat.Items.Add(usuarioEmisor+":"+ mensajeFinal);
        }

        private void conectarServidor()
        {
            repetirConexion();
            socketCliente.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(recibeDatos), socketCliente);

            byte[] buffer = Encoding.Default.GetBytes(serializarMensaje("", false, false));
            socketCliente.Send(buffer);
        }

        public string serializarMensaje(string contenidoMensaje, bool isMensajeConexion, bool isMensaje)
        {
            Mensaje mensajeChat = new Mensaje(contenidoMensaje, usuarioEmisor, isMensaje, false);
            return Newtonsoft.Json.JsonConvert.SerializeObject(mensajeChat).ToString();
        }
        private void recibeDatos(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                int received = socket.EndReceive(ar);
                byte[] dataBuf = new byte[received];
                Array.Copy(receivedBuf, dataBuf, received);

                mensaje = (Encoding.Default.GetString(dataBuf));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            //Conexion y mensajes

            string objetoSerializado = mensaje;

            envioMensaje = JsonConvert.DeserializeObject<Mensaje>(mensaje);

            if (envioMensaje.contenidoMensaje == null)
            {
                UsuarioConectado cc = Newtonsoft.Json.JsonConvert.DeserializeObject<UsuarioConectado>(objetoSerializado);
                //Llena lista con nombre de usuario
                listaConectados = new List<string>();
                for (int i = 0; i < cc.usuarioConectado.Count; i++)
                {
                    listaConectados.Add(cc.usuarioConectado[i] + " (" + cc.usuarioConectado[i] + ")");
                }
            }
            else if (envioMensaje.contenidoMensaje != null)
            {
                this.Dispatcher.Invoke(() =>{recibirMensaje(envioMensaje.contenidoMensaje, envioMensaje.usuarioEmisor);});
            }


            try
            {
                socketCliente.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(recibeDatos), socketCliente);
            }
            catch (SocketException)
            {
                return;
            }

        }

        private void repetirConexion()
        {

            while (!socketCliente.Connected)
            {
                try
                {
                    socketCliente.Connect(IPAddress.Loopback, 1234);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }

        public void enviarMensaje()
        {
            string texto = txt_Mensaje.Text.Trim();

            if (texto != "")
            {
                if (socketCliente.Connected)
                {
                    byte[] buffer = Encoding.Default.GetBytes(serializarMensaje(texto, false, true));
                    socketCliente.Send(buffer);
                }

                txt_Mensaje.Text = "";
                txt_Mensaje.Focus();
            }
        }

        private void cargarTablaConductores()
        {
            listConductores = ConductorDAO.obtenerConductores();
            dg_Conductores.ItemsSource = listConductores;
        }

        private void cargarTablaVehiculos()
        {
            listVehiculo = VehiculoDAO.obtenerVehiculos();
            dg_Vehiculos.ItemsSource = listVehiculo;
            
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

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.usuarioIniciado.Estado = "Desconectado";
            PersonalDAO.actualizarEstadoUsuario(usuarioIniciado);

            Login iniciarSesion = new Login();
            iniciarSesion.Show();

            this.Close();
        }

        private void dg_Reportes_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            int index = dg_Reportes.SelectedIndex;
            if (index>=0)
            {
                Reporte reporte = listReporte[index];
                if (reporte.IdDictamen == 0)
                {
                    MessageBox.Show("Aun no hay dictamen");
                }
                else
                {
                    int idDictamen = reporte.IdDictamen;
                    Console.WriteLine(idDictamen);
                    Dictamen detalleDictamen = new Dictamen(idDictamen);
                    detalleDictamen.Show();
                }
            }
        }
        
        public void actualizar(int idReporte, string estatus, string nombreDelegacion, string direccion, int dictamen)
        {
            cargarReportes();
        }

        public void actualizar(string numeroLicencia, string apellidos, string nombre, string fechaNacimiento, string telefono)
        {
            cargarTablaConductores();
        }
        public void actualizar(string numeroPLacas, string marca, string modelo, string anio, string color, string nombreAseguradora, string numeroPoliza)
        {
            cargarTablaVehiculos();
        }

        private void btn_EliminarConductor_Click(object sender, RoutedEventArgs e)
        {
            var index = dg_Conductores.SelectedIndex;
            if (index >= 0)
            {
                Conductor conductor = listConductores[index];

                if (MessageBox.Show("¿Desea eliminar el conductor con licencia: " + conductor.NumeroLicencia + "?", "Eliminar conductor", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    int idVehiculo = VehiculoDAO.getIdVehiculo(conductor.IdConductor);
                    Console.WriteLine(idVehiculo);
                    if (Reporte_VehiculoDAO.getIdReporte(idVehiculo)==0) {
                        if (idVehiculo > 0)
                        {
                            VehiculoDAO.eliminarVehiculo(conductor.IdConductor,true);
                            ConductorDAO.eliminarConductor(conductor.IdConductor);
                        }
                        else
                        {
                            if (idVehiculo == 0)
                            {
                                ConductorDAO.eliminarConductor(conductor.IdConductor);
                            }
                            else
                            {
                                MessageBox.Show("No se puede eliminar");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede borrar el conductor, el conductor tiene un reporte en proceso");
                    }
                }

                this.cargarTablaConductores();
                this.cargarTablaVehiculos();
            }
            else
            {
                MessageBox.Show(this, "Seleccione el conductor que deseas eliminar");
            }
        }

        private void btn_EditarConductor_Click(object sender, RoutedEventArgs e)
        {
            int index = dg_Conductores.SelectedIndex;
            if (index>=0)
            {
                Conductor conductor = listConductores[index];
                Boolean resultado = false;
                RegistroConductor rc = new RegistroConductor(this,false,conductor);
                rc.ShowDialog();
                resultado = rc.Resultado;
                if (resultado)
                {
                    this.cargarTablaConductores();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un conductor");
            }
        }

        private void btn_EliminarVehiculo_Click(object sender, RoutedEventArgs e)
        {
            int index = dg_Vehiculos.SelectedIndex;
            if (index >= 0)
            {
                Vehiculo veh = listVehiculo[index];

                if (MessageBox.Show("¿Desea eliminar el vehiculo con placas: " + veh.NumeroPlacas + "?", "Eliminar vehiculo", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    int reporteAsignado = Reporte_VehiculoDAO.getIdReporte(veh.IdVehiculo);
                    if (reporteAsignado == 0)
                    {
                        VehiculoDAO.eliminarVehiculo(veh.IdVehiculo, false);
                        cargarTablaVehiculos();
                    }
                    else
                    {
                        MessageBox.Show("No se puede borrar el vehiculo porque está asignado a un reporte");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un vehiculo");
            }

        }

        private void btn_EditarVehiculo_Click(object sender, RoutedEventArgs e)
        {
            int index = dg_Vehiculos.SelectedIndex;
            if (index >= 0)
            {
                Vehiculo vehiculo = listVehiculo[index];
                Boolean resultado = false;
                AgregarVehiculo av = new AgregarVehiculo(this,false,vehiculo);
                av.ShowDialog();
                resultado = av.Resultado;
                if (resultado)
                {
                    this.cargarTablaVehiculos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un vehiculo");
            }
        }

        private void btn_EliminarReporte_Click(object sender, RoutedEventArgs e)
        {
            int index = dg_Reportes.SelectedIndex;
            if (index>=0)
            {
                Reporte rep = listReporte[index];
                if (MessageBox.Show("¿Desea eliminar el reporte con numero: " + rep.IdReporte + "?", "Eliminar reporte", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ImagenDAO.eliminarImagenes(rep.IdReporte);
                    Reporte_VehiculoDAO.eliminarVehiculosReporte(rep.IdReporte);
                    ReporteDAO.eliminarReporte(rep.IdReporte);
                    MessageBox.Show("Reporte eliminado completamente");
                }
                cargarReportes();
            }
            else
            {
                MessageBox.Show("Seleccione un Reporte");
            }
        }

        private void tb_Reportes_GotFocus(object sender, RoutedEventArgs e)
        {
            cargarReportes();
        }
    }
}
