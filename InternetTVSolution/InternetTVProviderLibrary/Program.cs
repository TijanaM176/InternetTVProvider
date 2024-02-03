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
                string connectionString = "server=localhost;user=root;password=dizajniranje24;database=InternetTVProvider";
                databaseMenager.ConnectToDatabase("mysql", connectionString);

                //SQLite
                string sqliteConnectionString = "Data Source=InternetTVProvider.db;Version=3;";
                databaseMenager.ConnectToDatabase("sqlite", sqliteConnectionString);


        }


    }
}
