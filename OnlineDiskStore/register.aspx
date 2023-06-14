<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="OnlineDiskStore.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/register.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="register-1">
                <div class="image" style="text-align: center">
                    <img src="icons/logo-image.png" />
                </div>
                <div class="dangky">
                    <div class="bd">
                        <h2 style="text-align: center">ĐĂNG KÝ TÀI KHOẢN</h2>
                        <div class="hang">
                            <div class="thongtin">
                                <p>Tên tài khoản:</p>
                            </div>
                            <div class="nhap" style="padding-left: 60px;">
                                <asp:TextBox ID="TextBox3" CssClass="register-input" runat="server" Width="395px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="TextBox3" runat="server" Display="Dynamic" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="CustomValidator1" ForeColor="Red" runat="server" ControlToValidate="TextBox3" ErrorMessage="Tên đăng nhập không hợp lệ" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="hang">
                            <div class="thongtin">
                                <p>Mặt Khẩu:</p>
                            </div>
                            <div class="nhap" style="padding-left: 60px;">
                                <asp:TextBox ID="TextBox1" CssClass="register-input" TextMode="Password" runat="server" Width="395px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="TextBox1" runat="server" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="hang">
                            <div class="thongtin">
                                <p>Nhập lại mặt khẩu:</p>
                            </div>
                            <div class="nhap" style="padding-left: 60px;">
                                <asp:TextBox ID="TextBox2" CssClass="register-input" TextMode="Password" runat="server" Width="395px"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ErrorMessage="Mật khẩu không giống nhau" ControlToValidate="TextBox2" ControlToCompare="TextBox1"></asp:CompareValidator>
                            </div>
                        </div>

                        <div class="sub" style="text-align: center">
                            <asp:Button ID="Button1" Text="Đăng Ký" OnClick="Button1_Click" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="register-2">
                <span style="color:black">Bạn đã có tài khoản?
                </span>
                <span>
                    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server">Đăng nhập</asp:LinkButton>
                </span>
            </div>
        </div>
    </form>
</body>
</html>
