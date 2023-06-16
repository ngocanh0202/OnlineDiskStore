<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="become_seller.aspx.cs" Inherits="OnlineDiskStore.become_seller" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="css/become_seller_new.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="logo_dangky">
                <asp:ImageButton ID="ImageButton_logo" ImageUrl="icons/logo-image.png" runat="server" Height="90px" Width="90px" />
            </div>
            <div class="ten_trang">
                <h1 class="mauchu">Đăng ký thành người bán hàng</h1>
            </div>
            <div class="thongtin">
                <div class="thongtin_lable">
                    <ul class="thongtin_list">
                        <li>Tên của cửa hàng
                        </li>
                        <li>CMND/CCCD
                        </li>
                        <li>Tên ngân hàng
                        </li>
                        <li>Tài khoản ngân hàng
                        </li>
                    </ul>
                </div>
                <div class="Thongtin_textbox">
                    <ul class="thongtin_listbox">
                        <li>
                            <asp:TextBox ID="txt_Tencuahang" Font-Size="22px" runat="server" Width="450px" Height="35px"></asp:TextBox>
                        </li>
                        <li>
                            <asp:TextBox ID="txt_cmnd" Font-Size="22px" runat="server" Width="450px" Height="35px"></asp:TextBox>
                        </li>
                        <li>
                            <asp:TextBox ID="txt_tennganhang" Font-Size="22px" runat="server" Width="450px" Height="35px"></asp:TextBox>
                        </li>
                        <li>
                            <asp:TextBox ID="txt_tknganhang" Font-Size="22px" runat="server" Width="450px" Height="35px"></asp:TextBox>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="dangky">
                <asp:Button ID="btn_dangky" runat="server" ForeColor="White" Text="Đăng ký" Width="392px" Height="67px" Font-Size="32px" OnClick="btn_dangky_Click" />
            </div>
        </div>
    </form>
</body>
</html>
