<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="OnlineDiskStore.cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="css/cart.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="cart-banner">
                <div class="cart-banner-icon">
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="icons/logo-image.png" OnClick="ImageButton2_Click" />
                </div>
                <div class="car-banner-line">
                </div>
                <div class="cart-banner-text-icon">
                    <div class="cart-banner-text-icon">
                        <span>Giỏ Hàng</span>
                        <asp:Image ID="Image1" runat="server" ImageUrl="icons/cart-logo.png" />
                    </div>
                </div>
            </div>
            <!-------------------------------->
            <div class="cart-content-information">
                <div class="cart-content-information-image">
                    <p>Sản phẩm</p>
                </div>
                <div class="cart-content-information-name">
                    <p>Tên Sản Phẩm</p>
                </div>
                <div class="cart-content-information-quantity">
                    <p>Số lượng</p>
                </div>
                <div class="cart-content-information-price">
                    <p>Đơn giá</p>
                </div>
                <div class="cart-content-information-button">
                    <p>Xóa</p>
                </div>
            </div>
            <div class="cart-content-product">
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="1" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>
                        <div class="cart-content-product-1">
                            <div class="cart-content-information-image">
                                <div class="cart-content-information-image-1">
                                    <asp:Image CssClass="image2" ID="Image2" runat="server" ImageUrl='<%# "image/"+Eval("productImage") %>' />
                                </div>
                            </div>
                            <div class="cart-content-information-name">
                                <asp:Label CssClass="label1" ID="Label1" runat="server" Text='<%# Eval("productName") %>'></asp:Label>
                            </div>
                            <div class="cart-content-information-quantity">
                                <asp:Button ID="Button2" CssClass="button-in-de" CommandName="de" runat="server" Text="-" />
                                <asp:Label CssClass="label2" ID="Label2" runat="server" Text='<%# Eval("Quanity") %>'></asp:Label>
                                <asp:Button ID="Button3" CssClass="button-in-de" CommandName="in" runat="server" Text="+" />
                            </div>
                            <div class="cart-content-information-price">
                                <asp:Label CssClass="label3" ID="Label3" runat="server" Text='<%# Eval("productPrice") %>'></asp:Label>
                                <span>VND</span>
                            </div>
                            <div class="cart-content-information-button">
                                <asp:ImageButton CssClass="imagebutton1" ID="ImageButton1" runat="server" ImageUrl="icons/x.png" CommandArgument='<%# Eval("productID") %>' OnClick="ImageButton1_Click" />
                            </div>
                        </div>
                        <asp:Label ID="Label5" runat="server" Visible="False" Text='<%# Eval("productID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="cart-total">
                <div class="cart-total-1">
                    <div class="cart-total-1-1"><span>Tổng tiền</span><asp:Label CssClass="cart-total-1" ID="Label4" runat="server" Text="Label"></asp:Label></div>
                    <asp:Button CssClass="cart-total-2" ID="Button1" runat="server" Text="Thanh toán" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
