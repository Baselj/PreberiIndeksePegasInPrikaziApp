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

    public class IndeksWD
    {
        public DateTime dan { get; set; }
        public string OrgDan { get; set; }
        public Decimal cenaEurMWh { get; set; }

        public void pretvoriStringVDecimalnoStevilo(string nepretvorjenoDecimalnoStevilo)
        {
            this.cenaEurMWh = Decimal.Parse(nepretvorjenoDecimalnoStevilo.Replace(".", ","));
        }

        //Mozni odgovori
        //WD 2018-02-18/02
        public void pretvoriStringVDan(string nepretvorjenDan)
        {

            

            if (nepretvorjenDan.Substring(nepretvorjenDan.Length-3, 3) == "/02" || nepretvorjenDan.Substring(nepretvorjenDan.Length - 3, 3) == "/01")
            {
                this.dan = DateTime.Parse(nepretvorjenDan.Substring(3, nepretvorjenDan.Length - 6));
            }
            else if (nepretvorjenDan.Substring(0, 2) =="WD" && nepretvorjenDan.Substring(nepretvorjenDan.Length - 1, 1) != "B")
            {
                this.dan = DateTime.Parse(nepretvorjenDan.Substring(3, nepretvorjenDan.Length-3 ));
            }
            else if (nepretvorjenDan.Substring(0, 2) == "WD" && nepretvorjenDan.Substring(nepretvorjenDan.Length - 1, 1) =="B")
            {
                this.dan = DateTime.Parse(nepretvorjenDan.Substring(3, nepretvorjenDan.Length - 7));
            }
            else
            {
                this.dan = DateTime.Parse(nepretvorjenDan.Substring(nepretvorjenDan.IndexOf("2")));
            }

        }
        public static List<IndeksWD> VrniIndekseWD(string jsonNaslovIndeksi)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(jsonNaslovIndeksi);
            List<IndeksWD> vrnjeniIndeksi = new List<IndeksWD>();

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
                        IndeksWD indeksWD = new IndeksWD();
                        indeksWD.pretvoriStringVDecimalnoStevilo(dan.Element("y").Value);
                        indeksWD.pretvoriStringVDan(dan.Element("name").Value);

                        indeksWD.OrgDan = dan.Element("name").Value;
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

