using InternetTVProviderLibrary.FacadePattern;
using InternetTVProviderLibrary.Models;
using InternetTVProviderLibrary.StrategyPattern;
using InternetTvProviderWinApp.MediatorPattern;
using System.Data.Common;
using System.Windows.Forms.VisualStyles;

namespace InternetTvProviderWinApp
{
    public partial class HomePage : Form
    {
        DbConnection connection;
        QueryFacade facade;

        AddNewClient addNewClient;
        AddNewPackageForm addNewPackage;

        HomePageMediator mediator;

        Button addNewPackageButton = new Button();
        Button addNewClientButton = new Button();

        public static readonly int TVTypeID = 1;
        public static readonly int INTERNETTypeID = 2;
        public static readonly int COMBINEDTypeID = 3;

        public HomePage(DbConnection connection)
        {
            this.connection = connection;
            InitializeComponent();

            facade = new QueryFacade(connection);
            mediator = new HomePageMediator(this, addNewClient, addNewPackage);

            providerName.Text = ScanConfiguration.providerName;
            showAllClientsInList();
            showAllTVPackagesTable();
            showAllInternetPackagesTable();
            showAllCombinedPackagesTable();

            showAllClientsListBox.SelectedIndexChanged += showAllClientsListBox_SelectedIndexChanged;
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

        public void showAllClientsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUsername = showAllClientsListBox.SelectedItem.ToString();

            ShowClient showClientForm = new ShowClient(selectedUsername, connection);

            showClientForm.StartPosition = FormStartPosition.CenterScreen;

            showClientForm.Show();
        }


        public void showAllTVPackagesTable()
        {
            showAllTvPacketsGrid.Rows.Clear();

            List<Package> tvPackages = facade.getAllPackages(TVTypeID);
            TVPackage tvPackage;

            foreach (Package package in tvPackages)
            {
                tvPackage = (TVPackage)package;
                int rowIndex = showAllTvPacketsGrid.Rows.Add();

                showAllTvPacketsGrid.Rows[rowIndex].Cells["nameTV"].Value = tvPackage.Name;
                showAllTvPacketsGrid.Rows[rowIndex].Cells["descriptionTV"].Value = "opis";
                showAllTvPacketsGrid.Rows[rowIndex].Cells["priceTV"].Value = tvPackage.Price;
                showAllTvPacketsGrid.Rows[rowIndex].Cells["numberOfChannelsTV"].Value = tvPackage.NumberOfChannels;
                showAllTvPacketsGrid.Rows[rowIndex].Cells["nameTV"].Tag = tvPackage.ID;
            }

        }

        public void showAllInternetPackagesTable()
        {
            showAllInternetPacketsGrid.Rows.Clear();

            List<Package> internetPackages = facade.getAllPackages(INTERNETTypeID);
            InternetPackage internetPackage;

            foreach (Package package in internetPackages)
            {
                internetPackage = (InternetPackage)package;
                int rowIndex = showAllInternetPacketsGrid.Rows.Add();

                showAllInternetPacketsGrid.Rows[rowIndex].Cells["nameInternet"].Value = internetPackage.Name;
                showAllInternetPacketsGrid.Rows[rowIndex].Cells["descriptionInternet"].Value = "opis";
                showAllInternetPacketsGrid.Rows[rowIndex].Cells["priceInternet"].Value = internetPackage.Price;
                showAllInternetPacketsGrid.Rows[rowIndex].Cells["internetSpeed"].Value = internetPackage.InternetSpeed;
                showAllInternetPacketsGrid.Rows[rowIndex].Cells["nameInternet"].Tag = internetPackage.ID;

            }

        }

        public void showAllCombinedPackagesTable()
        {
            showAllCombinedPacketsGrid.Rows.Clear();

            List<Package> combinedPackages = facade.getAllPackages(COMBINEDTypeID);
            CombinedPackage combinedPackage;

            foreach (Package package in combinedPackages)
            {
                combinedPackage = (CombinedPackage)package;
                int rowIndex = showAllCombinedPacketsGrid.Rows.Add();

                showAllCombinedPacketsGrid.Rows[rowIndex].Cells["nameCombined"].Value = combinedPackage.Name;
                showAllCombinedPacketsGrid.Rows[rowIndex].Cells["descriptionCombined"].Value = "opis";
                showAllCombinedPacketsGrid.Rows[rowIndex].Cells["priceCombined"].Value = combinedPackage.Price;
                showAllCombinedPacketsGrid.Rows[rowIndex].Cells["nameCombined"].Tag = combinedPackage.ID;
            }

        }

        private void addNewClientButton_Click(object sender, EventArgs e)
        {
            addNewClient = new AddNewClient(this, connection, mediator);
            addNewClient.ShowDialog();
        }

        private void addNewPackageButton_Click(object sender, EventArgs e)
        {
            addNewPackage = new AddNewPackageForm(connection, mediator);
            addNewPackage.ShowDialog();
        }


        public void UpdateUserView(string noviKlijent)
        {
            showAllClientsListBox.Items.Add(noviKlijent);
            showAllClientsListBox.SelectedItem = noviKlijent;
        }

        public void UpdateInternetPackageView(InternetPackage package)
        {

            int rowIndexTV = showAllInternetPacketsGrid.Rows.Add();
            showAllInternetPacketsGrid.Rows[rowIndexTV].Cells["nameInternet"].Value = package.Name;
            showAllInternetPacketsGrid.Rows[rowIndexTV].Cells["descriptionInternet"].Value = "opis";
            showAllInternetPacketsGrid.Rows[rowIndexTV].Cells["priceInternet"].Value = package.Price;
            showAllInternetPacketsGrid.Rows[rowIndexTV].Cells["internetSpeed"].Value = package.InternetSpeed;
            showAllInternetPacketsGrid.Rows[rowIndexTV].Cells["nameInternet"].Tag = package.ID;
            showAllInternetPacketsGrid.Refresh();
        }
        public void UpdateCombinedPackageView(CombinedPackage package)
        {

            int rowIndexTV = showAllCombinedPacketsGrid.Rows.Add();
            showAllCombinedPacketsGrid.Rows[rowIndexTV].Cells["nameCombined"].Value = package.Name;
            showAllCombinedPacketsGrid.Rows[rowIndexTV].Cells["descriptionCombined"].Value = "opis";
            showAllCombinedPacketsGrid.Rows[rowIndexTV].Cells["priceCombined"].Value = package.Price;
            showAllCombinedPacketsGrid.Rows[rowIndexTV].Cells["nameCombined"].Tag = package.ID;
            showAllCombinedPacketsGrid.Refresh();
        }

        public void UpdateTVPackageView(TVPackage package)
        {

            int rowIndexTV = showAllTvPacketsGrid.Rows.Add();
            showAllTvPacketsGrid.Rows[rowIndexTV].Cells["nameTV"].Value = package.Name;
            showAllTvPacketsGrid.Rows[rowIndexTV].Cells["descriptionTV"].Value = "opis";
            showAllTvPacketsGrid.Rows[rowIndexTV].Cells["priceTV"].Value = package.Price;
            showAllTvPacketsGrid.Rows[rowIndexTV].Cells["numberOfChannelsTV"].Value = package.NumberOfChannels;
            showAllTvPacketsGrid.Rows[rowIndexTV].Cells["nameTV"].Tag = package.ID;
            showAllTvPacketsGrid.Refresh();

        }

        private void deleteSelectedPackage_Click(object sender, EventArgs e)
        {
            if (showAllInternetPacketsGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = showAllInternetPacketsGrid.SelectedRows[0];
                int packageId = (int)selectedRow.Cells["nameInternet"].Tag;

                if (packageId != -1)
                {
                    if (ConfirmDelete())
                    {
                        CombinedPackage combinedPackage = facade.removeInternetPackage(packageId);
                        showAllInternetPacketsGrid.Rows.Remove(selectedRow);
                        if (combinedPackage != null)
                            selectCombinedRowToRemove(combinedPackage.Name);
                    }
                }

            }
            else if (showAllCombinedPacketsGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = showAllCombinedPacketsGrid.SelectedRows[0];
                int packageId = (int)selectedRow.Cells["nameCombined"].Tag;

                if (packageId != -1)
                {
                    if (ConfirmDelete())
                    {
                        facade.removeCombinedPackage(packageId);
                        showAllCombinedPacketsGrid.Rows.Remove(selectedRow);
                    }
                }

            }
            else if (showAllTvPacketsGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = showAllTvPacketsGrid.SelectedRows[0];
                int packageId = (int)selectedRow.Cells["nameTV"].Tag;

                if (packageId != -1)
                {
                    if (ConfirmDelete())
                    {
                        CombinedPackage combinedPackage = facade.removeTVPackage(packageId);
                        showAllTvPacketsGrid.Rows.Remove(selectedRow);
                        if (combinedPackage != null)
                            selectCombinedRowToRemove(combinedPackage.Name);

                    }
                }
            }
            else
            {
                MessageBox.Show("No row selected!");
            }
        }

        private void selectCombinedRowToRemove(string name)
        {
            foreach (DataGridViewRow row in showAllCombinedPacketsGrid.Rows)
            {
                if (row.Cells["nameCombined"].Value != null && row.Cells["nameCombined"].Value.ToString() == name)
                {
                    showAllCombinedPacketsGrid.Rows.Remove(row);
                    break;
                }
            }
        }

        private bool ConfirmDelete()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the package?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientsLabel_Click(object sender, EventArgs e)
        {

        }
    }

}
