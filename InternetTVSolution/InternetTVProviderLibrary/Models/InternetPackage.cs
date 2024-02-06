using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Models
{
    public class InternetPackage : Package
    {
        public int InternetSpeed { get; set; }

        public InternetPackage(int id, string name, double price, int internetSpeed, int packageTypeId)
            : base(id, name, price, packageTypeId)
        {
            InternetSpeed = internetSpeed;
        }
    }
}
