<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="OnlineDiskStore.account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="css/account.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="account-banner">
                <div class="account-banner-image">
                    <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" />
                </div>
                <div class="account-banner-text">
                    <span>Thông tin tài khoản</span>
                </div>
            </div>
            <div class="account-content">
                <div class="account-content-left">
                    <asp:Button ID="Button1" runat="server" Text="Thông tin tài khoản" />
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="Hóa đơn" />
                    <br />
                    <asp:Button ID="Button3" runat="server" Text="Kho hàng" />
                </div>
                <div class="account-content-line">

                </div>
                <div class="account-content-right">
                    <div class="account-content-right-customer">
                        <asp:DataList ID="DataList1" runat="server">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            Tên đăng nhập
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mật khẩu
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="*************"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Họ tên
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
