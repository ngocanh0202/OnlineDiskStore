<%@ Page Title="" Language="C#" MasterPageFile="~/master-page.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="search2.aspx.cs" Inherits="OnlineDiskStore.search2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="css/search.css" />
    <div class="goods">
        <div class="header_text">
            <div class="text" style="width: 105px;">Tìm kiếm</div>
            <div class="line_header" style="width: 864px;"></div>
        </div>
        <div class="content_goods">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" Width="960px">
                <ItemTemplate>
                    <div class="item_disk">
                        <div class="image_of_disk">
                            <div class="image_of_disk_1">
                                <asp:ImageButton CssClass="ImageButton5" ID="ImageButton5" runat="server" ImageUrl='<%# "image/"+Eval("productImage") %>' CommandArgument='<%# Eval("productID") %>' OnClick="ImageButton5_Click1" />
                            </div>
                        </div>
                        <div class="information_of_disk">
                            <asp:LinkButton ID="LinkButton1" Text='<%# Eval("productName") %>' CommandArgument='<%# Eval("productID") %>' OnClick="LinkButton1_Click1" runat="server" Font-Bold="True" Font-Overline="False" Font-Underline="False" Font-Strikeout="False"></asp:LinkButton>
                            <br />
                            <asp:Label ID="giasp" runat="server" Text='<%# Eval("productPrice") %>'></asp:Label><span> VND</span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
