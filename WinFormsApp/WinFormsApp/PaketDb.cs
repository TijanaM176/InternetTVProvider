using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    internal abstract class PaketDb
    {
        protected SqlConnection _connection = DatabaseMenager.Instance.Connection;

        public List<Paket> getPackages()
        {
            _connection.Open();
            String query = setSelectAllQuery();
            List<Paket> paketi = executeSelectAllQuery(query);
            _connection.Close();
            return paketi;
        }

        public abstract String setSelectAllQuery();
        public abstract List<Paket> executeSelectAllQuery(String query);

      /*  public void insertPackages(Paket noviPaket)
        {
            _connection.Open();
            String query = insertPackageQuery();
            executeInsertPackageQuery(query, noviPaket);
            _connection.Close();
        }*/

       // public abstract String insertPackageQuery();
       // public abstract void executeInsertPackageQuery(String query, Paket noviPaket);
    }
}
