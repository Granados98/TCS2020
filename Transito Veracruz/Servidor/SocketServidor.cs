using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace Servidor
{
    class SocketServidor
    {

        /*
        Socket socketServer = null;
        Socket socketClienteRemoto = null;
        IPEndPoint direccion = null;
        IPEndPoint newclient;
        */
        private byte[] buffer = new byte[1024];
        private List<SocketServer> listClientes { get; set; }
        private List<string> usuariosConectados = new List<string>();
        private List<string> listaDirecciones = new List<string>();

        private Socket socketServidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private UsuarioConectado uc = new UsuarioConectado();
        string cliente = "";
        public SocketServidor()
        {

            listClientes = new List<SocketServer>();
            /*
            socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            direccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

            listClientes = new List<SocketServer>();
            socketServer.Bind(direccion);
            socketServer.Listen(2);
            Console.WriteLine("Escuchando...");*/
        }

        public void correrServidor()
        {
            socketServidor.Bind(new IPEndPoint(IPAddress.Any, 1234));
            socketServidor.Listen(1);
            socketServidor.BeginAccept(new AsyncCallback(AceptarCallBack), null);
        }
        private void AceptarCallBack(IAsyncResult ar)
        {
            Socket socket = socketServidor.EndAccept(ar);

            listClientes.Add(new SocketServer(socket));

            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            socketServidor.BeginAccept(new AsyncCallback(AceptarCallBack), null);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {

            Socket socket = (Socket)ar.AsyncState;

            if (socket.Connected)
            {
                int received;
                try
                {
                    received = socket.EndReceive(ar);
                }
                catch (Exception)
                {

                    for (int i = 0; i < listClientes.Count; i++)
                    {
                        if (listClientes[i].server.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                        {
                            listClientes.RemoveAt(i);

                            uc.usuarioConectado.RemoveAt(i);

                            string ccActualizado = JsonConvert.SerializeObject(uc).ToString();
                            enviarListaATodos(ccActualizado);
                        }
                    }
                    return;
                }
                if (received != 0)
                {
                    byte[] dataBuf = new byte[received];
                    Array.Copy(buffer, dataBuf, received);
                    string texto = Encoding.Default.GetString(dataBuf);




                    string respuesta = string.Empty;


                    for (int i = 0; i < listClientes.Count; i++)
                    {
                        if (socket.RemoteEndPoint.ToString().Equals(listClientes[i].server.RemoteEndPoint.ToString()))
                        {
                            cliente = listClientes[i].server.RemoteEndPoint.ToString();
                            listClientes[i].nombreCliente = listClientes[i].server.RemoteEndPoint.ToString();

                        }
                    }



                    string reporteRecibido = texto;
                    MensajeEnvio mensajeChat = Newtonsoft.Json.JsonConvert.DeserializeObject<MensajeEnvio>(texto);


                    if (!mensajeChat.isMensaje && !mensajeChat.isReporte)
                    {
                        usuariosConectados.Add(mensajeChat.usuarioEmisor);
                        listaDirecciones.Add(cliente);


                        uc = new UsuarioConectado (usuariosConectados);

                        respuesta = Newtonsoft.Json.JsonConvert.SerializeObject(uc).ToString();

                        enviarListaATodos(respuesta);
                    }


                    if (mensajeChat.isMensaje)
                    {
                        reenviarATodos(texto, cliente);
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
                            enviarListaATodos(ccActualizado);
                        }
                    }
                }
            }
            try
            {
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            }
            catch (SocketException)
            {

            }
        }

        public void enviarListaATodos(string listaSerializada)
        {

            for (int i = 0; i < listClientes.Count; i++)
            {
                EnviarInfo(listClientes[i].server, listaSerializada);
            }

        }


        public void reenviarATodos(string mensaje, string cliente)
        {

            for (int i = 0; i < listClientes.Count; i++)
            {
                if (cliente != listClientes[i].nombreCliente)
                    EnviarInfo(listClientes[i].server, mensaje);

            }

        }
        void EnviarInfo(Socket socket, string mensaje)
        {
            try
            {
                byte[] data = Encoding.Default.GetBytes(mensaje);
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                socketServidor.BeginAccept(new AsyncCallback(AceptarCallBack), null);
            }
            catch (SocketException)
            {

            }

        }

        private void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }
        /*
        public void enviarInformacion(Socket socket, string mensaje)
        {
            try
            {
                byte[] msjEnviar = Encoding.Default.GetBytes(mensaje);
                socket.Send(msjEnviar, 0, msjEnviar.Length, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void enviarMensajeAClientes(string mensaje, string cliente)
        {
            for (int i = 0; i < listClientes.Count; i++)
            {
                if (cliente != listClientes[i].nombreCliente)
                {
                    enviarInformacion(listClientes[i].server, mensaje);
                }
            }

        }
        public void conexionCLiente(Object s)
        {
            Socket socketClienteRemoto = (Socket)s;
            string mensaje = "";
            string info = "";
            bool band = false;
            string enviarMesaje = "";

            //Recibe el mensaje que el cliente envió
            while (true)
            {
                if (band!=false)
                {
                    byte[] ByRec = new byte[255];
                    int datos = socketClienteRemoto.Receive(ByRec, 0, ByRec.Length, 0);
                    Array.Resize(ref ByRec, datos);
                    mensaje = Encoding.Default.GetString(ByRec);
                    info += mensaje + "\n";
                    enviarMesaje = mensaje;
                    Console.WriteLine($"El cliente : " + mensaje + " " + newclient.Address + " " + newclient.Port);
                    Console.Out.Flush();
                }
                band = true;


                //manda el mensaje a todos los clientes que el servidor recibio.
                for (int i = 0; i < listClientes.Count; i++)
                {
                    if (socketClienteRemoto.RemoteEndPoint.ToString().Equals(listClientes[i].server.RemoteEndPoint.ToString()))
                    {
                        cliente = listClientes[i].server.RemoteEndPoint.ToString();
                        Console.WriteLine("El cliente es: "+ cliente);
                    }
                }

                enviarMensajeAClientes(enviarMesaje, cliente);

            }
        }


            public void Conectar()
            {
                Thread hilo;
                while (true)
                {
                    Console.WriteLine("Esperando Conexiones...");
                    socketClienteRemoto = socketServer.Accept();
                    newclient = (IPEndPoint)socketClienteRemoto.RemoteEndPoint;
                    hilo = new Thread(conexionCLiente);
                    hilo.Start(socketClienteRemoto);
                    //usuariosConectados.Add(newclient.Address);
                    Console.WriteLine("Se conecto al servidor: " + socketClienteRemoto.LocalEndPoint + " El cliente: " + newclient.Address + " Con el puerto: " + newclient.Port);
                    listClientes.Add(new SocketServer(socketClienteRemoto));


                }
            }
            */

    }

} 

