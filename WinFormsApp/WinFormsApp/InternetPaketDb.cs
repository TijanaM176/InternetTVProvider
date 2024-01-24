using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    internal class InternetPaketDb : PaketDb
    {
        public override string setSelectAllQuery()
        {
            String query = @"select *
                           from InternetPaket";

            return query;
        }

        public override List<Paket> executeSelectAllQuery(String query)
        {
            List<Paket> paketi = new List<Paket>();

            SqlCommand command = new SqlCommand(query, _connection);
            SqlDataReader reader = new SqlCommand().ExecuteReader();

            while (reader.Read())
            {
                paketi.Add(new InternetPaket());
                /*    paketi.Add(new InternetPaket(
                                                   int.Parse(reader["id"].ToString()),
                                                   int.Parse(reader["naziv"].ToString()),
                                                   int.Parse(reader["cena"].ToString()),
                                                   int.Parse(reader["brzina_interneta"].ToString())
                       ));*/
            }

            return paketi;
        }
    }
}
