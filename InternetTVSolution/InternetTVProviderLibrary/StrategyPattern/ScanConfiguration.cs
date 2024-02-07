using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.StrategyPattern
{
    internal class ScanConfiguration : IStrategy
    {
        public static string configurationString;
        public static string providerName;
        private string[] fileData;

        public void execute()
        {
            try
            {
                fileData = File.ReadAllLines("C:\\GIT projekti\\DS\\tim-13\\InternetTVSolution\\InternetTVProviderLibrary\\StrategyPattern\\configurationSQL.txt");

                if (fileData.Length < 2)
                {
                    providerName = "";
                    configurationString = "";
                }
                else
                {
                    providerName = fileData[0].Trim();
                    configurationString = fileData[1].Trim();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška pri čitanju fajla: " + ex.Message);
            }
        }

    }
}
