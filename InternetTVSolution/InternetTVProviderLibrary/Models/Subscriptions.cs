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

        public string name { get; set; }
        public double price { get; set; }
        public int packageTypeID { get; set; }

        public int activated { get; set; }
        Package package { get; set; }
        


        public Subscriptions(int clientId, string name, double price, int packageId, int packageTypeID, int activated)
        {
            this.clientId = clientId;
            this.packageId = packageId;
            this.name = name;
            this.price = price;
            this.packageTypeID = packageTypeID; 
            this.activated = activated;
        }
    }
}
