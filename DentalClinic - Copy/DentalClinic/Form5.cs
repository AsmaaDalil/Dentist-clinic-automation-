using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DentalClinic
{
    public partial class Form5 : Form
    {
        string connStr = "", sqlS = "";
        SqlConnection sqlConn;
        SqlCommand sqlCmd;
        DataTable dT;
        SqlDataAdapter sqlAdap;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[1].Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source=SOHAYLA-BAKRO\SQLEXPRESS; Initial Catalog=Project;Integrated Security = True";
            sqlConn = new SqlConnection();
            sqlCmd = new SqlCommand();
            sqlAdap = new SqlDataAdapter();
            sqlConn.ConnectionString = connStr;
            sqlCmd.Connection = sqlConn;
            show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void show()
        {
            dT = new DataTable();
            sqlS = "select * from [invoice]";
            sqlCmd.CommandText = sqlS;
            sqlAdap.SelectCommand = sqlCmd;
            try
            {
                sqlConn.Open();
                sqlAdap.Fill(dT);
                dataGridView1.DataSource = dT;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ");
            }
            finally
            {
                sqlConn.Close();
            }
        }
    }
}
