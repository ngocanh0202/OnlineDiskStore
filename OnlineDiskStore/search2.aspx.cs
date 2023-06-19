using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class search2 : System.Web.UI.Page
    {
        lopdungchung ldc;
        public search2()
        {
            ldc = new lopdungchung();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["name"]!=null) loadsearch();
            if (Request.QueryString["category"] != null) loadcategory();
            if (Request.QueryString["filtercategory"] != null && Request.QueryString["filteryear"] != null) loadfilter();
        }
        private void loadfilter()
        {
            string category = Request.QueryString["filtercategory"].ToString();
            string year = Request.QueryString["filteryear"].ToString();
            if(category == "0" && year != "0")
            {
                string sql = "select * from Product where productDistributeYear = '" + year+"'";
                DataList1.DataSource = ldc.getdata(sql);
                DataList1.DataBind();
            }else if (category != "0" && year == "0")
            {
                string sql = "select * from Product where UPPER(productCategory) like N'" + category + "'";
                DataList1.DataSource = ldc.getdata(sql);
                DataList1.DataBind();
            }else if (category != "0" && year != "0")
            {
                string sql = "select * from Product where UPPER(productCategory) like N'" + category + "' and productDistributeYear = '" + year+"'";
                DataList1.DataSource = ldc.getdata(sql);
                DataList1.DataBind();
            }else if (category == "0" && year == "0")
            {
                string sql = "select * from Product";
                DataList1.DataSource = ldc.getdata(sql);
                DataList1.DataBind();
            }
        }
        private void loadsearch()
        {
            string sql = "SELECT * FROM Product WHERE UPPER(productName) LIKE '%" + Request.QueryString["name"].ToString() + "%' ";
            DataList1.DataSource = ldc.getdata(sql);
            DataList1.DataBind();
        }
        private void loadcategory()
        {
            
            string a = Request.QueryString["category"].ToString();
            if (a != "0")
            {
                string sql = "select * from Product where UPPER(productCategory) LIKE N'" + a + "' ";
                DataList1.DataSource = ldc.getdata(sql);
                DataList1.DataBind();
            }
            else
            {
                string sql = "select * from Product where productCategory NOT IN (N'Hành động',N'Trí tuệ',N'Đối kháng',N'Đánh theo lượt',N'Chiến thuật',N'Nhập vai',N'Kinh dị',N'Bắn súng',N'Thể thao')";
                DataList1.DataSource = ldc.getdata(sql);
                DataList1.DataBind();
            }
        }
        protected void ImageButton5_Click1(object sender, ImageClickEventArgs e)
        {         
            string a = ((ImageButton)sender).CommandArgument.ToString();
            Response.Redirect("detail.aspx?id=" + a);
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            string a = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("detail.aspx?id=" + a);
        }
    }
}