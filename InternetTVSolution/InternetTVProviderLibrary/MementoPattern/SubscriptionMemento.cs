using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetTVProviderLibrary.Models;


namespace InternetTVProviderLibrary.Memento
{ 
    public class SubscriptionMemento
    {
        private List<Subscriptions> subscriptions;

        public SubscriptionMemento(List<Subscriptions> subscriptions)
        {
            this.subscriptions = new List<Subscriptions>(subscriptions);
        }

        public List<Subscriptions> GetSubscriptions()
        {
            return new List<Subscriptions>(subscriptions);
        }
    }
}
