using InternetTVProviderLibrary.FacadePattern;
using InternetTVProviderLibrary.Models;
using System.Data.Common;
using System.Windows.Forms.VisualStyles;

namespace InternetTvProviderWinApp
{
    public partial class PocetnaStrana : Form
    {
        DbConnection connection;
        QueryFacade facade;

        Button addNewPackageButton = new Button();
        Button addNewClientButton = new Button();

        private static readonly int TVTypeID = 1;
        private static readonly int INTERNETTypeID = 2;
        private static readonly int COMBINEDTypeID = 3;

        public PocetnaStrana(DbConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
            facade = new QueryFacade(connection);

            showAllClientsInList();
            showAllTVPackagesTable();
            showAllInternetPackagesTable();
            showAllCombinedPackagesTable();

            showAllClientsListBox.SelectedIndexChanged += showAllClientsListBox_SelectedIndexChanged;
        }

        public void showAllClientsInList()
        {

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

                showAllInternetPacketsGrid.Rows[rowIndex].Cells["nameInternet"].Tag = internetPackage.ID; // Pretpostavljamo da je ID dostupan u InternetPackage klasi

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
            AddNewClient addNewClient = new AddNewClient(this, connection);
            addNewClient.NoviKlijentDodat += AddNewClient_NoviKlijentDodat;
            addNewClient.ShowDialog();
        }

        private void addNewPackageButton_Click(object sender, EventArgs e)
        {
            AddNewPackageForm addNewPackage = new AddNewPackageForm(connection);
            addNewPackage.NoviTVPaketDodat += AddNewPackage_NoviTVPaketDodat;
            addNewPackage.NoviInternetPaketDodat += AddNewPackage_NoviInternetPaketDodat;
            addNewPackage.NoviCombinedPaketDodat += AddNewPackage_NoviCombinedPaketDodat;
            addNewPackage.ShowDialog();
        }
        private void AddNewClient_NoviKlijentDodat(object sender, DodavanjeKlijentaEventArgs e)
        {
            // Osvežavanje liste klijenata na osnovu informacija o novom klijentu
            string noviKlijent = e.NoviKlijent;
            UpdateUserView(noviKlijent);
        }
        private void AddNewPackage_NoviTVPaketDodat(object sender, DodavanjeTVPaketaEventArgs e)
        {
            string noviPaket = e.NazivPaketa;
            string tipPaketa = e.TipPaketa;
            double price = e.Price;
            int numOfChanels = e.NumberOfChanels;
            UpdateTVPackageView(noviPaket, tipPaketa, price, numOfChanels);

        }
        private void AddNewPackage_NoviInternetPaketDodat(object sender, DodavanjeInternetPaketaEventArgs e)
        {
            string noviPaket = e.NazivPaketa;
            string tipPaketa = e.TipPaketa;
            double price = e.Price;
            string internetspeed = e.InternetSpeed;
            UpdateInternetPackageView(noviPaket, tipPaketa, price, internetspeed);
        }
        private void AddNewPackage_NoviCombinedPaketDodat(object sender, DodavanjeCombinedPaketaEventArgs e)
        {
            string noviPaket = e.NazivPaketa;
            string tipPaketa = e.TipPaketa;
            UpdateCombinedPackageView(noviPaket, tipPaketa);
        }

        private void packetsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateUserView(string noviKlijent)
        {
            showAllClientsListBox.Items.Add(noviKlijent);
            showAllClientsListBox.SelectedItem = noviKlijent;
        }

        private void UpdateInternetPackageView(string noviPaket, string tipPaketa, double price, string internetSpeed)
        {

            int rowIndexTV = showAllInternetPacketsGrid.Rows.Add();
            showAllInternetPacketsGrid.Rows[rowIndexTV].Cells["nameInternet"].Value = noviPaket;
            showAllInternetPacketsGrid.Rows[rowIndexTV].Cells["descriptionInternet"].Value = "opis";
            showAllInternetPacketsGrid.Rows[rowIndexTV].Cells["priceInternet"].Value = price;
            showAllInternetPacketsGrid.Rows[rowIndexTV].Cells["internetSpeed"].Value = internetSpeed;
        }
        private void UpdateCombinedPackageView(string noviPaket, string tipPaketa)
        {

            int rowIndexTV = showAllCombinedPacketsGrid.Rows.Add();
            showAllCombinedPacketsGrid.Rows[rowIndexTV].Cells["nameCombined"].Value = noviPaket;
            showAllCombinedPacketsGrid.Rows[rowIndexTV].Cells["descriptionCombined"].Value = "opis";
        }

        private void UpdateTVPackageView(string noviPaket, string tipPaketa, double price, int numOfChanels)
        {

            int rowIndexTV = showAllTvPacketsGrid.Rows.Add();
            showAllTvPacketsGrid.Rows[rowIndexTV].Cells["nameTV"].Value = noviPaket;
            showAllTvPacketsGrid.Rows[rowIndexTV].Cells["descriptionTV"].Value = "opis";
            showAllTvPacketsGrid.Rows[rowIndexTV].Cells["priceTV"].Value = price;
            showAllTvPacketsGrid.Rows[rowIndexTV].Cells["numberOfChannelsTV"].Value = numOfChanels;

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
                        CombinedPackage combinedPackage = facade.getCombinedPackageByPackageID(packageId);

                        if (combinedPackage != null)
                        {
                            facade.removeCombinedPackage(combinedPackage.ID);
                        }

                        facade.removeInternetPackage(packageId);
                        showAllInternetPacketsGrid.Rows.Remove(selectedRow);
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
                        CombinedPackage combinedPackage = facade.getCombinedPackageByPackageID(packageId);

                        if (combinedPackage != null)
                        {
                            facade.removeCombinedPackage(combinedPackage.ID);
                        }

                        facade.removeTVPackage(packageId);
                        showAllTvPacketsGrid.Rows.Remove(selectedRow);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nijedan red nije selektovan!");
            }
        }

        private bool ConfirmDelete()
        {
            DialogResult result = MessageBox.Show("Da li ste sigurni da želite da izbrišete paket?", "Potvrda brisanja paketa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }
    }

}
