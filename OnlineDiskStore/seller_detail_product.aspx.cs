using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class seller_detail_product : System.Web.UI.Page
    {
        lopdungchung ldc;
        public seller_detail_product()
        {
            ldc = new lopdungchung();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            loaddata();
            loaddropdownlist_update_year();
            loaddropdownlist_category();
        }
        private void loaddata()
        {
            if (Request.QueryString["id"] == null) return;
            string a = Request.QueryString["id"].ToString();
            string sql = "SELECT Product.*, Seller.sellerName FROM Product JOIN Seller ON Product.sellerID = Seller.sellerID WHERE Product.productID = '"+ a + "' and Product.sellerID = '" + Session["customerID"] +"' GROUP BY Product.productName, Product.productID, Seller.sellerID, Seller.sellerName,Product.productImage,Product.productDescription,Product.productPrice,Product.productCategory,Product.productStockLevel,Product.sellerID,Product.productDistributeYear";
            DataList1.DataSource = ldc.getdata(sql);
            DataList1.DataBind(); 
        }
        private void loaddropdownlist_update_year()
        {
            int old = 1998;
            int newyear = (int)DateTime.Now.Year;
            while (newyear>=old)
            {
                DropDownList1.Items.Add(""+newyear);
                newyear--;
            }
        }
        private void loaddropdownlist_category()
        {
            DropDownList2.Items.Add("Hành động");
            DropDownList2.Items.Add("Trí tuệ"); 
            DropDownList2.Items.Add("Đối kháng");
            DropDownList2.Items.Add("Đánh theo lượt");
            DropDownList2.Items.Add("Chiến thuật");
            DropDownList2.Items.Add("Nhập vai");
            DropDownList2.Items.Add("Kinh dị");
            DropDownList2.Items.Add("Bắn súng");
            DropDownList2.Items.Add("Thể thao");
            DropDownList2.Items.Add("Thế giới mở");
            DropDownList2.Items.Add("Mô phỏng");
            DropDownList2.Items.Add("Phiêu lưu");
            DropDownList2.Items.Add("Thể thao");
        }
        protected void logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("warehouse.aspx");
        }

        protected void image_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("warehouse.aspx?name=" + search.Text);
        }

        protected void account_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("accountuser.aspx");
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            string sql = "select sum(quantity) from ReceiptProduct where productID = '"+ Request.QueryString["id"].ToString()+ "' ";
            Label Label8 = (Label)e.Item.FindControl("Label8");
            object a = ldc.count(sql);
            if (a != DBNull.Value)
            {
                Label8.Text = (int)a + " ";
            }
            else
            {
                Label8.Text = 0 + " ";
            }
        }
        // Tải ảnh mới 
        protected void hideButton_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {       
                //Xóa ảnh cũ trong server
                string sqlimageold = "select productImage from Product where productID = '"+ Request.QueryString["id"].ToString() + "' ";
                string oldimage = "image/"+ ldc.read(sqlimageold, "productImage");
                File.Delete(Server.MapPath(oldimage));
                //lưu ảnh mới
                string name = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + FileUpload1.FileName;
                string newimage = "image/"+ name;
                FileUpload1.SaveAs(Server.MapPath(newimage));
                //update sql
                string sql = "update Product set productImage = '"+name+"' where productID = '"+ Request.QueryString["id"].ToString() + "' ";
                ldc.command(sql, "Cập nhập ảnh thành công", this);
            }
            loaddata();
        }
        // Cập nhập tên
        protected void btn_name_Click(object sender, EventArgs e)
        {
            string sql = "update Product set productName = N'"+txt_product_name.Text+"' where productID = '"+ Request.QueryString["id"].ToString() + "' ";
            ldc.command(sql,"Cập nhập tên thành công",this);
            loaddata();
            txt_product_name.Text = "";
        }
        public bool ContainsOnlyDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        // Cập nhập giá tiền
        protected void Button1_Click1(object sender, EventArgs e)
        {
            if(ContainsOnlyDigits(txt_product_price.Text) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Nhập giá tiền không đúng định dạng')", true);
                return;
            }
            string sql = "update Product set productPrice = '"+txt_product_price.Text+"' where productID = '"+ Request.QueryString["id"].ToString() + "' ";
            ldc.command(sql,"Cập nhập giá tiền thành công", this);
            loaddata();
            txt_product_price.Text = "";
        }
        // cập nhập số lượng bán
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ContainsOnlyDigits(txt_product_number.Text) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Chỉ nên nhập số!!')", true);
                return;
            }
            string sql = "update Product set productStockLevel = '" + txt_product_number.Text + "' where productID = '"+ Request.QueryString["id"].ToString() + "' ";
            ldc.command(sql, "Cập nhập số lượng bán thành công", this);
            loaddata();
            txt_product_number.Text = ""; 
        }
        // cập nhập thông tin sản phẩm
        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql = "update Product set productCategory = N'"+DropDownList2.SelectedItem.Text
                +"', productDistributeYear = N'"+DropDownList1.SelectedItem.Text
                +"', productDescription = N'"+ TextBox1.Text + "' where productID = '"+ Request.QueryString["id"].ToString() + "'   ";
            ldc.command(sql,"Cập nhập thông tin thành công", this);
            loaddata();
            TextBox1.Text = "";
        }
        // xóa hàng hóa
        protected void Button4_Click(object sender, EventArgs e)
        {
            string sqlimageold = "select productImage from Product where productID = '" + Request.QueryString["id"].ToString() + "' ";
            string oldimage = "image/" + ldc.read(sqlimageold, "productImage");
            File.Delete(Server.MapPath(oldimage));

            string sql = "delete from Product where productID = '"+ Request.QueryString["id"].ToString() + "' ";
            string sql2 = "delete from CartProduct where productID = '"+ Request.QueryString["id"].ToString() + "' ";
            
            ldc.command2(sql2);
            ldc.command(sql,"Xóa sản phẩm thành công", this);
            Response.Redirect("warehouse.aspx");
        }
    }
}