using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Models
{
    public class Klijent
    {
        public int Id { get; set; }
        public string Username {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Klijent(string username, string ime, string prezime, int id)
        {
            Username = username;
            FirstName = ime;
            LastName = prezime;
            Id = id;
        }

    }
}
