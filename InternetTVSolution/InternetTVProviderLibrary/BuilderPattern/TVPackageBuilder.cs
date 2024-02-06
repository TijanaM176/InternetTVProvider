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
        public void SetTypeID(int typeID)
        {
            this.typeID = typeID;
        }
        public void SetNumberOfChanels(int numOfChanels)
        {
            this.numOfChanels = numOfChanels;
        }

        public Package Build()
        {
            return new TVPackage(id, name, price,numOfChanels,typeID);
        }
    }
}
