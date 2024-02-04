using InternetTVProviderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Memento
{
    public class SubscriptionMemento
    {
        private List<Client> clients;
        private List<Package> packages;
        private List<Subscriptions> subscriptions;

        public SubscriptionMemento(List<Client> clients, List<Package> packages, List<Subscriptions> subscriptions)
        {
            this.clients = new List<Client>(clients);
            this.packages = new List<Package>(packages);
            this.subscriptions = new List<Subscriptions>(subscriptions);
        }

        public List<Client> GetClients()
        {
            return new List<Client>(clients);
        }

        public List<Package> GetPackages()
        {
            return new List<Package>(packages);
        }

        public List<Subscriptions> GetSubscriptions()
        {
            return new List<Subscriptions>(subscriptions);
        }

        public void RestoreState(SubscriptionOriginator originator)
        {
            originator.SetState(clients, packages, subscriptions);
        }
    }
}
