using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace Threading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(CountNumbers);
            Thread thread2 = new Thread(buttonBackColor);
            Thread thread3 = new Thread(picBoxBackColor);
            thread1.Start();
            thread2.Start();
            thread3.Start();
            for (int i = 1; i <= 1000; i = i + 1)//i++
            {
                Application.DoEvents();
                textBox1.Text = "Main Thread: " + i.ToString();
                Thread.Sleep(10); //  1000 تأخير لمدة ثانية واحدة
            }
        }
        void CountNumbers()
        {
            for (int i = 1; i <= 1000; i = i + 2)
            {
                ThreadHelperClass.SetText(this, textBox2,"Secondary Thread: " + i.ToString());
                Thread.Sleep(10); 
            }
        }        
        void buttonBackColor()
        {
            for (int i = 1; i <= 1000; i = i + 1)
            {
                if (i % 2 == 0)
                    button1.BackColor = Color.Red;
                else
                    button1.BackColor = Color.Blue;
                Thread.Sleep(100); 
            }
        }
        void picBoxBackColor()
        {
            for (int i = 1; i <= 1000; i = i + 1)
            {
                if (i % 2 == 0)
                    pictureBox1.BackColor = Color.Gold; 
                else
                    pictureBox1.BackColor = Color.BlueViolet;
                Thread.Sleep(100);
            }
        }
        public static class ThreadHelperClass
        {
            delegate void SetTextCallback(Form f, Control ctrl, string text);
            public static void SetText(Form form, Control ctrl, string text)
            {
                // InvokeRequired required compares the thread ID of the 
                // calling thread to the thread ID of the creating thread. 
                // If these threads are different, it returns true. 
                if (ctrl.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    form.Invoke(d, new object[] { form, ctrl, text });
                }
                else
                {
                    ctrl.Text = text;
                }
            }
        }
    }
}