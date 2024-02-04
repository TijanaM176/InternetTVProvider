using InternetTVProviderLibrary.SingletonPattern;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary
{
    internal class Queries
    {
        private DbConnection connection;

        public Queries(DbConnection connection)
        {
            this.connection = connection;
        }
    }
}
