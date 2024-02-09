using InternetTVProviderLibrary.FacadePattern;
using InternetTVProviderLibrary.Models;
using MySqlX.XDevAPI;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InternetTvProviderWinApp
{
    public partial class ShowClient : Form
    {
        DbConnection connection;
        QueryFacade facade;

        public ShowClient(string username, DbConnection connection)
        {
            this.connection = connection;
            facade = new QueryFacade(connection);
            int cliend_id;

            InitializeComponent();
            this.facade = facade;

            InternetTVProviderLibrary.Models.Client client = facade.getClientByUsername(username);

            if (client != null)
            {
                cliend_id = client.Id;
                label1.Text = "First Name: " + client.FirstName;
                label2.Text = "Last Name: " + client.LastName;
                label3.Text = "Username: " + client.Username;

                //DisplaySubscriptions();
            }
            else
            {
                MessageBox.Show("Client not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        /*
        private void DisplaySubscriptions()
        {

        }
        */

        private void ShowClient_Load(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}
