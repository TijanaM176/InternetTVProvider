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
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        [ForeignKey("PackageTypeID")]
        public int PackageTypeID { get; set; }

        
        public Package(int ID, string Name, double Price, int PackageTypeID)
        {
            this.ID = ID;
            this.Name = Name;
            this.Price = Price;
            this.PackageTypeID = PackageTypeID;
        }

    }
}
