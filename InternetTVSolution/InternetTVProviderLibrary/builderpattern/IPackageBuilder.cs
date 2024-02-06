using InternetTVProviderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.BuilderPattern
{
    public interface IPackageBuilder
    {
        void SetID(int id);
        void SetName(string name);
        void SetPrice(double price);
        void SetTypeID(int typeId);
        //Package Build();
    }
}
