using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Linq;

namespace PreberiIndekse
{
    //Drzi podatke
    public class Volumen
    {
        public DateTime contractDay { get; set; }
        public string tipProdukta { get; set; }
        public int volumenMWh { get; set; }
    }


    public static class Pegas
    {
        public static DateTime pretvoriStringVDan(string nepretvorjenDan)
        {
            if (nepretvorjenDan.Substring(0, 2) == "DA")
            {
                return DateTime.Parse(nepretvorjenDan.Substring(3, nepretvorjenDan.Length - 3));
            }
            else if (nepretvorjenDan.Substring(0, 2) == "WE")
            {
                return DateTime.Parse(nepretvorjenDan.Substring(3, nepretvorjenDan.IndexOf("/") - 3));
            }
            else if (nepretvorjenDan.Length >= 13) 
            {
                if (nepretvorjenDan.Substring(0, 13) == "Delivery Day ")
                {
                    return DateTime.Parse(nepretvorjenDan.Substring(13));
                }
                return DateTime.Parse(nepretvorjenDan.Substring(nepretvorjenDan.IndexOf("2")));

            }
            else 
            {
                return DateTime.Parse(nepretvorjenDan.Substring(nepretvorjenDan.IndexOf("2")));
            }


        }
        public static List<Volumen> VrniVolumne(string jsonNaslovVolumni)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(jsonNaslovVolumni);
            List<Volumen> vrnjeniVolumni = new List<Volumen>();

            // For that you will need to add reference to System.Runtime.Serialization
            using (Stream stream = request.GetResponse().GetResponseStream())
            {
                var jsonReader = JsonReaderWriterFactory.CreateJsonReader(stream, new System.Xml.XmlDictionaryReaderQuotas());
                var xmlPrebraniVolumni= XElement.Load(jsonReader);

                IEnumerable<XElement> dnevi = xmlPrebraniVolumni.Descendants("data").Elements();

                foreach (XElement dan in dnevi)
                {
                    
                    Volumen volumenDan = new Volumen();
                    volumenDan.contractDay = Pegas.pretvoriStringVDan(dan.Element("name").Value);
                    int volumenMwh;
                    if (int.TryParse(dan.Element("y").Value, out volumenMwh))
                    {
                        volumenDan.volumenMWh = volumenMwh;
                    }
                    
                    volumenDan.tipProdukta = dan.Element("name").Value.Substring(0, 2);
                
                    if (volumenDan.tipProdukta == "WE" )
                    { //dodaj 2 zapisa
                        Volumen volumenDanWE1 = new Volumen();
                        Volumen volumenDanWE2 = new Volumen();

                        volumenDanWE1.contractDay = Pegas.pretvoriStringVDan(dan.Element("name").Value);
                        volumenDanWE1.tipProdukta = "WE";
                        volumenDanWE1.volumenMWh = int.Parse(dan.Element("y").Value)/2;

                        volumenDanWE2.contractDay = volumenDanWE1.contractDay.AddDays(1);
                        volumenDanWE2.tipProdukta = "WE";
                        volumenDanWE2.volumenMWh = int.Parse(dan.Element("y").Value) / 2;

                        vrnjeniVolumni.Add(volumenDanWE1); vrnjeniVolumni.Add(volumenDanWE2);

                        volumenDanWE1 = null;
                        volumenDanWE2 = null;
                    }
                    else
                    {
                        vrnjeniVolumni.Add(volumenDan);
                    }
                    volumenDan = null;
                }
                
            }
            return vrnjeniVolumni;
        }

        public static List<Volumen> VrniZdruzeneVolumne(this List<Volumen> nezdruzeniVolumni)
        {
            List<Volumen> vrnjeniZdruzeniVolumni = new List<Volumen>();
            var datumi = nezdruzeniVolumni.OrderBy(s=>s.contractDay).Select(s => s.contractDay).Distinct();

            foreach (var datum in datumi)
            {
                Volumen volumenDan = new Volumen();
                volumenDan.contractDay = datum.AddDays(0);
                volumenDan.volumenMWh = nezdruzeniVolumni.Where(c => c.contractDay == datum).Sum(c => c.volumenMWh);
                volumenDan.tipProdukta = "DA";
                if (nezdruzeniVolumni.Where(c => (c.contractDay == datum) &&(c.tipProdukta == "WE")).Count() != 0 )
                {
                    volumenDan.tipProdukta = "WE";
                }

                vrnjeniZdruzeniVolumni.Add(volumenDan);
                volumenDan = null;
            }
            //v primeru da je WE lahko prepise napacne vrednosti
            //vrnjeniZdruzeniVolumni.RemoveRange(0, 3);
           // vrnjeniZdruzeniVolumni.RemoveRange(vrnjeniZdruzeniVolumni.Count() - 1, 1);
            return vrnjeniZdruzeniVolumni;
        }


    } 

}
