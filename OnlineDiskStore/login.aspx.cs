using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class login : System.Web.UI.Page
    {
        lopdungchung ldc;
        public login()
        {
            ldc = new lopdungchung(); 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
        }
        // Điều hướng đến trang đăng ký
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }
        // Đăng nhập
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select count(*) from Customer where customerUserName = '"+TextBox1.Text+"' and customerPassword = '"+TextBox2.Text+"'";
            int a = (int)ldc.count(sql);
            if (a == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Sai tên tài khoản hoặc mật khẩu')", true);
                return;
            }
            string idcustomer = "select customerID from Customer where customerUserName = '"+TextBox1.Text+"'";
            SqlDataReader dr;
            SqlCommand cm = new SqlCommand(idcustomer,ldc.cn);
            ldc.cn.Open();
            dr = cm.ExecuteReader();
            if (dr.Read())
            {
                Session["customerID"] = dr["customerID"];
            }
            dr.Close();
            ldc.cn.Close();
            string idcart = "select cartID from Cart where customerID = '" + Session["customerID"] +"'";
            Session["cartID"] = ldc.read(idcart, "cartID");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Đăng nhập thành công')", true);
            Response.Redirect("home-page.aspx");
        }

        protected void Image1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home-page.aspx");
        }
    }
}