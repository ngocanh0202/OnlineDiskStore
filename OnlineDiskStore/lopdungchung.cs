using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
    }
}