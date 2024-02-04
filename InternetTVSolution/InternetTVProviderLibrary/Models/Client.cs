using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Username {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Client(string username, string firstname, string lastname, int id)
        {
            Username = username;
            FirstName = firstname;
            LastName = lastname;
            Id = id;
        }

    }
}
