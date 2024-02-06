using InternetTVProviderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.BuilderPattern
{
    public class TVPackageBuilder:IPackageBuilder
    {
        private int id;
        private string name;
        private double price;
        private int typeID;
        private int numOfChanels;

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
        public IPackageBuilder SetTypeID(int typeID)
        {
            this.typeID = typeID;
            return this;
        }
        public IPackageBuilder SetNumberOfChanels(int numOfChanels)
        {
            this.numOfChanels = numOfChanels;
            return this;
        }

        public Package Build()
        {
            return new TVPackage(id, name, price,numOfChanels,typeID);
        }
    }
}
