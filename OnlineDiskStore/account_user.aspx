<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account_user.aspx.cs" Inherits="OnlineDiskStore.account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="css/account_user_new.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container">
            <div class="account-customer-update">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DataList ID="DataList1" runat="server">
                            <ItemTemplate>
                                <table style="width: 430px; height: 420px;">
                                    <tr>
                                        <td colspan="2">-----------------TÀI KHOẢN-----------------</td>
                                    </tr>
                                    <tr>
                                        <td class="account-customer-update-1">Tên đăng nhập
                                        </td>
                                        <td class="account-customer-update-2">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("customerUserName") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="account-customer-update-1">
                                            <asp:Label ID="lb_password" runat="server" Text="Mật khẩu"></asp:Label>
                                        </td>
                                        <td class="account-customer-update-2">
                                            <asp:TextBox ID="txt_password" runat="server" Text="*********"></asp:TextBox><asp:Button CssClass="btn_password" ID="btn_edit" runat="server" Text="Hiện" OnClick="btn_edit_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="account-customer-update-1">
                                            <asp:Label ID="lb_password_new" runat="server" Visible="false" Text="Nhập mật khẩu mới"></asp:Label>
                                        </td>
                                        <td class="account-customer-update-2">
                                            <asp:TextBox ID="txt_password_new" TextMode="Password" Visible="false" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="account-customer-update-1">
                                            <asp:Label ID="lb_password_new_again" runat="server" Visible="false" Text="Nhập lại mật khẩu"></asp:Label>
                                        </td>
                                        <td class="account-customer-update-2">
                                            <asp:TextBox ID="txt_password_new_again" TextMode="Password" Visible="false" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:CompareValidator Display="Dynamic" ID="CompareValidator1" runat="server" ControlToValidate="txt_password_new" ControlToCompare="txt_password_new_again" ForeColor="Red" ErrorMessage="Mật khẩu không giống"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="Button1" CssClass="btn_password" OnClick="Button1_Click" runat="server" Text="Cập nhập mật khẩu" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">-----------------THÔNG TIN CHI TIẾT-----------------</td>
                                    </tr>
                                    <tr>
                                        <td class="account-customer-update-1">Họ tên
                                        </td>
                                        <td class="account-customer-update-2">
                                            <asp:TextBox ID="txt_name" runat="server" Text='<%# Eval("customerName") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="account-customer-update-1">Email
                                        </td>
                                        <td class="account-customer-update-2">
                                            <asp:TextBox ID="txt_email" runat="server" Text='<%# Eval("customerEmail") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="account-customer-update-1">Số điện thoại
                                        </td>
                                        <td class="account-customer-update-2">
                                            <asp:TextBox ID="txt_phone" runat="server" Text='<%# Eval("customerPhone") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="account-customer-update-1">Địa chỉ
                                        </td>
                                        <td class="account-customer-update-2">
                                            <asp:TextBox ID="txt_address" runat="server" Text='<%# Eval("customerAddress") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="account-customer-update-1">Số tài khoản:
                                        </td>
                                        <td class="account-customer-update-2">
                                            <asp:TextBox ID="txt_banknumber" runat="server" Text='<%# Eval("customerBankNumber") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="account-customer-update-1">Tên ngân hàng
                                        </td>
                                        <td class="account-customer-update-2">
                                            <asp:TextBox ID="txt_bankname" runat="server" Text='<%# Eval("customerBankName") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="Button2" CssClass="btn_password" Enabled="true" runat="server" Text="Cập nhập thông tin cá nhân" OnClick="Button2_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
