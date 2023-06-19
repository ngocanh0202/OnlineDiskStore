using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class register : System.Web.UI.Page
    {
        lopdungchung ldc;
        public register()
        {
            ldc = new lopdungchung();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
        // kiểm tra tên tài khoản bị trùng
        private int checknameaccount()
        {
            string sql = "select count(*) from Customer where customerUserName = '"+TextBox3.Text+"' ";
            if ((int)ldc.count(sql)!=0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Tên tài khoản bị trùng')", true);
                return 1;            
            }
            return 0;
        }
        // Đăng ký
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (Page.IsValid )
            {
                if (checknameaccount() == 1) return;
                //tạo ID mới cho customer
                string sql = "select count(*) from Customer";
                string newidcustomer = "" + GenerateRandomNumber()+((int)ldc.count(sql)+1);
                //update tài khoản vào csdl
                string sql2 = "insert into Customer (customerID, customerUserName, customerPassword) values ('"+newidcustomer+"','"+TextBox3.Text+"','"+TextBox1.Text+"')";
                ldc.command2(sql2);
                //tạo giỏ hàng mới
                string newidcart = "" + GenerateRandomNumber() + newidcustomer;
                string sql3 = "insert into Cart values('"+newidcart+"','"+newidcustomer+"')";
                ldc.command2(sql3);
                Response.Redirect("login.aspx");
            }
         
        }
        //random
        public static int GenerateRandomNumber()
        {
            Random random = new Random();
            int min = 10000; 
            int max = 99999; 
            return random.Next(min, max);
        }
        private bool HasUpperCharacter(string a)
        {
            foreach(char c in a)
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
        // Kiểm tra 0 có số đằng trước vs (1)
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = args.Value;
            bool isValid = !char.IsDigit(username[0]) && !HasSpecialCharacters(username);
            args.IsValid = isValid;
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string password = args.Value;
            bool isVaild = HasSpecialCharacters(password) && HasNumberCharacter(password) && password.Length >= 9 && HasUpperCharacter(password);
            CustomValidator2.ErrorMessage = "Mật khẩu nên có độ dài 9 ký tự, có số, có ký tự đặc biệt và ít nhất có một chữ viết hoa";
            args.IsValid = isVaild;           
        }
    }
}