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

        public IPackageBuilder SetID(int id)
        {
            this.id = id;
            return this;
        }

        public IPackageBuilder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public IPackageBuilder SetPrice(double price)
        {
            this.price = price;
            return this;
        }

        public IPackageBuilder SetTvPackageID(int tvPackageID)
        {
            this.tvPackageID = tvPackageID;
            return this;
        }

        public IPackageBuilder SetInternetPackageID(int internetPackageID)
        {
            this.internetPackageID = internetPackageID;
            return this;
        }

        public IPackageBuilder SetTypeID(int typeID)
        {
            this.typeID = typeID;
            return this;
        }

        public Package Build()
        {
            return new CombinedPackage(id, name, price, tvPackageID, internetPackageID, typeID);
        }
    }
}
