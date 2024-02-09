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
        Button deleteTVPackageButton = new Button();
        // Button deleteInternetPackageButton = new Button();
        //Button deleteCombinedPackageButton = new Button();

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

            List<Package> tvPackages = facade.getAllPackages(1);
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
                internetPackage = (InternetPackage)package;
                int rowIndex = showAllInternetPacketsGrid.Rows.Add();

                showAllInternetPacketsGrid.Rows[rowIndex].Cells["nameInternet"].Value = internetPackage.Name;
                showAllInternetPacketsGrid.Rows[rowIndex].Cells["descriptionInternet"].Value = "opis";
                showAllInternetPacketsGrid.Rows[rowIndex].Cells["priceInternet"].Value = internetPackage.Price;
                showAllInternetPacketsGrid.Rows[rowIndex].Cells["internetSpeed"].Value = internetPackage.InternetSpeed;

                showAllInternetPacketsGrid.Rows[rowIndex].Cells["nameInternet"].Tag = internetPackage.ID; // Pretpostavljamo da je ID dostupan u InternetPackage klasi

            }

            // ako treba obeleziti neko polje
            if (showAllInternetPacketsGrid.Rows.Count > 0)
            {
                showAllInternetPacketsGrid.Rows[0].Selected = true;
            }
        }

        public void showAllCombinedPackagesTable()
        {
            showAllCombinedPacketsGrid.Rows.Clear();

            List<Package> combinedPackages = facade.getAllPackages(3);
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

            // ako treba obeleziti neko polje
            if (showAllCombinedPacketsGrid.Rows.Count > 0)
            {
                showAllCombinedPacketsGrid.Rows[0].Selected = true;
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

        private void deleteTVPackageButton_Click(object sender, EventArgs e)
        {
            if (showAllTvPacketsGrid != null)
            {
                DataGridViewRow selectedRow = showAllTvPacketsGrid.SelectedRows[0];
                if (selectedRow.Cells["nameTv"].Tag != null) // Provera da li je Tag postavljen
                {
                    int packageId = (int)selectedRow.Cells["nameTv"].Tag; // Dohvatanje ID-a paketa iz Tag svojstva odgovarajuće ćelije
                    MessageBox.Show("ID:" + packageId);
                    CombinedPackage comp = facade.getCombinedPackageByPackageID(packageId);
                    if (comp != null)
                    {
                        facade.removeCombinedPackage(comp.ID);
                    }
                    facade.removeTVPackage(packageId); // Poziv funkcije za uklanjanje paketa
                    showAllTvPacketsGrid.Rows.Remove(selectedRow); // Uklanjanje odabrane vrste iz DataGridView-a
                }
                else
                {
                    MessageBox.Show("ID paketa nije dostupan za brisanje.");
                }
            }
            else
            {
                // Handle the case when no row is selected
                MessageBox.Show("No row selected.");
            }
        }
       
        private void packetsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void UpdateUserView(string noviKlijent)
        {
            // Dodaj novog klijenta u listu klijenata na formi
            // Ako imate ListBox na formi gde prikazujete klijente, dodajte novog klijenta u tu ListBox
            // Na primer, ako ListBox zove showAllClientsListBox:

            showAllClientsListBox.Items.Add(noviKlijent);

            // Opciono: Postavite novog klijenta kao selektovanog u ListBox-u
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

        private void deleteInternetPackageButton_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = showAllInternetPacketsGrid.SelectedRows[0];
            if (selectedRow.Cells["nameInternet"].Tag != null) // Provera da li je Tag postavljen
            {
                int packageId = (int)selectedRow.Cells["nameInternet"].Tag; // Dohvatanje ID-a paketa iz Tag svojstva odgovarajuće ćelije
                CombinedPackage comp = facade.getCombinedPackageByPackageID(packageId);
                if (comp != null)
                {
                    facade.removeCombinedPackage(comp.ID);
                }
                facade.removeInternetPackage(packageId); // Poziv funkcije za uklanjanje paketa
                showAllInternetPacketsGrid.Rows.Remove(selectedRow); // Uklanjanje odabrane vrste iz DataGridView-a
            }
            else
            {
                MessageBox.Show("ID paketa nije dostupan za brisanje.");
            }
        }

        private void deleteCombinedPackageButton_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = showAllCombinedPacketsGrid.SelectedRows[0];
            if (selectedRow.Cells["nameCombined"].Tag != null) // Provera da li je Tag postavljen
            {
                int packageId = (int)selectedRow.Cells["nameCombined"].Tag; // Dohvatanje ID-a paketa iz Tag svojstva odgovarajuće ćelije
                facade.removeCombinedPackage(packageId); // Poziv funkcije za uklanjanje paketa
                showAllCombinedPacketsGrid.Rows.Remove(selectedRow); // Uklanjanje odabrane vrste iz DataGridView-a
            }
            else
            {
                MessageBox.Show("ID paketa nije dostupan za brisanje.");
            }
        }
    }

}
