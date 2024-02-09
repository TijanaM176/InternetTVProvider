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

        public AddNewSubscription(DbConnection connection)
        {
            InitializeComponent();

            cancelButton.Click += closeAddNewSub;
            addSubButton.Click += addNewSub;

            PocetnaStrana pocetnaStrana = new PocetnaStrana(connection);
            facade = new QueryFacade(connection);
        }

        public void addNewSub(object sender, EventArgs e)
        {
            int clientID = Convert.ToInt32(ClientIDTextBox);
            int packageID = Convert.ToInt32(PackageIDTextBox);
            string name = Convert.ToString(NameTextBox);
            double price = Convert.ToDouble(priceNumericUpDown.Value);
            int type = Convert.ToInt32(packageTypeTextBox);

            facade.insertNewSubscriptionForClientID(clientID, packageID, name, price, type);

            this.Close();
        }

        public void closeAddNewSub(object sender, EventArgs e)
        {
            this.Close();
        }
      
    }
}
