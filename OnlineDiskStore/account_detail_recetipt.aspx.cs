using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        lopdungchung ldc;
        public WebForm1()
        {
            ldc = new lopdungchung();  
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            loaddata();
            total();
        }
        private void loaddata()
        {
            string a = Request.QueryString["id"];
            string sql = "SELECT Product.productName, ReceiptProduct.quantity, Product.productPrice, Product.productImage FROM ReceiptProduct JOIN Product ON Product.productID = ReceiptProduct.productID WHERE ReceiptProduct.receiptID = '"+a+"'; ";
            GridView1.DataSource = ldc.getdata(sql);
            GridView1.DataBind();
        }
        private void total()
        {
            string a = "select totalPrice from Receipt where receiptID = '"+ Request.QueryString["id"].ToString()+ "' ";
            Label4.Text = "" +ldc.read(a, "totalPrice") ;
        }
    }
}