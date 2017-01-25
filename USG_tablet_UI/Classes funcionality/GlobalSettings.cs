using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USG_tablet_UI
{
    static class GlobalSettings
    {

        public static List<string> rodzajeBadan = new List<String>() { "USG", "Tomografia", "RTG" };
        public static Pacjent lastPacjentSelected = null;
        public static Badanie lastBadanieSelected = null;
        public static string beaconDistance = null;

    }
}
