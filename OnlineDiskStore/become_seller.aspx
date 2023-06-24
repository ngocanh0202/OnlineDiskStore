<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="become_seller.aspx.cs" Inherits="OnlineDiskStore.become_seller" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="css/become_seller.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="margin-top:30px">
            <div class="logo_dangky">
                <asp:ImageButton ID="ImageButton_logo" OnClick="ImageButton_logo_Click" ImageUrl="icons/logo-image.png" runat="server" Height="90px" Width="90px" />
            </div>
            <div class="ten_trang">
                <h1 class="mauchu">Đăng ký thành người bán hàng</h1>
            </div>
            <div class="thongtin">
                <div class="table">
                    <table class="table_nho">
                        <tr style="border:none">
                            <td>Tên của cửa hàng</td>
                            <td>
                                <asp:TextBox ID="txt_Tencuahang" Style="font-size: 22px; width: 450px; height: 35px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="border:none">
                            <td>CMND/CCCD</td>
                            <td>
                                <asp:TextBox ID="txt_cmnd" Style="font-size: 22px; width: 450px; height: 35px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="border:none">
                            <td>Tên ngân hàng</td>
                            <td>
                                <asp:TextBox ID="txt_tennganhang" Style="font-size: 22px; width: 450px; height: 35px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="border:none">
                            <td>Tài khoản ngân hàng</td>
                            <td>
                                <asp:TextBox ID="txt_tknganhang" Style="font-size: 22px; width: 450px; height: 35px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="dangky">
                    <asp:Button ID="btn_dangky" runat="server" ForeColor="White" OnClick="btn_dangky_Click1" Text="Đăng ký" Width="392px" Height="67px" Font-Size="32px" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
