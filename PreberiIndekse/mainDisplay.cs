using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreberiIndekse
{
    public partial class mainDisplay : Form
    {
        public mainDisplay()
        {
            InitializeComponent();
            
        }

        private void prenesiIndeksButton_Click(object sender, EventArgs e)
        {
            Program.PreberiIndekse();
            Program.PreberiIndekseEGSI();
            //Program.PreberiIndekseWD();
            displayIndeksGridView.DataSource = SqliteDataAccess.LoadIndex();
        }

        private void izvozCsvButton_Click(object sender, EventArgs e)
        {
            string strValue = "Gas_Day;Gas_Hub;Product_Type;PriceEurMWh";
            
            for (int i = 0; i < displayIndeksGridView.Rows.Count; i++)
            {
                for (int j = 0; j < displayIndeksGridView.Rows[i].Cells.Count; j++)
                {
                    if (!string.IsNullOrEmpty(displayIndeksGridView.Rows[i].Cells[j].Value.ToString()))
                    {
                        if (j > 0)
                            strValue = strValue + ";" + displayIndeksGridView.Rows[i].Cells[j].Value.ToString();
                        else
                        {
                            if (string.IsNullOrEmpty(strValue))
                                strValue = displayIndeksGridView.Rows[i].Cells[j].Value.ToString();
                            else
                                strValue = strValue + Environment.NewLine + displayIndeksGridView.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                // strValue = strValue + Environment.NewLine;
            }
            string strFile = Application.StartupPath + @"\PegasIndex.csv";

            if ( !string.IsNullOrEmpty(strValue))
            {
                File.WriteAllText(strFile, strValue);
            }
            Process.Start(Application.StartupPath);
        }

        private void prikaziIndeksButton_Click(object sender, EventArgs e)
        {
            displayIndeksGridView.DataSource = SqliteDataAccess.LoadIndex();
        }

        private void izbrisButton_Click(object sender, EventArgs e)
        {
            SqliteDataAccess.IzbrisiVse();
            displayIndeksGridView.DataSource = SqliteDataAccess.LoadIndex();
        }
    }
}

