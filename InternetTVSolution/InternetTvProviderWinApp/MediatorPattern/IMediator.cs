using InternetTVProviderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTvProviderWinApp.MediatorPattern
{
    public interface IMediator
    {
        void NotifyNewClient(object sender, string ev);
        public void NotifyNewPackage(object sender, Package package);
    }
}
