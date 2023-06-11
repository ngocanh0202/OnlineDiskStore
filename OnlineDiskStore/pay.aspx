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
                    <asp:ListItem Text="Chưa chọn">
                    </asp:ListItem>
                    <asp:ListItem Text="Free Ship">
                    </asp:ListItem>
                    <asp:ListItem Text="Giảm 30% đơn giá">
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
                    <asp:ListItem Text="Thanh toán khi có hàng"></asp:ListItem>
                    <asp:ListItem Text="Thanh toán bằng thẻ đã đăng nhập"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <button type="button" id="button-close-method-pay" onclick="closeevenmethodpay()">Chốt</button>
            </div>
            <!---------------------------------------------------->
            <div class="pay-address">
                <div class="pay-address-text">
                    <button type="button" onclick="openchoiceaddress()">Địa chỉ giao hàng</button>
                </div>
                <asp:Label ID="Label6" runat="server" Font-Size="20px" Text=""></asp:Label>
            </div>
            <div class="pay-address-choices" id="pay-address-choices-id">
                <div class="pay-address-choices-tinh">
                    <span>Tỉnh/Thành phố</span>
                    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        <asp:ListItem Text="Đà Nẵng"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
                <div class="pay-address-choices-tinh-quan">
                    <span>Quận/ Huyện</span>
                    <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        <asp:ListItem Text="Quận Hải Châu"></asp:ListItem>
                        <asp:ListItem Text="Quận liên chiếu"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
                <div class="pay-address-choices-phuong-xa">
                    <span>Nhập thông tin chi tiết địa chỉ</span>
                    <asp:TextBox ID="TextBox1" runat="server" Width="300px" Height="110px"></asp:TextBox>
                </div>
                <br />
                <button type="button" id="button-close-address" onclick="closechoiceaddress()">Chốt</button>
            </div>
        </div>
        <script src="javascript/even_pay.js"></script>
        <script src="javascript/even_method_pay.js"></script>
    </form>
</body>
</html>
