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
    /// Logika interakcji dla klasy HistoriaBadan.xaml
    /// </summary>
    public partial class HistoriaBadan : Page
    {

        List<Badanie> currList = new List<Badanie>();
        List<Badanie> originalList = new List<Badanie>();

        public HistoriaBadan()
        {
            InitializeComponent();
            DatabaseHandler dbh = new DatabaseHandler();
            originalList = dbh.getListaBadanFromDB();
            currList = originalList;
            foreach (Badanie b in currList)
            {
                lstBadania.Items.Add(b);
            }
        }

        private void btnWstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\DanePacjenta.xaml", UriKind.Relative));
        }

        private void lstBadania_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GlobalSettings.lastBadanieSelected = (Badanie)lstBadania.SelectedItem;
            this.NavigationService.Navigate(new Uri("Pages\\DaneBadania.xaml", UriKind.Relative));
        }

        private void txtSearchBadania_TextChanged(object sender, TextChangedEventArgs e)
        {
            currList = originalList.FindAll(b => b.ToString().ToLower().Contains(txtSearchBadania.Text.ToLower()));
            refreshList();
        }

        private void refreshList()
        {
            lstBadania.Items.Clear();
            foreach (Badanie b in currList)
            {
                lstBadania.Items.Add(b);
            }
        }
    }
}
