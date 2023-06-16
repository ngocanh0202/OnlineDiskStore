﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seller_detail_product.aspx.cs" Inherits="OnlineDiskStore.seller_detail_product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="css/banner.css" />
    <link rel="stylesheet" href="css/detail_new.css" />
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
                        <asp:TextBox ID="search" placeholder="Tìm kiếm" runat="server"></asp:TextBox>
                    </div>
                    <div class="search-2">
                        <asp:ImageButton ID="image" runat="server" ImageUrl="icons/logo-timkiem.png" OnClick="image_Click" />
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
            <div class="detail-content">
                <div class="detail-content-1">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DataList ID="DataList1" OnItemDataBound="DataList1_ItemDataBound" OnItemCommand="DataList1_ItemCommand" runat="server">
                                <ItemTemplate>
                                    <div class="detail-content-information-big1">
                                        <div class="detail-content-image">
                                            <asp:Image CssClass="detail-content-image-1" ID="Image1" runat="server" ImageUrl='<%# "image/"+Eval("productImage") %>' />
                                        </div>
                                        <div class="detail-content-information-1">
                                            <div class="detail-content-information-1-name">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("productName") %>'></asp:Label>
                                            </div>
                                            <div class="detail-content-information-1-sold">
                                                <asp:Label ID="Label8" runat="server" Text=""></asp:Label><span>Đã bán</span>
                                            </div>
                                            <div class="detail-content-information-1-content_price"><h1>GIÁ TIỀN</h1></div>
                                            <div class="detail-content-information-1-price">
                                                <div class="detail-content-information-1-price-2">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("productPrice") %>'></asp:Label>
                                                </div>
                                            </div>
                                            <div class="detail-content-information-1-number">
                                                <span class="detail-content-information-1-number-1">Số lượng</span>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("productStockLevel") %>'></asp:Label>
                                                <span class="detail-content-information-1-number-2">Sản phẩm có sẵn</span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="detail-content-information-2">
                                        <div class="detail-content-information-2-1">
                                            <span>Thông tin sản phẩm</span>
                                        </div>
                                        <div class="detail-content-information-2-2">
                                            <div class="detail-content-information-2-2-triangle"></div>
                                        </div>
                                        <div class="detail-content-information-2-3">
                                            <div class="detail-content-information-2-3-information">
                                                <span>Tên người bán: </span>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("sellerName") %>'></asp:Label>
                                                <br />
                                                <span>Năm phát hành: </span>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("productDistributeYear") %>'></asp:Label>
                                                <br />
                                                <span>Thể loại: </span>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("productCategory") %>'></asp:Label>
                                                <br />
                                                <span>Mô tả:</span><asp:Label ID="Label7" runat="server" Text='<%# Eval("productDescription") %>'></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>