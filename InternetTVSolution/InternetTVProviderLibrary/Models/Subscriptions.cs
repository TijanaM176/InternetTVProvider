using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Models
{
    public class Subscriptions
    {
        [Required]
        public int clientId { get; set; }
        [ForeignKey("clientId")]
        Client client { get; set; }
        [Required]
        public int packageId { get; set; }
        [ForeignKey("packageId")]
        Package package { get; set; }

        public Subscriptions(int clientId, int packageId)
        {
            this.clientId = clientId;
            this.packageId = packageId;
        }
    }
}
