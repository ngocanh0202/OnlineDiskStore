﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class add_product : System.Web.UI.Page
    {
        lopdungchung ldc;
        public add_product()
        {
            ldc = new lopdungchung();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            dropdownlist();
            dropdownlist2();
        }
        private void dropdownlist2()
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
        private void dropdownlist()
        {
            int oldyear = 1998;
            int newyear = DateTime.Now.Year;
            while (newyear >= oldyear)
            {
                DropDownList1.Items.Add("" + newyear);
                newyear--;
            }
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
        protected void btn_themsp_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã cập nhật ảnh hay chưa
            if (Image1.ImageUrl != "")
            {

                // Lấy thông tin sản phẩm từ các control trên trang
                string productName = txt_tensanpham.Text;
                if(ContainsOnlyDigits(txt_giaien.Text) == false || ContainsOnlyDigits(txt_soluong.Text) == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Vui lòng nhập số')", true);
                    return;
                }
                decimal productPrice = decimal.Parse(txt_giaien.Text);
                int productStockLevel = int.Parse(txt_soluong.Text);
                string productCategory = ""+ DropDownList2.SelectedItem.ToString();
                int productDistributeYear = int.Parse(DropDownList1.SelectedItem.ToString());
                string productDescription = txt_mota.Text;
                string imagePath = Path.GetFileName(Image1.ImageUrl);

                // Thêm thông tin sản phẩm vào database
                string query = "INSERT INTO [dbo].[Product] ([productName], [productImage], [productDescription], [productPrice], [productCategory], [productStockLevel], [sellerID], [ProductDistributeYear]) Values (N'" + productName + "', N'" + imagePath + "', N'" + productDescription + "', '" + productPrice + "', N'" + productCategory + "', '" + productStockLevel + "', '" + Session["customerID"] +"', '" + productDistributeYear + "')";
                ldc.command(query,"Đã thêm sản phẩm thành công!",this);

            }
            else
            {
                // Hiển thị thông báo nếu chưa cập nhật ảnh
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Vui lòng cập nhật ảnh trước khi thêm sản phẩm!')", true);
            }
            Response.Redirect("warehouse.aspx");
        }

        protected void hideButton_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn ảnh để upload chưa
            if (FileUpload1.HasFile)
            {
                try
                {
                    // Lưu ảnh vào folder Image trên server
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + FileUpload1.FileName;
                    string imagePath = "~/image/" + filename;
                    FileUpload1.SaveAs(Server.MapPath(imagePath));
                    Image1.ImageUrl = imagePath;

                    // Hiển thị thông báo thành công
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Đã cập nhật ảnh thành công!')", true);
                }
                catch
                {
                    // Xử lý lỗi nếu việc tải lên ảnh thất bại
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Gặp lỗi....!')", true);
                }
            }
            else
            {
                // Hiển thị thông báo nếu không có tệp tin được chọn
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Vui lòng chọn ảnh!')", true);
            }
        }

        protected void Image_btn_them_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("warehouse.aspx");
        }
    }
}