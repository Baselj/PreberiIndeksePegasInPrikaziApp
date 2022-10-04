using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace PreberiIndekse
{

    public class IndeksWD
    {/*
        public DateTime Gas_Day { get; set; }
        public string Gas_Hub { get; set; }
        public string Product_Type { get; set; }
        private string OrgDan { get; set; }
        public Decimal PriceEurMWh { get; set; }
        */
        public DateTime Gas_Day { get; set; }
        public string Gas_Hub { get; set; }
        public string Product_Type { get; set; }
        private string OrgDan { get; set; }
        public Decimal PriceEurMWh { get; set; }

        public void pretvoriStringVDecimalnoStevilo(string nepretvorjenoDecimalnoStevilo)
        {
            this.PriceEurMWh = Decimal.Parse(nepretvorjenoDecimalnoStevilo.Replace(".", ","));
        }

        //Mozni odgovori
        //WD 2018-02-18/02
        public void pretvoriStringVDan(string nepretvorjenDan)
        {

            

            if (nepretvorjenDan.Substring(nepretvorjenDan.Length-3, 3) == "/02" || nepretvorjenDan.Substring(nepretvorjenDan.Length - 3, 3) == "/01")
            {
                this.Gas_Day = DateTime.Parse(nepretvorjenDan.Substring(3, nepretvorjenDan.Length - 6));
            }
            else if (nepretvorjenDan.Substring(0, 2) =="WD" && nepretvorjenDan.Substring(nepretvorjenDan.Length - 1, 1) != "B")
            {
                this.Gas_Day = DateTime.Parse(nepretvorjenDan.Substring(3, nepretvorjenDan.Length-3 ));
            }
            else if (nepretvorjenDan.Substring(0, 2) == "WD" && nepretvorjenDan.Substring(nepretvorjenDan.Length - 1, 1) =="B")
            {
                this.Gas_Day = DateTime.Parse(nepretvorjenDan.Substring(3, nepretvorjenDan.Length - 7));
            }
            else
            {
                this.Gas_Day = DateTime.Parse(nepretvorjenDan.Substring(nepretvorjenDan.IndexOf("2")));
            }

        }
        public static List<Indeks> VrniIndekseWD(string jsonNaslovIndeksi, string gas_hub, string type)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(jsonNaslovIndeksi);
            List<Indeks> vrnjeniIndeksi = new List<Indeks>();

            // For that you will need to add reference to System.Runtime.Serialization
            using (Stream stream = request.GetResponse().GetResponseStream())
            {
                var jsonReader = JsonReaderWriterFactory.CreateJsonReader(stream, new System.Xml.XmlDictionaryReaderQuotas());
                var xmlPrebraniIndeksi = XElement.Load(jsonReader);


                IEnumerable<XElement> dnevi = xmlPrebraniIndeksi.Descendants("item");
                foreach (XElement dan in dnevi)
                {
                    if (dan.Element("name") != null)
                    {
                        Indeks indeksWD = new Indeks();
                        indeksWD.pretvoriStringVDecimalnoStevilo(dan.Element("y").Value);
                        indeksWD.pretvoriStringVDan(dan.Element("name").Value);

                        
                        indeksWD.Product_Type = type;
                        indeksWD.Gas_Hub = gas_hub;
                        vrnjeniIndeksi.Add(indeksWD);
                        indeksWD = null;
                    }
                }
            }
            //vrnjeniIndeksi.RemoveRange(0, 3);
            return vrnjeniIndeksi;
        }
    }
}

