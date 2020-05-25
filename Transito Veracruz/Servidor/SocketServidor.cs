using System;
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
        public void Conectar()
        {

            Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint direccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            socketServer.Bind(direccion);
            socketServer.Listen(2);

            Console.WriteLine("Escuchando...");

            Socket socketClienteRemoto = socketServer.Accept();

            IPEndPoint newclient = (IPEndPoint)socketClienteRemoto.RemoteEndPoint;
            Console.WriteLine("Cliente conectado con IP {0} en puerto {1}", newclient.Address, newclient.Port);

            string mensaje = "";
            string info = "";

            do
            {

                byte[] ByRec = new byte[255];
                int datos = socketClienteRemoto.Receive(ByRec, 0, ByRec.Length, 0);
                Array.Resize(ref ByRec, datos);
                mensaje = Encoding.Default.GetString(ByRec);
                info += mensaje + "\n";
                Console.WriteLine("El cliente dice: " + mensaje);


            } while (!mensaje.ToLower().Equals("salir"));

            var timestamp = DateTime.Now.ToFileTime();
            File.WriteAllBytes($"cliente-{timestamp}.txt", Encoding.Default.GetBytes(info));

            socketServer.Close();
            Console.WriteLine("Socket servidor desconectado, pulsa una tecla para terminar...");
        }

    }
}
