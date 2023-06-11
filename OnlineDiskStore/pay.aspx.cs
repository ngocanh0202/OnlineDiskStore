using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class pay : System.Web.UI.Page
    {
        lopdungchung ldc;
        public pay()
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
            string sql = "select Product.productName, Product.productImage, Product.productPrice, CartProduct.Quanity from CartProduct join Product on Product.productID = CartProduct.productID where CartProduct.cartID = '01' ";
            DataList1.DataSource = ldc.getdata(sql);
            DataList1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label4.Text = DropDownList1.SelectedValue.ToString();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home-page.aspx");
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label5.Text = DropDownList2.SelectedValue.ToString();
        }
    }
}