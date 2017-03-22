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
    /// Logika interakcji dla klasy ZaplanujBadanie.xaml
    /// </summary>
    public partial class ZaplanujBadanieLandscape : Page
    {

        List<String> sourceList = new List<String>();
        DatabaseHandler dbh = new DatabaseHandler();

        public ZaplanujBadanieLandscape()
        {
            InitializeComponent();
            GlobalSettings.currentPage = "ZaplanujBadanieLandscape";
            lblUsername.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblGodzina.HorizontalContentAlignment = HorizontalAlignment.Center;
            txtGodzina.HorizontalContentAlignment = HorizontalAlignment.Center;
            sourceList = dbh.getListaTypowBadanFromDB();
            cboRodzajBadania.ItemsSource = sourceList;
            calendar.SelectedDate = DateTime.Now;
        }

        private void cboRodzajBadania_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            calendar.Visibility = System.Windows.Visibility.Visible;
            txtGodzina.Visibility = System.Windows.Visibility.Visible;
            lblGodzina.Visibility = System.Windows.Visibility.Visible;
            btnZaplanuj.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnWstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\Landscape\\DanePacjenta.xaml", UriKind.Relative));
        }

        private void btnZaplanuj_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = calendar.SelectedDate.GetValueOrDefault();
            string dateToInsert = dt.ToString("yyyy-MM-dd") + " " + txtGodzina.Text + ":00";

            txtGodzina.Text = dateToInsert;

            dbh.insertBadanieIntoDB(GlobalSettings.lastPacjentSelected, cboRodzajBadania.SelectedItem.ToString(), dateToInsert);
            this.NavigationService.Navigate(new Uri("Pages\\Landscape\\DanePacjenta.xaml", UriKind.Relative));
        }

        private void calendar_GotFocus(object sender, RoutedEventArgs e)
        {
            txtGodzina.Focus();
            Mouse.Capture(null);
       } 

    }
}
