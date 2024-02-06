using InternetTVProviderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.BuilderPattern
{
    public class InternetPackageBuilder : IPackageBuilder
    {
        private int id;
        private string name;
        private double price;
        private int internetSpeed;
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

        public void SetInternetSpeed(int internetSpeed)
        {
            this.internetSpeed = internetSpeed;
        }

        public void SetTypeID(int typeID)
        {
            this.typeID = typeID;
        }

        public InternetPackage Build()
        {
            return new InternetPackage(id, name, price, internetSpeed, typeID);
        }

    }
}
