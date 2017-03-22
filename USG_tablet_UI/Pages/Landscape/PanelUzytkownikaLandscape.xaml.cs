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
    /// Logika interakcji dla klasy PanelUzytkownika.xaml
    /// </summary>
    public partial class PanelUzytkownikaLandscape : Page
    {
        public PanelUzytkownikaLandscape()
        {
            InitializeComponent();
            GlobalSettings.currentPage = "PanelUzytkownikaLandscape";
            lblUsername.HorizontalContentAlignment = HorizontalAlignment.Center;
        }

        private void btnWstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\Landscape\\StartPage.xaml", UriKind.Relative));
        }
    }
}
