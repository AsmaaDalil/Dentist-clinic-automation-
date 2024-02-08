
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary3
{
    namespace Add_Edit_Remove
    {

        public class add_edit_remove
        {
            static SqlConnection connstr = new SqlConnection(@"Data Source=SOHAYLA-BAKRO\SQLEXPRESS; Initial Catalog=Project;Integrated Security = True");// للاتصال 
            static public void open()
            {
                if (connstr.State == ConnectionState.Closed)//اذا القاعدة مغلقة 
                {
                    connstr.Open();//افتحها
                }
            }
            static public void close()
            {
                if (connstr.State == ConnectionState.Open)
                {
                    connstr.Close();
                }
            }
            static public DataTable GetData(string Query)//دالة للعرض لبجدوب استدعيها بكل مكان 
            {
                open();
                SqlCommand cmd = new SqlCommand(Query, connstr);//يقوم بوضع التعليمة 
                SqlDataReader reader = cmd.ExecuteReader();//كلاس قراءة السطر والخلايا 
                DataTable dt = new DataTable();//كلاس يحفظ الجدول الذي سنعرضه 
                dt.Load(reader);//بعد مايحمل عم يقرا 
                close();
                return dt;//برجعلي جدول 


            }
            static public void Execute(string Query)//دالة للتعديل والاضافة والحذف 
            {
                open();
                SqlCommand cmd = new SqlCommand(Query, connstr);//يقوم بوضع التعليمة 
                cmd.ExecuteNonQuery();//لمعالجة التعليمة وتنفيذها 
                close();
            }
            static public DataTable SerchById(string id)
            {
                
                string Query = string.Format("select * from invoice where id = '{0}'",id);
                open();
                SqlCommand cmd = new SqlCommand(Query, connstr);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                close();
                return dt;

            }
        }
    }
   
}
