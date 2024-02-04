using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Models
{
    public class Package
    {
        [Key]
        public int ID { get; }

        [ForeignKey("PackageTypeID")]
        public PackageType PackageType { get; }

        public string Name { get; set; }
        public double Price { get; set; }
        public int NumberOfChannels { get; set; }
        public int InternetSpeed { get; set; }
        public int PackageTypeID { get; set; }

        public Package(int ID, string Name, double Price, int NumberOfChannels, int InternetSpeed, int PackageTypeID)
        {
            this.ID = ID;
            this.Name = Name;
            this.Price = Price;
            this.NumberOfChannels = NumberOfChannels;
            this.InternetSpeed = InternetSpeed;
            this.PackageTypeID = PackageTypeID;
        }

    }
}
