using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp34
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rectangle r = new Rectangle(5,4);
            textBox1.Text = r.GetArea().ToString();
            textBox2.Text = r.GetPerimeter().ToString();            
            textBox3.Text = r.PrintInfo();
            textBox4.Text = r.HelloShape();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Circle c = new Circle(5);
            textBox1.Text = c.GetArea().ToString();
            textBox2.Text = c.GetPerimeter().ToString();
            textBox3.Text = c.PrintInfo();
            textBox4.Text = c.HelloShape();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyCircle c = new MyCircle(5);
            textBox1.Text = c.GetArea().ToString();
            textBox2.Text = c.GetPerimeter().ToString();
            textBox3.Text = c.PrintInfo();
            textBox4.Text = c.HelloShapeNoVir();
        }
    }
}
