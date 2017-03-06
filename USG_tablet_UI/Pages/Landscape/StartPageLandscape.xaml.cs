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

namespace USG_tablet_UI.Pages.Landscape
{
    /// <summary>
    /// Logika interakcji dla klasy StartPageLandscape.xaml
    /// </summary>
    public partial class StartPageLandscape : Page
    {
        public StartPageLandscape()
        {
            InitializeComponent();
            GlobalSettings.currentPage = "StartPageLandscape";
        }
    }
}
