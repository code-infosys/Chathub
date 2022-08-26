<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Chathub.search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                    Search Friends On Chathub
                </li>

            </ul>

        </div>
    </div>



    <asp:Panel ID="pnlsearch" runat="server" DefaultButton="btnSearch">
        <div class="searchform">
            <asp:TextBox ID="txtMainSearch" CssClass="search-query span6" runat="server" placeholder="Name or keyword"></asp:TextBox>
            <asp:LinkButton ID="btnSearch" CssClass="btn" runat="server" OnClick="btnSearch_Click" CausesValidation="False">
                <i class="icon-eye-open"></i> Go
            </asp:LinkButton>
        </div>
    </asp:Panel>

    <br />
    <%--<asp:Repeater ID="rptChatFrnd" runat="server">
        <ItemTemplate>
            
             <a href='/visitprofile/<%#Eval("user_id") %>'> 
                <div style="margin-bottom: 8px; padding: 5px; border-bottom: 1px dotted #cbcbcb;">
                    <%--  star.ashx?w=35&h=35&iurl=--%>
    <%-- <img src="/starimg/<%#Eval("img_name").ToString().Length>0? Eval("img_name"):"male.jpg"%>" style='border: 1px solid black; width:35px; float: left; margin-right: 8px;
                        <%#Eval("sex").ToString() == "Male" ? "display: block;": "display: none;" %>' />
                    <img src="/starimg/<%#Eval("img_name").ToString().Length>0? Eval("img_name"):"female.jpg"%>" style="border: 1px solid black;width:35px; float: left; margin-right: 8px;
                        <%#Eval("sex").ToString() == "Male" ? "display: none;": "display: block;" %>" />
                    <span style="float: left; text-align: justify;">
                        <%#Eval("username")%>
                    </span>
                    <div style="clear: both">--%>
    <%-- </div>
                </div>
            </a>
        </ItemTemplate>
    </asp:Repeater>--%>





    <asp:ListView ID="ListViewChatFrnd" runat="server" EnableModelValidation="True" DataKeyNames="user_id" OnPagePropertiesChanged="ListViewChatFrnd_PagePropertiesChanged">

        <ItemTemplate>

            <a href='/visitprofile/<%#Eval("user_id") %>'>
                <div class="well" style="margin-bottom: 8px; padding: 5px; border-bottom: 1px dotted #cbcbcb;">
                    <%--  star.ashx?w=35&h=35&iurl=--%>
                    <img src="/starimg/<%#Eval("img_name").ToString().Length>0? Eval("img_name"):"male.jpg"%>" style='border: 1px solid black; width: 35px; float: left; margin-right: 8px; <%#Eval("sex").ToString() == "Male" ? "display: block;": "display: none;" %>' />
                    <img src="/starimg/<%#Eval("img_name").ToString().Length>0? Eval("img_name"):"female.jpg"%>" style="border: 1px solid black; width: 35px; float: left; margin-right: 8px; <%#Eval("sex").ToString() == "Male" ? "display: none;": "display: block;" %>" />
                    <span style="float: left; text-align: justify;">
                        <%#Eval("username")%>
                    </span>
                    <div style="clear: both">
                    </div>
                </div>
            </a>

        </ItemTemplate>


        <LayoutTemplate>

            <div class="clearfix"></div>
            <div runat="server" id="itemPlaceholderContainer" style=""><span runat="server" id="itemPlaceholder" /></div>
            <div class="paginationStar">

                <div class="clearfix"></div>
                <asp:DataPager runat="server" ID="DataPager1" PageSize="10">
                     <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-inverse" ShowFirstPageButton="True" PreviousPageText="<" FirstPageText="<<" ShowNextPageButton="False"></asp:NextPreviousPagerField>
                        <asp:NumericPagerField NumericButtonCssClass="active"></asp:NumericPagerField>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True" ButtonCssClass="btn btn-inverse" NextPageText=">" LastPageText=">>" ShowPreviousPageButton="false"></asp:NextPreviousPagerField>
                    </Fields>
                </asp:DataPager>

            </div>
        </LayoutTemplate>

    </asp:ListView>


    <%--  <asp:ObjectDataSource ID="objUserChatFrnd" runat="server" SelectMethod="GetUserAllImagesForOther"
                TypeName="Chathub.Methodsall">
                <SelectParameters>
                    <asp:SessionParameter Name="userid" SessionField="qPlusSes" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>--%>





    <asp:Literal ID="Litmsgerr" runat="server"></asp:Literal>
    <div style="clear: both;">
    </div>
    <br />
</asp:Content>
