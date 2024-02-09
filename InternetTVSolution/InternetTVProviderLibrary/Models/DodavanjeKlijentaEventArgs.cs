using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Models
{
    public class DodavanjeKlijentaEventArgs:EventArgs
    {
        public string NoviKlijent { get; }

        public DodavanjeKlijentaEventArgs(string noviKlijent)
        {
            NoviKlijent = noviKlijent;
        }
    }
}
