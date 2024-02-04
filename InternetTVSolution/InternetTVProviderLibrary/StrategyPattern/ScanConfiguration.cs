using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.StrategyPattern
{
    internal class ScanConfiguration : IStrategy
    {
        private string configurationPath;
        private string providerName;
        private string[] fileData;

        public string getConfigurationPath()
        {
            return configurationPath;
        }

        public string getProviderName()
        {
            return providerName;
        }

        public void connectSQL()
        {
            try
            {
                fileData = File.ReadAllLines("C:\\GIT projekti\\DS\\tim-13\\InternetTVSolution\\InternetTVProviderLibrary\\StrategyPattern\\configurationSQL.txt");
                providerName = fileData[0];
                configurationPath = fileData[1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška pri čitanju fajla: " + ex.Message);
            }
        }
    }
}
