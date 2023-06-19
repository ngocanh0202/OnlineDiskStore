using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class account1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // customer
        protected void Button1_Click(object sender, EventArgs e)
        {
            /*Response.Redirect("accountuser.aspx");*/
            Response.Redirect("accountuser.aspx");
        }
        // Hóa đơn
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("accountreceipt.aspx");
        }
        // Home
        protected void Image1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home-page.aspx");
        }
        // Thông tin cửa hàng
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("account_store.aspx");
        }
        //  Kho hàng
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("warehouse.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}