using InternetTVProviderLibrary.FacadePattern;
using InternetTVProviderLibrary.Models;
using System.Data.Common;

namespace InternetTvProviderWinApp
{
    public partial class PocetnaStrana : Form
    {
        DbConnection connection;
        QueryFacade facade; //= new QueryFacade(connection);

        Button addNewPackageButton = new Button();
        Button addNewClientButton = new Button();
        Button deletePackageButton = new Button();

        public PocetnaStrana()
        {
            InitializeComponent();
        }

    
        public void showAllClientsInList()
        {
            showAllClientsListBox.Items.Clear();

            List<Client> clients = facade.getAllClients();

            foreach (Client client in clients)
            {
                showAllClientsListBox.Items.Add(client.Username);
            }

            showAllClientsListBox.SelectedIndex = 0;
        }

        public void showAllTVPackagesTable()
        {
            showAllTvPacketsGrid.Rows.Clear();

            List<Package> tvPackages = facade.getAllPackages(1);
            TVPackage tvPackage;

            foreach (Package package in tvPackages)
            {
                tvPackage = (TVPackage) package;
                int rowIndex = showAllTvPacketsGrid.Rows.Add();

                showAllTvPacketsGrid.Rows[rowIndex].Cells["nameTV"].Value = tvPackage.Name;
                showAllTvPacketsGrid.Rows[rowIndex].Cells["descriptionTV"].Value = "opis";
                showAllTvPacketsGrid.Rows[rowIndex].Cells["priceTV"].Value = tvPackage.Price;
                showAllTvPacketsGrid.Rows[rowIndex].Cells["numberOfChannelsTV"].Value = tvPackage.NumberOfChannels;
            }

            // ako treba obeleziti neko polje
            if (showAllTvPacketsGrid.Rows.Count > 0)
            {
                showAllTvPacketsGrid.Rows[0].Selected = true;
            }
        }

        public void showAllInternetPackagesTable()
        {
            showAllInternetPacketsGrid.Rows.Clear();

            List<Package> internetPackages = facade.getAllPackages(2);
            InternetPackage internetPackage;

            foreach (Package package in internetPackages)
            {
                internetPackage = (InternetPackage) package;
                int rowIndex = showAllTvPacketsGrid.Rows.Add();

                showAllTvPacketsGrid.Rows[rowIndex].Cells["nameInternet"].Value = internetPackage.Name;
                showAllTvPacketsGrid.Rows[rowIndex].Cells["descriptionInternet"].Value = "opis";
                showAllTvPacketsGrid.Rows[rowIndex].Cells["priceInternet"].Value = internetPackage.Price;
                showAllTvPacketsGrid.Rows[rowIndex].Cells["internetSpeed"].Value = internetPackage.InternetSpeed;
            }

            // ako treba obeleziti neko polje
            if (showAllInternetPacketsGrid.Rows.Count > 0)
            {
                showAllInternetPacketsGrid.Rows[0].Selected = true;
            }
        }

        public void showAllCombinedPackagesTable()
        {
            showAllInternetPacketsGrid.Rows.Clear();

            List<Package> combinedPackages = facade.getAllPackages(2);
            CombinedPackage combinedPackage;

            foreach (Package package in combinedPackages)
            {
                combinedPackage = (CombinedPackage) package;
                int rowIndex = showAllTvPacketsGrid.Rows.Add();

                showAllTvPacketsGrid.Rows[rowIndex].Cells["nameCombined"].Value = combinedPackage.Name;
                showAllTvPacketsGrid.Rows[rowIndex].Cells["descriptionCombined"].Value = "opis";
                showAllTvPacketsGrid.Rows[rowIndex].Cells["priceCombined"].Value = combinedPackage.Price;
            }

            // ako treba obeleziti neko polje
            if (showAllInternetPacketsGrid.Rows.Count > 0)
            {
                showAllInternetPacketsGrid.Rows[0].Selected = true;
            }
        }

        private void addNewClientButton_Click(object sender, EventArgs e)
        {
            AddNewClient addNewClient = new AddNewClient(connection);
            addNewClient.ShowDialog();
        }

        private void addNewPackageButton_Click(object sender, EventArgs e)
        {
            AddNewPackageForm addNewPackage = new AddNewPackageForm(connection);
            addNewPackage.ShowDialog();
        }

        private void deletePackageButton_Click(object sender, EventArgs e)
        {
            /* TODO */
        }
    }

}
