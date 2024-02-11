using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.FactoryPattern
{
    public interface IDatabaseConnectionFactory
    {
        DbConnection CreateConnection();
        void InitializeTables();
        void InsertDataInTables();

    }
}
