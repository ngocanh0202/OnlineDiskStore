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
            if (Page.IsValid)
            {
                if (checknameaccount() == 1) return;
                string sql = "select count(*) from Customer";
                string newidcustomer = "" + GenerateRandomNumber()+((int)ldc.count(sql)+1);
                string sql2 = "insert into Customer (customerID, customerUserName, customerPassword) values ('"+newidcustomer+"','"+TextBox3.Text+"','"+TextBox1.Text+"')";
                ldc.command2(sql2);
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
        // Kiểm tra 0 có số đằng trước vs (1)
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = args.Value;
            bool isValid = !char.IsDigit(username[0]) && !HasSpecialCharacters(username);
            args.IsValid = isValid;
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
    }
}