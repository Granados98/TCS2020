using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Server
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private byte[] buffer = new byte[1024];
        private List<SocketServer> listClientes { get; set; }
        private List<string> usuariosConectados = new List<string>();
        private List<string> listaDirecciones = new List<string>();

        private Socket socketServidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private UsuarioConectado uc = new UsuarioConectado();
        string usuario = "";
        public MainWindow()
        {
            InitializeComponent();
            listClientes = new List<SocketServer>();
            correrServidor();
        }

        public void correrServidor()
        {
            lb_Servidor.Content = "Servidor Encendido";
            socketServidor.Bind(new IPEndPoint(IPAddress.Any, 1234));
            socketServidor.Listen(1);

            socketServidor.BeginAccept(new AsyncCallback(AceptarCallBack), null);
        }
        private void AceptarCallBack(IAsyncResult async)
        {
            Socket socket = socketServidor.EndAccept(async);

            listClientes.Add(new SocketServer(socket));

            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            socketServidor.BeginAccept(new AsyncCallback(AceptarCallBack), null);
        }

        private void ReceiveCallback(IAsyncResult async)
        {

            Socket socket = (Socket)async.AsyncState;

            if (socket.Connected)
            {
                int recibido;
                try
                {
                    recibido = socket.EndReceive(async);
                }
                catch (Exception)
                {

                    for (int i = 0; i < listClientes.Count; i++)
                    {
                        if (listClientes[i].server.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                        {
                            listClientes.RemoveAt(i);

                            uc.usuarioConectado.RemoveAt(i);

                            string listaActualizado = JsonConvert.SerializeObject(uc).ToString();
                            enviarListaUsuario(listaActualizado);
                        }
                    }
                    return;
                }

                if (recibido != 0)
                {
                    byte[] dataBuffer = new byte[recibido];
                    Array.Copy(buffer, dataBuffer, recibido);
                    string texto = Encoding.Default.GetString(dataBuffer);

                    string respuesta = string.Empty;

                    for (int i = 0; i < listClientes.Count; i++)
                    {
                        if (socket.RemoteEndPoint.ToString().Equals(listClientes[i].server.RemoteEndPoint.ToString()))
                        {
                            usuario = listClientes[i].server.RemoteEndPoint.ToString();
                            listClientes[i].nombreCliente = listClientes[i].server.RemoteEndPoint.ToString();
                        }
                    }



                    MensajeEnvio mensajeEnvio = Newtonsoft.Json.JsonConvert.DeserializeObject<MensajeEnvio>(texto);


                    if (!mensajeEnvio.isMensaje && !mensajeEnvio.isReporte)
                    {
                        usuariosConectados.Add(mensajeEnvio.usuarioEmisor);
                        listaDirecciones.Add(usuario);

                        uc = new UsuarioConectado(usuariosConectados);

                        respuesta = Newtonsoft.Json.JsonConvert.SerializeObject(uc).ToString();

                        enviarListaUsuario(respuesta);
                    }

                    if (mensajeEnvio.isMensaje)
                    {
                        enviarATodos(texto, usuario);
                    }



                }
                else
                {
                    for (int i = 0; i < listClientes.Count; i++)
                    {
                        if (listClientes[i].server.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                        {
                            listClientes.RemoveAt(i);

                            uc.usuarioConectado.RemoveAt(i);

                            string ccActualizado = Newtonsoft.Json.JsonConvert.SerializeObject(uc).ToString();
                            enviarListaUsuario(ccActualizado);
                        }
                    }
                }
            }
            try
            {
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void enviarListaUsuario(string listaSerializada)
        {

            for (int i = 0; i < listClientes.Count; i++)
            {
                enviarMensaje(listClientes[i].server, listaSerializada);
            }

        }


        public void enviarATodos(string mensaje, string cliente)
        {

            for (int i = 0; i < listClientes.Count; i++)
            {
                if (cliente != listClientes[i].nombreCliente)
                    enviarMensaje(listClientes[i].server, mensaje);

            }

        }
        void enviarMensaje(Socket socket, string mensaje)
        {
            try
            {
                byte[] data = Encoding.Default.GetBytes(mensaje);
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                socketServidor.BeginAccept(new AsyncCallback(AceptarCallBack), null);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void SendCallback(IAsyncResult asyncResult)
        {
            Socket socket = (Socket)asyncResult.AsyncState;
            socket.EndSend(asyncResult);
        }
    }
}
