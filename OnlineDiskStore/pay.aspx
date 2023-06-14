<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pay.aspx.cs" Inherits="OnlineDiskStore.pay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="css/pay-new.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="pay-banner">
                <div class="pay-banner-logo">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="icons/logo-image.png" OnClick="ImageButton1_Click" />
                </div>
                <div class="pay-banner-line">
                </div>
                <div class="pay-banner-text">
                    <h1>Thanh toán</h1>
                </div>
            </div>
            <div class="pay-content">
                <div class="pay-text">
                    <div class="pay-text-image">
                        <p>Sản phẩm</p>
                    </div>
                    <div class="pay-text-name">
                        <p>Tên</p>
                    </div>
                    <div class="pay-text-numbers">
                        <p>Số lượng</p>
                    </div>
                    <div class="pay-text-price">
                        <p>Đơn giá</p>
                    </div>
                </div>
                <div class="pay-text-datalist">
                    <asp:DataList ID="DataList1" runat="server">
                        <ItemTemplate>
                            <div class="pay-text-datalist-1">
                                <div class="pay-text-datalist-image">
                                    <asp:Image ID="Image1" runat="server" CssClass="payimage" ImageUrl='<%# "image/"+Eval("productImage") %>' />
                                </div>
                                <div class="pay-text-datalist-name">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("productName") %>'></asp:Label>
                                </div>
                                <div class="pay-text-datalist-numbers">
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Quanity") %>'></asp:Label>
                                </div>
                                <div class="pay-text-datalist-price">
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("productPrice") %>'></asp:Label>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
            <div class="pay-voucher">
                <div class="pay-voucher-text">
                    <p>voucher</p>
                </div>
                <div class="pay-voucher-button">
                    <button type="button" id="button-voucher" onclick="openevenvoucher()">Chọn Voucher</button>
                    <asp:Label ID="Label4" runat="server" Text="Chưa chọn" Font-Size="20px"></asp:Label>
                </div>
            </div>
            <div class="pay-voucher-Choices_voucher" id="pay-voucher-Choices_voucher-id">
                <h1>Chọn voucher</h1>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Value="0" Text="Chưa chọn">
                    </asp:ListItem>
                    <asp:ListItem Value="1" Text="Free Ship">
                    </asp:ListItem>
                    <asp:ListItem Value="2" Text="Giảm 30% đơn giá">
                    </asp:ListItem>
                </asp:DropDownList>
                <br />
                <button type="button" id="button-close-voucher" onclick="closeevenvoucher()">Chốt</button>
            </div>
            <!---------------------------------->
            <div class="pay-method-pay">
                <div class="pay-method-pay-text">
                    <p>Phương thức thanh toán</p>
                </div>
                <div class="pay-method-pay-button">
                    <button type="button" id="button-method-pay" onclick="openevenmethodpay()">Chọn phương thức thanh toán</button>
                    <asp:Label ID="Label5" runat="server" Font-Size="20px" Text=""></asp:Label>
                </div>
            </div>
            <div class="pay-method-pay-choices" id="pay-method-pay-choices-id">
                <h1>Chọn phương thức thanh toán</h1>
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    <asp:ListItem Value="0">Chọn phương thức thanh toán</asp:ListItem>
                    <asp:ListItem Value="1" Text="Thanh toán khi có hàng"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Thanh toán bằng thẻ"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <button type="button" id="button-close-method-pay" onclick="closeevenmethodpay()">Chốt</button>
            </div>
            <!---------------------------------------------------->
            <div class="pay-address">
                <div class="pay-address-text">
                    <button type="button" onclick="openchoiceaddress()">Địa chỉ giao hàng</button>
                </div>
                <div>
                    <asp:Label ID="Label6" runat="server" Font-Size="20px" Text=""></asp:Label>
                </div>
            </div>
            <div class="pay-address-choices" id="pay-address-choices-id">
                <div class="pay-address-choices-tinh">
                    <span>tỉnh/thành phố</span>
                    <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                        <asp:ListItem Text="Chọn tỉnh/thành phố" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Đà Nẵng"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
                <div class="pay-address-choices-huyen-quan">
                    <span>quận/huyện</span>
                    <asp:DropDownList ID="DropDownList4" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                        <asp:ListItem Text="Chọn Quận/Huyện" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Quận Hải Châu"></asp:ListItem>
                        <asp:ListItem Text="Quận Liên Chiếu"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
                <div class="pay-address-choices-phuong-xa">
                    <span>phường/xã</span>
                    <asp:DropDownList ID="DropDownList5" runat="server" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                        <asp:ListItem Text="Chọn Phường/Xã" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Xã Hòa Bắc"></asp:ListItem>
                        <asp:ListItem Text="Xã Hòa Châu"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <br />
                <div class="pay-address-choices-phuong-xa">
                    <span>Nhập thông tin chi tiết địa chỉ</span>
                    <asp:TextBox ID="TextBox1" TextMode="MultiLine" runat="server" OnTextChanged="TextBox1_TextChanged" Width="300px" Height="110px"></asp:TextBox>
                </div>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Chốt" OnClick="Button1_Click" />
                <%--<button type="button" id="button-close-address" onclick="closechoiceaddress()">Chốt</button>--%>
            </div>
            <!---------------------------------------------------------->
            <div class="pay-total">
                <div class="pay-total-text">
                    <p>Tổng tiền cần thanh toán</p>
                </div>
                <div class="pay-total-price">
                    <span>Tổng tiền đơn hàng: +</span><asp:Label ID="lb_price_product" runat="server" Text=""></asp:Label><span>VND</span>
                    <br />
                    <span>Tiền vận chuyển: +</span><asp:Label ID="Label8" runat="server" Text="40000"></asp:Label><span>VND</span>
                    <br />
                    <asp:Label ID="Label9" runat="server" Visible="false" Text="Voucher: -"></asp:Label><asp:Label ID="Label10" runat="server" Text=""></asp:Label><asp:Label ID="Label7" runat="server" Visible="false" Text="VND"></asp:Label>
                    <br />
                    <span>------------------------------------</span>
                    <br />
                    <span>Tổng Tiền:</span><asp:Label ID="lb_total" runat="server" Text=""></asp:Label><asp:Label ID="Label11" runat="server" Text="VND"></asp:Label>
                </div>
            </div>
            <div class="pay-button">
                <asp:Button ID="Button2" runat="server" Text="Thanh Toán" OnClick="Button2_Click" />
            </div>
        </div>
        <script src="javascript/even_pay.js"></script>
        <script src="javascript/even_method_pay.js"></script>
        <script src="javascript/even_address.js"></script>
    </form>
</body>
</html>
