using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace USG_tablet_UI
{
    class TCPlistener
    {
        private int port;
        Byte[] bytes = new Byte[256];
        String data = null;

        public TCPlistener(int p)
        {
            this.port = p;
        }

        public string getData()
        {
            IPAddress[] ipTab = Array.FindAll(
                Dns.GetHostEntry(string.Empty).AddressList,
                a => a.AddressFamily == AddressFamily.InterNetwork);
            IPAddress ipAdd = ipTab[0];
            TcpListener serverSocket = new TcpListener(ipAdd, this.port);
            TcpClient clientSocket = default(TcpClient);
            serverSocket.Start();

            //Console.Write("Waiting for a connection at " + ipAdd.ToString() + "\r\n");
            clientSocket = serverSocket.AcceptTcpClient();
            //Console.WriteLine("Connected!\r\n");

            data = null;
            int i;

            NetworkStream stream = clientSocket.GetStream();

            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
            }

            clientSocket.Close();
            serverSocket.Stop();

            return data;
        }
    }
}
