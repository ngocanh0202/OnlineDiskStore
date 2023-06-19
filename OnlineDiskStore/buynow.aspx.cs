using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiskStore
{
    public partial class buynow : System.Web.UI.Page
    {
        lopdungchung ldc;
        public buynow()
        {
            ldc = new lopdungchung();   
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            loaddata();
        }
        private void loaddata()
        {
            string sql = "select * from Product where productID = '" + Request.QueryString["idbuynow"] +"' ";
            DataList1.DataSource = ldc.getdata(sql);
            DataList1.DataBind();
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home-page.aspx");
        }
        

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label4.Text = DropDownList1.SelectedItem.Text;
            if (DropDownList1.SelectedValue != "0")
            {
                if (DropDownList1.SelectedValue == "1")
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
                    Label10.Text = "" + c;
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

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue != "0")
            {
                Label5.Text = DropDownList2.SelectedItem.Text + "";
                if (DropDownList2.SelectedValue == "2")
                {
                    string sql = "select count(customerBankNumber) from Customer where customerID = '" + Session["customerID"] + "' ";
                    object banknumber = ldc.count(sql);
                    if ((int)banknumber == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerMessage", "alert('Bạn chưa có thông tin về thẻ ngân hàng, vui lòng cập nhập')", true);
                        Response.Redirect("accountuser.aspx");
                    }
                }
            }
        }
        string stringaddress()
        {
            string a = "";
            if (DropDownList3.SelectedValue != "0")
                if (DropDownList3.SelectedItem != null)
                {
                    a = DropDownList3.SelectedValue.ToString() + "" + a;
                }
            if (DropDownList4.SelectedValue != "0")
                if (DropDownList4.SelectedItem != null)
                {
                    a = a + ", " + DropDownList4.SelectedItem.ToString();
                }
            if (DropDownList5.SelectedValue != "0")
                if (DropDownList5.SelectedItem != null)
                {
                    a = a + ", " + DropDownList5.SelectedValue.ToString();
                }
            if (TextBox1 != null)
            {
                a = TextBox1.Text + ", " + a;
            }
            return a;
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label6.Text = stringaddress();
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label6.Text = stringaddress();
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label6.Text = stringaddress();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Label6.Text = stringaddress();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "CloseScript", "let add = document.getElementById('pay-address-choices-id'); add.classList.remove('open-pay-address-choices'); __doPostBack('', '');", true);
        }
        // Thành toán
        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            System.Web.UI.WebControls.Label Label2 = (System.Web.UI.WebControls.Label)e.Item.FindControl("Label2");
            Label2.Text = ""+ Request.QueryString["idbuynow"].ToString();
        }
    }
}