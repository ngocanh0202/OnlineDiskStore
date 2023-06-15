<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search_product.aspx.cs" Inherits="OnlineDiskStore.search_product" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!---------CANCEL------------->
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="css/banner.css" />
    <link rel="stylesheet" href="css/search.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
     
            <div class="banner">
                <!---------Banner------------->
                <asp:ImageButton ID="logo" runat="server" ImageUrl="icons/logo-image.png" OnClick="logo_Click" />
                <div class="search">
                    <div class="search-1">
                        <%--<input id="search" type="text" placeholder="Tìm kiếm" />--%>
                        <asp:TextBox ID="search" runat="server"></asp:TextBox>
                    </div>
                    <div class="search-2">
                        <asp:ImageButton ID="image" runat="server" OnClick="image_Click" ImageUrl="icons/logo-timkiem.png" />
                    </div>
                </div>
                <div class="cart">
                    <div class="cart-1">
                        <asp:ImageButton ID="cart" runat="server" ImageUrl="icons/cart-logo.png" OnClick="cart_Click" />
                    </div>
                    <div class="cart-2">
                        <p>Giỏ hàng</p>
                    </div>
                </div>
                <div class="account">
                    <div class="account-1">
                        <asp:ImageButton ID="account" runat="server" OnClick="account_Click" ImageUrl="icons/logo-account.png" />
                    </div>
                    <div class="account-2">
                        <p>Tài khoản</p>
                    </div>
                </div>
            </div>
            <div class="goods">
                <div class="header_text">
                    <div class="text" style="width: 200px;">Hàng vừa cập nhập</div>
                    <div class="line_header" style="width: 769px;"></div>
                </div>
                <div class="content_goods">
                    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" Width="960px">
                        <ItemTemplate>
                            <div class="item_disk">
                                <div class="image_of_disk">
                                    <div class="image_of_disk_1">
                                        <asp:ImageButton CssClass="ImageButton5" ID="ImageButton5" runat="server" ImageUrl='<%# "image/"+Eval("productImage") %>' CommandArgument='<%# Eval("productID") %>' OnClick="ImageButton5_Click" />
                                    </div>
                                </div>
                                <div class="information_of_disk">
                                    <asp:LinkButton ID="LinkButton1" Text='<%# Eval("productName") %>' CommandArgument='<%# Eval("productID") %>' OnClick="LinkButton1_Click" runat="server" Font-Bold="True" Font-Overline="False" Font-Underline="False" Font-Strikeout="False"></asp:LinkButton>
                                    <br />
                                    <asp:Label ID="giasp" runat="server" Text='<%# Eval("productPrice") %>'></asp:Label><span> VND</span>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
