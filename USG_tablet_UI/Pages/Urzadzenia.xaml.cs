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

namespace USG_tablet_UI.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Urzadzenia.xaml
    /// </summary>
    public partial class Urzadzenia : Page
    {

        VideoHandler vh = null;
        TCPconnection conn = null;

        public Urzadzenia()
        {
            InitializeComponent();
            GlobalSettings.currentPage = "Urzadzenia";
            vh = new VideoHandler(imgVideo);
        }

        private void btnWstecz_Click(object sender, RoutedEventArgs e)
        {
            vh.disconnect();
            if (conn!=null) conn.disconnect();
            this.NavigationService.Navigate(new Uri("Pages\\StartPage.xaml", UriKind.Relative));
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            vh.connect(txtIP.Text);
            conn = new TCPconnection(txtIP.Text, 13000);
        }

        private void btnFreeze_Click(object sender, RoutedEventArgs e)
        {
            conn.send("freeze");
        }

        private void btnGainUp_Click(object sender, RoutedEventArgs e)
        {
            conn.send("gainup");
        }

        private void btnGainDown_Click(object sender, RoutedEventArgs e)
        {
            conn.send("gaindown");
        }

        private void btn8bit_Click(object sender, RoutedEventArgs e)
        {
            conn.send("8bitgreyscale");
        }

        private void btnRefreshGain_Click(object sender, RoutedEventArgs e)
        {
            conn.send("getgain");
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                TCPlistener tl = new TCPlistener(12000);
                string content = tl.getData();
                this.lblGain.Dispatcher.Invoke((Action)delegate { lblGain.Content = content; });
            }).Start(); 
        }
    }
}
