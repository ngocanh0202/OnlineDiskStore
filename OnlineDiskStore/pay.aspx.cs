using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            if(Request.QueryString["id"] != null)
            {
                loaddata();
                loadaddress();
                totalprice();
                totallb();
            }
            else if (Request.QueryString["idproduct"] != null && Request.QueryString["quantity"] != null)
            {
                loaddata();
                loadaddress();
                totalprice();
                totallb();
            }
        }
        // lấy địa chỉ mặc định cho khách hàng
        private void loadaddress()
        {
            string sql = "select customerAddress from customer where customerID = '" + Session["customerID"] +"' ";
            Label6.Text = ldc.read(sql, "customerAddress");
        }
        // load dữ liệu tù cartproduct
        private void loaddata()
        {
            if (Request.QueryString["id"] != null)
            {
                string sql = "select Product.productName, Product.productImage, Product.productPrice, CartProduct.Quanity from CartProduct join Product on Product.productID = CartProduct.productID where CartProduct.cartID = '" + Request.QueryString["id"].ToString() + "' ";
                DataList1.DataSource = ldc.getdata(sql);
                DataList1.DataBind();
            }
            else if (Request.QueryString["idproduct"] != null && Request.QueryString["quantity"] != null)
            {
                string sql = "select productName, productImage, productPrice from Product where productID = '"+ Request.QueryString["idproduct"] + "' ";
                DataList1.DataSource = ldc.getdata(sql);
                DataList1.DataBind();
            }
        }
        // Tiền sản phẩm
        private void totalprice()
        {
            if(Request.QueryString["id"] != null)
            {
                string sql = "select sum(Product.productPrice * CartProduct.Quanity) as total from CartProduct join Product on Product.productID = CartProduct.productID where CartProduct.cartID = '" + Request.QueryString["id"].ToString() + "' ";
                object price = ldc.count(sql);
                lb_price_product.Text = price + "";
            }
            else if (Request.QueryString["idproduct"] != null && Request.QueryString["quantity"] != null)
            {
                string sql = "select (productPrice * "+ Request.QueryString["quantity"] + ") as total from Product where productID = '"+ Request.QueryString["idproduct"] + "' ";
                lb_price_product.Text = ldc.read(sql, "total") +"";
            }

        }
        // tổng Tiền cần thanh toán
        private void totallb()
        {
            int a = int.Parse(lb_price_product.Text.ToString());
            int b = int.Parse(Label8.Text.ToString());
            lb_total.Text = "" + (a + b);
        }
        //Even chọn Voucher
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label4.Text = DropDownList1.SelectedItem.Text;
            if (DropDownList1.SelectedValue != "0")
            {
                if(DropDownList1.SelectedValue == "1")
                {
                    Label9.Visible = true;
                    Label10.Text = "40000";
                    Label7.Visible = true;
                    lb_total.Text = lb_price_product.Text;
                }
                else if (DropDownList1.SelectedValue == "2")
                {
                    Label9.Visible = true;
                    int a = int.Parse(lb_price_product.Text.ToString()); // tổng tiền sản phẩm
                    int b = int.Parse(Label8.Text.ToString()); // tiền vận chuyển
                    int c = ((a + b) * 30) / 100;
                    Label10.Visible = true;
                    Label10.Text = ""+c;
                    Label7.Visible = true;
                    lb_total.Text = (a + b - c) + "";
                }
            }
            else
            {
                Label9.Visible = false;
                Label10.Visible = false;
                Label7.Visible = false;
                int a = int.Parse(lb_price_product.Text.ToString()); // tổng tiền sản phẩm
                int b = int.Parse(Label8.Text.ToString()); // tiền vận chuyển
                lb_total.Text = (a + b) + "";
            }
        }
        // logo 
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home-page.aspx");
        }
        //Phương thức thanh toán
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList2.SelectedValue != "0")
            {
                Label5.Text = DropDownList2.SelectedItem.Text+"";
                if(DropDownList2.SelectedValue == "2")
                {
                    string sql = "select count(customerBankNumber) from Customer where customerID = '" + Session["customerID"] +"' ";
                    object banknumber = ldc.count(sql);
                    if((int)banknumber == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Bạn chưa có thông tin về thẻ ngân hàng, vui lòng cập nhập')", true);
                        Response.Redirect("accountuser.aspx");
                    }
                }
            }

        }
        //xử lý chuổi địa chỉ
        string stringaddress()
        {
            string a = "";
            if(DropDownList3.SelectedValue !="0")
                if (DropDownList3.SelectedItem != null)
                {
                    a = DropDownList3.SelectedValue.ToString() + "" + a;
                }
            if(DropDownList4.SelectedValue != "0")
                if (DropDownList4.SelectedItem != null)
                {
                    a =  a +", "+DropDownList4.SelectedItem.ToString();
                }
            if(DropDownList5.SelectedValue != "0")
                if (DropDownList5.SelectedItem != null)
                {
                    a = a +", " + DropDownList5.SelectedValue.ToString();
                }
            if(TextBox1 != null)
            {
                a = TextBox1.Text +", "+ a;
            }
            return a;
        }

        //Chọn Phường xã 
        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
             Label6.Text = stringaddress();
        }
        //Chọn Tỉnh thành phố
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label6.Text = stringaddress();
        }
        //Chọn Quận huyện
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label6.Text = stringaddress();
        }
        //Chọn Địa chỉ chi tiết
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Label6.Text = stringaddress();
        }
        //đóng sự kiện chọn địa chỉ
        protected void Button1_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "CloseScript", "let add = document.getElementById('pay-address-choices-id'); add.classList.remove('open-pay-address-choices'); __doPostBack('', '');", true);
        }
        // Xử lý hóa đơn, check thông tin cần thiết
        private int receipt(int ID)
        {

            if (DropDownList2.SelectedValue != "0" && Label6.Text != "")
            {
                string sqlreceipt = "insert into Receipt values ('" + ID + "','" + Request.QueryString["id"].ToString() + "','" + Session["customerID"] +"',N'" + Label6.Text + "','" + lb_total.Text + "','" + DateTime.Now + "',N'" + DropDownList2.SelectedItem.Text + "')";
                ldc.command2(sqlreceipt);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Chưa điền đủ thông tin')", true);
                return 0;
            }
            return 1;
        }
        Hashtable hashtable = new Hashtable();
        //receiptproduct, chèn thông tin hóa đơn sản phẩm
        private void receiptProduct(int ID)
        {
            string sql = "select * from CartProduct where cartID = '"+ Request.QueryString["id"].ToString() + "'";
            SqlCommand cm = new SqlCommand(sql,ldc.cn);
            SqlDataReader dr;
            
            ldc.cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read()){
                hashtable.Add(dr["productID"], dr["quanity"]);
            }
            dr.Close(); 
            ldc.cn.Close();
            foreach (DictionaryEntry items in hashtable)
            {
                string sqlre = "insert into ReceiptProduct values('" + ID + "','" + items.Key.ToString() + "','" + items.Value.ToString() + "')";
                ldc.command2(sqlre);
            }
           
        }
        // Xóa sau khi trong giỏ hàng khi đã thanh toán thành công
        private void deletecart()
        {
            string sql = "delete from CartProduct where cartID = '"+ Request.QueryString["id"].ToString() + "'";
            ldc.command2(sql);
        }
        // Cập nhập lại số lượng sản phẩm trong Product
        private void deletequanityproduct()
        {
            foreach (DictionaryEntry items in hashtable)
            {
                string sql1 = "select productStockLevel from Product where productID = '" + items.Key.ToString() + "'";
                int a = (int)ldc.count(sql1);
                int b = a - (int)items.Value;
                string sql2 = "update Product set productStockLevel = '"+b+"' where productID = '"+items.Key.ToString()+"' ";
                ldc.command2(sql2);
            }
        }
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
                string sql1product = "select sum(productStockLevel) from Product where productID = '" + items.Key + "'";
                string sql2cart = "select sum(Quanity) from CartProduct where productID = '" + items.Key + "' and cartID = '" + Request.QueryString["id"].ToString() + "'";
                if ((int)ldc.count(sql1product) < (int)ldc.count(sql2cart))
                {
                    check = 0;
                    break;
                }
            }
            return check;
        }
        private bool checkbuynow()
        {
            string sqlproduct = "select sum(productStockLevel) from Product where productID = '"+ Request.QueryString["idproduct"] + "' ";
            if ((int)ldc.count(sqlproduct) < int.Parse(Request.QueryString["quantity"]))
            {
                return false;
            }
            return true;
        }
        //button thanh toán
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (checkcartnumber() == 0) {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Không thể thanh toán')", true);
                    return;
                }
                string sqlcount = "select count(*) from Receipt";
                object a = ldc.count(sqlcount);
                int ID = (int)a + 1;
                if (receipt(ID) == 0) return;
                receiptProduct(ID); // thêm xóa đơn
                deletecart(); // xóa giỏ hàng
                deletequanityproduct(); // cập nhập lại số lượng
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Thanh toán thành công')", true);
                Response.Redirect("home-page.aspx");
            }
            else if (Request.QueryString["idproduct"] != null && Request.QueryString["quantity"] != null)
            {
                if(checkbuynow() == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Không thể thanh toán')", true);
                    return;
                }
                if (DropDownList2.SelectedValue == "0" && Label6.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Chưa điền đủ thông tin')", true);
                    return;
                }
                string sqlcount = "select count(*) from Receipt";
                object a = ldc.count(sqlcount);
                int ID = (int)a + 1;           
                string sql1 = "insert into Receipt values('" + ID + "','" + Session["cartID"] + "','" + Session["customerID"] + "',N'" + Label6.Text + "','"+ lb_total.Text + "','"+DateTime.Now+ "', N'" + DropDownList2.SelectedItem.Text + "') ";
                string sql2 = "insert into ReceiptProduct values('"+ID+"','"+ Request.QueryString["idproduct"].ToString()+ "','"+ Request.QueryString["quantity"].ToString()+ "')";
                ldc.command2(sql1);
                ldc.command2(sql2);
                string updateproduct = "update Product set productStockLevel = productStockLevel - "+ Request.QueryString["quantity"].ToString() + " where productID = '"+ Request.QueryString["idproduct"] + "' ";
                ldc.command2(updateproduct);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Thanh toán thành công')", true);            
                Response.Redirect("home-page.aspx");
                
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label Label2 = (Label)e.Item.FindControl("Label2");
                if (Request.QueryString["id"] != null)
                {
                    DataRowView rowView = (DataRowView)e.Item.DataItem;
                    Label2.Text = rowView["Quanity"].ToString();
                    

                }
                else if (Request.QueryString["idproduct"] != null && Request.QueryString["quantity"] != null)
                {
                    Label2.Text = Request.QueryString["quantity"].ToString();
                }
            }
                
        }
    }
}