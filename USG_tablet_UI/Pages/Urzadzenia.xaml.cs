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
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Net;
using System.Net.Sockets;

namespace USG_tablet_UI.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Urzadzenia.xaml
    /// </summary>
    public partial class Urzadzenia : Page
    {

        public Urzadzenia()
        {
            InitializeComponent();
            GlobalSettings.currentPage = "Urzadzenia";
            GlobalSettings.vh = new VideoHandler(imgVideo);
            GlobalSettings.vh.connect(GlobalSettings.uScanIP);          
            GlobalSettings.conn = new TCPconnection(GlobalSettings.uScanIP, 13000);
            if (GlobalSettings.gainRefreshTimer == null)
            {            
                GlobalSettings.gainRefreshTimer = new DispatcherTimer();
                GlobalSettings.gainRefreshTimer.Tick += new EventHandler(refreshGain);
                GlobalSettings.gainRefreshTimer.Interval = new TimeSpan(0, 0, 0, 2);

            }
            GlobalSettings.gainRefreshTimer.Start(); 
        }

        private void btnWstecz_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.gainRefreshTimer.Stop();
            GlobalSettings.vh.disconnect();
            if (GlobalSettings.conn != null) GlobalSettings.conn.disconnect();
            GlobalSettings.conn = null;
            GlobalSettings.vh = null;
            GlobalSettings.gainRequestCompleted = true;
            GlobalSettings.videoServiceDisconnectFlag = true;
            this.NavigationService.Navigate(new Uri("Pages\\StartPage.xaml", UriKind.Relative));
        }

        private void btnFreeze_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("frze");
        }

        private void btnGainUp_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("gaup");
        }

        private void btnGainDown_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("gadn");
        }

        private void btn8bit_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("8bgr");
        }

        private void refreshGain(object sender, EventArgs e)
        {
            if (GlobalSettings.gainRequestCompleted == true)
            {
                GlobalSettings.gainRequestCompleted = false;
                GlobalSettings.conn.send("ggai");
                new Thread(() =>
                {
                    try
                    {
                        Thread.CurrentThread.IsBackground = true;
                        TCPlistener tl = new TCPlistener(12000);
                        string content = tl.getData();
                        this.lblGain.Dispatcher.Invoke((Action)delegate { lblGain.Content = content; });
                        GlobalSettings.gainRequestCompleted = true;
                    }
                    catch (Exception ex) { GlobalSettings.gainRequestCompleted = true; };
                }).Start();
            }
        }
    }
}
