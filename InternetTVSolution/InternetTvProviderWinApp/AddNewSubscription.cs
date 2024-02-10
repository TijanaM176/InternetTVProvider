using InternetTVProviderLibrary.FacadePattern;
using InternetTVProviderLibrary.Models;
using System.Data;
using System.Data.Common;

namespace InternetTvProviderWinApp
{
    public partial class AddNewSubscription : Form
    {
        QueryFacade facade;
        ShowClient showClient;
        int clientID, packageTypeID, packageID;

        public AddNewSubscription(DbConnection connection, int clientID, ShowClient showClient)
        {
            InitializeComponent();

            this.clientID = clientID;
            this.showClient = showClient;
            cancelButton.Click += closeAddNewSub;
            addSubButton.Click += addNewSub;

            HomePage pocetnaStrana = new HomePage(connection);
            facade = new QueryFacade(connection);

            fillAllDropDownFields();
        }

        public void fillAllDropDownFields()
        {
            List<Package> packagesTV = facade.getAllPackages(HomePage.TVTypeID);
            List<Package> packagesInternet = facade.getAllPackages(HomePage.INTERNETTypeID);
            List<Package> packagesCombined = facade.getAllPackages(HomePage.COMBINEDTypeID);
            List<string> allPackageIDsAndNames = new List<string>();

            allPackageIDsAndNames.AddRange(packagesTV.Select(p => $"{p.PackageTypeID} - {p.Name} - {p.ID}"));
            allPackageIDsAndNames.AddRange(packagesInternet.Select(p => $"{p.PackageTypeID} - {p.Name} - {p.ID}"));
            allPackageIDsAndNames.AddRange(packagesCombined.Select(p => $"{p.PackageTypeID} - {p.Name} - {p.ID}"));
            allPackageIDsAndNames = allPackageIDsAndNames.Distinct().ToList();

            foreach (string packageInfo in allPackageIDsAndNames)
            {
                dropDownPackageInfo.Items.Add(packageInfo);
            }

        }

        public void addNewSub(object sender, EventArgs e)
        {
            string packageInfo = dropDownPackageInfo.Text;

            if (packageInfo != null)
            {
                string[] infoParts = packageInfo.Split('-');

                for (int i = 0; i < infoParts.Length; i++)
                {
                    infoParts[i] = infoParts[i].Trim();
                }

                int packageTypeID = int.TryParse(infoParts[0].ToString(), out int resultType) ? resultType : -1;
                int packageID = int.TryParse(infoParts[2].ToString(), out int resultID) ? resultID : -1;

                Package package = facade.getPackageByTypeID(packageTypeID, packageID);

                if (package != null)
                {
                    facade.insertNewSubscriptionForClientID(clientID, package.ID, package.Name, package.Price, package.PackageTypeID);
                    showClient.DisplaySubscriptions();
                }
                else
                {
                    MessageBox.Show("Ne postoji taj paket u listi svih paketa!");
                }
            }
            else
            {
                MessageBox.Show("Niste popunili sva polja!");
            }

            this.Close();
        }

        public void closeAddNewSub(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
