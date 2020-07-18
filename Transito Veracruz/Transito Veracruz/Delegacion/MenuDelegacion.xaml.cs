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
        private List<Vehiculo> listVehiculo { get; set; }

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
            byte[] msjEnviar = Encoding.Default.GetBytes(txt_Mensaje.Text);
            socketCliente.Send(msjEnviar, 0, msjEnviar.Length, 0);

            block_Chat.Items.Add("Tu: "+txt_Mensaje.Text);
            
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

        private void recibeMensajes()
        {
            byte[] recibeBytes = new byte[255];
            int datos = socketCliente.Receive(recibeBytes, 0, recibeBytes.Length, 0);
            Array.Resize(ref recibeBytes, datos);
            mensajeRecibido = Encoding.Default.GetString(recibeBytes);

            block_Chat.Items.Add(mensajeRecibido);
            block_Chat.UpdateLayout();
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
                }
            }
        }
        
        public void actualizar(int idReporte, int numeroReporte, string estatus, string nombreDelegacion, string direccion)
        {
            cargarReportes();
        }

        public void actualizar(int idConductor, string numeroLicencia, string apellidos, string nombre, DateTime fechaNacimiento, string telefono)
        {
            cargarTablaConductores();
        }
        public void actualizar(int idVehiculo, string numeroPLacas, string marca, string modelo, string anio, string color, string nombreAseguradora, string numeroPoliza)
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
                    if (Reporte_VehiculoDAO.idReporte(idVehiculo)==0) {
                        if (idVehiculo > 0)
                        {
                            VehiculoDAO.eliminarVehiculo(conductor.IdConductor);
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
    }
}
