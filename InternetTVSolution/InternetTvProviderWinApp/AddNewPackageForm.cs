﻿using InternetTVProviderLibrary.FacadePattern;
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
    public partial class AddNewPackageForm : Form
    {
        QueryFacade facade;
        public AddNewPackageForm(DbConnection connection)
        {
            InitializeComponent();

            cancelButton.Click += closeAddNewPackage;
            addPackageButton.Click += addNewPackage;

            packageTypeComboBox.SelectedIndex = 0;
            packageTypeComboBox.SelectedIndexChanged += indexChanged;

            internetSpeedLabel.Visible = false;
            internetSpeedNumericUpDown.Visible = false;
        }

        private void indexChanged(object sender, EventArgs e)
        {
            int selectedIndex = packageTypeComboBox.SelectedIndex;

            if (selectedIndex == 0)
            {
                numberOfChannelsLabel.Visible = true;
                numberOfChannelsNumericUpDown.Visible = true;

                internetSpeedLabel.Visible = false;
                internetSpeedNumericUpDown.Visible = false;
            }
            else if (selectedIndex == 1)
            {
                numberOfChannelsLabel.Visible = false;
                numberOfChannelsNumericUpDown.Visible = false;

                internetSpeedLabel.Visible = true;
                internetSpeedNumericUpDown.Visible = true;
            }
            else if (selectedIndex == 2)
            {
                numberOfChannelsLabel.Visible = true;
                numberOfChannelsNumericUpDown.Visible = true;

                internetSpeedLabel.Visible = true;
                internetSpeedNumericUpDown.Visible = true;
            }
        }

        private void addNewPackage(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            double price = Convert.ToDouble(priceNumericUpDown.Value);
            int packageType = packageTypeComboBox.SelectedIndex + 1;
            int numberOfChannels;
            int internetSpeed;

            if (packageType == 1)
            {
                numberOfChannels = Convert.ToInt32(numberOfChannelsNumericUpDown.Value);
                facade.addNewTVPackage(name, price, numberOfChannels, packageType);
            }
            else if (packageType == 2)
            {
                internetSpeed = Convert.ToInt32(internetSpeedNumericUpDown.Value);
                facade.addNewInternetPackage(name, price, internetSpeed, packageType);
            }
            else
            {
                numberOfChannels = Convert.ToInt32(numberOfChannelsNumericUpDown.Value);
                internetSpeed = Convert.ToInt32(internetSpeedNumericUpDown.Value);
                // facade.addNewCombinedPackage(name, price, , packageType);   
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