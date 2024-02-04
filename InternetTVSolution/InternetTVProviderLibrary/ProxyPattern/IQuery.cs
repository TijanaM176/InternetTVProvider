using InternetTVProviderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.ProxyPattern
{
    public interface IQuery
    {
        List<Client> getAllClients();
        List<Package> getAllPackages();
        void addNewClient(Client newClient);
        void addNewPackage(Package newPackage);
        Package getPackageByPackageID(int paketID);
        int getTypeID(string typeName);
        void removePackage(int paketID);
        PackageType getPackageTypeByID(int id);
        Client getClientByUsername(string username);
    }
}
