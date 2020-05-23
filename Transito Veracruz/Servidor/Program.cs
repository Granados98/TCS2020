using System;

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
