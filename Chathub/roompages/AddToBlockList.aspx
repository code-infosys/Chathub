<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="AddToBlockList.aspx.cs" Inherits="Chathub.roompages.AddToBlockList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                    Your Block users List
                </li>

            </ul>

        </div>
    </div>


    <blockquote>
        Help: If you want to block to any user, Then First find user by using his/her name on search box ,then confirm first user is that user which you want to block<br />
        Then Click To <b>Block</b>
    </blockquote>
    <br />
    <div class="label label-inverse">Block List Users</div>

    <div style="border-top: 1px dotted black; border-bottom: 1px dotted black;">

        <asp:ListView ID="ListView1" runat="server" EnableModelValidation="True" DataSourceID="objUsersget" OnItemCommand="ListView1_ItemCommand">


            <EmptyDataTemplate>
                <h4 class="badge badge-important">! No User In Block Your List</h4>
            </EmptyDataTemplate>
            <ItemTemplate>

                <div style="margin-bottom: 8px; padding: 5px; border-bottom: 1px dotted #cbcbcb;" class="well">

                    <img src="/starimg/<%#Eval("img_name").ToString().Length>0? Eval("img_name"):"male.jpg"%>" style='border: 1px solid black; width: 35px; float: left; margin-right: 8px; <%#Eval("sex").ToString() == "Male" ? "display: block;": "display: none;" %>' />
                    <img src="/starimg/<%#Eval("img_name").ToString().Length>0? Eval("img_name"):"female.jpg"%>" style="border: 1px solid black; width: 35px; float: left; margin-right: 8px; <%#Eval("sex").ToString() == "Male" ? "display: none;": "display: block;" %>" />
                    <span style="float: left; text-align: justify;">
                        <%#Eval("username")%>
                    </span>
                    <br />
                    <asp:LinkButton runat="server" ID="bltnUnblock" CommandArgument='<%#Eval("id")%>' CommandName="btnUnblock" Text="Unblock"></asp:LinkButton>
                    <div style="clear: both">
                    </div>
                </div>

            </ItemTemplate>
            <LayoutTemplate>
                <table id="Table1" runat="server">
                    <tr id="Tr1" runat="server">
                        <td id="Td1" runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr id="Tr2" runat="server" style="">
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>

                            </table>
                        </td>
                    </tr>
                    <tr id="Tr3" runat="server">
                        <td id="Td2" runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server" PageSize="10">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-inverse" ShowFirstPageButton="True" PreviousPageText="<" FirstPageText="<<" ShowNextPageButton="False"></asp:NextPreviousPagerField>
                                    <asp:NumericPagerField NumericButtonCssClass="active"></asp:NumericPagerField>
                                    <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True" ButtonCssClass="btn btn-inverse" NextPageText=">" LastPageText=">>" ShowPreviousPageButton="false"></asp:NextPreviousPagerField>
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="objUsersget" runat="server" SelectMethod="MyBlockListUser" TypeName="Chathub.Methodsall"></asp:ObjectDataSource>


        <div style="clear: both;"></div>
    </div>
    <br />
    <br />

    <div class="badge">Add Another </div>

    <asp:Panel ID="pnlsearch" runat="server" DefaultButton="btnSearch">
        <div class="searchform">
            <asp:TextBox ID="txtMainSearch" CssClass="search-query span6" runat="server" placeholder="Name or keyword"></asp:TextBox>
            <asp:Button ID="btnSearch" CssClass="btn" runat="server" OnClick="btnSearch_Click" CausesValidation="False" Text="Go" />
        </div>
    </asp:Panel>

    <br />





    <asp:ListView ID="ListViewChatFrnd" runat="server" EnableModelValidation="True" DataKeyNames="user_id" OnPagePropertiesChanged="ListViewChatFrnd_PagePropertiesChanged" OnItemCommand="ListViewChatFrnd_ItemCommand">

        <ItemTemplate>


            <div style="margin-bottom: 8px; padding: 5px; border-bottom: 1px dotted #cbcbcb;" class="well">
                <%--  star.ashx?w=35&h=35&iurl=--%>
                <img src="/starimg/<%#Eval("img_name").ToString().Length>0? Eval("img_name"):"male.jpg"%>" style='border: 1px solid black; width: 35px; float: left; margin-right: 8px; <%#Eval("sex").ToString() == "Male" ? "display: block;": "display: none;" %>' />
                <img src="/starimg/<%#Eval("img_name").ToString().Length>0? Eval("img_name"):"female.jpg"%>" style="border: 1px solid black; width: 35px; float: left; margin-right: 8px; <%#Eval("sex").ToString() == "Male" ? "display: none;": "display: block;" %>" />
                <span style="float: left; text-align: justify;">
                    <%#Eval("username")%>
                </span>
                <br />
                <a class="label label-success" href='/visitprofile/<%#Eval("user_id") %>'>View Profile for Confirm </a>
                <br />
               
                    <asp:LinkButton Text="Block" runat="server" CssClass="badge badge-warning" CommandArgument='<%#Eval("user_id")%>' CommandName="Blokuser"></asp:LinkButton>
                
                <div style="clear: both">
                </div>
            </div>


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






    <asp:Literal ID="Litmsgerr" runat="server"></asp:Literal>
    <div style="clear: both;">
    </div>
    <br />
</asp:Content>
