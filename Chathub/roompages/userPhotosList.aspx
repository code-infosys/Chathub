<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="userPhotosList.aspx.cs" Inherits="Chathub.roompages.userPhotosList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
    <script src="<%#Page.ResolveUrl("~/js/jswpesrcps.js") %>"></script>
    <link rel="stylesheet" href="<%#Page.ResolveUrl("~/plugins/jquery.colorbox/example1/colorbox.css") %>" />
    <script>
        $(function () {
            FormElements.init();
        });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                    Photos List of
                    <asp:Literal ID="litname" runat="server"></asp:Literal>
                </li>

            </ul>

        </div>
    </div>


    <asp:Label ID="lblblocklistmsg" runat="server" Text=""></asp:Label>

    <asp:Panel ID="pnlCloseoverallBlocklist" runat="server">



        <div class="row-fluid">
            <ul class="thumbnails">

                <asp:ListView ID="ListView1" runat="server" DataSourceID="objUsersget" EnableModelValidation="True" DataKeyNames="id" OnItemCommand="ListView1_ItemCommand">

                    <ItemTemplate>

                        <li class="span3">
                            <a rel="gallery_group" href="../starimg/<%#Eval("img_name") %>" class="thumbnail">
                                <div class="zoom">

                                    <img src="../star.ashx?w=100&h=100&iurl=<%#Eval("img_name")%>" />


                                </div>
                            </a>


                            <asp:LinkButton ID="linLike" CssClass="badge badge-success" CommandName="lLine" CommandArgument='<%#Eval("id")%>' runat="server">Give Star</asp:LinkButton>  
                           <span class="badge badge-warning">  <%#Eval("LikeCounts").ToString().Length>0?Eval("LikeCounts"):0 %>  </span>
                        </li>

                    </ItemTemplate>


                    <LayoutTemplate>

                        <div class="clearfix"></div>
                        <div runat="server" id="itemPlaceholderContainer" style=""><span runat="server" id="itemPlaceholder" /></div>
                        <div class="paginationStar">

                            <div class="clearfix"></div>
                            <asp:DataPager runat="server" ID="DataPager1" PageSize="5">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-inverse" ShowFirstPageButton="True" PreviousPageText="<" FirstPageText="<<" ShowNextPageButton="False"></asp:NextPreviousPagerField>
                                    <asp:NumericPagerField NumericButtonCssClass="active"></asp:NumericPagerField>
                                    <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True" ButtonCssClass="btn btn-inverse" NextPageText=">" LastPageText=">>" ShowPreviousPageButton="false"></asp:NextPreviousPagerField>
                                </Fields>
                            </asp:DataPager>

                        </div>
                    </LayoutTemplate>

                </asp:ListView>

            </ul>
        </div>
        <asp:ObjectDataSource ID="objUsersget" runat="server" SelectMethod="GetUserAllImagesForOther"
            TypeName="Chathub.Methodsall">
            <SelectParameters>
                <%--  <asp:SessionParameter Name="userid" SessionField="qPlusSes" Type="Int32" />--%>
                <asp:QueryStringParameter Name="userid" QueryStringField="uid" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>



        <script src="<%#Page.ResolveUrl("~/plugins/jquery.mousewheel/jquery.mousewheel.min.js") %>"></script>
        <script src="<%#Page.ResolveUrl("~/plugins/jquery.colorbox/jquery.colorbox-min.js") %>"></script>

        <script>
            /*<![CDATA[*/
            $(".thumbnail").colorbox({ rel: 'group1', transition: "none", width: "75%", height: "75%" });
            /*]]>*/
    </script>
    </asp:Panel>
</asp:Content>
