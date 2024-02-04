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
            throw new NotImplementedException();
        }

        public Package getPackageByPackageID(int paketID)
        {
            throw new NotImplementedException();
        }

        public PackageType getPackageTypeByID(int id)
        {
            throw new NotImplementedException();
        }

        public int getTypeID(string typeName)
        {
            throw new NotImplementedException();
        }

        public void removePackage(int paketID)
        {
            throw new NotImplementedException();
        }
    }
}
