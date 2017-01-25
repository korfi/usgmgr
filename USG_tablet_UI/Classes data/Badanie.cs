using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USG_tablet_UI
{
    public class Badanie
    {

        DateTime data { get; set; }
        string rodzaj { get; set; }
        Pacjent pacjent { get; set; }

        public Badanie(DateTime d, string r, Pacjent p)
        {
            this.data = d;
            this.rodzaj = r;
            this.pacjent = p;
        }

        public override string ToString()
        {
            return rodzaj + ": " + data.ToString("yyyy-MM-dd HH:mm");
        }

    }
}
