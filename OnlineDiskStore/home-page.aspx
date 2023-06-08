<%@ Page Title="" Language="C#" MasterPageFile="~/master-page.Master" AutoEventWireup="true" CodeBehind="home-page.aspx.cs" Inherits="OnlineDiskStore.home_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="owlcarousel/assets/owl.carousel.min.css" rel="stylesheet" />
    <link href="owlcarousel/assets/owl.theme.default.min.css" rel="stylesheet" />
    <script src="javascript/jquery.min.js"></script>
    <script src="owlcarousel/owl.carousel.min.js"></script>
    <link href="css/home_page_new.css" rel="stylesheet"/>
    <script>
        $(document).ready(function () {
            $('.owl-carousel').owlCarousel({
                loop: true,
                margin: 10,
                nav: false,
                responsive: {
                    0: {
                        items: 1
                    },
                    600: {
                        items: 1
                    },
                    1000: {
                        items: 1    
                    }
                }
            })
        });
    </script>
    <style>
        .item{
            text-align:center;
        }
    </style>
    <div class="owl-carousel owl-theme" style="width: 960px;">
        <div class="item">
              <asp:DataList ID="DataList2" runat="server" Width="960px" Height="412.5px">
                  <ItemTemplate>
                      <div class="item-image">
                          <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "image/"+Eval("productImage") %>' CommandArgument='<%# Eval("productID") %>' OnClick="ImageButton1_Click" />
                      </div> 
                  </ItemTemplate>
              </asp:DataList>
        </div>
        <div class="item">
              <asp:DataList ID="DataList3" runat="server" Width="960px" Height="412.5px">
                  <ItemTemplate>
                      <div class="item-image">
                          <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "image/"+Eval("productImage") %>' CommandArgument='<%# Eval("productID") %>' OnClick="ImageButton1_Click1" />
                      </div> 
                  </ItemTemplate>
              </asp:DataList>
        </div>
        <div class="item">
              <asp:DataList ID="DataList4" runat="server" Width="960px" Height="412.5px">
                  <ItemTemplate>
                      <div class="item-image">
                          <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "image/"+Eval("productImage") %>' CommandArgument='<%# Eval("productID") %>' OnClick="ImageButton1_Click2" />
                      </div> 
                  </ItemTemplate>
              </asp:DataList>
        </div>
        <div class="item">
              <asp:DataList ID="DataList5" runat="server" Width="960px" Height="412.5px">
                  <ItemTemplate>
                      <div class="item-image">
                          <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "image/"+Eval("productImage") %>' CommandArgument='<%# Eval("productID") %>' OnClick="ImageButton1_Click3" />
                      </div> 
                  </ItemTemplate>
              </asp:DataList>
        </div>
    </div>
    <div class="goods">
        <div class="header_text">
            <div class="text">Hàng hóa</div>
            <div class="line_header"></div>
        </div>
        <div class="content_goods">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" Width="960px">
                <ItemTemplate>
                    <div class ="item_disk">
                        <div class="image_of_disk">
                            <div class="image_of_disk_1">
                                <asp:ImageButton  CssClass="ImageButton5" ID="ImageButton5" runat="server" ImageUrl='<%# "image/"+Eval("productImage") %>' CommandArgument='<%# Eval("productID") %>' OnClick="ImageButton5_Click"/>
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
</asp:Content>
