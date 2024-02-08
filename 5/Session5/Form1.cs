using System;
using System.Windows.Forms;
namespace Session5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MyGraphics myGrph = new MyGraphics();
            myGrph.x = 50;
            myGrph.y = 50;
            myGrph.SetRectangleParms(150, 50);
            myGrph.DrawRectangle(this);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MyGraphics myGrph = new MyGraphics();
            myGrph.DrawButton(this);
        }
    }
}
