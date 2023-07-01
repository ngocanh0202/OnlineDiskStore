using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lopdungchung ldc = new lopdungchung();
            string sql = "select * from Customer";
            GridView1.DataSource = ldc.getdata(sql);
            GridView1.DataBind();
        }
    }
}