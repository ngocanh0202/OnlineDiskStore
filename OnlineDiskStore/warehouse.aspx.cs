using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class warehouse : System.Web.UI.Page
    {
        lopdungchung ldc;
        public warehouse()
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
            if (Request.QueryString["name"] == null)
            {
                string sql = "select * from Product where sellerID = '" + Session["customerID"] + "' ";
                DataList1.DataSource = ldc.getdata(sql);
                DataList1.DataBind();
            }
            else
            {
                string sql = "select * from Product where sellerID = '" + Session["customerID"] + "' and productName like '%"+ Request.QueryString["name"] + "%' ";
                DataList1.DataSource = ldc.getdata(sql);
                DataList1.DataBind();
            }
            
        }
        // click ảnh
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string id = ((ImageButton)sender).CommandArgument.ToString();
            Response.Redirect("seller_detail_product.aspx?id=" + id);
        }
        // click link
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("seller_detail_product.aspx?id=" + id);
        }
    }
}