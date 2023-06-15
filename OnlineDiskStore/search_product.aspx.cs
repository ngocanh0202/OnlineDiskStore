using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class search_product : System.Web.UI.Page
    {
        lopdungchung ldc;
        public search_product()
        {
            ldc = new lopdungchung();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            if(Request.QueryString["name"] != null)
            {
                search.Text = Request.QueryString["name"].ToString();
                loadsearch();
            }
        }
        private void loadsearch()
        {
            string sql = "SELECT * FROM Product WHERE productName LIKE '%" + Request.QueryString["name"].ToString() + "%' ";
            DataList1.DataSource = ldc.getdata(sql);
            DataList1.DataBind();
        }

        protected void image_Click(object sender, ImageClickEventArgs e)
        {
            if (search.Text != "")
            {
                string a = search.Text;
                Response.Redirect("search_product.aspx?name=" + a);
            }
        }

        protected void logo_Click(object sender, ImageClickEventArgs e)
        {
            //Server.Transfer("home-page.aspx");
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
                string sql = "select cartID from Cart where customerID = '" + Session["customerID"] + "'";
                string idcart = "";
                SqlCommand cm = new SqlCommand(sql, ldc.cn);
                ldc.cn.Open();
                dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    idcart = dr["cartID"].ToString();
                }
                ldc.cn.Close();
                Response.Redirect("cart.aspx?id=" + idcart);
            }
        }

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

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            string a = ((ImageButton)sender).CommandArgument.ToString();
            Response.Redirect("detail.aspx?id=" + a);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string a = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("detail.aspx?id=" + a);
        }
    }
}