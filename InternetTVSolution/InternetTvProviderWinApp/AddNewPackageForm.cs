using InternetTVProviderLibrary.FacadePattern;
using InternetTVProviderLibrary.Models;
using InternetTvProviderWinApp.MediatorPattern;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InternetTvProviderWinApp
{
    public partial class AddNewPackageForm : Form
    {
        QueryFacade facade;
        HomePageMediator mediator;

        public AddNewPackageForm(DbConnection connection, HomePageMediator mediator)
        {
            InitializeComponent();

            cancelButton.Click += closeAddNewPackage;
            addPackageButton.Click += addNewPackage;

            packageTypeComboBox.SelectedIndex = 0;
            packageTypeComboBox.SelectedIndexChanged += indexChanged;

            internetSpeedForInternetPackageLabel.Visible = false;
            internetSpeedForInternetPackageTextBox.Visible = false;

            internetSpeedLabel.Visible = false;
            internetSpeedTextBox.Visible = false;

            HomePage pocetnaStrana = new HomePage(connection);
            facade = new QueryFacade(connection);
            this.mediator = mediator;
        }
        

        private void indexChanged(object sender, EventArgs e)
        {
            int selectedIndex = packageTypeComboBox.SelectedIndex;

            if (selectedIndex == 0)
            {
                numberOfChannelsLabel.Visible = true;
                numberOfChannelsNumericUpDown.Visible = true;

                internetSpeedForInternetPackageLabel.Visible = false;
                internetSpeedForInternetPackageTextBox.Visible = false;

                internetSpeedLabel.Visible = false;
                internetSpeedTextBox.Visible = false;
            }
            else if (selectedIndex == 1)
            {
                numberOfChannelsLabel.Visible = false;
                numberOfChannelsNumericUpDown.Visible = false;

                internetSpeedForInternetPackageLabel.Visible = true;
                internetSpeedForInternetPackageTextBox.Visible = true;

                internetSpeedLabel.Visible = false;
                internetSpeedTextBox.Visible = false;
            }
            else if (selectedIndex == 2)
            {
                numberOfChannelsLabel.Visible = true;
                numberOfChannelsNumericUpDown.Visible = true;

                internetSpeedForInternetPackageLabel.Visible = false;
                internetSpeedForInternetPackageTextBox.Visible = false;

                internetSpeedLabel.Visible = true;
                internetSpeedTextBox.Visible = true;
            }
        }

        private void addNewPackage(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            double price = Convert.ToDouble(priceNumericUpDown.Value);
            int packageType = packageTypeComboBox.SelectedIndex + 1;
            int numberOfChannels;
            string internetSpeed;

            if (packageType == 1)
            {
                numberOfChannels = Convert.ToInt32(numberOfChannelsNumericUpDown.Value);
                TVPackage package = facade.addNewTVPackage(name, price, numberOfChannels, packageType);
                mediator.NotifyNewPackage(this, package);
            }
            else if (packageType == 2)
            {
                internetSpeed = internetSpeedForInternetPackageTextBox.Text;
                InternetPackage package = facade.addNewInternetPackage(name, price, internetSpeed, packageType);
                mediator.NotifyNewPackage(this, package);
            }
            else
            {
                numberOfChannels = Convert.ToInt32(numberOfChannelsNumericUpDown.Value);
                internetSpeed = internetSpeedTextBox.Text;

                int tvPackageID = facade.getTVPackageIdByNumOfChannels(numberOfChannels);
                int internetPackageID = facade.getInternetPackageIdByInternetSpeed(internetSpeed);

                CombinedPackage package = facade.addNewCombinedPackage(name, tvPackageID, internetPackageID, packageType);
                mediator.NotifyNewPackage(this, package);
            }


            this.Close();
        }

        private void closeAddNewPackage(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
