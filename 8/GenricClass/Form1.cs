using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace GenricClass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string s1="", s2="";
            product<int, string> newP = new product<int, string>(1,"342423");
            newP.print(ref s1, ref s2);
            textBox1.Text = s1 + " " + s2;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            initDG(dataGridView1);
            insertValueDG(dataGridView1);
        }
        public void initDG(DataGridView dGV)
        {
            dGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGV.RightToLeft = RightToLeft.Yes;
            dGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGV.AllowUserToAddRows = false;
            foreach (Control previous in Form1.ActiveForm.Controls)
            {
                if (previous.GetType() == typeof(DataGridView))
                {
                    dGV.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
                    dGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightBlue;
                    dGV.AlternatingRowsDefaultCellStyle.BackColor = Color.LimeGreen;
                }
            }
        }
        public void insertValueDG(DataGridView dGV)
        {
            List<product<int, string>> product = new List<product<int, string>>();
            product.Add(new product<int, string>(1, "432432"));
            product.Add(new product<int, string>(2, "234323"));
            product.Add(new product<int, string>(3, "535553"));
            product.Add(new product<int, string>(4, "565523"));
            dGV.DataSource = product;
            dGV.Columns[0].HeaderText = "رقم المنتج";
            dGV.Columns[1].HeaderText = "الرقم التسلسلي";
        }
    } 
}
