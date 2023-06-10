using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class detail : System.Web.UI.Page
    {
        lopdungchung ldc;
        public detail() 
        {
            ldc = new lopdungchung();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            loaddatadetail(Request.QueryString["id"]);
        }
        private void loaddatadetail(object a)
        {
            if (a == null)
            {
                return;
            }
            string id = a.ToString();
            string sql = "select * from Product,Seller where productID = '" + id + "' and Product.sellerID = Seller.sellerID ";
            //string sql = "select * from Product,Seller where productID = 01 and Product.sellerID = Seller.sellerID";
            DataList1.DataSource = ldc.getdata(sql);
            DataList1.DataBind();  
        }


        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
               
                Label Label2 = (Label)e.Item.FindControl("Label2");
                Label2.Text = Label2.Text + "VND";
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if(e.CommandName== "Increase")
            {
                TextBox TextBox1 = (TextBox)e.Item.FindControl("TextBox1");
                Label Label3 = (Label)e.Item.FindControl("Label3");
                int quantity = int.Parse(TextBox1.Text);
                int quantity_of_product = int.Parse(Label3.Text);
                if(quantity < quantity_of_product)
                    quantity++;
                TextBox1.Text = quantity.ToString();
            }
            else if (e.CommandName == "Decrease")
            {
                TextBox TextBox1 = (TextBox)e.Item.FindControl("TextBox1");
                int quantity = int.Parse(TextBox1.Text);
                if(quantity > 1)
                {
                    quantity--;
                }
                TextBox1.Text = quantity.ToString();
            }
        }

        protected void addtocart_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            TextBox txt = (TextBox)item.FindControl("TextBox1");
            int textbox11 = int.Parse(txt.Text);
            string id = ((Button)sender).CommandArgument.ToString();
            string dem1sql = "select productStockLevel from Product where productID = '"+id+"'";
            string dem2sql = "select count(*) from CartProduct where productID = '" + id + "'";

            if ((int)ldc.count(dem2sql) == 0)
            {

                string sql = "insert into CartProduct values('01','" + id + "','" + textbox11 + "')";
                ldc.command(sql, "Thêm vào giỏ hàng thành công", this);
            }
            else if ((int)ldc.count(dem2sql) > 0)
            {
                string dem22sql = "select Quanity from CartProduct where productID = '" + id + "'";
                if ((int)ldc.count(dem1sql) >= ((int)ldc.count(dem22sql) + textbox11))
                {
                    int dem = (int)ldc.count(dem22sql) + textbox11;
                    string sql = "update CartProduct set Quanity = '"+dem+"' where productID = '"+id+"'";
                    ldc.command(sql, "Thêm vào giỏ hàng thành công", this);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Hàng thêm quá tải')", true);
                }
            }

        }

        protected void buynow_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),"alerMessage", "alert('Chưa cập nhập chức năng này')", true);
        }

        protected void cart_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cart.aspx");
        }

        protected void logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home-page.aspx");
        }
    }
}