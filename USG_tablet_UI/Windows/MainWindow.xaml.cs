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
            else if (GlobalSettings.currentPage == "DaneBadania")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\Landscape\\DaneBadaniaLandscape.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "DaneBadaniaLandscape")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\DaneBadania.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "DanePacjenta")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\Landscape\\DanePacjentaLandscape.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "DanePacjentaLandscape")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\DanePacjenta.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "HistoriaBadan")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\Landscape\\HistoriaBadanLandscape.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "HistoriaBadanLandscape")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\HistoriaBadan.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "Kalendarz")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\Landscape\\KalendarzLandscape.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "KalendarzLandscape")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\Kalendarz.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "ListaPacjentow")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\Landscape\\ListaPacjentowLandscape.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "ListaPacjentowLandscape")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\ListaPacjentow.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "PanelUzytkownika")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\Landscape\\PanelUzytkownikaLandscape.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "PanelUzytkownikaLandscape")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\PanelUzytkownika.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "Urzadzenia")
            {
                GlobalSettings.gainRefreshTimer.Stop();
                GlobalSettings.vh.disconnect();
                if (GlobalSettings.conn != null) GlobalSettings.conn.disconnect();
                GlobalSettings.conn = null;
                GlobalSettings.vh = null;
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\Landscape\\UrzadzeniaLandscape.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "UrzadzeniaLandscape")
            {
                GlobalSettings.gainRefreshTimer.Stop();
                GlobalSettings.vh.disconnect();
                if (GlobalSettings.conn != null) GlobalSettings.conn.disconnect();
                GlobalSettings.conn = null;
                GlobalSettings.vh = null;
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\Urzadzenia.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "ZaplanujBadanie")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\Landscape\\ZaplanujBadanieLandscape.xaml", UriKind.Relative));
            }
            else if (GlobalSettings.currentPage == "ZaplanujBadanieLandscape")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("Pages\\ZaplanujBadanie.xaml", UriKind.Relative));
            }
        }

    }
}
