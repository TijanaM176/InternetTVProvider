using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Models
{
    public class DodavanjeTVPaketaEventArgs:EventArgs
    {

        public string NazivPaketa { get; }
        public string TipPaketa { get; }
        public double Price { get; }
        public int NumberOfChanels { get; }
        public DodavanjeTVPaketaEventArgs(string nazivPaketa, string tipPaketa, double price, int numofChanels)
        {
            NazivPaketa = nazivPaketa;
            TipPaketa = tipPaketa;
            Price = price;
            NumberOfChanels = numofChanels;
        }
    }
}
