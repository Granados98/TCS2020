using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Servidor
{
    class Program
    {

        static void Main(string[] args)
        {
            
            SocketServidor servidor = new SocketServidor();
            servidor.Conectar();
            
        }
    }
}
