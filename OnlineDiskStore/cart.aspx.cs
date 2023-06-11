using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class cart : System.Web.UI.Page
    {
        lopdungchung ldc;
        public cart()
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
            string sql = "SELECT Product.productImage, Product.productName, CartProduct.quanity, Product.productPrice, Product.productID FROM CartProduct JOIN Product ON CartProduct.productID = Product.productID where CartProduct.cartID = '01' GROUP BY Product.productImage, Product.productName, CartProduct.quanity, Product.productPrice, Product.productID";
            
            DataList1.DataSource = ldc.getdata(sql);
            DataList1.DataBind();
        }
        private void total()
        {
            string sql = "SELECT SUM(Product.productPrice * CartProduct.Quanity) AS totalPrice FROM CartProduct JOIN Product ON CartProduct.productID = Product.productID where CartProduct.cartID = '01'";
            object a = (object)ldc.count(sql);
            Label4.Text = a.ToString() + "VND";
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "in")
            {

                Label Label2 = (Label)e.Item.FindControl("Label2");
                Label Label1 = (Label)e.Item.FindControl("Label1");
                Label Label5 = (Label)e.Item.FindControl("Label5");
                string sql = "select productStockLevel from Product,CartProduct where CartProduct.cartID = '01' and productName = '"+Label1.Text+"'";
                int a = int.Parse(Label2.Text);
                if (a < (int)ldc.count(sql))
                {
                    a++;
                }
                string sqlcartproduct = "update CartProduct set Quanity = '"+a+"' where cartID = '01' and productID = '"+Label5.Text+"' ";
                ldc.command2(sqlcartproduct);
                total();
                Label2.Text = a.ToString();
            }
            else if (e.CommandName == "de")
            {
                Label Label2 = (Label)e.Item.FindControl("Label2");
                Label Label5 = (Label)e.Item.FindControl("Label5");
                int quantity = int.Parse(Label2.Text);
                if (quantity > 1)
                {
                    quantity--;
                }
                string sqlcartproduct = "update CartProduct set Quanity = '"+quantity+"' where cartID = '01' and productID = '"+Label5.Text+"'";
                ldc.command2(sqlcartproduct);
                total();
                Label2.Text = quantity.ToString();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string a = ((ImageButton)sender).CommandArgument.ToString();
            string sql = "delete from CartProduct where cartID = '01' and productID = '"+a+"'";
            ldc.command(sql, "xoa thanh cong", this);
            loaddata();
            total();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home-page.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("pay.aspx");
        }
    }
}