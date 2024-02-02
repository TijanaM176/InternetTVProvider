using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary
{
    public interface IClientBuilder
    {
        IClientBuilder SetUsername(string Username);
        IClientBuilder SetIme(string FirstName);
        IClientBuilder SetPrezime(string LastName);
        IClientBuilder SetId(int Id);
        Client Build();
    }
}
