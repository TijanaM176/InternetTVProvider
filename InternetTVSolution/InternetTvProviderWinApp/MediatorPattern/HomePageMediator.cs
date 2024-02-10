using InternetTVProviderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTvProviderWinApp.MediatorPattern
{
    public class HomePageMediator : IMediator
    {
        private HomePage homePage;
        private AddNewClient addNewClient;
        private AddNewPackageForm addNewPackageForm;

        public HomePageMediator(HomePage homePage, AddNewClient addNewClient, AddNewPackageForm addNewPackageForm)
        {
            this.homePage = homePage;
            this.addNewClient = addNewClient;
            this.addNewPackageForm = addNewPackageForm;
        }   

        public void NotifyNewClient(object sender, string klijent)
        {
            homePage.UpdateUserView(klijent);
        }

        public void NotifyNewPackage(object sender, Package package)
        {
            if (package is TVPackage)
                homePage.UpdateTVPackageView((TVPackage)package);
            else if (package is InternetPackage)
                homePage.UpdateInternetPackageView((InternetPackage)package);
            else
                homePage.UpdateCombinedPackageView((CombinedPackage)package);
        }
    }
}
