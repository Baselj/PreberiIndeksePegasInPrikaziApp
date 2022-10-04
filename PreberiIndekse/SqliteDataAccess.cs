using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreberiIndekse
{


    public  class SqliteDataAccess
    {
        private static string LoadConnectionString(string id= "PegasIndexes")
        {
            return ConfigurationManager.ConnectionStrings["PegasIndexes"].ConnectionString;
        }

        public static List<Indeks> LoadIndex()
        {
            List<Indeks> vrnjeniIndeksi = new List<Indeks>();
            
            using (var connection = new SQLiteConnection(LoadConnectionString()))
            {
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = "Select gas_day,gas_hub,type,gas_index from Gas_Index";
                    using (var reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Indeks indeks = new Indeks();
                            indeks.Gas_Day = Convert.ToDateTime(reader["gas_day"]);
                            indeks.Gas_Hub = reader["gas_hub"].ToString();
                            indeks.Product_Type = reader["type"].ToString();
                            indeks.PriceEurMWh = Convert.ToDecimal( reader["gas_index"]);
                            vrnjeniIndeksi.Add(indeks);
                            indeks = null;
                        }
                    }
                    connection.Close();

                }
            }
            return vrnjeniIndeksi;
        }


    }



}
