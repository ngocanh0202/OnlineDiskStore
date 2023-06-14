using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class Master_page : System.Web.UI.MasterPage
    {
        lopdungchung ldc;
        public Master_page()
        {
            ldc = new lopdungchung();   
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home-page.aspx");
        }

        protected void cart_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["customerID"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Bạn chưa đăng nhập tài khoản')", true);
            }
            else
            {
                SqlDataReader dr;
                string sql = "select cartID from Cart where customerID = '" + Session["customerID"] +"'";
                string idcart = "";
                SqlCommand cm = new SqlCommand(sql, ldc.cn);
                ldc.cn.Open();
                dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    idcart = dr["cartID"].ToString();
                }
                ldc.cn.Close();
                Response.Redirect("cart.aspx?id="+idcart);
            }
            
        }
        // checklogin
        protected void account_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["customerID"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Response.Redirect("account.aspx");
            }
        }
    }
}