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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace USG_tablet_UI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigationFrame.Navigate(new StartPage());
            GlobalSettings.beaconWindow = new BeaconWindow();
            GlobalSettings.mainWindow = this;
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += new System.EventHandler(orientationChanged);
        }

        private void orientationChanged(object sender, EventArgs e)
        {
            if (GlobalSettings.currentPage == "StartPage")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\Landscape\\StartPageLandscape.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "StartPageLandscape")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\StartPage.xaml", UriKind.Relative));
            }
        }

    }
}
