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
using ClassLibrary3;
using ClassLibrary3.Add_Edit_Remove;

namespace DentalClinic
{
    public partial class Form3 : Form
    {
        string connStr = "", sqlS = "";
        SqlConnection sqlConn;
        SqlCommand sqlCmd;
        DataTable dT;  
        SqlDataAdapter sqlAdap;

        public Form3()
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
                MessageBox.Show("ادخل رقم السجل المراد التعديل عليه");
            }
            public void SuccessEvent1()
            {
                MessageBox.Show("تمت العملية بنجاح ");
            }
            public void FailEvent1()
            {
                MessageBox.Show("فشلت العملية ");
            }
            public void TestTextbox(TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5, TextBox t6, TextBox t7, TextBox t8, TextBox t9, TextBox t10)
            {
                if (t1.Text == "" && t2.Text == "" && t3.Text == "" && t4.Text == "" && t5.Text == "" && t6.Text == "" && t7.Text == "" && t8.Text == "" && t9.Text == "" && t10.Text == "")
                {
                    EmptyMessageEvent();
                }
            }
       
            public void TestTextbox(TextBox t1)
            {
                if (t1.Text == "" )
                {
                    EmptyMessageEvent();
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


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[0].Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           


            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "")
            {

                try
                {
                    if (radioButton1.Checked == true && radioButton3.Checked == true)//اذا الراديو الاولى مفعلة والتالتي 
                    {
                        add_edit_remove.Execute("insert into [medical_record]([id],[patient_name],[age],[phone],[patient_gender],[housing_candition],[address_sick],[date_visit],[date_review],[date_expiry],[pharmaceutical],[pathological_case]) values ('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + "," + textBox4.Text + ",'male','resident','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')");
                        dataGridView1.DataSource = add_edit_remove.GetData("select * from medical_record");
                    }
                    else if (radioButton1.Checked == true && radioButton4.Checked == true)
                    {
                        add_edit_remove.Execute("insert into [medical_record]([id],[patient_name],[age],[phone],[patient_gender],[housing_candition],[address_sick],[date_visit],[date_review],[date_expiry],[pharmaceutical],[pathological_case]) values ('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + "," + textBox4.Text + ",'male','displaced','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')");
                        dataGridView1.DataSource = add_edit_remove.GetData("select * from medical_record");
                    }
                    else if (radioButton2.Checked == true && radioButton3.Checked == true)
                    {
                        add_edit_remove.Execute("insert into [medical_record]([id],[patient_name],[age],[phone],[patient_gender],[housing_candition],[address_sick],[date_visit],[date_review],[date_expiry],[pharmaceutical],[pathological_case]) values ('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + "," + textBox4.Text + ",'feminine','resident','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')");
                        dataGridView1.DataSource = add_edit_remove.GetData("select * from medical_record");
                    }
                    else if (radioButton2.Checked == true && radioButton4.Checked == true)
                    {
                        add_edit_remove.Execute("insert into [medical_record]([id],[patient_name],[age],[phone],[patient_gender],[housing_candition],[address_sick],[date_visit],[date_review],[date_expiry],[pharmaceutical],[pathological_case]) values ('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + "," + textBox4.Text + ",'feminine','displaced','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')");
                        dataGridView1.DataSource = add_edit_remove.GetData("select * from medical_record");
                    }

                    EventMessage EE = new EventMessage();//الحدث
                    EE.SuccessEvent += new Message(EE.SuccessEvent1);//
                    EE.success();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("المريض موجود مسبقا");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                }

            }
            else
            {
                EventMessage EE = new EventMessage();
                EE.EmptyMessageEvent += new Message(EE.EventMessageAllFieldEmpty);
                EE.TestTextbox(textBox1,textBox2,textBox3,textBox4,textBox5,textBox6,textBox7,textBox8,textBox9,textBox10);


            }
               







        }




        private void button5_Click(object sender, EventArgs e)
        { 
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = add_edit_remove.GetData("select * from medical_record");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
             if (textBox1.Text != "")
            {
               
                DialogResult r = MessageBox.Show("سيتم التعديل على الحقول التي ملأتها ماعدا رقم السجل", "تعديل", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (r == DialogResult.OK)
                {
                    try
                    {

                        if (dataGridView1.CurrentRow != null)
                        {

                            if (radioButton1.Checked == true && radioButton3.Checked == true)
                            {
                                add_edit_remove.Execute("UPDATE [medical_record] set patient_name='" + textBox2.Text + "',age='" + Convert.ToInt32(textBox3.Text) + "',phone='" + textBox4.Text + "',patient_gender='" + "male" + "',housing_candition='" + "resident" + "',address_sick='" + textBox5.Text + "',date_visit='" + textBox6.Text + "',date_review='" + textBox7.Text + "',date_expiry='" + textBox8.Text + "',pharmaceutical='" + textBox9.Text + "' ,pathological_case='" + textBox10.Text + "' WHERE (id='" + textBox1.Text + "')");
                                dataGridView1.DataSource = add_edit_remove.GetData("select * from medical_record");

                            }
                            else if (radioButton1.Checked == true && radioButton4.Checked == true)
                            {
                                add_edit_remove.Execute("UPDATE [medical_record] set patient_name='" + textBox2.Text + "',age='" + Convert.ToInt32(textBox3.Text) + "',phone='" + textBox4.Text + "',patient_gender='" + "male" + "',housing_candition='" + "displaced" + "',address_sick='" + textBox5.Text + "',date_visit='" + textBox6.Text + "',date_review='" + textBox7.Text + "',date_expiry='" + textBox8.Text + "',pharmaceutical='" + textBox9.Text + "' ,pathological_case='" + textBox10.Text + "' WHERE (id='" + textBox1.Text + "')");
                                dataGridView1.DataSource = add_edit_remove.GetData("select * from medical_record");
                            }
                            else if (radioButton2.Checked == true && radioButton3.Checked == true)
                            {
                                add_edit_remove.Execute("UPDATE [medical_record] set patient_name='" + textBox2.Text + "',age='" + Convert.ToInt32(textBox3.Text) + "',phone='" + textBox4.Text + "',patient_gender='" + "feminine" + "',housing_candition='" + "resident" + "',address_sick='" + textBox5.Text + "',date_visit='" + textBox6.Text + "',date_review='" + textBox7.Text + "',date_expiry='" + textBox8.Text + "',pharmaceutical='" + textBox9.Text + "' ,pathological_case='" + textBox10.Text + "' WHERE (id='" + textBox1.Text + "')");
                                dataGridView1.DataSource = add_edit_remove.GetData("select * from medical_record");



                            }
                            else if (radioButton2.Checked == true && radioButton4.Checked == true)
                            {
                                add_edit_remove.Execute("UPDATE [medical_record] set patient_name='" + textBox2.Text + "',age='" + Convert.ToInt32(textBox3.Text) + "',phone='" + textBox4.Text + "',patient_gender='" + "feminine" + "',housing_candition='" + "displaced" + "',address_sick='" + textBox5.Text + "',date_visit='" + textBox6.Text + "',date_review='" + textBox7.Text + "',date_expiry='" + textBox8.Text + "',pharmaceutical='" + textBox9.Text + "' ,pathological_case='" + textBox10.Text + "' WHERE (id='" + textBox1.Text + "')");
                                dataGridView1.DataSource = add_edit_remove.GetData("select * from medical_record");
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
            dataGridView1.DataSource = add_edit_remove.GetData("select * from medical_record");
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult r = MessageBox.Show("سيتم الحذف بناء على رقم السجل المدخل", "حذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (r == DialogResult.OK)
                {
                    try
                    {
                        if (dataGridView1.CurrentRow != null)
                        {
                            add_edit_remove.Execute("delete from medical_record where id=" + textBox1.Text);
                            dataGridView1.DataSource = add_edit_remove.GetData("select * from medical_record");
                        }
                        EventMessage EE = new EventMessage();
                        EE.SuccessEvent += new Message(EE.SuccessEvent1);
                        EE.success();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";

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
                MessageBox.Show("ادخل رقم المريض المراد حذفه");
            }
            dataGridView1.DataSource = add_edit_remove.GetData("select * from medical_record");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Enter id");
            }
        }





       

        

       
     

        private void button6_Click_1(object sender, EventArgs e)
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
                    textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "male") 
                    {
                        radioButton1.Checked = true;
                    }
                    else if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "feminine")
                    {
                        radioButton2.Checked = true;
                    }
                    else if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "resident")
                    {
                        radioButton3.Checked = true;
                    }
                   else if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "displaced")
                    {
                        radioButton4.Checked = true;
                    }
                    textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    textBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    textBox8.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    textBox9.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    textBox10.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                }
                else
                {
                    MessageBox.Show("المريض غير موجود");
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                }


            }
            else
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
            }
        }

 
       
    }

    }

