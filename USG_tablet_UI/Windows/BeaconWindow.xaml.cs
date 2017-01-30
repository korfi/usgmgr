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
using System.Windows.Shapes;

namespace USG_tablet_UI
{
    /// <summary>
    /// Logika interakcji dla klasy BeaconWindow.xaml
    /// </summary>
    public partial class BeaconWindow : Window
    {
        public BeaconWindow()
        {
            InitializeComponent();
            NavigationFrame.Navigate(new DeviceFoundPage());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            GlobalSettings.beaconWindow = new BeaconWindow();
        }
    }
}
