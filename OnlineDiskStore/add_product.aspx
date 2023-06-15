<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_product.aspx.cs" Inherits="OnlineDiskStore.add_product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link href="css/add_product_new.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="themsp">
                <div class="themsp_Image">
                    <asp:ImageButton ID="Image_btn_them" runat="server" ImageUrl="icons/logo-image.png" />
                </div>
                <div class="themsp_line">
                </div>
                <div class="themsp_chu">
                    <p class="chu_trang">Thêm sản phẩm</p>
                </div>
            </div>
            <div class="them">
                <div class="sanpham">
                    <div class="sanpham_chu">
                        <p class="chu">
                            Ảnh sản phẩm
                        </p>
                    </div>
                    <div class="sanpham_anh">
                        <asp:Image ID="Image1" runat="server" />
                    </div>
                    <div class="sanpham_btn">
                        <asp:FileUpload ID="FileUpload1" Style="display: none" runat="server" onchange="upload()" />
                        <input type="button" value="Tải hình ảnh lên" class="button_upload_file" onclick="showBrowseDialog()" />

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
                    </div>
                </div>
                <div class="sanpham_line">
                </div>
                <div class="thongtin">
                    <div class="thongtin_1">
                        <div class="thongtin_lable">
                            <ul class="thongtin_list_1">
                                <li>Tên sản phẩm
                                </li>
                                <li>Giá tiền
                                </li>
                                <li>Số lượng
                                </li>
                            </ul>
                        </div>
                        <div class="thongtin_txt">
                            <ul class="thongtin_list_2">
                                <li>
                                    <asp:TextBox ID="txt_tensanpham" runat="server" Height="28px" Width="400px"></asp:TextBox>
                                </li>
                                <li>
                                    <asp:TextBox ID="txt_giaien" runat="server" Height="28px" Width="400px"></asp:TextBox>
                                </li>
                                <li>
                                    <asp:TextBox ID="txt_soluong" runat="server" Height="28px" Width="400px"></asp:TextBox>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="thongtin_2">
                        Thông tin sản phẩm
                    </div>
                    <div class="thongtin_3">
                    </div>
                    <div class="thongtin_4">
                        <div class="thongtin_4_1">
                            <ul class="thongtin_4_11">
                                <li>Thể loại
                                </li>
                                <li>Năm phát hành
                                </li>
                                <li>Mô tả
                                </li>
                            </ul>
                        </div>
                        <div class="thongtin_4_2">
                            <ul class="thongtin_4_21">
                                <li>
                                    <asp:TextBox ID="txt_theloai" runat="server" Height="28px" Width="400px"></asp:TextBox>
                                </li>
                                <li>
                                    <asp:DropDownList ID="DropDownList1" CssClass="DropDownList1" runat="server"></asp:DropDownList>
                                </li>
                                <li>
                                    <asp:TextBox ID="txt_mota" TextMode="MultiLine" runat="server" Height="212px" Width="400px"></asp:TextBox>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="them_btn">
                        <asp:Button ID="btn_themsp" runat="server" Text="Thêm sản phẩm" CssClass="btn_themsp" OnClick="btn_themsp_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
