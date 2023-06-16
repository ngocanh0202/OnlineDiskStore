<%@ Page Title="" Language="C#" MasterPageFile="~/account.Master" AutoEventWireup="true" CodeBehind="accountuser.aspx.cs" Inherits="OnlineDiskStore.accountuser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="css/account_user_update.css" />
    <div class="account_big_user">
        <asp:DataList ID="DataList2" runat="server">
            <ItemTemplate>
                <table class="account_big_user_table">
                    <tr>
                        <td class="account_big_user_information-1">Tên Đăng Nhập:
                        </td>
                        <td class="account_big_user_information-2">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("customerUserName") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="account_big_user_information-1">Mật khẩu:
                        </td>
                        <td class="account_big_user_information-2">
                            <asp:Label ID="Label2" runat="server" Text="***********"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="account_big_user_information-1">Họ tên:
                        </td>
                        <td class="account_big_user_information-2">
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("customerName") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="account_big_user_information-1">Email:
                        </td>
                        <td class="account_big_user_information-2">
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("customerEmail") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="account_big_user_information-1">Địa chỉ:
                        </td>
                        <td class="account_big_user_information-2">
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("customerAddress") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="account_big_user_information-1">Số tài khoản:
                        </td>
                        <td class="account_big_user_information-2">
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("customerBankNumber") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <div class="account-big-user-button-update">
            <button type="button" onclick="openupdate()">CẬP NHẬP</button>
            <div class="account-customer-update" id="account-customer-update-id">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DataList ID="DataList1" OnItemDataBound="DataList1_ItemDataBound" runat="server">
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
                <button type="button" style="height:31px;width:66px;margin-top:10px" onclick="closeupdate()">Đóng</button>
            </div>
        </div>
    </div>
    <script>
        let id = document.getElementById("account-customer-update-id");
        function openupdate() {
            id.classList.add("open-account-customer-update");
        }
        function closeupdate() {
            id.classList.remove("open-account-customer-update");
        }
    </script>
</asp:Content>
