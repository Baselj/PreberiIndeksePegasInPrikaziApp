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



        }

        public static void PreberiIndekseWD()
        {
            int sleep = 100;
            List<Indeks> CeghWDEndOfDay = Indeks.VrniIndekseWD("https://www.powernext.com/data-feed/132737/141/66","CEGH","WD");
            SqliteDataAccess.SaveIndex(CeghWDEndOfDay);
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> EtfWDEndOfDay = Indeks.VrniIndekseWD("https://www.powernext.com/data-feed/132737/141/20","ETF", "WD");
            SqliteDataAccess.SaveIndex(EtfWDEndOfDay);
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> PegNordWDEndOfDay = Indeks.VrniIndekseWD("https://www.powernext.com/data-feed/132737/141/516", "CEGH", "WD");
            SqliteDataAccess.SaveIndex(PegNordWDEndOfDay);
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> TtfWDEndOfDay = Indeks.VrniIndekseWD("https://www.powernext.com/data-feed/132737/141/17", "CEGH", "WD");
            SqliteDataAccess.SaveIndex(TtfWDEndOfDay);
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> ZtpWDEndOfDay = Indeks.VrniIndekseWD("https://www.powernext.com/data-feed/132737/141/48", "CEGH", "WD");
            SqliteDataAccess.SaveIndex(ZtpWDEndOfDay);
            System.Threading.Thread.Sleep(sleep);

       
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

        }

        public static void PreberiIndekse()
        {
            int sleep = 100;
            List<Indeks> CeghDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/16", "CEGH", "DA");
            SqliteDataAccess.SaveIndex(CeghDaEndOfDay); 
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> CzVtpDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/458", "CZ-VTP", "DA");
            SqliteDataAccess.SaveIndex(CzVtpDaEndOfDay);
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> ETFDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/20","ETF", "DA");
            SqliteDataAccess.SaveIndex(ETFDaEndOfDay);
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> PegNordDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/516", "PEG NORD", "DA");
            SqliteDataAccess.SaveIndex(PegNordDaEndOfDay);
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> TtfDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/17", "TTF", "DA");
            SqliteDataAccess.SaveIndex(TtfDaEndOfDay);
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> ZtpDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132733/137/48", "ZTP", "DA");
            SqliteDataAccess.SaveIndex(ZtpDaEndOfDay);
            System.Threading.Thread.Sleep(sleep);


            
            
        }
        
        public static void PreberiIndekseEGSI()
        {
            int sleep = 100;
            List<Indeks> CeghDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/16", "CEGH", "DA-EGSI");
            SqliteDataAccess.SaveIndex(CeghDaEndOfDay);
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> CzvtpDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/458","CZ VTP", "DA-EGSI");
            SqliteDataAccess.SaveIndex(CeghDaEndOfDay);
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> EtfhDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/20", "ETF", "DA-EGSI");
            SqliteDataAccess.SaveIndex(CeghDaEndOfDay);
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> PegnordDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/516", "PEGNORD", "DA-EGSI");
            SqliteDataAccess.SaveIndex(CeghDaEndOfDay);
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> TtfDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/17", "TTF", "DA-EGSI");
            SqliteDataAccess.SaveIndex(CeghDaEndOfDay);
            System.Threading.Thread.Sleep(sleep);
            List<Indeks> ZtpDaEndOfDay = Indeks.VrniIndekseDaAndWeEof("https://www.powernext.com/data-feed/132735/139/48", "ZTP", "DA-EGSI");
            SqliteDataAccess.SaveIndex(CeghDaEndOfDay);
            System.Threading.Thread.Sleep(sleep);
        }



    }
}
