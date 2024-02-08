using System;
using System.Windows.Forms;
namespace DealWithDelgate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Button mybutton = new Button();
            mybutton.Location = new System.Drawing.Point(10, 10);
            mybutton.Size = new System.Drawing.Size(100, 30);
            mybutton.Text = "myButton";
            mybutton.Click += new EventHandler(myButton_Click);
            this.Controls.Add(mybutton);   
        }
        private void myButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button Clicked!");
        }
        public double ConvertTLToD(double tl)
        {
            return tl * 20.70;
        }
        public double  ConvertEUToD(double eu)
        {
            return eu * 1.09;
        }
        public double ConvertSPToD(double sp)
        {
            return sp * 7990;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double amount = 0.0;
            double result = 0.0;
            try
            {
                amount = Convert.ToDouble(textBox1.Text);
                if (amount > 0)
                {
                    if (comboBox1.Text == "TL")
                        result = ConvertTLToD(amount);
                    else if (comboBox1.Text == "EU")
                        result = ConvertEUToD(amount);
                    else if (comboBox1.Text == "SP")
                        result = ConvertSPToD(amount);
                    else
                        comboBox1.Text = "Enter Coin";
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error");
            }
            textBox2.Text = result.ToString();
        }
        public delegate double myDelegate(double value);
        private void button2_Click(object sender, EventArgs e)
        {
            double amount = 0.0;
            double result = 0.0;
            myDelegate aDelegate;
            try
            {
                amount = Convert.ToDouble(textBox1.Text);
                if (amount > 0)
                {
                    if (comboBox1.Text == "TL")
                    {
                        aDelegate = new myDelegate(ConvertTLToD);
                        result = aDelegate(amount);
                    }
                    else if (comboBox1.Text == "EU")
                    {
                        aDelegate = new myDelegate(ConvertEUToD);
                        result = aDelegate(amount);
                    }
                    else if (comboBox1.Text == "SP")
                    {
                        aDelegate = new myDelegate(ConvertSPToD);
                        result = aDelegate(amount);
                    }
                    else
                        comboBox1.Text = "Enter Coin";
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error");
            }
            textBox2.Text = result.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double amount = 0.0;
            double result = 0.0;
            myDelegate aDelegate =null;
            try
            {
                amount = Convert.ToDouble(textBox1.Text);
                if (amount > 0)
                {
                    if (comboBox1.Text == "TL")
                    {
                        aDelegate = new myDelegate(ConvertTLToD);
                    }
                    else if (comboBox1.Text == "EU")
                    {
                        aDelegate = new myDelegate(ConvertEUToD);
                    }
                    else if (comboBox1.Text == "SP")
                    {
                        aDelegate = new myDelegate(ConvertSPToD);
                    }
                    else
                        comboBox1.Text = "Enter Coin";

                    result = aDelegate(amount);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error");
            }
            textBox2.Text = result.ToString();
        }
    }
}
