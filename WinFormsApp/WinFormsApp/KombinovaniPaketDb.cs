using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    internal class KombinovaniPaketDb : PaketDb
    {
        public override string setSelectAllQuery()
        {
            String query = @"SELECT *
                           FROM KombinovaniPaketi";

            return query;
        }

        public override List<Paket> executeSelectAllQuery(String query)
        {
            List<Paket> paketi = new List<Paket>();

            SqlCommand command = new SqlCommand(query, _connection);
            SqlDataReader reader = new SqlCommand().ExecuteReader();

            while(reader.Read())
            {
                paketi.Add(new KombinovaniPaket());
            /*    paketi.Add(new KombinovaniPaket(
                                               int.Parse(reader["id"].ToString()),
                                               int.Parse(reader["naziv"].ToString()),
                                               int.Parse(reader["cena"].ToString()),
                                               int.Parse(reader["tv_paket_id"].ToString()),
                                               int.Parse(reader["internet_paket_id"].ToString())
                   ));*/ 
            }

            return paketi;
        }

    }
}
