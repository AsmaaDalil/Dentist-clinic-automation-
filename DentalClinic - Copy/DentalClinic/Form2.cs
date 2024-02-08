using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary3;
using ClassLibrary3.Add_Edit_Remove;

namespace DentalClinic
{
    public partial class Form2 : Form
    {
        string connStr = "", sqlS = "";
        SqlConnection sqlConn;
        SqlCommand sqlCmd;
        DataTable dT;
        SqlDataAdapter sqlAdap;
        public Form2()
        {
            InitializeComponent();
        }
        public delegate void Message();
        class EventMessage
        {
            public event Message EmptyMessageEvent;
            public event Message SuccessEvent;
            public event Message FailEvent;
            public void EventMessageAllFieldEmpty()
            {
                MessageBox.Show("املأ جميع الحقول");
            }
            public void EventMessageFieldEmpty()
            {
                MessageBox.Show("ادخل رقم الفاتورة المراد التعديل عليها");
            }
         
            public void SuccessEvent1()
            {
                MessageBox.Show("تمت العملية بنجاح ");
            }
            public void FailEvent1()
            {
                MessageBox.Show("الفاتورة غير موجودة ");
            }
            public void TestTextbox(TextBox t1, TextBox t2, ComboBox c1, TextBox t4)
            {
                if (t1.Text == "" && t2.Text == "" && c1.Text == "" && t4.Text == "" )
                {
                    EventMessageAllFieldEmpty();
                }
            }
            public void TestTextbox(TextBox t1)
            {
                if (t1.Text == "")
                {
                    EventMessageFieldEmpty();
                }
            }
            public void Failed()
            {

                FailEvent();

            }
            public void success()
            {

                SuccessEvent();

            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "" && textBox4.Text != "" )
            {

                try
                {

                    if (comboBox1.SelectedIndex == 0)
                    {
                        add_edit_remove.Execute("insert into [invoice]([id],[value],[currency_type],[date_pay]) values ('" + numericUpDown1.Value + "'," + textBox2.Text + ",'LT','" + textBox4.Text + "')");
                        dataGridView1.DataSource = add_edit_remove.GetData("select * from invoice");
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        add_edit_remove.Execute("insert into [invoice]([id],[value],[currency_type],[date_pay]) values ('" + textBox1.Text + "'," + textBox2.Text + ",'USD','" + textBox4.Text + "')");
                        dataGridView1.DataSource = add_edit_remove.GetData("select * from invoice");
                    }
                    else
                    {
                        add_edit_remove.Execute("insert into [invoice]([id],[value],[currency_type],[date_pay]) values ('" + textBox1.Text + "'," + textBox2.Text + ",'EUR','" + textBox4.Text + "')");
                        dataGridView1.DataSource = add_edit_remove.GetData("select * from invoice");
                    }
                    EventMessage EE = new EventMessage();
                    EE.SuccessEvent += new Message(EE.SuccessEvent1);
                    EE.success();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    textBox4.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(" الفاتورة موجودة مسبقاً");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    textBox4.Text = "";

                }
           
            }
            else 
            {
                EventMessage EE = new EventMessage();
                EE.EmptyMessageEvent += new Message(EE.EventMessageAllFieldEmpty);
                EE.TestTextbox(textBox1, textBox2,comboBox1, textBox4);
            }


            dataGridView1.DataSource = add_edit_remove.GetData("select * from invoice");

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
                EventMessage EE = new EventMessage();
                EE.FailEvent += new Message(EE.FailEvent1);
                EE.Failed();
            }
            finally
            {
                sqlConn.Close();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = add_edit_remove.GetData("select * from invoice");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            }
       
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult r = MessageBox.Show("سيتم الحذف بناء على رقم الفاتورة المدخل","حذف",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (r == DialogResult.OK)
                {
                    try
                    {
                        add_edit_remove.Execute("delete from invoice where id=" + textBox1.Text);
                        dataGridView1.DataSource = add_edit_remove.GetData("select * from medical_record");
                        EventMessage EE = new EventMessage();
                        EE.SuccessEvent += new Message(EE.SuccessEvent1);
                        EE.success();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox1.Text = "";
                        textBox4.Text = "";

                    }
                    catch (Exception ex)
                    {
                        EventMessage EE = new EventMessage();
                        EE.FailEvent += new Message(EE.FailEvent1);
                        EE.Failed();
                    }
               
                }
                
               
            }
            else
            {
                MessageBox.Show("ادخل رقم الفاتورة المراد حذفها");
            }
            dataGridView1.DataSource = add_edit_remove.GetData("select * from medical_record");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" )
            {
                DialogResult r = MessageBox.Show("سيتم التعديل على الحقول التي ملأتها عدا رقم الفاتورة", "تعديل", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (r == DialogResult.OK)
                {
                    try
                    {

                        if (dataGridView1.CurrentRow != null)
                        {
                            if (comboBox1.SelectedIndex == 0) {
                                add_edit_remove.Execute("UPDATE [invoice] set value='" + Convert.ToInt32(textBox2.Text) + "',currency_type='" + "LT" + "',date_pay='" + textBox4.Text + "' WHERE (id='" + textBox1.Text + "')");
                                dataGridView1.DataSource = add_edit_remove.GetData("select * from invoice");
                            }
                         else   if (comboBox1.SelectedIndex == 1)
                            {
                                add_edit_remove.Execute("UPDATE [invoice] set value='" + Convert.ToInt32(textBox2.Text) + "',currency_type='" + "USD" + "',date_pay='" + textBox4.Text + "' WHERE (id='" + textBox1.Text + "')");
                                dataGridView1.DataSource = add_edit_remove.GetData("select * from invoice");
                            }
                            else 
                            {
                                add_edit_remove.Execute("UPDATE [invoice] set value='" + Convert.ToInt32(textBox2.Text) + "',currency_type='" + "EUR" + "',date_pay='" + textBox4.Text + "' WHERE (id='" + textBox1.Text + "')");
                                dataGridView1.DataSource = add_edit_remove.GetData("select * from invoice");
                            }
                        }

                        EventMessage EE = new EventMessage();
                        EE.SuccessEvent += new Message(EE.SuccessEvent1);
                        EE.success();


                    }
                    catch (Exception ex)
                    {
                        EventMessage EE = new EventMessage();
                        EE.FailEvent += new Message(EE.FailEvent1);
                        EE.Failed();
                    }
                 
                }
               
            }
            else
            {
                EventMessage EE = new EventMessage();
                EE.EmptyMessageEvent += new Message(EE.EventMessageFieldEmpty);
                EE.TestTextbox(textBox1);
            }
            dataGridView1.DataSource = add_edit_remove.GetData("select * from invoice");
        }

 

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                DataTable dt = add_edit_remove.SerchById(textBox1.Text);
                DataView dv = new DataView(dt);
                dataGridView1.DataSource = dv;

                if (dataGridView1.CurrentRow != null)
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                   comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                }
                else
                {
                    MessageBox.Show("الفاتورة غير موجودة");
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    textBox4.Text = "";


                }


            }
            else
            {
                textBox2.Text = "";
                comboBox1.Text = "";
                textBox4.Text = "";


            }

            void ShowOnCondition()
            {
                dT = new DataTable();
                sqlS = "select * from [invoice]where id=" + textBox1.Text;
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
}
