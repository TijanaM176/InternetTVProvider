using InternetTVProviderLibrary;
using InternetTVProviderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.BuilderPattern
{
    public class ClientBuilder:IClientBuilder
    {
        private string Username;
        private string FirstName;
        private string LastName;
        private int Id;


        public IClientBuilder SetUsername(string username)
        {
            this.Username = username;
            return this;
        }

        public IClientBuilder SetIme(string ime)
        {
            this.FirstName = ime;
            return this;
        }

        public IClientBuilder SetPrezime(string prezime)
        {
            this.LastName = prezime;
            return this;
        }

        public IClientBuilder SetId(int id)
        {
            this.Id = id;
            return this;
        }


        public Client Build()
        {
            return new Client(Username, FirstName, LastName, Id);
        }

        Client IClientBuilder.Build()
        {
            throw new NotImplementedException();
        }

    }
}
