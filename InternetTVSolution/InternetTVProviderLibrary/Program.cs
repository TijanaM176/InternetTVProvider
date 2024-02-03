using InternetTVProviderLibrary.SingletonPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary
{
     class Program
    {

            static void Main()
            {
                DatabaseMenager databaseMenager = DatabaseMenager.Instance;

                //MYSQL
                string connectionString = "server=localhost;user=root;password=;database=InternetTVProvider";
                databaseMenager.ConnectToDatabase("mysql", connectionString);

            //SQLite
                string databasePath = @"C:\Users\risti\OneDrive\Desktop\database\InternetTVProvider.db";
                string sqliteConnectionString = "Data Source="+databasePath+";Version=3;";
                databaseMenager.ConnectToDatabase("sqlite", sqliteConnectionString);


        }


    }
}
