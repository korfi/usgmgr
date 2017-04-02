using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.IO;
using System.Threading;

namespace USG_tablet_UI
{
    class VideoHandler
    {
        System.Windows.Controls.Image image;
        Thread backgroundThread;
        IPEndPoint ipep;
        EndPoint ep = null;

        public VideoHandler(System.Windows.Controls.Image im)
        {
            this.image = im;
        }

        public void connect(String ipAddr)
        {
            ipep = new IPEndPoint(IPAddress.Any, 9050);
            IPEndPoint remote = new IPEndPoint(IPAddress.Any, 9050);
            ep = (EndPoint) remote;
            if (GlobalSettings.udpSock == null) GlobalSettings.udpSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            GlobalSettings.udpSock.Bind(ipep);

            backgroundThread = new Thread(delegate()
            {
                connect(GlobalSettings.udpSock);
            });
            backgroundThread.IsBackground = true;
            backgroundThread.Start();
        }

        public void disconnect()
        {
            GlobalSettings.videoServiceDisconnectFlag = true;
        }

        private void connect(Socket s)
        {
            byte[] data = new byte[20480];

            while (GlobalSettings.videoServiceDisconnectFlag == false)
            {
                data = new byte[20480];
                GlobalSettings.udpSock.ReceiveFrom(data, ref ep);

                MemoryStream ms = new MemoryStream(data);
                try
                {

                    Application.Current.Dispatcher.Invoke((Action)(() =>
                    {
                        BitmapImage bmi = new BitmapImage();
                        bmi.BeginInit();
                        bmi.StreamSource = ms;
                        bmi.EndInit();
                        this.image.Source = bmi;
                    }));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("something broke: " + e.ToString());
                }

            }

            try
            {
                //s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something broke: " + e.ToString());
            }


        }


        private static byte[] ReceiveVarData(Socket s)
        {
            int total = 0;
            int recv;
            byte[] datasize = new byte[4];

            recv = s.Receive(datasize, 0, 4, 0);
            int size = BitConverter.ToInt32(datasize, 0);
            int dataleft = size;
            byte[] data = new byte[size];


            while (total < size)
            {
                recv = s.Receive(data, total, dataleft, 0);
                if (recv == 0)
                {
                    break;
                }
                total += recv;
                dataleft -= recv;
            }
            return data;
        }

    }
}
