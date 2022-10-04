using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        public static void IzbrisiVse()
        {
            using (var connection = new SQLiteConnection(LoadConnectionString()))
            {
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = String.Format("delete  from Gas_index");
                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }
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

        public static void SaveIndex(List<Indeks> indeks)
        {
            using (var connection = new SQLiteConnection(LoadConnectionString()))
            {
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open();

                    foreach (Indeks ind in indeks)
                    {
                        command.CommandText = String.Format("select gas_index from Gas_index where gas_day = '{0}' and gas_hub='{1}' and type ='{2}'", ind.Gas_Day.Date, ind.Gas_Hub, ind.Product_Type);
                        command.ExecuteNonQuery();
                        //if no string update
                        if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                        {
                            command.CommandText = String.Format("Insert into Gas_Index (gas_day,gas_hub,type,gas_index) values ('{0}', '{1}','{2}',{3})", ind.Gas_Day.Date, ind.Gas_Hub,ind.Product_Type, ind.PriceEurMWh.ToString().Replace(",", "."));
                            command.ExecuteNonQuery();
                        }
                        //otherwise update
                        else
                        {
                            command.CommandText = String.Format("update Gas_Index set gas_index = {3} where gas_day= '{0}' and gas_hub='{1}' and type = '{2}'", ind.Gas_Day.Date, ind.Gas_Hub, ind.Product_Type, ind.PriceEurMWh.ToString().Replace(",", ".")).Replace(",",".");
                            command.ExecuteNonQuery();
                        }

                    }
                    

                    connection.Close();

                }
            }
        }




    }



}
