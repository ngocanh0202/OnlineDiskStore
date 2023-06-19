<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seller_detail_product.aspx.cs" Inherits="OnlineDiskStore.seller_detail_product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="css/banner.css" />
    <link rel="stylesheet" href="css/seller_detail_product_new.css" />
    <link rel="stylesheet" href="css/update_detail_product_information_new.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="width: 1200px">
            <div class="banner">
                <!---------Banner------------->
                <asp:ImageButton ID="logo" runat="server" ImageUrl="icons/logo-image.png" OnClick="logo_Click" />
                <div class="search">
                    <div class="search-1">
                        <asp:TextBox ID="search" placeholder="Tìm kiếm trong kho hàng" runat="server"></asp:TextBox>
                    </div>
                    <div class="search-2">
                        <asp:ImageButton ID="image" runat="server" ImageUrl="icons/logo-timkiem.png" OnClick="image_Click" />
                    </div>
                </div>
                <div class="account" style="left: 1082px;">
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
                            <asp:DataList ID="DataList1" OnItemDataBound="DataList1_ItemDataBound" runat="server">
                                <ItemTemplate>
                                    <div class="detail-content-information-big1">
                                        <div class="detail-content-image">
                                            <asp:Image CssClass="detail-content-image-1" ID="Image1" runat="server" ImageUrl='<%# "image/"+Eval("productImage") %>' />
                                            <input type="image" src="icons/edit.png" style="margin-left:5px" onclick="updateimage()" class="icon-image" />
                                        </div>

                                        <div class="detail-content-information-1">
                                            <div class="detail-content-information-1-name">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("productName") %>'></asp:Label>
                                                <input type="image" src="icons/edit.png" onclick="updatename()" style="margin-left: 5px;" class="icon-image" />
                                            </div>
                                            <div class="detail-content-information-1-sold">
                                                <asp:Label ID="Label8" runat="server"></asp:Label><span> Đã bán</span>
                                            </div>
                                            <div class="detail-content-information-1-content_price">
                                                <h1>GIÁ TIỀN<input type="image" src="icons/edit.png" style="margin-left: 5px;" onclick="updateprice()" class="icon-image" /></h1>
                                            </div>
                                            <div class="detail-content-information-1-price">
                                                <div class="detail-content-information-1-price-2">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("productPrice") %>'></asp:Label>
                                                    <span>VND</span>
                                                </div>
                                            </div>
                                            <div class="detail-content-information-1-number">
                                                <div>
                                                    <asp:Label ID="Label3" CssClass="number_product_seller_still" runat="server" Text='<%# Eval("productStockLevel") %>'></asp:Label>
                                                    <span class="detail-content-information-1-number-2">Sản phẩm có sẵn</span>
                                                </div>
                                                <div  style="margin-left: 5px;position: relative;top: -10px;">
                                                    <input type="image" src="icons/edit.png" onclick="updatequantity()" class="icon-image" />
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="detail-content-information-2">
                                        <div class="detail-content-information-2-1" style="background: white; font-size: 28px; margin-left: 55px;">
                                            <span>Thông tin sản phẩm</span>
                                            <input type="image" src="icons/edit.png" onclick="updateinformation()" style="margin-left: 15px;" class="icon-image" />
                                        </div>
                                        <div class="detail-content-information-2-2">
                                            <div class="detail-content-information-2-2-triangle" style="border: none; height: 13px; width: 97.5%; margin-left: 30px; background: #D9D9D9; margin-top: 10px; margin-bottom: 10px;"></div>
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
        <%-- Update image --%>
        <div class="update_seller" id="update_image_seller" style="height: 205px; width: 200px; padding-top: 45px;">
            <asp:FileUpload ID="FileUpload1" Style="display: none" runat="server" onchange="upload()" />
            <input type="button" value="Tải hình ảnh mới" class="button_upload_file" onclick="showBrowseDialog()" />
            <asp:Button runat="server" ID="hideButton" Text="" Style="display: none;" OnClick="hideButton_Click" />
            <script type="text/javascript" language="javascript">
                function showBrowseDialog() {
                    var fileuploadctrl = document.getElementById('<%= FileUpload1.ClientID %>');
                    fileuploadctrl.click();
                }
                function upload() {
                    var btn = document.getElementById('<%= hideButton.ClientID %>');
                    btn.click();
                }
            </script>
            <button type="button" style="margin-top: 15px" onclick="closeupdateimage()">ĐÓNG</button>
            <br />
            <div style="margin-top:14px; font-size:11px;padding: 0px 5px 0px;">
                <span>Lưu ý<span style="color:red">(*)</span>:Ảnh sẽ được cập nhập ngay và luôn ngay khi chọn ảnh</span>
            </div>       
        </div>
        <%-- update name --%>
        <div class="update_seller" id="update_name_seller" style="left: 43%; border: 1px solid; width: 400px; text-align: center; padding-top: 10px; padding-bottom: 14px;">
            <span>----Nhập tên mới sản phẩm----</span>
            <br />
            <asp:TextBox ID="txt_product_name" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btn_name" CssClass="button_update" runat="server" OnClick="btn_name_Click" Text="CẬP NHẬP" />
            <button type="button" onclick="closeupdatename()">ĐÓNG</button>
        </div>
        <%-- update price --%>
        <div class="update_seller" id="update_price_seller" style="left: 43%; border: 1px solid; width: 400px; text-align: center; padding-top: 10px; padding-bottom: 14px;">
            <span>----Cập nhập giá tiền mới----</span>
            <br />
            <asp:TextBox ID="txt_product_price" Style="border: 1px solid" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" CssClass="button_update" OnClick="Button1_Click1" runat="server" Text="CẬP NHẬP" />
            <button type="button" onclick="closeupdateprice()">ĐÓNG</button>
        </div>
        <%-- update number --%>
        <div class="update_seller" id="update_number_seller" style="left: 43%; border: 1px solid; width: 400px; text-align: center; padding-top: 10px; padding-bottom: 14px;">
            <span>---Cập nhập số lượng bán---</span>
            <br />
            <asp:TextBox ID="txt_product_number" Style="border: 1px solid" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button2" CssClass="button_update" runat="server" OnClick="Button2_Click" Text="CẬP NHẬP" />
            <button type="button" onclick="closeupdatenumber()">ĐÓNG</button>
        </div>
        <%-- update information --%>
        <div class="update_seller" id="update_information_seller" style="top: 33%; left: 35%; border: 1px solid; width: 600px; text-align: center; padding-top: 10px; padding-bottom: 14px;">
            <span>---Cập nhập thông tin sản phẩm---</span>
            <table>
                <tr>
                    <td class="information_td">Thể loại:</td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="DropDownList1" Style="width: 169px; border: 1px solid;" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="information_td">Năm phát hành:
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="DropDownList2" Style="width: 169px; border: 1px solid;" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="information_td">Mô tả:</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TextBox1" Style="border: 1px solid; width: 370px; height: 160px;" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="Button3" CssClass="button_update" runat="server" OnClick="Button3_Click" Text="CẬP NHẬP" />
            <button type="button" onclick="closeupdateinformation()">ĐÓNG</button>
        </div>
        <script src="javascript/update_product_seller.js"></script>
        <div style="text-align:center">
            <asp:Button ID="Button4" runat="server" Height="66px" Width="120px" Font-Size="25px" style="margin-bottom:40px;" CssClass="button_update" OnClick="Button4_Click" Text="XÓA" />
        </div>
    </form>
</body>
</html>
