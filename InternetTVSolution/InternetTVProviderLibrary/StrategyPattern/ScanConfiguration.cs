using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.StrategyPattern
{
    internal class ScanConfiguration : IStrategy
    {
        public static string configurationPath;
        public static string providerName;
        private string[] fileData;

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
