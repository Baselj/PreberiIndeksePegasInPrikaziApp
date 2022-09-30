using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace PreberiIndekse
{
    public class Indeks
    {
        public DateTime dan { get; set; }
        public string OrgDan { get; set; }
        public Decimal cenaEurMWh { get; set; }

        public void pretvoriStringVDecimalnoStevilo(string nepretvorjenoDecimalnoStevilo)
        {
            this.cenaEurMWh = Decimal.Parse(nepretvorjenoDecimalnoStevilo.Replace(".", ","));
        }

        //Mozni odgovori
        //DA 2018-01-12
        //WE 2018-01-13/14
        public void pretvoriStringVDan(string nepretvorjenDan)
        {
            if(nepretvorjenDan.Substring(0,2) == "DA")
            {
                this.dan = DateTime.Parse(nepretvorjenDan.Substring(3,nepretvorjenDan.Length -3));
            }
            else if (nepretvorjenDan.Substring(0, 2) == "WE")
            {
                this.dan = DateTime.Parse(nepretvorjenDan.Substring(3, nepretvorjenDan.IndexOf("/") - 3));
            }
            else
            {
                this.dan= DateTime.Parse(nepretvorjenDan.Substring(nepretvorjenDan.IndexOf("2")));
            }

      
        }
        public static List<Indeks> VrniIndekseDaAndWeEof(string jsonNaslovIndeksi)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(jsonNaslovIndeksi);
            List<Indeks> vrnjeniIndeksi = new List<Indeks>();

            // For that you will need to add reference to System.Runtime.Serialization
            using (Stream stream = request.GetResponse().GetResponseStream())
            {
                var jsonReader = JsonReaderWriterFactory.CreateJsonReader(stream, new System.Xml.XmlDictionaryReaderQuotas());
                var xmlPrebraniIndeksi = XElement.Load(jsonReader);
                int prvic = 0;

                IEnumerable<XElement> dnevi = xmlPrebraniIndeksi.Descendants("item");
                foreach (XElement dan in dnevi)
                {
                    if (dan.Element("name") != null)
                    {
                        Indeks indeks = new Indeks(); 
                        indeks.pretvoriStringVDecimalnoStevilo(dan.Element("y").Value);
                        indeks.pretvoriStringVDan(dan.Element("name").Value);

                        if (dan.Element("name").Value.Substring(0, 2) == "WE" )
                        {

                            indeks.dan = indeks.dan.AddDays(prvic++);

                        }
                        if (dan.Element("name").Value.Substring(0, 2) != "WE" )
                        {

                            prvic = 0;

                        }
                        indeks.OrgDan = dan.Element("name").Value;
                        vrnjeniIndeksi.Add(indeks);
                        indeks = null;
                    }
                }
            }
           // vrnjeniIndeksi.RemoveRange(0, 3);
            return vrnjeniIndeksi;
        }
    }
}
