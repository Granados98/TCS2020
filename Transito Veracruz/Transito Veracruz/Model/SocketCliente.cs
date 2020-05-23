using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model
{
    class SocketCliente
    {
        public void ConectarAlServidor(String mensaje)
        {
            Socket socketCliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint direccionConexion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

            try
            {

                socketCliente.Connect(direccionConexion);
                Console.WriteLine("Conectado con exito al servidor...");

                do
                {
                    Console.WriteLine("Ingresa la informacion para envio del servidor:");
                    mensaje = Console.ReadLine();
                    Console.WriteLine("");
                    byte[] msjEnviar = Encoding.Default.GetBytes(mensaje);
                    socketCliente.Send(msjEnviar, 0, msjEnviar.Length, 0);

                } while (!mensaje.ToLower().Equals("salir"));

                socketCliente.Close();
                Console.WriteLine("Conexion cerrada con el servidor, presiona una tecla para terminar...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error de conexion con el servidor..." + e.Message);
            }
        }
    
    }
}
