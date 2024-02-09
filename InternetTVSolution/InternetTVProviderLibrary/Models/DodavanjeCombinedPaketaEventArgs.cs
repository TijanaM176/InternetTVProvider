using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Models
{
    public class DodavanjeCombinedPaketaEventArgs:EventArgs
    {
        public string NazivPaketa { get; }
        public string TipPaketa { get; }
        public DodavanjeCombinedPaketaEventArgs(string nazivPaketa, string tipPaketa)
        {
            NazivPaketa = nazivPaketa;
            TipPaketa = tipPaketa;
            
        }
    }
}
