using InternetTVProviderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Memento
{
    // Originator
    public class SubscriptionOriginator
    {
        private List<Subscriptions> subscriptions;

        public SubscriptionOriginator()
        {
            subscriptions = new List<Subscriptions>();
        }

        public void SetSubscriptions(List<Subscriptions> subscriptions)
        {
            this.subscriptions = subscriptions;
        }

        public List<Subscriptions> GetSubscriptions()
        {
            return subscriptions;
        }

        // Kreiranje Memento objekta koji čuva trenutno stanje
        public SubscriptionMemento CreateMemento()
        {
            return new SubscriptionMemento(subscriptions);
        }

        // Vraćanje na prethodno stanje
        public void SetMemento(SubscriptionMemento memento)
        {
            subscriptions = memento.GetSubscriptions();
        }
    }
}

