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

namespace USG_tablet_UI
{
    /// <summary>
    /// Logika interakcji dla klasy DeviceFoundPage.xaml
    /// </summary>
    public partial class DeviceFoundPage : Page
    {
        public DeviceFoundPage()
        {
            InitializeComponent();
            lblWykrytoUrzadzenie.HorizontalContentAlignment = HorizontalAlignment.Center;
        }

        private void btnUScan_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.mainWidnow.NavigationFrame.NavigationService.Navigate(new Uri("Pages\\Urzadzenia.xaml", UriKind.Relative));
            GlobalSettings.beaconWindow.Close();
        }
    }
}
