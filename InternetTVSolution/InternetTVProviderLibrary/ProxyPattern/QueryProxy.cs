using InternetTVProviderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.ProxyPattern
{
    public class QueryProxy : IQuery
    {
        Queries queries = null;

        List<Client> clients = new List<Client>();
        List<TVPackage> tvPackages = new List<TVPackage>();
        List<InternetPackage> internetPackages = new List<InternetPackage>();
        List<CombinedPackage> combinedPackages = new List<CombinedPackage>();

        public QueryProxy(DbConnection connection)
        {
            queries = new Queries(connection);
            clients = null;
            tvPackages = null;
            internetPackages = null;
            combinedPackages = null;
        }

        public void addNewClient(Client newClient)
        {
            clients = null;
            //queries.addNewClient(newClient);
        }

        public void addNewCombinedPackage(CombinedPackage newPackage)
        {
            combinedPackages = null;
            //queries.addNewCombinedPackage(newPackage);
        }

        public void addNewInternetPackage(InternetPackage newPackage)
        {
            internetPackages = null;
            //queries.addNewInternetPackage(newPackage);
        }

        public void addNewTVPackage(TVPackage newPackage)
        {
            tvPackages = null;
            //queries.addNewTVPackage(newPackage);
        }

        public List<Client> getAllClients()
        {
            //if (clients == null)
                //clients = queries.getAllClients();

            return clients;
        }

        public List<CombinedPackage> getAllCombinedPackages()
        {
            //if (combinedPackages == null)
            //  combinedPackages = queries.getAllCombinedPackages();

            return combinedPackages;
        }

        public List<InternetPackage> getAllInternetPackages()
        {
            //if (internetPackages == null)
            //  internetPackages = queries.getAllInternetPackages();

            return internetPackages;
        }

        public List<TVPackage> getAllTVPackages()
        {
            //if (tvPackages == null)
            //  tvPackages = queries.getAllTVPackages();

            return tvPackages;
        }

        public Client getClientByUsername(string username)
        {
            return null;//queries.getClientByUsername(username);
            
        }

        public CombinedPackage getCombinedPackageByPackageID(int packageID)
        {
            return queries.getCombinedPackageByPackageID(packageID);
        }

        public InternetPackage getInternetPackageByPackageID(int packageID)
        {
            return queries.getInternetPackageByPackageID(packageID);
        }

        public PackageType getPackageTypeByID(int id)
        {
            return queries.getPackageTypeByID(id);
        }

        public List<Package> getSubscribedPackagesByClientId(int clientId)
        {
            return queries.getSubscribedPackagesByClientId(clientId);
        }


        public TVPackage getTVPackageByPackageID(int packageID)
        {
            return queries.getTVPackageByPackageID(packageID);
        }

        public int getTypeID(string typeName)
        {
            return queries.getTypeID(typeName);
        }

        public void removeTVPackage(int packageID)
        {
            tvPackages = null;
            queries.removeTVPackage(packageID);
        }
        public void removeInternetPackage(int packageID)
        {
            internetPackages = null;
            queries.removeInternetPackage(packageID);
        }
        public void removeCombinedPackage(int packageID)
        {
            combinedPackages = null;
            queries.removeCombinedPackage(packageID);
        }
        public void updateSubscribedPackageByClientID(Subscriptions subscription)
        {
            queries.updateSubscribedPackageByClientID(subscription);
        }

        public void insertNewSubscriptionForClientID(Subscriptions subscription)
        {
            queries.insertNewSubscriptionForClientID(subscription);
        }

        public int getPriceTVPackage(int packageID)
        {
            throw new NotImplementedException();
        }

        public int getPriceInternetPackage(int packageID)
        {
            throw new NotImplementedException();
        }
    }
}
