using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class accountreceipt : System.Web.UI.Page
    {
        lopdungchung ldc;
        public accountreceipt()
        {
            ldc = new lopdungchung();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            loaddata();
        }
        private void loaddata()
        {
            /*string sql = "select receiptID,paymentDetail,createdDate,methodPay,totalPrice from Receipt where customerID = '" + Session["customerID"] + "' ";*/
            string sql = "select top(8)* from Receipt where customerID = '" + Session["customerID"] + "' order by cast(receiptID as INT) desc";
            GridView1.DataSource = ldc.getdata(sql);
            GridView1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string a = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("account_detail_recetipt.aspx?id="+a);
        }
    }
}