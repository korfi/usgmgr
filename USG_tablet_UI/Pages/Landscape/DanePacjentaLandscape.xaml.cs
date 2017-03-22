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

namespace USG_tablet_UI.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy DanePacjenta.xaml
    /// </summary>
    public partial class DanePacjentaLandscape : Page
    {
        public DanePacjentaLandscape()
        {
            InitializeComponent();
            lblImieNazwisko.Content = GlobalSettings.lastPacjentSelected;
            lblImieNazwisko.HorizontalContentAlignment = HorizontalAlignment.Center;
            GlobalSettings.currentPage = "DanePacjentaLandscape";
        }

        private void btnWstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\Landscape\\ListaPacjentowLandscape.xaml", UriKind.Relative));
        }

        private void btnZaplanujBadanie_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\Landscape\\ZaplanujBadanieLandscape.xaml", UriKind.Relative));
        }

        private void btnHistoriaBadan_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\Landscape\\HistoriaBadanLandscape.xaml", UriKind.Relative));
        }

    }
}
