<%@ Page Title="" Language="C#" MasterPageFile="~/master_seller_page.Master" AutoEventWireup="true" CodeBehind="warehouse.aspx.cs" Inherits="OnlineDiskStore.warehouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-line">
        <span>Kho hàng</span>
        <div class="line"></div>
    </div>
    <div class="warehouse-under">
        <asp:DataList ID="DataList1" RepeatColumns="4" runat="server">
            <ItemTemplate>
                <div class="warehouse-content">
                    <div class="warehouse-image-big">
                        <div class="warehouse-image">
                            <asp:ImageButton ID="ImageButton1" CssClass="image-1" runat="server" ImageUrl='<%# "image/"+Eval("productImage") %>' CommandArgument='<%# Eval("productID") %>' OnClick="ImageButton1_Click" />
                        </div>
                    </div>
                    <div class="warehouse-text">
                        <asp:LinkButton ID="LinkButton1" CssClass="link-warehouse-seller" runat="server" Text='<%# Eval("productName") %>' CommandArgument='<%# Eval("productID") %>' OnClick="LinkButton1_Click"></asp:LinkButton>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("productPrice") %>'></asp:Label><span>VND</span>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
