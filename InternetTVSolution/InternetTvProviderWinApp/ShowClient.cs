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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InternetTvProviderWinApp
{
    public partial class ShowClient : Form
    {
        DbConnection connection;
        QueryFacade facade;
        int client_id;

        public ShowClient(string username, DbConnection connection)
        {
            this.connection = connection;
            facade = new QueryFacade(connection);


            InitializeComponent();

            InternetTVProviderLibrary.Models.Client client = facade.getClientByUsername(username);

            if (client != null)
            {
                client_id = client.Id;
                label1.Text = "First Name: " + client.FirstName;
                label2.Text = "Last Name: " + client.LastName;
                label3.Text = "Username: " + client.Username;

                DisplaySubscriptions();

            }
            else
            {
                MessageBox.Show("Client not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }


        private void DisplaySubscriptions()
        {
            listView1.Items.Clear();

            List<Subscriptions> subscriptions = facade.getSubscriptionsByClientId(client_id);

            foreach (Subscriptions subscription in subscriptions)
            {
                ListViewItem item = new ListViewItem(subscription.name);
                item.SubItems.Add(subscription.price.ToString());
                //item.SubItems.Add(subscription.activated.ToString());
                
                string status = (subscription.activated == 1) ? "Active" : "Inactive";
                item.SubItems.Add(status);
                
                listView1.Items.Add(item);
            }

            double sum = facade.getAllSubscriptionsPriceByClient(client_id);
            label5.Text = "Total: " + sum.ToString("0.00") + "$";
        }



        private void ShowClient_Load(object sender, EventArgs e)
        {
            listView1.ItemActivate += ListView1_ItemActivate;

        }


        private void ListView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string selectedSubscriptionName = selectedItem.SubItems[0].Text;

                Subscriptions selectedSubscription = facade.getSubscriptionsByClientId(client_id).Find(subscription => subscription.name == selectedSubscriptionName);

                if (selectedSubscription != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to change the subscription status?", "Confirmation", MessageBoxButtons.OKCancel);


                    if (result == DialogResult.OK)
                    {
                        selectedSubscription.activated = (selectedSubscription.activated == 1) ? 0 : 1;

                        facade.updateSubscribedPackageByClientID(selectedSubscription);

                        selectedItem.SubItems[2].Text = (selectedSubscription.activated == 1) ? "Active" : "Inactive";

                        double sum = facade.getAllSubscriptionsPriceByClient(client_id);
                        label5.Text = "Total: " + sum.ToString("0.00") + "$";
                    }

                }
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            

        }
    }
}
