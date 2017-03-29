using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace USG_tablet_UI
{
    class TCPconnection
    {

        private String IPaddr;
        private int port;
        Socket s = null;

        public TCPconnection(String IP, int po)
        {
            this.IPaddr = IP;
            this.port = po;
            connect();
        }

        private void connect()
        {
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipAdd = System.Net.IPAddress.Parse(this.IPaddr);
            IPEndPoint remoteEP = new IPEndPoint(ipAdd, this.port);

            s.Connect(remoteEP);
        }

        public void disconnect()
        {
            s.Disconnect(true);
            s.Close();
        }

        public void send(String msg)
        {
            try                    // bo nie mozna uzyskac dostepu do usunietego obiektu po powrocie do glownego ekranu
            {           
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(msg);
                s.Send(byData);
            }
            catch (Exception ex) { }
        }


    }
}   
