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
            if (IsPostBack) return;
            dropdown1();
            dropdown2();
        }
        // quay về home page
        protected void logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home-page.aspx");
        }
        // vào giỏ hàng
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
        private void dropdown1()
        {
            string sql = "select productCategory from Product group by productCategory";
            SqlCommand cm = new SqlCommand(sql,ldc.cn);
            SqlDataReader dr;
            ldc.cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {              
                DropDownList1.Items.Add(dr["productCategory"]+"");
            }
            ldc.cn.Close();
        }
        private void dropdown2()
        {
            string sql = "select productDistributeYear from Product group by productDistributeYear order by productDistributeYear desc ";
            SqlCommand cm = new SqlCommand(sql, ldc.cn);
            SqlDataReader dr;
            ldc.cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                DropDownList2.Items.Add(dr["productDistributeYear"] + "");
            }
            ldc.cn.Close();
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
                Response.Redirect("account_user.aspx");
            }
        }
        // button tìm kiếm
        protected void image_Click(object sender, ImageClickEventArgs e)
        {
            if (search.Text != "")
            {
                string a = search.Text;
                Response.Redirect("search2.aspx?name=" + a);
            }
        }


        /*   Chọn thể loại nhanh   */
        protected void hanhdong_Click(object sender, EventArgs e)
        {
            string value = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("search2?category="+value);
        }

        protected void tritue_Click(object sender, EventArgs e)
        {
            string value = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("search2?category=" + value);
        }

        protected void doikhang_Click(object sender, EventArgs e)
        {
            string value = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("search2?category=" + value);
        }

        protected void danhtheoluot_Click(object sender, EventArgs e)
        {
            string value = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("search2?category=" + value);
        }

        protected void chienthuat_Click(object sender, EventArgs e)
        {
            string value = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("search2?category=" + value);
        }

        protected void nhapvai_Click(object sender, EventArgs e)
        {
            string value = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("search2?category=" + value);
        }

        protected void kinhdi_Click(object sender, EventArgs e)
        {
            string value = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("search2?category=" + value);
        }

        protected void bansung_Click(object sender, EventArgs e)
        {
            string value = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("search2?category=" + value);
        }

        protected void thethao_Click(object sender, EventArgs e)
        {
            string value = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("search2?category=" + value);
        }

        protected void khac_Click(object sender, EventArgs e)
        {
            string value = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("search2?category=" + value);
        }
        // Bộ lọc
        protected void filter_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "0" && DropDownList2.SelectedValue == "0") return;
            Response.Redirect("search2?filtercategory="+DropDownList1.SelectedValue.ToString()+ "&filteryear=" + DropDownList2.SelectedValue.ToString());           
        }
    }
}