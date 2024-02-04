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
        List<Package> packages = new List<Package>();

        public QueryProxy(DbConnection connection)
        {
            queries = new Queries(connection);
            clients = null;
            packages = null;
        }

        public void addNewClient(Client newClient)
        {
            clients = null;
            //queries.addNewClient(newClient);
        }
        public void addNewPackage(Package newPackage)
        {
            packages = null;
           // queries.addNewPackage(newPackage);
        }

        public List<Client> getAllClients()
        {
            //if (clients == null)
                //clients = queries.getAllClients();

            return clients;
        }

        public List<Package> getAllPackages()
        {
            //if (packages == null)
              //  packages = queries.getAllPackages();

            return packages;
        }

        public Client getClientByUsername(string username)
        {
            return null;//queries.getClientByUsername(username);
            
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

        public int getTypeID(string typeName)
        {
            return 0;// queries.getTypeID(typeName);
        }

        public void removePackage(int paketID)
        {
            packages = null;
            //queries.removePackage(paketID);
        }


     
    }
}
