using System;
using System.Windows.Forms;
using Math.SuMi;
using Math.MuDi;
namespace MathForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double n1=0;
        double n2=0;
        double res=0;
        string err = "";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                n1 = Convert.ToDouble(textBox1.Text);
                n2 = Convert.ToDouble(textBox2.Text);
                suMi s = new suMi();
                res = s.sum(n1, n2, ref err);
                if (err == "")
                {
                    textBox3.Text = res.ToString();
                }
            }
            catch (Exception er)
            {
                textBox3.Text = "0";
                MessageBox.Show(er.ToString()); //or MessageBox.Show("error");
            }
            finally
            {
                
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                n1 = Convert.ToDouble(textBox1.Text);
                n2 = Convert.ToDouble(textBox2.Text);
                suMi s = new suMi();
                s.mines(n1, ref n2, ref err);
                if (err == "")
                {
                    textBox3.Text = n2.ToString();
                }
            }
            catch (Exception er)
            {
                textBox3.Text = "0";
                MessageBox.Show(er.ToString()); //or MessageBox.Show("error");
            }
            finally
            {

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                n1 = Convert.ToDouble(textBox1.Text);
                n2 = Convert.ToDouble(textBox2.Text);
                muDi.multiply(n1, n2,out res, out err);
                if (err == "")
                {
                    textBox3.Text = res.ToString();
                }
            }
            catch (Exception er)
            {
                textBox3.Text = "0";
                MessageBox.Show(er.ToString()); //or MessageBox.Show("error");
            }
            finally
            {

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                n1 = Convert.ToDouble(textBox1.Text);
                n2 = Convert.ToDouble(textBox2.Text);
                muDi s = new muDi();
                s.divide(n1, n2, out err);
                res = s.res;
                if (err == "")
                {
                    textBox3.Text = res.ToString();
                }
            }
            catch (Exception er)
            {
                textBox3.Text = "0";
                MessageBox.Show(er.ToString()); //or MessageBox.Show("error");
            }
            finally
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
