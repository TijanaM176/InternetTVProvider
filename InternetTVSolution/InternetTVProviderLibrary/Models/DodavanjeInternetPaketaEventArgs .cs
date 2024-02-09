using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Models
{
    public class DodavanjeInternetPaketaEventArgs : EventArgs
    {
        public string NazivPaketa { get; }
        public string TipPaketa { get; }
        public double Price { get; }
        public string InternetSpeed { get; }
        public DodavanjeInternetPaketaEventArgs(string nazivPaketa, string tipPaketa,double price, string internetSpeed)
        {
            NazivPaketa = nazivPaketa;
            TipPaketa = tipPaketa;
            Price = price;
            InternetSpeed = internetSpeed;
        }
    }

}
