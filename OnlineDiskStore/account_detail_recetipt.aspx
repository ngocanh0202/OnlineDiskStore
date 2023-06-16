<%@ Page Title="" Language="C#" MasterPageFile="~/account.Master" AutoEventWireup="true" CodeBehind="account_detail_recetipt.aspx.cs" Inherits="OnlineDiskStore.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/account_receipt_detail.css" rel="stylesheet" />
    <asp:GridView ID="GridView1" runat="server" CssClass="gridview_detail" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Tên sản phẩm">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("productName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hình ảnh">
                <ItemTemplate>
                    <div class="image_product_detail">
                        <asp:Image ID="Image2" runat="server" CssClass="image_product_detail-1" ImageUrl='<%# "image/"+Eval("productImage") %>' />
                    </div>            
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Giá tiền">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("productPrice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Số lượng">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <div class="detail_receipt">
        <span>Tổng hóa đơn: </span><asp:Label ID="Label4" runat="server" Text=""></asp:Label><span>VND</span>
    </div>
</asp:Content>
