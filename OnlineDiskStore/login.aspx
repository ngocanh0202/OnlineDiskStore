<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="OnlineDiskStore.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/login.css"/>
    <link rel="stylesheet" href="content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="login-logo">
                <asp:Image ID="Image1" runat="server" ImageUrl="icons/logo-image.png" />
            </div>
            <h2 style="margin-top: 17px; font-size: 25px;">Đăng Nhập</h2>
            <div class="login-textbox">
                <div class="login-textbox-user">
                    <div class="login-textbox-user-1">Tên tài khoản</div>
                    <div class="login-textbox-user-2">
                        <asp:TextBox ID="TextBox1" CssClass="textbox-login" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="login-textbox-pass">
                    <div class="login-textbox-user-1">
                        Mật khẩu
                    </div>
                    <div class="login-textbox-user-2">
                        <asp:TextBox ID="TextBox2" TextMode="Password" CssClass="textbox-login" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="login-check-remember">
                <asp:CheckBox ID="CheckBox1" runat="server" /><span>Ghi nhớ</span>
            </div>
            <div class="login-button">
                <asp:Button ID="Button1" runat="server" Text="Đăng nhập" OnClick="Button1_Click" />
            </div>
            <div class="login-line">
            </div>
            <div class="login-register">
                <span>Bạn chưa có tài khoản?</span><span><asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server">Đăng ký</asp:LinkButton></span>
            </div>
        </div>
    </form>
</body>
</html>
