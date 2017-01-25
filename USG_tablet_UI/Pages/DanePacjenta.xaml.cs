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
    public partial class DanePacjenta : Page
    {
        public DanePacjenta()
        {
            InitializeComponent();
            lblImieNazwisko.Content = GlobalSettings.lastPacjentSelected;
            lblImieNazwisko.HorizontalContentAlignment = HorizontalAlignment.Center;
        }

        private void btnWstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\ListaPacjentow.xaml", UriKind.Relative));
        }

        private void btnZaplanujBadanie_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\ZaplanujBadanie.xaml", UriKind.Relative));
        }

        private void btnHistoriaBadan_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\HistoriaBadan.xaml", UriKind.Relative));
        }

    }
}
