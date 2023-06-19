using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class accountuser : System.Web.UI.Page
    {
        lopdungchung ldc;
        public accountuser()
        {
            ldc = new lopdungchung();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            loaddata();
        }
        void loaddata()
        {
            string sql = "select *,trim(customerBankNumber) from Customer where CustomerID = '" + Session["customerID"] + "' ";
            DataList1.DataSource = ldc.getdata(sql);
            DataList1.DataBind();
            DataList2.DataSource = ldc.getdata(sql);
            DataList2.DataBind();
        }
        // hiển thị textbox để cập nhập mật khẩu
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
        private bool HasUpperCharacter(string a)
        {
            foreach (char c in a)
            {
                if (char.IsUpper(c))
                {
                    return true;
                }
            }
            return false;
        }
        // Kiểm có số
        private bool HasNumberCharacter(string a)
        {
            foreach (char c in a)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
        // kiểm tra không có kỹ tự đặc biệt (1)
        private bool HasSpecialCharacters(string input)
        {
            string specialChars = @"!@#$%^&*()_+-=[]{};:'""<>,.?/`~";

            foreach (char c in input)
            {
                if (specialChars.Contains(c))
                    return true;
            }

            return false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            TextBox txt_password_new_again = (TextBox)item.FindControl("txt_password_new_again");
            TextBox txt_password_new = (TextBox)item.FindControl("txt_password_new");
            if (txt_password_new_again.Text != "" || txt_password_new.Text != "")
            {
                if (txt_password_new_again.Text == txt_password_new.Text && HasSpecialCharacters(txt_password_new.Text) && HasNumberCharacter(txt_password_new.Text) && HasUpperCharacter(txt_password_new.Text))
                {
                    string sql = "update Customer set customerPassword = '" + txt_password_new_again.Text + "' where customerID = '" + Session["customerID"] + "' ";
                    ldc.command(sql, "Cập nhập mật khẩu thành công", this);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Mật khẩu nên có độ dài 9 ký tự, có số, có ký tự đặc biệt và ít nhất có một chữ viết hoa')", true);
                    return;
                }
            }
            Label lb_password_new = (Label)item.FindControl("lb_password_new");
            lb_password_new.Visible = false;
            txt_password_new.Visible = false;

            Label lb_password_new_again = (Label)item.FindControl("lb_password_new_again");
            lb_password_new_again.Visible = false;
            txt_password_new_again.Visible = false;
            TextBox txt_password = (TextBox)item.FindControl("txt_password");
            txt_password.Text = "*********";
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
            if (ContainsOnlyDigits(txt_banknumber.Text) == false || a.Length < 9 || a.Length > 14)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Số tài khoản nhập sai')", true);
                return;
            }
            TextBox txt_name = (TextBox)item.FindControl("txt_name");
            TextBox txt_email = (TextBox)item.FindControl("txt_email");
            TextBox txt_phone = (TextBox)item.FindControl("txt_phone");
            TextBox txt_address = (TextBox)item.FindControl("txt_address");
            TextBox txt_bankname = (TextBox)item.FindControl("txt_bankname");

            string sql = "update Customer set customerName = N'" + txt_name.Text
                + "', customerEmail = N'" + txt_email.Text
                + "', customerAddress = N'" + txt_address.Text
                + "', customerPhone = N'" + txt_phone.Text
                + "', customerBankNumber = N'" + txt_banknumber.Text
                + "', customerBankName = N'" + txt_bankname.Text + "' where customerID = '" + Session["customerID"] + "'";
            ldc.command(sql, "Cập nhập thông tin thành công", this);

            /*ClientScript.RegisterStartupScript(this.GetType(), "CloseScript", "let add = document.getElementById('pay-address-choices-id'); add.classList.remove('open-pay-address-choices'); __doPostBack('', '');", true);*/
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                TextBox txt_banknumber = (TextBox)e.Item.FindControl("txt_banknumber");
                string value = ((DataRowView)e.Item.DataItem)["customerBankNumber"].ToString().Trim();
                txt_banknumber.Text = value;
            }
        }
    }
}