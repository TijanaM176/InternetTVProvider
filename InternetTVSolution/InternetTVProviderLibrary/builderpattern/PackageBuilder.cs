using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary
{
    public class PackageBuilder : IPackageBuilder
    {
        private int id;
        private string name;
        private double price;
        private int internetSpeed;
        private int numberOfChannels;
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

        public IPackageBuilder SetInternetSpeed(int internetSpeed)
        {
            this.internetSpeed = internetSpeed;
            return this;
        }

        public IPackageBuilder SetNumberOfChannels(int numberOfChannels)
        {
            this.numberOfChannels = numberOfChannels;
            return this;
        }

        public IPackageBuilder SetTypeID(int typeID)
        {
            this.typeID = typeID;
            return this;
        }

        public Package Build()
        {
            return new Package(id, name, price, numberOfChannels, internetSpeed, typeID);
        }
    }
}
