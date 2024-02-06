using InternetTVProviderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.BuilderPattern
{
    public class CombinedPackageBuilder : IPackageBuilder
    {
        private int id;
        private string name;
        private double price;
        private int tvPackageID;
        private int internetPackageID;
        private int typeID;

        public void SetID(int id)
        {
            this.id = id;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetPrice(double price)
        {
            this.price = price;
        }

        public void SetTvPackageID(int tvPackageID)
        {
            this.tvPackageID = tvPackageID;
        }

        public void SetInternetPackageID(int internetPackageID)
        {
            this.internetPackageID = internetPackageID;
        }

        public void SetTypeID(int typeID)
        {
            this.typeID = typeID;
        }

        public CombinedPackage Build()
        {
            return new CombinedPackage(id, name, price, tvPackageID, internetPackageID, typeID);
        }
    }
}
