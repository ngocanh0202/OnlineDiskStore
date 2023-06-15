using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class become_seller : System.Web.UI.Page
    {
        lopdungchung ldc;
        public become_seller()
        {
            ldc = new lopdungchung();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
        }

        protected void btn_dangky_Click(object sender, EventArgs e)
        {
            string sellerName = txt_Tencuahang.Text;
            string sellerCitizenIDNum = txt_cmnd.Text;
            string sellerBankName = txt_tennganhang.Text;
            string sellerBankNumber = txt_tknganhang.Text;

            // Kiểm tra các trường dữ liệu có hợp lệ không (có thể thêm kiểm tra nếu cần)
            if (string.IsNullOrEmpty(sellerName) || string.IsNullOrEmpty(sellerCitizenIDNum) || string.IsNullOrEmpty(sellerBankName) || string.IsNullOrEmpty(sellerBankNumber))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Vui lòng nhập đầy đủ thông tin!')", true);
                return;
            }

            // Tạo câu truy vấn SQL để thêm dữ liệu vào CSDL
            string query = string.Format("INSERT INTO Seller (sellerID, sellerName, sellerCitizenIDNum, sellerBankNumber, sellerBankName) VALUES ('{0}', '{1}', '{2}', '{3}','{4}')",
                Session["customerID"],sellerName, sellerCitizenIDNum, sellerBankNumber, sellerBankName);

            // Khởi tạo đối tượng LopDungChung và gọi phương thức thêm dữ liệu
            ldc.command(query,"Đăng ký thành công", this);
        }
    }
}