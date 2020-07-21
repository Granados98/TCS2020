using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Servidor
{
    class SocketServidor
    {


        Socket socketServer = null;
        Socket socketClienteRemoto = null;
        IPEndPoint direccion = null;
        IPEndPoint newclient;
        private List<SocketServer> listClientes { get; set; }

        string cliente = "";
        public SocketServidor()
        {
            socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            direccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

            listClientes = new List<SocketServer>();
            socketServer.Bind(direccion);
            socketServer.Listen(2);
            Console.WriteLine("Escuchando...");
        }

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

     }

} 

