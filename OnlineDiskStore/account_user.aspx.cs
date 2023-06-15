using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class account : System.Web.UI.Page
    {
        lopdungchung ldc;
        public account()
        {
            ldc = new lopdungchung();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            loadcustomer();
        }
        // chuyển về home page
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home-page.aspx");
        }
        // Load thông tin customer
        private void loadcustomer()
        {
            string sql = "select * from Customer where CustomerID = '"+ Session["customerID"] + "' ";
            DataList1.DataSource = ldc.getdata(sql);
            DataList1.DataBind();
        }
        // hiện mật khẩu cũ
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            
            Label lb_password = (Label)item.FindControl("lb_password");
            lb_password.Text = "Mật khẩu cũ";
            TextBox txt_password = (TextBox)item.FindControl("txt_password");
            string sql = "select customerPassword from customer where customerID = '" + Session["customerID"] + "'";
            txt_password.Text = "" + ldc.read(sql, "customerPassword");

            Label lb_password_new = (Label)item.FindControl("lb_password_new");
            lb_password_new.Visible = true;
            TextBox txt_password_new = (TextBox)item.FindControl("txt_password_new");
            txt_password_new.Visible = true;

            Label lb_password_new_again = (Label)item.FindControl("lb_password_new_again");
            lb_password_new_again.Visible = true;
            TextBox txt_password_new_again = (TextBox)item.FindControl("txt_password_new_again");
            txt_password_new_again.Visible = true;


        }
        // Cập nhập mật khẫu mới 
        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            TextBox txt_password_new_again = (TextBox)item.FindControl("txt_password_new_again");
            TextBox txt_password_new = (TextBox)item.FindControl("txt_password_new");
            if(txt_password_new_again.Text == txt_password_new.Text)
            {
                string sql = "update Customer set customerPassword = '" + txt_password_new_again.Text + "' where customerID = '" + Session["customerID"] + "' ";
                ldc.command(sql, "Cập nhập mật khẩu thành công", this);
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
        protected void Button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            TextBox txt_banknumber = (TextBox)item.FindControl("txt_banknumber");
            string a = txt_banknumber.Text;
            if (ContainsOnlyDigits(txt_banknumber.Text) == false|| a.Length < 9 || a.Length > 14)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Số tài khoản nhập sai')", true);
                return;
            }
            TextBox txt_name = (TextBox)item.FindControl("txt_name");
            TextBox txt_email = (TextBox)item.FindControl("txt_email");
            TextBox txt_phone = (TextBox)item.FindControl("txt_phone");
            TextBox txt_address = (TextBox)item.FindControl("txt_address");
            TextBox txt_bankname = (TextBox)item.FindControl("txt_bankname");

            string sql = "update Customer set customerName = '"+txt_name.Text
                +"', customerEmail = N'"+txt_email.Text
                +"', customerAddress = N'"+txt_address.Text
                +"', customerPhone = N'"+txt_phone.Text
                +"', customerBankNumber = N'"+txt_banknumber.Text
                +"', customerBankName = N'"+txt_bankname.Text+"' where customerID = '"+ Session["customerID"] + "'";
            ldc.command(sql,"Cập nhập thông tin thành công", this);

           /* ClientScript.RegisterStartupScript(this.GetType(), "CloseScript", "let add = document.getElementById('pay-address-choices-id'); add.classList.remove('open-pay-address-choices'); __doPostBack('', '');", true);*/
        }
    }
}