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
            
        }

        public void addNewTVPackage(TVPackage newPackage)
        {
            
        }

        public List<Client> getAllClients()
        {
            //if (clients == null)
                //clients = queries.getAllClients();

            return clients;
        }

        public List<CombinedPackage> getAllCombinedPackages()
        {
            throw new NotImplementedException();
        }

        public List<InternetPackage> getAllInternetPackages()
        {
            //if (internetPackages == null)
            //  internetPackages = queries.getAllInternetPackages();

            return internetPackages;
        }

        public List<TVPackage> getAllTVPackages()
        {
            throw new NotImplementedException();
        }

        public Client getClientByUsername(string username)
        {
            return null;//queries.getClientByUsername(username);
            
        }

        public CombinedPackage getCombinedPackageByPackageID(int packageID)
        {
            throw new NotImplementedException();
        }

        public InternetPackage getInternetPackageByPackageID(int packageID)
        {
            throw new NotImplementedException();
        }

        public Package getPackageByPackageID(int paketID)
        {
            return null;// queries.getPackageByPackageId(paketId);
        }

        public PackageType getPackageTypeByID(int id)
        {
            return null;// queries.getPackageTypeById(id);
        }
        public List<Package> getSubscribedPackagesByClientId(int clientId, bool activated)
        {
            return null;// queries.getSubscribedPackagesByClientId(clientId,activated);
        }


        public TVPackage getTVPackageByPackageID(int packageID)
        {
            throw new NotImplementedException();
        }

        public int getTypeID(string typeName)
        {
            return 0;// queries.getTypeID(typeName);
        }

        public void removeTVPackage(int paketID)
        {
            tvPackages = null;
            //queries.removeTVPackage(paketID);
        }
        public void removeInternetPackage(int paketID)
        {
            
        }
        public void removeCombinedPackage(int paketID)
        {
            
        }

        

    }
}
