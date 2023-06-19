<%@ Page Title="" Language="C#" MasterPageFile="~/account.Master" AutoEventWireup="true" CodeBehind="accountreceipt.aspx.cs" Inherits="OnlineDiskStore.accountreceipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/account_receipt.css" rel="stylesheet" />
    <div style="display: flex;flex-direction: column;align-items: stretch;height: auto;width: auto;">
        <asp:GridView ID="GridView1" Width="100%" AutoGenerateColumns="False" CssClass="receipt_css" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Mã đơn giá">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="link_button_id" runat="server" CommandArgument='<%# Eval("receiptID") %>' Text='<%# Eval("receiptID") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Địa chỉ">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("paymentDetail") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phương thức thanh toán">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("methodPay") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày tạo">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("createdDate", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tổng tiền">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("totalPrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </div>
</asp:Content>
