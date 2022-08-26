﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="onlineusers.aspx.cs" Inherits="Chathub.onlineusers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                    Chathub Online Users List
                </li>

            </ul>

        </div>
    </div>

    <div class="span10">
        <asp:ListView ID="ListView1" runat="server" EnableModelValidation="True" DataSourceID="objUsersget">

            <EmptyDataTemplate>
                <h4>! No User Without You</h4>
            </EmptyDataTemplate>
            <ItemTemplate>
                <a href='/visitprofile/<%#Eval("user_id") %>'>
                    <div style="margin-bottom: 8px; padding: 5px; border-bottom: 1px dotted #cbcbcb;" class="well">
                        <%#Eval("user_online").ToString()=="True"?" <img src='/images/online.png' title='Online' class='onlinoffcls' /> ":" <img src='/images/offline.png' class='onlinoffcls' title='Offline' />" %>

                        <img src="starimg/<%#Eval("img_name").ToString().Length>0? Eval("img_name"):"male.jpg"%>" style='border: 1px solid black; width: 35px; float: left; margin-right: 8px; <%#Eval("sex").ToString() == "Male" ? "display: block;": "display: none;" %>' />
                        <img src="starimg/<%#Eval("img_name").ToString().Length>0? Eval("img_name"):"female.jpg"%>" style="border: 1px solid black; width: 35px; float: left; margin-right: 8px; <%#Eval("sex").ToString() == "Male" ? "display: none;": "display: block;" %>" />
                        <span style="float: left; text-align: justify;">
                            <%#Eval("username")%>
                        </span>
                        <div style="clear: both">
                        </div>
                    </div>
                </a>
            </ItemTemplate>
            <LayoutTemplate>
                <table id="Table1" runat="server" style="width:100%;">
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
                        <td id="Td2" runat="server" style="" class="paginationStar">
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

        <div style="clear: both;"></div>
    </div>

    <asp:ObjectDataSource ID="objUsersget" runat="server" SelectMethod="GetOnlineUsers" TypeName="Chathub.Methodsall">
        <SelectParameters>
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>
