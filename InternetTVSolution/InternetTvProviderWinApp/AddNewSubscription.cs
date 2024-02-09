using InternetTVProviderLibrary.FacadePattern;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetTvProviderWinApp
{
    public partial class AddNewSubscription : Form
    {
        QueryFacade facade;
        ShowClient showClient;
        int clientID;

        public AddNewSubscription(DbConnection connection, int clientID, ShowClient showClient)
        {
            InitializeComponent();

            this.clientID = clientID;
            this.showClient = showClient;
            cancelButton.Click += closeAddNewSub;
            addSubButton.Click += addNewSub;

            HomePage pocetnaStrana = new HomePage(connection);
            facade = new QueryFacade(connection);
        }

        public void addNewSub(object sender, EventArgs e)
        {
            int packageID = Convert.ToInt32(PackageIDTextBox.Text);
            string name = NameTextBox.Text;
            double price = Convert.ToDouble(priceNumericUpDown.Value);
            int type = Convert.ToInt32(packageTypeTextBox.Text);

            if (int.TryParse(PackageIDTextBox.Text, out packageID))
            {
                facade.insertNewSubscriptionForClientID(clientID, packageID, name, price, type);
                showClient.DisplaySubscriptions();
            }
            else
            {
                MessageBox.Show("Ne postoji paket sa ID = " + PackageIDTextBox + "!");
            }

            this.Close();
        }

        public void closeAddNewSub(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
