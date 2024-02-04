﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.BuilderPattern
{
    public interface IPackageBuilder
    {
        IPackageBuilder SetID(int id);
        IPackageBuilder SetName(string name);
        IPackageBuilder SetPrice(double price);
        IPackageBuilder SetInternetSpeed(int internetSpeed);
        IPackageBuilder SetNumberOfChannels(int numberOfChannels);
        IPackageBuilder SetTypeID(int typeId);
        Package Build();
    }
}