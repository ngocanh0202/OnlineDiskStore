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
            object id = Request.QueryString["id"];
            loaddatadetail(id);
            cartnumber();
        }
        private void cartnumber()
        {
            if (Session["customerID"] != null)
            {
                string idcart = "select cartID from Cart where CustomerID = '" + Session["customerID"] + "' ";
                string a = ldc.read(idcart, "cartID");
                string sql = "select count(productID) from CartProduct where cartID = '" + a + "'  ";
                Label1.Text = "" + ldc.count(sql);
            }
        }
        private void loaddatadetail(object a)
        {
            if (a == null)
            {
                return;
            }
            string id = a.ToString();
            string sql = "select * from Product,Seller where productID = '" + id + "' and Product.sellerID = Seller.sellerID ";
            //string sql2 = "SELECT Product.*, Seller.sellerName, SUM(ReceiptProduct.quantity) AS numbersold FROM Product JOIN Seller ON Product.sellerID = Seller.sellerID JOIN ReceiptProduct ON Product.productID = ReceiptProduct.productID WHERE Product.productID = '"+id+"' GROUP BY Product.productName, Product.productID, Seller.sellerID, Seller.sellerName,Product.productImage,Product.productDescription,Product.productPrice,Product.productCategory,Product.productStockLevel,Product.sellerID,Product.productDistributeYear,Seller.sellerCitizenIDNum,Seller.sellerBankNumber,Seller.sellerBankName";
            //string sql = "select * from Product,Seller where productID = 01 and Product.sellerID = Seller.sellerID";
            DataList1.DataSource = ldc.getdata(sql);
            DataList1.DataBind();  
        }
        // check kiểm tra xem còn sản phẩm để mua không
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
               
                Label Label2 = (Label)e.Item.FindControl("Label2");
                Label2.Text = Label2.Text + "VND";
            }
            checkstillforsale(e);
            productnumbersold(e);

        }
        // lấy số sản phẩm được bán
        private void productnumbersold(DataListItemEventArgs e)
        {
            string sql = "select sum(quantity) from ReceiptProduct where productID = '"+ Request.QueryString["id"].ToString()+ "' ";
            Label Label8 = (Label)e.Item.FindControl("Label8");
            object a = ldc.count(sql);
            if (a != DBNull.Value)
            {
                Label8.Text = (int)a+" ";
            }
            else
            {
                Label8.Text = 0+" ";
            }
            
        }
        // check còn bán
        private void checkstillforsale(DataListItemEventArgs e)
        {
            string sql = "select productStockLevel from Product where productID = '" + Request.QueryString["id"].ToString() + "'";
            int a = (int)ldc.count(sql);
            if (a == 0)
            {
                Button addtocart = (Button)e.Item.FindControl("addtocart");
                addtocart.Visible = false;
                Button buynow = (Button)e.Item.FindControl("buynow");
                buynow.Visible = false;

            }
        }
        // xử lý tăng giảm sản phẩm khi chuẩn thêm vào giỏ hàng
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
        // xử lý sự kiện thêm vào giỏ hàng
        protected void addtocart_Click(object sender, EventArgs e)
        {
            if (Session["customerID"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Bạn chưa đăng nhập tài khoản')", true);
                return;
            }
            Button btn = (Button)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            TextBox txt = (TextBox)item.FindControl("TextBox1");
            int textbox11 = int.Parse(txt.Text);
            string id = ((Button)sender).CommandArgument.ToString();
            string dem1sql = "select productStockLevel from Product where productID = '"+id+"'"; // lấy số lượng sản phẩm
            string idcarrt = "select cartID from Cart where CustomerID = '" + Session["customerID"] + "'"; // lấy ID cart của tài khoản
            string dem2sql = "select count(*) from CartProduct where productID = '" + id + "' and cartID = '"+ldc.read(idcarrt, "cartID") +"'"; // số lượng sản phẩm đã thêm vào giỏ hàng 

            if ((int)ldc.count(dem2sql) == 0)
            {
                string sql = "insert into CartProduct values('"+ldc.read(idcarrt, "cartID") +"','" + id + "','" + textbox11 + "')";
                ldc.command(sql, "Thêm vào giỏ hàng thành công", this);
                cartnumber();
                UpdatePanel2.Update();
            }
            else if ((int)ldc.count(dem2sql) > 0)
            {
                string dem22sql = "select Quanity from CartProduct where productID = '" + id + "' and cartID = '"+ldc.read(idcarrt, "cartID") +"'";
                if ((int)ldc.count(dem1sql) >= ((int)ldc.count(dem22sql) + textbox11))
                {
                    int dem = (int)ldc.count(dem22sql) + textbox11;
                    string sql = "update CartProduct set Quanity = '"+dem+"' where productID = '"+id+"' and cartID= '"+ ldc.read(idcarrt, "cartID") + "' ";
                    ldc.command(sql, "Thêm vào giỏ hàng thành công", this);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Hàng thêm quá tải')", true);
                }
            }

        }
        // chưa hoàn thiện
        protected void buynow_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),"alerMessage", "alert('Chưa cập nhập chức năng này')", true);
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
                Response.Redirect("cart.aspx?id=" + idcart);
            }
        }
        // quay lại home page
        protected void logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home-page.aspx");
        }
        // tài khoản
        protected void account_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["customerID"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Response.Redirect("accountuser.aspx");
            }
        }

        protected void image_Click(object sender, ImageClickEventArgs e)
        {
            if(search.Text != "")
            {
                string a = search.Text;
                Response.Redirect("search2.aspx?name=" + a);
            }       
        }
    }
}