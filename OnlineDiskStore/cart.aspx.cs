using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            check();
        }
        // kiểm tra giỏ hàng để ẩn thành phần
        private void check()
        {
            string sql = "select count(*) from CartProduct where cartID = '" + Request.QueryString["id"].ToString() +"'";
            int a = (int)ldc.count(sql);
            if(a == 0)
            {
                Button1.Visible = false;
                Label6.Visible = false;
                Label4.Visible = false;
            }
        }
        // load dữ liệu trong giỏ hàng
        private void loaddata()
        {
            string sql = "SELECT Product.productImage, Product.productName, CartProduct.quanity, Product.productPrice, Product.productID FROM CartProduct JOIN Product ON CartProduct.productID = Product.productID where CartProduct.cartID = '" + Request.QueryString["id"].ToString() + "' GROUP BY Product.productImage, Product.productName, CartProduct.quanity, Product.productPrice, Product.productID";
            
            DataList1.DataSource = ldc.getdata(sql);
            DataList1.DataBind();
        }
        // tính tổng tiền
        private void total()
        {
            string sql = "SELECT SUM(Product.productPrice * CartProduct.Quanity) AS totalPrice FROM CartProduct JOIN Product ON CartProduct.productID = Product.productID where CartProduct.cartID = '" + Request.QueryString["id"].ToString() + "'";
            object a = (object)ldc.count(sql);
            Label4.Text = a.ToString() + "VND";
        }
        // xử lý tăng giảm số lượng giảm phẩm mua trong giỏ hàng
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "in")
            {

                Label Label2 = (Label)e.Item.FindControl("Label2");
                Label Label1 = (Label)e.Item.FindControl("Label1");
                Label Label5 = (Label)e.Item.FindControl("Label5");
                string sql = "select productStockLevel from Product,CartProduct where CartProduct.cartID = '" + Request.QueryString["id"].ToString() + "' and productName = '"+Label1.Text+"'";
                int a = int.Parse(Label2.Text);
                if (a < (int)ldc.count(sql))
                {
                    a++;
                }
                string sqlcartproduct = "update CartProduct set Quanity = '"+a+"' where cartID = '"+ Request.QueryString["id"].ToString() + "' and productID = '"+Label5.Text+"' ";
                ldc.command2(sqlcartproduct);
                total(); // tính lại tổng tiền
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
                string sqlcartproduct = "update CartProduct set Quanity = '"+quantity+"' where cartID = '"+ Request.QueryString["id"].ToString() + "' and productID = '"+Label5.Text+"'";
                ldc.command2(sqlcartproduct);
                total();// tính lại tổng tiền
                if(checkcartnumber()==1) { Button1.Visible = true; }
                Label2.Text = quantity.ToString();
            }
        }
        // xử lý khi xóa sản phâm trong giỏ hàng
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string a = ((ImageButton)sender).CommandArgument.ToString();
            string sql = "delete from CartProduct where cartID = '"+ Request.QueryString["id"].ToString() + "' and productID = '"+a+"'";
            ldc.command(sql, "xoa thanh cong", this);
            loaddata();  // load lại datalist
            total(); // tính lại tổn g
            if (checkcartnumber() != 0) { Button1.Visible = true; } // kiểm tra số hàng để mở lại button thanh toán
            check(); // kiểm tra số lượng sản phẩm để mở tong tiền và button thanh toán
           
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home-page.aspx");
        }
        // thanh toán
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkcartnumber() == 0)
            {
                Button1.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('không thể mua được vì hàng cung không đủ')", true);
                return;
            }
            Response.Redirect("pay.aspx?id="+ Request.QueryString["id"].ToString());
        }
        // lấy dữ liệu từ cartproduct
        private void takedatafromcartproduct(ref Hashtable ht)
        {
            string sql = "select productID,Quanity from CartProduct where cartID = '" + Request.QueryString["id"].ToString() + "' ";
            SqlCommand cm = new SqlCommand(sql, ldc.cn);       
            SqlDataReader dr;
            ldc.cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                ht.Add(dr["productID"], dr["quanity"]);
            }
            dr.Close();
            ldc.cn.Close();
        }
        private int checkcartnumber()
        {
            Hashtable ht = new Hashtable();
            takedatafromcartproduct(ref ht);
            int check = 1;
            foreach (DictionaryEntry items in ht)
            {
                string sql1product = "select sum(productStockLevel) from Product where productID = '"+items.Key+"'";
                string sql2cart = "select sum(Quanity) from CartProduct where productID = '"+items.Key+"' and cartID = '" + Request.QueryString["id"].ToString() + "'";
                if ((int)ldc.count(sql1product) < (int) ldc.count(sql2cart))
                {
                    check = 0;
                    break;
                }
            }
            return check;
        }
        // xử lý xung đột mua hàng
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (checkcartnumber() == 0)
            {
                Button1.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('không thể mua được vì hàng cung không đủ')", true);
            }
        }
    }
}