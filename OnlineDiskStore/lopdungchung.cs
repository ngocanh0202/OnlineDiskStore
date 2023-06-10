using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace OnlineDiskStore
{
    public class lopdungchung
    {
        string connectionstring;
        SqlConnection cn;
        public lopdungchung()
        {
            connectionstring = @"Data Source=NGOCANH\NGOCANH;Initial Catalog=OnlineDiskStore;Integrated Security=True";
            cn = new SqlConnection(connectionstring); 
        }
        public DataTable getdata(string a)
        {
            SqlDataAdapter da = new SqlDataAdapter(a, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void command(string sql, string inform,object a)
        {
            SqlCommand cm = new SqlCommand(sql, cn);
            cn.Open();
            try
            {
                cm.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock((Control)a, a.GetType(), "alerMessage", "alert('" + inform + "')", true);
            }
            catch {
                ScriptManager.RegisterClientScriptBlock((Control)a, a.GetType(), "alerMessage", "alert('Thất bại')", true);
            }
            
            cn.Close();

        }
        public void command2(string sql)
        {
            SqlCommand cm = new SqlCommand(sql,cn);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }
        public object count(string sql)
        {
            SqlCommand cm = new SqlCommand(sql, cn);
            cn.Open ();
            object a = cm.ExecuteScalar();
            cn.Close();
            return a;
        }
    }
}