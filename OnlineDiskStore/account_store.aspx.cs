using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class account_store : System.Web.UI.Page
    {
        lopdungchung ldc;
        public account_store()
        {
            ldc = new lopdungchung();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (check() == false) return;
            loaddata();
        }
        private void loaddata()
        {
            string sql = "select * from Seller where sellerID = '" + Session["customerID"] +"' ";
            DataList1.DataSource = ldc.getdata(sql);
            DataList1.DataBind();
            DataList2.DataSource = ldc.getdata(sql);
            DataList2.DataBind();
        }
        private bool check()
        {
            string sql = "select count(sellerID) from Customer where customerID = '" + Session["customerID"] +"' ";
            int a = (int)ldc.count(sql);
            if (a > 0)
            {
                Button1.Visible= false;
                return true;
            }
            else
            {
                Button1.Visible = true;
                return false;
            }
        }


        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                TextBox txt_banknum = (TextBox)e.Item.FindControl("txt_banknum");
                string value = ((DataRowView)e.Item.DataItem)["sellerBankNumber"].ToString().Trim();
                txt_banknum.Text = value;
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
            DataListItem dtl = (DataListItem)btn.NamingContainer;
            TextBox txt_banknum = (TextBox)dtl.FindControl("txt_banknum");
            string banknum_string = txt_banknum.Text;
            if(ContainsOnlyDigits(banknum_string) == false || banknum_string.Length < 9 || banknum_string.Length > 14)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Số tài khoản nhập sai')", true);
                return;
            }
            TextBox txt_cccd = (TextBox)dtl.FindControl("txt_cccd");
            if(ContainsOnlyDigits(txt_cccd.Text) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Số CCCD/CMND nhập sai')", true);
                return;
            }
            TextBox txt_bankname = (TextBox)dtl.FindControl("txt_bankname");
            TextBox txt_name = (TextBox)dtl.FindControl("txt_name");
            

            string sql = "update Seller set sellerCitizenIDNum = N'"+txt_cccd.Text+"', sellerName = N'"+txt_name.Text+"', sellerBankNumber = N'"+ banknum_string + "', sellerBankName = N'"+ txt_bankname.Text+ "' where sellerID = '" + Session["customerID"] +"'  ";
            ldc.command2(sql);
            Response.Redirect("account_store.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("become_seller.aspx");
        }
    }
}