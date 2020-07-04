﻿using System;
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
        private ArrayList usuariosConectados = new ArrayList();
        
        public SocketServidor()
        {
            socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            direccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

            socketServer.Bind(direccion);
            socketServer.Listen(2);
            Console.WriteLine("Escuchando...");
        }

        public void conexionCLiente(Object s)
        {
            Socket socketClienteRemoto = (Socket)s;
            string mensaje = "";
            string info = "";
            while(true){

                byte[] ByRec = new byte[255];
                int datos = socketClienteRemoto.Receive(ByRec, 0, ByRec.Length, 0);
                Array.Resize(ref ByRec, datos);
                mensaje = Encoding.Default.GetString(ByRec);
                info += mensaje + "\n";
                Console.WriteLine("El cliente dice: " + mensaje);
                Console.Out.Flush();
            }
        }
        public void Conectar()
        {
            Thread hilo;
            while (true)
            {
                Console.WriteLine("Esperando Conexiones...");
                socketClienteRemoto = socketServer.Accept();
                hilo = new Thread(conexionCLiente);
                hilo.Start(socketClienteRemoto);
                Console.WriteLine("Se conecto...");
            }
            //IPEndPoint newclient = (IPEndPoint)socketClienteRemoto.RemoteEndPoint;
            //Console.WriteLine("Cliente conectado con IP {0} en puerto {1}", newclient.Address, newclient.Port);

            /*
            //lee el idUsuario
            string idUsuarioCadena = "";

            byte[] idUsuarioConectado = new byte[255];
            int datosUsuario = socketClienteRemoto.Receive(idUsuarioConectado, 0, idUsuarioConectado.Length, 0);
            Array.Resize(ref idUsuarioConectado, datosUsuario);
            idUsuarioCadena = Encoding.Default.GetString(idUsuarioConectado);


            foreach (string id in usuariosConectados)
            {
                if (id == idUsuarioCadena)
                {
                    Console.WriteLine("Usuario ya agregado...");
                }
            }
            usuariosConectados.Add(idUsuarioCadena); 
            */
            //lee el mensaje del usuario en el servidor

            //cketServer.Close();
            //Console.WriteLine("Socket servidor desconectado, pulsa una tecla para terminar...");
        }

    }

}
