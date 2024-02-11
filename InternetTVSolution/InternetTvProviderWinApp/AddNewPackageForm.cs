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
            TVPackageLabel.Visible = false;
            TVPackageComboBox.Visible = false;
            InternetPackageLabel.Visible = false;
            InternetPackageComboBox.Visible = false;

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

              
                TVPackageLabel.Visible = false;
                TVPackageComboBox.Visible = false;
                InternetPackageLabel.Visible = false;
                InternetPackageComboBox.Visible = false;
            }
            else if (selectedIndex == 1)
            {
                numberOfChannelsLabel.Visible = false;
                numberOfChannelsNumericUpDown.Visible = false;

                internetSpeedForInternetPackageLabel.Visible = true;
                internetSpeedForInternetPackageTextBox.Visible = true;

                internetSpeedLabel.Visible = false;
                internetSpeedTextBox.Visible = false;

            
                TVPackageLabel.Visible = false;
                TVPackageComboBox.Visible = false;
                InternetPackageLabel.Visible = false;
                InternetPackageComboBox.Visible = false;
            }
            else if (selectedIndex == 2)
            {
                numberOfChannelsLabel.Visible = false;
                numberOfChannelsNumericUpDown.Visible = false;

                internetSpeedForInternetPackageLabel.Visible = false;
                internetSpeedForInternetPackageTextBox.Visible = false;

                internetSpeedLabel.Visible = false;
                internetSpeedTextBox.Visible = false;

              
                TVPackageLabel.Visible = true;
                TVPackageComboBox.Visible = true;
                InternetPackageLabel.Visible = true;
                InternetPackageComboBox.Visible = true;

            
                FillComboBoxes();
            }
        }

        private void FillComboBoxes()
        {
            TVPackageComboBox.Items.Clear();
            InternetPackageComboBox.Items.Clear();

            Dictionary<int, string> tvPackages = new Dictionary<int, string>();
            List<Package> allTvPackages = facade.getAllPackages(1);
            foreach (Package package in allTvPackages)
            {
                tvPackages.Add(package.ID, package.Name);
            }

            Dictionary<int, string> internetPackages = new Dictionary<int, string>();
            List<Package> allInternetPackages = facade.getAllPackages(2);
            foreach (Package package in allInternetPackages)
            {
                internetPackages.Add(package.ID, package.Name);
            }

            TVPackageComboBox.DataSource = new BindingSource(tvPackages, null);
            TVPackageComboBox.DisplayMember = "Value";
            TVPackageComboBox.ValueMember = "Key";

            InternetPackageComboBox.DataSource = new BindingSource(internetPackages, null);
            InternetPackageComboBox.DisplayMember = "Value";
            InternetPackageComboBox.ValueMember = "Key";
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
                int tvPackageId = (int)TVPackageComboBox.SelectedValue;
                int internetPackageId = (int)InternetPackageComboBox.SelectedValue;

                CombinedPackage package = facade.addNewCombinedPackage(name, tvPackageId, internetPackageId, packageType);
                package.Price = price;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
