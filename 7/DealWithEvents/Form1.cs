using System;
using System.Windows.Forms;
namespace DealWithEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void PriceE();
        class LapTopShop
        {
            private string nameLapTop;
            private int priceLapTop;
            public event PriceE PPriceEvent;
            public string NameLapTop
            {
                get { return nameLapTop; }
                set { nameLapTop = value; }
            }
            public int PriceLapTop
            {
                get { return priceLapTop; }
                set { priceLapTop = value; }
            }

            public void order(int p)
            {
                if (p > priceLapTop)
                    PPriceEvent();
                priceLapTop = priceLapTop - p;
            }
            public void massgeEvent()
            {
                MessageBox.Show("Money not enough!!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LapTopShop p = new LapTopShop();
            p.NameLapTop = "computer";
            p.PriceLapTop = 150;
            p.PPriceEvent += new PriceE(p.massgeEvent);
            p.order(300);
            textBox1.Text= "remain :" + p.PriceLapTop.ToString();
        }
        TrackBar trackBar1;
        private void button2_Click(object sender, EventArgs e)
        {            
            trackBar1 = new TrackBar();
            trackBar1.Location = new System.Drawing.Point(66, 146);
            trackBar1.Maximum = 1000;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new System.Drawing.Size(618, 45);
            trackBar1.TabIndex = 2;
            trackBar1.Scroll += new System.EventHandler(trackBar1_Scroll);
            Controls.Add(trackBar1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LapTopShop p = new LapTopShop();
            p.NameLapTop = "Hp";
            p.PriceLapTop = trackBar1.Value;
            p.PPriceEvent += new PriceE(p.massgeEvent);
            p.order(300);
            textBox1.Text ="remain :"+ p.PriceLapTop.ToString();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Value quantity: " + trackBar1.Value;
        }
    }
}
