using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InternetTVProviderLibrary.FacadePattern;
using InternetTVProviderLibrary.Models;
using InternetTvProviderWinApp.MediatorPattern;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InternetTvProviderWinApp
{
    public partial class AddNewClient : Form
    {
        
        QueryFacade userFacade;
        HomePage pocetna;
        HomePageMediator mediator;

    public AddNewClient(HomePage pocetna,DbConnection connection, HomePageMediator mediator)
        {
            InitializeComponent();
            this.pocetna = pocetna;
            userFacade = new QueryFacade(connection);
            this.mediator = mediator;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Implementacija funkcionalnosti za čuvanje korisnika
            userFacade.addNewClient(textBox4.Text, textBox1.Text, textBox3.Text);
            mediator.NotifyNewClient(this, textBox4.Text);
            this.Close();
        }

        // Event handler za klik na dugme "Otkaži"
        private void button2_Click(object sender, EventArgs e)
        {
            // Implementacija funkcionalnosti za otkazivanje
            this.Close(); // Zatvaranje trenutnog overlay prozora
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
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
