using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Models
{
    public class CombinedPackage : Package
    {
        [ForeignKey("TVPackage")]
        public int TVPackageId { get; set; }

        [ForeignKey("InternetPackage")]
        public int InternetPackageId { get; set; }

        public CombinedPackage(int id, string name, double price, int tvPackageId, int internetPackageId, int packageTypeId)
            : base(id, name, price, packageTypeId)
        {
            TVPackageId = tvPackageId;
            InternetPackageId = internetPackageId;
        }
    }

}
