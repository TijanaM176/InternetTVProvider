using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Models
{
    public class TVPackage : Package
    {
        public int NumberOfChannels { get; set; }

        public TVPackage(int id, string name, double price, int numberOfChannels, int packageTypeId)
            : base(id, name, price,packageTypeId)
        {
            NumberOfChannels = numberOfChannels;
        }
    }

}
