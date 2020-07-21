using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace Servidor
{
    class SocketServer
    {
        public Socket server { get; set; }
        public string nombreCliente { get; set; }
        public SocketServer(Socket server)
        {
            this.server = server;
        }
    }
}
