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
            Dictionary<string, KeyValuePair<int, int>> allPackageInfo = new Dictionary<string, KeyValuePair<int, int>>();

            List<Package> packagesTV = facade.getAllPackages(HomePage.TVTypeID);
            List<Package> packagesInternet = facade.getAllPackages(HomePage.INTERNETTypeID);
            List<Package> packagesCombined = facade.getAllPackages(HomePage.COMBINEDTypeID);

            foreach (Package package in packagesTV)
            {
                allPackageInfo.Add(package.Name, new KeyValuePair<int, int>(package.ID, package.PackageTypeID));
            }

            foreach (Package package in packagesInternet)
            {
                allPackageInfo.Add(package.Name, new KeyValuePair<int, int>(package.ID, package.PackageTypeID));
            }

            foreach (Package package in packagesCombined)
            {
                allPackageInfo.Add(package.Name, new KeyValuePair<int, int>(package.ID, package.PackageTypeID));
            }

            dropDownPackageInfo.DataSource = new BindingSource(allPackageInfo, null);
            dropDownPackageInfo.DisplayMember = "Key";
            dropDownPackageInfo.ValueMember = "Value";
        }


        public void addNewSub(object sender, EventArgs e)
        {
            // Proveravamo da li je odabrani element u drop-down listi
            if (dropDownPackageInfo.SelectedItem != null)
            {
                // Dobijamo odabrani element (ime paketa) iz drop-down liste
                string packageName = dropDownPackageInfo.SelectedItem.ToString();

                // Dobijamo ID paketa i ID tipa paketa iz odabrane vrednosti u drop-down listi
                KeyValuePair<int, int> packageInfo = (KeyValuePair<int, int>)dropDownPackageInfo.SelectedValue;
                int packageID = packageInfo.Key;
                int packageTypeID = packageInfo.Value;

                // Dobijamo informacije o paketu na osnovu ID-ja paketa
                Package package = facade.getPackageByTypeID(packageTypeID, packageID);

                if (package != null)
                {
                    // Ubacujemo novu pretplatu za datog klijenta
                    facade.insertNewSubscriptionForClientID(clientID, package.ID, package.Name, package.Price, package.PackageTypeID);
                    // Osvežavamo prikaz pretplata
                    showClient.DisplaySubscriptions();
                }
                else
                {
                    MessageBox.Show("Ne postoji taj paket u listi svih paketa!");
                }
            }
            else
            {
                MessageBox.Show("Niste odabrali paket!");
            }

            this.Close();
        }


        public void closeAddNewSub(object sender, EventArgs e)
        {
            this.Close();
        }

        private void packageInfoLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
