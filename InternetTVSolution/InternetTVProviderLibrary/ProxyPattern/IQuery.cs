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
        List<TVPackage> getAllTVPackages();
        List<InternetPackage> getAllInternetPackages();
        List<CombinedPackage> getAllCombinedPackages();
        void insertNewClient(Client newClient);
        void addNewTVPackage(TVPackage newPackage);
        void addNewInternetPackage(InternetPackage newPackage);
        void addNewCombinedPackage(CombinedPackage newPackage);
        TVPackage getTVPackageByPackageID(int packageID);
        InternetPackage getInternetPackageByPackageID(int packageID); 
        CombinedPackage getCombinedPackageByPackageID(int packageID); 
        int getTypeID(string typeName);
        void removeTVPackage(int packageID);
        void removeInternetPackage(int packageID);
        void removeCombinedPackage(int packageID);
        PackageType getPackageTypeByID(int id);
        Client getClientByUsername(string username);
        public List<Subscriptions> getSubscriptionsByClientId(int clientId);
        void updateSubscribedPackageByClientID(Subscriptions subscription);
        void insertNewSubscriptionForClientID(Subscriptions subscription);
        double getPriceTVPackage(int packageID);
        double getPriceInternetPackage(int packageID);
        int getTVPackageIdByNumOfChannels(int numOfChannels);
        int getInternetPackageIdByInternetSpeed(string internetSpeed);

    }
}
