<%@ Page Title="" Language="C#" MasterPageFile="~/account.Master" AutoEventWireup="true" CodeBehind="account_store.aspx.cs" Inherits="OnlineDiskStore.account_store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .button_update_seller {
            background: red;
            color: white;
        }

            .button_update_seller:hover {
                background: white;
                color: red;
            }

        .Button1_become_seller {
            background: red;
            color: white;
            height: 70px;
            width: 300px;
            font-size: 17px;    
        }

            .Button1_become_seller:hover {
                background: white;
                color: red;
            }
    </style>
    <link rel="stylesheet" href="css/account_user_update.css" />
    <asp:Button ID="Button1" runat="server" CssClass="Button1_become_seller" Text="TRỞ THÀNH NGƯỜI BÁN HÀNG" OnClick="Button1_Click" />
    <div class="account_big_user">
        <asp:DataList ID="DataList2" runat="server">
            <ItemTemplate>
                <table class="account_big_user_table">
                    <tr>
                        <td colspan="2">Thông tin cửa hàng
                        </td>
                    </tr>
                    <tr>
                        <td class="account_big_user_information-1">CCCD/CMND:
                        </td>
                        <td class="account_big_user_information-2">
                            <asp:Label ID="lb_cccd" runat="server" Text='<%# Eval("sellerCitizenIDNum") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="account_big_user_information-1">Tên cửa hàng:
                        </td>
                        <td class="account_big_user_information-2">
                            <asp:Label ID="lb_name" runat="server" Text='<%# Eval("sellerName") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="account_big_user_information-1">Số tài khoản ngân hàng:
                        </td>
                        <td class="account_big_user_information-2">
                            <asp:Label ID="lb_banknum" runat="server" Text='<%# Eval("sellerBankNumber") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="account_big_user_information-1">Tên ngân hàng:
                        </td>
                        <td class="account_big_user_information-2">
                            <asp:Label ID="lb_bankname" runat="server" Text='<%# Eval("sellerBankName") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
                <div class="account-big-user-button-update">
                    <button type="button" onclick="openupdate()">CẬP NHẬP</button>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <div class="account-customer-update" id="account-customer-update-id">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DataList ID="DataList1" OnItemDataBound="DataList1_ItemDataBound" runat="server">
                        <ItemTemplate>
                            <table style="width: 430px; height: 420px; font-size: 20px">
                                <tr>
                                    <td colspan="2">THÔNG TIN CỬA HÀNG</td>
                                </tr>
                                <tr>
                                    <td class="account-customer-update-1">CCCD/CMND
                                    </td>
                                    <td class="account-customer-update-2">
                                        <asp:TextBox ID="txt_cccd" runat="server" Text='<%# Eval("sellerCitizenIDNum") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="account-customer-update-1">Tên cửa hàng
                                    </td>
                                    <td class="account-customer-update-2">
                                        <asp:TextBox ID="txt_name" runat="server" Text='<%# Eval("sellerName") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="account-customer-update-1">Số tài khoản ngân hàng
                                    </td>
                                    <td class="account-customer-update-2">
                                        <asp:TextBox ID="txt_banknum" runat="server" Text='<%# Eval("sellerBankNumber") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="account-customer-update-1">Tên ngân hàng
                                    </td>
                                    <td class="account-customer-update-2">
                                        <asp:TextBox ID="txt_bankname" runat="server" Text='<%# Eval("sellerBankName") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="Button2" runat="server" Text="Cập nhập" CssClass="button_update_seller" OnClick="Button2_Click" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </ContentTemplate>
            </asp:UpdatePanel>
            <button type="button" style="height: 31px; width: 66px; margin-top: 10px" onclick="closeupdate()">Đóng</button>
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
