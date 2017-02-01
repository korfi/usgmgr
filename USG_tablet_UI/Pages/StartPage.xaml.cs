using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Logika interakcji dla klasy StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();          
        }

        private void btnDanePacjentow_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\ListaPacjentow.xaml", UriKind.Relative));
        }

        private void btnKalendarz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\Kalendarz.xaml", UriKind.Relative));
        }

        private void btnUrzadzenia_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\Urzadzenia.xaml", UriKind.Relative));
        }

        private void placeholderTrybik_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\PanelUzytkownika.xaml", UriKind.Relative));
        }

        private void lblUsername_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\PanelUzytkownika.xaml", UriKind.Relative));
        }

        private void btnTestBeaconEnable_Click(object sender, RoutedEventArgs e)
        {
            BeaconHandler bh = new BeaconHandler();
        }
    }
}
