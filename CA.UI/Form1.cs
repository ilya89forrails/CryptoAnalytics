using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CA.Scrapper.Core;
using CA.Scrapper.Core.Marketcap;
using CA.DAL;

namespace CA.UI
{
    public partial class Form1 : Form
    {
        ParserWorker<Cryptocurrency[]> parser;


        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<Cryptocurrency[]>(
                     new MarketcapParser()
                );

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnCompleted(object arg1)
        {
            MessageBox.Show("All work is done!");
        }

        private void Parser_OnNewData(object arg1, Cryptocurrency[] arg2)
        {
            ListIems.Items.AddRange(arg2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            parser.Settings = new MarketcapSettings((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            parser.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }
    }
}
