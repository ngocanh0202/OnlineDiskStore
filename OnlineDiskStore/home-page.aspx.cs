﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class home_page : System.Web.UI.Page
    {
        lopdungchung ldc;
        public DataTable dtrandom;
        public home_page()
        {
            ldc = new lopdungchung();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            loaddatalist1();
            loaddatarandom();
            loaddatalist6();
            loaddatalist2(dtrandom.Rows[0]["productID"]);
            loaddatalist3(dtrandom.Rows[1]["productID"]);
            loaddatalist4(dtrandom.Rows[2]["productID"]);
            loaddatalist5(dtrandom.Rows[3]["productID"]);
            
        }
        // Chọn ra 6 sản phẩm vừa mới cập nhập
        public void loaddatalist6()
        {
            string sql = "select TOP 6 * from Product order by productID DESC";
            DataList6.DataSource = ldc.getdata(sql);
            DataList6.DataBind();
        }
        // Chọn ra 12 sản phẩm giảm dần theo năm
        public void loaddatalist1()
        {
            string sql = "select TOP 12 * from Product order by productDistributeYear DESC";
            DataList1.DataSource = ldc.getdata(sql);
            DataList1.DataBind();
        }
        // radom
        public void loaddatalist2(object a)
        {
            string id = a.ToString();
            string sql = "select * from Product where productID='"+id+"'";
            DataList2.DataSource = ldc.getdata(sql);
            DataList2.DataBind();
        }
        // random
        public void loaddatalist3(object a)
        {
            string id = a.ToString();
            string sql = "select * from Product where productID='" + id + "'";
            DataList3.DataSource = ldc.getdata(sql);
            DataList3.DataBind();
        }
        // random
        public void loaddatalist4(object a)
        {
            string id = a.ToString();
            string sql = "select * from Product where productID='" + id + "'";
            DataList4.DataSource = ldc.getdata(sql);
            DataList4.DataBind();
        }
        // random
        public void loaddatalist5(object a)
        {
            string id = a.ToString();
            string sql = "select * from Product where productID='" + id + "'";
            DataList5.DataSource = ldc.getdata(sql);
            DataList5.DataBind();
        }
        // chọn 4 sản phâm ngẫu nhiên
        public void loaddatarandom()
        {
            dtrandom = new DataTable();
            string sql = "SELECT TOP 4 * FROM Product ORDER BY NEWID();";
            dtrandom = ldc.getdata(sql);
        }
        // click image
        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            string a = ((ImageButton)sender).CommandArgument.ToString();
            Response.Redirect("detail.aspx?id="+a);
        }
        // click image
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string a = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("detail.aspx?id=" + a);
        }
        // click image
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string a = ((ImageButton)sender).CommandArgument.ToString();
            Response.Redirect("detail.aspx?id=" + a);
        }
        // click image
        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            string a = ((ImageButton)sender).CommandArgument.ToString();
            Response.Redirect("detail.aspx?id=" + a);
        }
        // click image
        protected void ImageButton1_Click2(object sender, ImageClickEventArgs e)
        {
            string a = ((ImageButton)sender).CommandArgument.ToString();
            Response.Redirect("detail.aspx?id=" + a);
        }
        // click image
        protected void ImageButton1_Click3(object sender, ImageClickEventArgs e)
        {
            string a = ((ImageButton)sender).CommandArgument.ToString();
            Response.Redirect("detail.aspx?id=" + a);
        }
    }
}