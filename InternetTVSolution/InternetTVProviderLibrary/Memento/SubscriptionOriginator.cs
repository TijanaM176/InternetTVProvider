using InternetTVProviderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Memento
{
    public class SubscriptionOriginator
    {
        private List<Client> clients;
        private List<Package> packages;
        private List<Subscriptions> subscriptions;

        public SubscriptionOriginator()
        {
            this.clients = new List<Client>();
            this.packages = new List<Package>();
            this.subscriptions = new List<Subscriptions>();
        }

        public void SetState(List<Client> clients, List<Package> packages, List<Subscriptions> subscriptions)
        {
            this.clients = new List<Client>(clients);
            this.packages = new List<Package>(packages);
            this.subscriptions = new List<Subscriptions>(subscriptions);
        }

        public SubscriptionMemento SaveStateToMemento()
        {
            return new SubscriptionMemento(clients, packages, subscriptions);
        }

        public void RestoreStateFromMemento(SubscriptionMemento memento)
        {
            memento.RestoreState(this);
        }

        public void AddNewClient(Client client)
        {
            clients.Add(client);
        }

        public void AddNewPackage(Package package)
        {
            packages.Add(package);
        }

        public void AddNewSubscription(Subscriptions subscription)
        {
            subscriptions.Add(subscription);
        }

        public List<Client> GetAllClients()
        {
            return clients;
        }

        public List<Package> GetAllPackages()
        {
            return packages;
        }

        public List<Subscriptions> GetAllSubscriptions()
        {
            return subscriptions;
        }
    }
}
