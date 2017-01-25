using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USG_tablet_UI
{
    public class Pacjent
    {

        string imie { get; set; }
        string nazwisko { get; set; }
        public int id { get; set; }

        public Pacjent(int id, string i, string n)
        {
            this.id = id;
            this.imie = i;
            this.nazwisko = n;
        }

        public override string ToString()
        {
            return imie + " " + nazwisko;
        }

    }
}
