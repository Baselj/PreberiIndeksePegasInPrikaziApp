using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Linq;

using System.Windows.Forms;

namespace PreberiIndekse
{
    
    class Program
    {
        
        static void Main(string[] args)
        {


            Application.Run(new mainDisplay());
            
            WebRequest request = WebRequest.Create("https://www.powernext.com");
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            request.Timeout = 100000;
            
            int sleep = 100;
            

            System.Threading.Thread.Sleep(sleep);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            System.Threading.Thread.Sleep(sleep);
            PreberiIndekse();
            PreberiIndekseWD();
            PreberiVolumne();
            
            Console.ReadLine();
            //System.IO.File.WriteAllText(@"C:\Delo\SOUP\2018-02-05PreberiIndeksePEGAS\PreberiIndekse\POPString.csv", Encoding.UTF8);

        }

        public static void PreberiIndekseWD()
        {
            int sleep = 100;
            List<IndeksWD> CeghWDEndOfDay = IndeksWD.VrniIndekseWD("https://www.powernext.com/data-feed/132737/141/66");
            System.Threading.Thread.Sleep(sleep);
            List<IndeksWD> EtfWDEndOfDay = IndeksWD.VrniIndekseWD("https://www.powernext.com/data-feed/132737/141/20");
            System.Threading.Thread.Sleep(sleep);
            List<IndeksWD> GplWDEndOfDay = IndeksWD.VrniIndekseWD("https://www.powernext.com/data-feed/132737/141/19");
            System.Threading.Thread.Sleep(sleep);
            List<IndeksWD> NcgWDEndOfDay = IndeksWD.VrniIndekseWD("https://www.powernext.com/data-feed/132737/141/18");
            System.Threading.Thread.Sleep(sleep);
            List<IndeksWD> PegNordWDEndOfDay = IndeksWD.VrniIndekseWD("https://www.powernext.com/data-feed/132737/141/516");
            System.Threading.Thread.Sleep(sleep);
            // List<IndeksWD> TrsWDEndOfDay = IndeksWD.VrniIndekseWD("https://www.powernext.com/data-feed/132737/141/50");

            List<IndeksWD> TtfWDEndOfDay = IndeksWD.VrniIndekseWD("https://www.powernext.com/data-feed/132737/141/17");
            System.Threading.Thread.Sleep(sleep);
            List<IndeksWD> ZtpWDEndOfDay = IndeksWD.VrniIndekseWD("https://www.powernext.com/data-feed/132737/141/48");
            System.Threading.Thread.Sleep(sleep);

            foreach (var indeks in CeghWDEndOfDay)
            {

                Console.WriteLine(indeks.dan.ToString());
                Console.WriteLine(indeks.OrgDan);
                if (CeghWDEndOfDay.Where(x => x.dan == indeks.dan).Count() != 0)
                    Console.WriteLine(CeghWDEndOfDay.Where(x => x.dan == indeks.dan).Average(c => c.cenaEurMWh));
                if (EtfWDEndOfDay.Where(x => x.dan == indeks.dan).Count() != 0)
                    Console.WriteLine(EtfWDEndOfDay.Where(x => x.dan == indeks.dan).Average(c => c.cenaEurMWh));
                if (GplWDEndOfDay.Where(x => x.dan == indeks.dan).Count() != 0)
                    Console.WriteLine(GplWDEndOfDay.Where(x => x.dan == indeks.dan).Average(c => c.cenaEurMWh));
                if (NcgWDEndOfDay.Where(x => x.dan == indeks.dan).Count() != 0)
                    Console.WriteLine(NcgWDEndOfDay.Where(x => x.dan == indeks.dan).Average(c => c.cenaEurMWh));
                if (PegNordWDEndOfDay.Where(x => x.dan == indeks.dan).Count() != 0)
                    Console.WriteLine(PegNordWDEndOfDay.Where(x => x.dan == indeks.dan).Average(c => c.cenaEurMWh));
                //if (TrsWDEndOfDay.Where(x => x.dan == indeks.dan).Count() != 0)
                   // Console.WriteLine(TrsWDEndOfDay.Where(x => x.dan == indeks.dan).Average(c => c.cenaEurMWh));
                if (TtfWDEndOfDay.Where(x => x.dan == indeks.dan).Count() != 0)
                    Console.WriteLine(TtfWDEndOfDay.Where(x => x.dan == indeks.dan).Average(c => c.cenaEurMWh));
                if(ZtpWDEndOfDay.Where(x => x.dan == indeks.dan).Count() != 0)
                Console.WriteLine(ZtpWDEndOfDay.Where(x => x.dan == indeks.dan).Average(c => c.cenaEurMWh));

            }
        }


        public static void PreberiVolumne()
        {
            int sleep = 100;
            List<Volumen> volumniCegh =Pegas.VrniVolumne("https://www.powernext.com/data-feed/132736/140/16").VrniZdruzeneVolumne();
            System.Threading.Thread.Sleep(sleep);
            List<Volumen> volumniCzvtp = Pegas.VrniVolumne("https://www.powernext.com/data-feed/132736/140/458").VrniZdruzeneVolumne();
            System.Threading.Thread.Sleep(sleep);
            List<Volumen> volumniEtf = Pegas.VrniVolumne("https://www.powernext.com/data-feed/132736/140/20").VrniZdruzeneVolumne();
            System.Threading.Thread.Sleep(sleep);
            List<Volumen> volumniGpl = Pegas.VrniVolumne("https://www.powernext.com/data-feed/132736/140/19").VrniZdruzeneVolumne();
            System.Threading.Thread.Sleep(sleep);
            List<Volumen> volumniNcg = Pegas.VrniVolumne("https://www.powernext.com/data-feed/132736/140/18").VrniZdruzeneVolumne();
            System.Threading.Thread.Sleep(sleep);
            List<Volumen> volumniPegnord = Pegas.VrniVolumne("https://www.powernext.com/data-feed/132736/140/516").VrniZdruzeneVolumne();
            System.Threading.Thread.Sleep(sleep);
            //List<Volumen> volumniTrs = Pegas.VrniVolumne("https://www.powernext.com/data-feed/132736/140/50").VrniZdruzeneVolumne();

            List<Volumen> volumniTtf = Pegas.VrniVolumne("https://www.powernext.com/data-feed/132736/140/17").VrniZdruzeneVolumne();
            System.Threading.Thread.Sleep(sleep);
            List<Volumen> volumniZtp = Pegas.VrniVolumne("https://www.powernext.com/data-feed/132736/140/48").VrniZdruzeneVolumne();
            System.Threading.Thread.Sleep(sleep);


            foreach (var volumen in volumniCegh)
            {


                Console.WriteLine(volumen.contractDay.ToString());
                Console.WriteLine(volumen.tipProdukta.ToString());
                Console.WriteLine(volumen.volumenMWh.ToString());

                if (volumniCzvtp.Find(x => x.contractDay == volumen.contractDay) != null)
                    Console.WriteLine(volumniCzvtp.Find(x => x.contractDay == volumen.contractDay).volumenMWh);
                if (volumniEtf.Find(x => x.contractDay == volumen.contractDay) != null)
                    Console.WriteLine(volumniEtf.Find(x => x.contractDay == volumen.contractDay).volumenMWh);
                if (volumniGpl.Find(x => x.contractDay == volumen.contractDay) != null)
                    Console.WriteLine(volumniGpl.Find(x => x.contractDay == volumen.contractDay).volumenMWh);
                if (volumniNcg.Find(x => x.contractDay == volumen.contractDay) != null)
                    Console.WriteLine(volumniNcg.Find(x => x.contractDay == volumen.contractDay).volumenMWh);
                if (volumniPegnord.Find(x => x.contractDay == volumen.contractDay) != null)
                    Console.WriteLine(volumniPegnord.Find(x => x.contractDay == volumen.contractDay).volumenMWh);
                //if (volumniTrs.Find(x => x.contractDay == volumen.contractDay) != null)
                    //Console.WriteLine(volumniTrs.Find(x => x.contractDay == volumen.contractDay).volumenMWh);
                if (volumniTtf.Find(x => x.contractDay == volumen.contractDay) != null)
                    Console.WriteLine(volumniTtf.Find(x => x.contractDay == volumen.contractDay).volumenMWh);
                if (volumniZtp.Find(x => x.contractDay == volumen.contractDay) != null)
                    Console.WriteLine(volumniZtp.Find(x => x.contractDay == volumen.contractDay).volumenMWh);
                Console.WriteLine();
            }
        }

        public static void PreberiIndekse()
        {
            int sleep = 100;
            List<Indeks> CeghDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/16");
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> CzVtpDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/458");
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> ETFDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/20");
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> GPLDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/19");
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> NCGDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/18");
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> PegNordDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/516");
            
            //List<Indeks> TrsDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/50");
            
            List<Indeks> TtfDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/17");
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> ZtpDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/48");
            System.Threading.Thread.Sleep(sleep);

            foreach (var indeks in CeghDaEndOfDay)
            {
                Console.WriteLine(indeks.Gas_Day.ToString());
                Console.WriteLine(indeks.PriceEurMWh.ToString());
                if (CzVtpDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day) != null)
                    Console.WriteLine(CzVtpDaEndOfDay.Find(x=>x.Gas_Day==indeks.Gas_Day).PriceEurMWh);
                if (ETFDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day) != null)
                    Console.WriteLine(ETFDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day).PriceEurMWh);
                if (GPLDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day) != null)
                    Console.WriteLine(GPLDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day).PriceEurMWh);
                if (NCGDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day) != null)
                    Console.WriteLine(NCGDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day).PriceEurMWh);
                if (PegNordDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day) != null)
                Console.WriteLine(PegNordDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day).PriceEurMWh);
                //if (TrsDaEndOfDay.Find(x => x.dan == indeks.dan) != null)
               // Console.WriteLine(TrsDaEndOfDay.Find(x => x.dan == indeks.dan).cenaEurMWh);
                if (TtfDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day) != null)
                    Console.WriteLine(TtfDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day).PriceEurMWh);
                if (ZtpDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day) != null)
                    Console.WriteLine(ZtpDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day).PriceEurMWh);
            }

            
            
        }

        public static void PreberiIndekseEGSI()
        {
            int sleep = 100;
            List<Indeks> CeghDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/16");
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> CzvtpDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/458");
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> EtfhDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/20");
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> GplDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/19");
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> NcgDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/18");
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> PegnordDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/516");
            System.Threading.Thread.Sleep(sleep);
            //List<Indeks> TrsDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/50");

            List<Indeks> TtfDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/17");
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> ZtpDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/48");
            System.Threading.Thread.Sleep(sleep);

            foreach (var indeks in CeghDaEndOfDay)
            {
                Console.WriteLine(indeks.Gas_Day.ToString());
                Console.WriteLine(indeks.PriceEurMWh.ToString());
                Console.WriteLine(CzvtpDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day).PriceEurMWh);
                Console.WriteLine(EtfhDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day).PriceEurMWh);
                Console.WriteLine(GplDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day).PriceEurMWh);
                Console.WriteLine(NcgDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day).PriceEurMWh);
                Console.WriteLine(PegnordDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day).PriceEurMWh);
                //Console.WriteLine(TrsDaEndOfDay.Find(x => x.dan == indeks.dan).cenaEurMWh);
                Console.WriteLine(TtfDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day).PriceEurMWh);
                Console.WriteLine(ZtpDaEndOfDay.Find(x => x.Gas_Day == indeks.Gas_Day).PriceEurMWh);

            }

        }



    }
}
