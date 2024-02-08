using System;
using System.Windows.Forms;
namespace Session4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Person p = new Person("Ahmad","Idleb",20);
            textBox1.Text = p.Display(2,"Hp");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            programmer p = new programmer("samer");
            textBox1.Text = p.DisplayName();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            developer d = new developer();
            textBox1.Text = d.DisplayName();
            textBox1.Text = textBox1.Text +"---" +d.DisplayCity();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Person p = new developer();
            textBox1.Text = p.DisplayName();
            textBox1.Text = textBox1.Text + "---" + p.DisplayCity();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Complex c1 = new Complex(3, 7);
            textBox1.Text = c1.Display(); 
            Complex c2 = new Complex(5, 2);
            textBox1.Text = textBox1.Text + "----" + c2.Display();
            Complex c3 = c1 + c2;
            textBox1.Text = textBox1.Text + "----" + c3.Display();
        }
    }
}
