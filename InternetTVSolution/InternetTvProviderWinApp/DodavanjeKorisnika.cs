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
using InternetTVProviderLibrary.FacadePattern;
using InternetTVProviderLibrary.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InternetTvProviderWinApp
{
    public partial class AddNewClient : Form
    {
        QueryFacade userFacade;
        PocetnaStrana pocetna;
        public event EventHandler<DodavanjeKlijentaEventArgs> NoviKlijentDodat;
        public AddNewClient(PocetnaStrana pocetna,DbConnection connection)
        {
            InitializeComponent();
            this.pocetna = pocetna;
            userFacade = new QueryFacade(connection);
        }
        private void OnNoviKlijentDodat(string noviKlijent)
        {
            NoviKlijentDodat?.Invoke(this, new DodavanjeKlijentaEventArgs(noviKlijent));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Implementacija funkcionalnosti za čuvanje korisnika
            userFacade.addNewClient(textBox4.Text, textBox1.Text, textBox3.Text);
            
            this.Close(); // Zatvaranje trenutnog overlay prozora
            OnNoviKlijentDodat(textBox4.Text);
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
