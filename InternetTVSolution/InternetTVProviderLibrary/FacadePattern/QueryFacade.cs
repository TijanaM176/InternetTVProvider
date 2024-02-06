using InternetTVProviderLibrary.Models;
using InternetTVProviderLibrary.ProxyPattern;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.FacadePattern
{
    internal class QueryFacade
    {
        protected IQuery queries;

        public QueryFacade(DbConnection conn)
        {
            queries = new QueryProxy(conn);
        }

        public List<Package> getAllPackages(int PackageTypeID)
        {
            List<Package> packages = new List<Package>();

            switch (PackageTypeID)
            {
                case 1:
                    List<TVPackage> tvPackages;
                    tvPackages = queries.getAllTVPackages();

                    foreach (TVPackage tvPackage in tvPackages) { packages.Add(tvPackage); }

                    return packages;
                case 2:
                    List<InternetPackage> internetPackages;
                    internetPackages = queries.getAllInternetPackages();

                    foreach (InternetPackage internetPackage in internetPackages) { packages.Add(internetPackage); }

                    return packages;
                case 3:
                    List<CombinedPackage> combinedPackages;
                    combinedPackages = queries.getAllCombinedPackages();

                    foreach (CombinedPackage combinedPackage in combinedPackages) { packages.Add(combinedPackage); }

                    return packages;
            }

            return packages;
        }

        public List<Client> getAllClients()
        {
            return queries.getAllClients();
        }

    }
}
