using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace OnlineDiskStore
{
    public class lopdungchung
    {
        string connectionstring;
        public SqlConnection cn;
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
        // có thông báo
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
        // không có thông báo
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
        // đọc một coloum 
        public string read(string sql, string column)
        {
            SqlCommand cm = new SqlCommand(sql,cn);
            SqlDataReader dr;
            string readcolumn = "";
            cn.Open ();
            dr = cm.ExecuteReader();
            if (dr.Read())
            {
                readcolumn = dr[column].ToString();
            }
            dr.Close();
            cn.Close();
            return readcolumn;
        }
        // đọc 2 coloum 
        /*public List<string> read2(string sql,string column1, string column2)
        {
            SqlCommand cm = new SqlCommand(sql, cn);
            SqlDataReader dr;
            List<string> list = new List<string>();
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                list.Add(dr[column1].ToString());
                list.Add(dr[column2].ToString());
            }
            dr.Close(); 
            cn.Close();
            return list;
        }*/
    }
}