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
    /// Logika interakcji dla klasy ListaPacjentow.xaml
    /// </summary>
    public partial class ListaPacjentow : Page
    {

        List<Pacjent> currList = new List<Pacjent>();
        List<Pacjent> originalList = new List<Pacjent>();

        public ListaPacjentow()
        {
            InitializeComponent();
            GlobalSettings.currentPage = "ListaPacjentow";
            DatabaseHandler dbh = new DatabaseHandler();
            originalList = dbh.getListaPacjentowFromDB();
            currList = originalList;
            refreshList();
        }

        private void btnWstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\StartPage.xaml", UriKind.Relative));
        }

        private void lstPacjenci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GlobalSettings.lastPacjentSelected = (Pacjent)lstPacjenci.SelectedItem;
            this.NavigationService.Navigate(new Uri("Pages\\DanePacjenta.xaml", UriKind.Relative));
        }

        private void txtSearchPacjenci_TextChanged(object sender, TextChangedEventArgs e)
        {
            currList = originalList.FindAll(p => p.ToString().ToLower().Contains(txtSearchPacjenci.Text.ToLower()));
            refreshList();
        }

        private void refreshList()
        {
            lstPacjenci.Items.Clear();
            foreach (Pacjent p in currList)
            {
                lstPacjenci.Items.Add(p);
            }
        }


    }
}
