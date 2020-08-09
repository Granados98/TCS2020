using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
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
