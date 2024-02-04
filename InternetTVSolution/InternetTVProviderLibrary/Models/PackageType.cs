using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Models
{
    public class PackageType
    {
        [Key]
        public int PackageTypeID { get; set; }
        public string Name { get; set; }

        public PackageType(int PackageTypeID, string Name)
        {
            this.PackageTypeID = PackageTypeID;
            this.Name = Name;
        }

    }
}
