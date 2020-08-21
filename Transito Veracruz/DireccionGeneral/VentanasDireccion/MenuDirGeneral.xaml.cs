using System;
using System.Collections.Generic;
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
using DireccionGeneral.Clases;
using DireccionGeneral.Model.daoDireccion;
using DireccionGeneral.Model.dbDireccion;
using DireccionGeneral.Model.InterfaceDireccion;
using DireccionGeneral.Model.pocosDireccion;
using Newtonsoft.Json;

namespace DireccionGeneral.VentanasDireccion
{
    /// <summary>
    /// Lógica de interacción para MenuDirGeneral.xaml
    /// </summary>
    public partial class MenuDirGeneral : Window, InterfaceMenu
    {

        private Socket socketCliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //IPEndPoint direccionConexion = new IPEndPoint(IPAddress.Any, 1234);


        private string mensaje = "";
        private string usuarioEmisor = "";
        //private String mensajeRecibido = "";

        private List<string> listaConectados = new List<string>();

        byte[] receivedBuf = new byte[1024];
        Mensaje envioMensaje = new Mensaje();

        Personal personal { get; set; }

        private List<Personal> listPersonal = new List<Personal>();
        private List<Delegacion> listDelegacion = new List<Delegacion>();
        private List<Reporte> listReporte = new List<Reporte>();

        private List<string> listDelegacionesPerm = new List<string>();


        private Personal usuarioIniciado { get; set; }
        public MenuDirGeneral(Personal personal)        {
            this.personal = personal;
            InitializeComponent();

            this.usuarioIniciado = personal;
            usuarioEmisor = personal.Usuario;

            nombre_Usuario.Content = usuarioIniciado.Usuario;
            CargaDelegaciones();
            CargarUsuarios();
            CargaReportes();
            cargaComboBoxDelegaciones();
            conectarServidor();
            cargarCBDelegaciones();
        }


        private void conectarServidor()
        {
            repetirConexion();
            socketCliente.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(recibeDatos), socketCliente);

            byte[] buffer = Encoding.Default.GetBytes(serializarMensaje("", false, false));
            socketCliente.Send(buffer);
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
                this.Dispatcher.Invoke(() => { recibirMensaje(envioMensaje.contenidoMensaje, envioMensaje.usuarioEmisor); });
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

        public void recibirMensaje(string mensajeRecibido, string usuarioEmisor)
        {
            string mensajeFinal = Convert.ToString(mensajeRecibido);
            block_Chat.Items.Add(usuarioEmisor + ": " + mensajeFinal);
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
        private void cargaComboBoxDelegaciones()
        {
            List<string> delegaciones = new List<string>();
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                if (conexion != null)
                {
                    String query = String.Format("SELECT idReporte,nombreDelegacion FROM Reporte");
                    command = new SqlCommand(query, conexion);
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read() == true)
                    {
                        
                        foreach (var del in delegaciones)
                        {
                            if (del!=dr[1].ToString())
                            {
                                delegaciones.Add(dr[1].ToString());
                            }
                        }
                    }

                    foreach (var del in delegaciones)
                    {
                        Console.WriteLine(del);
                        cb_Delegacion.Items.Add(del);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("No se encontro el Conductor");
            }
        }

        private void CargaReportes()
        {
            listReporte = ReporteDAO.getReportes();
            dgReportes.ItemsSource = listReporte;
        }
        private void CargarUsuarios()
        {
            listPersonal = PersonalDAO.getPersonal();
            dgPersonal.ItemsSource = listPersonal;
        }

        private void CargaDelegaciones()
        {
            listDelegacion = DelegacionDAO.getDelegaciones();
            dgDelegaciones.ItemsSource = listDelegacion;
        }

        private void btn_AgregarDelegacion_Click(object sender, RoutedEventArgs e)
        {
            Delegacion delegacion = new Delegacion();
            AgregarDelegacion ad = new AgregarDelegacion(this, true, delegacion);
            ad.Show();
        }

        private void btn_AgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Personal personal = new Personal();
            RegistroUsuario nuevoUsuario = new RegistroUsuario(this,true,personal);
            nuevoUsuario.Show();
        }

        private void btn_AgregarDictamen_Click(object sender, RoutedEventArgs e)
        {
            int index = dgReportes.SelectedIndex;
            if (index>=0)
            {
                Reporte reporte = listReporte[index];

                int dictamenVer = ReporteDAO.verificaExistenciaDictamen(reporte.IdReporte);
                if (dictamenVer==0)
                {
                    DictaminarReporte nuevoDictamen = new DictaminarReporte(this, reporte, personal);
                    nuevoDictamen.ShowDialog();
                    bool resultado = nuevoDictamen.Resultado;
                    if (resultado)
                    {
                        CargaReportes();
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe un dictamen");
                }
            }
        }

        private void btn_VerDetalle_Click(object sender, RoutedEventArgs e)
        {
            int index = dgReportes.SelectedIndex;
            if (index>=0)
            {
                Reporte reporte = listReporte[index];
                VisualizarReporte verReporte = new VisualizarReporte(reporte);
                verReporte.Show();
            }
            else
            {
                MessageBox.Show("Seleccione un reporte");
            }
        }

        

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.usuarioIniciado.Estado = "Desconectado";
            PersonalDAO.actualizarEstadoUsuario(usuarioIniciado);

            LoginDirGeneral iniciarSesion = new LoginDirGeneral();
            iniciarSesion.Show();

            this.Close();
        }
        private void btn_EditarDelegacion_Click(object sender, RoutedEventArgs e)
        {
            int index = dgDelegaciones.SelectedIndex;
            if (index >= 0)
            {
                Delegacion delegacion = listDelegacion[index];
                Boolean resultado = false;
                AgregarDelegacion ad = new AgregarDelegacion(this, false, delegacion);
                ad.ShowDialog();
                resultado = ad.Resultado;
                if (resultado)
                {
                    this.CargaDelegaciones();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una delegacion");
            }

        }

        private void btn_EliminarDelegacion_Click(object sender, RoutedEventArgs e)
        {
            int index = dgDelegaciones.SelectedIndex;
            if (index>=0)
            {
                Delegacion delegacion = listDelegacion[index];
                if (MessageBox.Show("¿Desea eliminar el reporte con numero: " + delegacion.IdDelegacion + "?", "Eliminar reporte", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    DelegacionDAO.eliminarDelegacion(delegacion.IdDelegacion);
                    CargaDelegaciones();
                }


                }
            else
            {
                MessageBox.Show("Seleccione una delegacion");
            }
        }



        public void actualizar(int idPersonal, string tipoPersonal, string apellidos, string nombre, string cargo, string usuario, string contrasena, string nombreDelegacion)
        {
            CargarUsuarios();
        }

        public void actualizar(int idDelegacion, string nombre, string colonia, string codigoPostal, string municipio, string telefono, string correo, string calle, string numeroDireccion)
        {
            CargaDelegaciones();
        }

        private void btn_EditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            int index = dgPersonal.SelectedIndex;
            if (index >= 0)
            {
                Personal personal = listPersonal[index];
                Boolean resultado = false;
                RegistroUsuario ru = new RegistroUsuario(this, false, personal);
                ru.ShowDialog();
                resultado = ru.Resultado;
                if (resultado)
                {
                    this.CargarUsuarios();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una delegacion");
            }

        }

        private void btn_EliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            int index = dgPersonal.SelectedIndex;
            if (index >= 0)
            {
                Personal personal = listPersonal[index];
                if (MessageBox.Show("¿Desea eliminar el usuario: " + personal.Usuario + "?", "Eliminar reporte", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    PersonalDAO.eliminarPersonal(personal.IdPersonal);
                    CargarUsuarios();
                }


            }
            else
            {
                MessageBox.Show("Seleccione una delegacion");
            }
        }

        public void actualizar(int idReporte, string estatus, string nombreDelegacion, string direccion, string fechaCreacion, int idDictamen)
        {
            CargaReportes();
        }

        private void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            block_Chat.Items.Add("Tú: " + txt_Mensaje.Text);
            enviarMensaje();
        }

        private void btn_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            CargaReportes();
        }


        private void btn_Buscar_Click(object sender, RoutedEventArgs e)
        {
            List<Reporte> listReporteBusqueda = new List<Reporte>();
            string estatus = cb_Estatus.Text;
            string delegacion = cb_Delegacion.Text;
            if (cb_Estatus.SelectedItem!=null)
            {
                listReporteBusqueda = ReporteDAO.getReportesEstatus(estatus);
                dgReportes.ItemsSource = listReporteBusqueda;
            }
            if (cb_Delegacion.SelectedItem!=null)
            {
                listReporteBusqueda = ReporteDAO.getReportesDelegacion(delegacion);
                dgReportes.ItemsSource = listReporteBusqueda;
            }
            if (cb_Delegacion.SelectedItem!=null && cb_Estatus.SelectedItem != null)
            {
                listReporteBusqueda = ReporteDAO.getReportesAvanzada(delegacion,estatus);
                dgReportes.ItemsSource = listReporteBusqueda;
            }

            cb_Delegacion.Text="";
            cb_Estatus.Text = "";
        }

        private void cargarCBDelegaciones()
        {
            SqlConnection conexion = null;

            try
            {
                conexion = ConnectionUtils.getConnection();
                SqlCommand command;
                if (conexion != null)
                {
                    String query = String.Format("SELECT idDelegacion,nombre FROM Delegacion");
                    command = new SqlCommand(query, conexion);
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read() == true)
                    {
                        cb_Delegacion.Items.Add(dr[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
