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
    /// Logika interakcji dla klasy Kalendarz.xaml
    /// </summary>
    public partial class KalendarzLandscape : Page
    {
        public KalendarzLandscape()
        {
            InitializeComponent();
            GlobalSettings.currentPage = "KalendarzLandscape";
        }

        private void btnWstecz_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages\\Landscape\\StartPageLandscape.xaml", UriKind.Relative));
        }
    }
}
