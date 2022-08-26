<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="Chathub.message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
 
     



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     

    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                    Inbox Messages List 
                </li>

            </ul>

        </div>
    </div>
    
    

    <div class="span10">

        <asp:ListView ID="ListView1" runat="server" EnableModelValidation="True" DataSourceID="objUsersget">

            <EmptyDataTemplate>
                <h4>! No Message</h4>
            </EmptyDataTemplate>
            <ItemTemplate>

                <a href='/chat/<%#Eval("user_id") %>'>
                    <div style="padding: 8px; margin-bottom: 10px;" class="<%#Eval("seen").ToString().Trim()=="N"?"well alert alert-block": "well " %>">
                        <%-- star.ashx?w=35&h=35&iurl=--%>
                        <%#Eval("user_online").ToString()=="True"?" <img src='/images/online.png' title='Online' class='onlinoffcls' /> ":" <img src='/images/offline.png' class='onlinoffcls' title='Offline' />" %>

                        <img src="/starimg/<%#Eval("img_name").ToString().Length>0? Eval("img_name"):"nophoto.png"%>" style='border: 1px solid black; width: 35px; float: left; margin-right: 8px;' />
                      
                        <span style="float: left; text-align: justify; text-transform: capitalize;">
                            <%#Eval("username")%>
                        </span>
                        <div style="clear: both;">
                        </div>
                    </div>
                </a>
            </ItemTemplate>
            <LayoutTemplate>
                <div class="clearfix"></div>
                <div runat="server" id="itemPlaceholderContainer" style=""><span runat="server" id="itemPlaceholder" /></div>
                <div class="dataTables_paginate paging_bootstrap pagination">
                    <br />
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

        <div style="clear: both;"></div>
    </div>


    <asp:ObjectDataSource ID="objUsersget" runat="server" SelectMethod="GetUserMessagesInboxPage" TypeName="Chathub.Methodsall">
        <SelectParameters>
            <asp:SessionParameter Name="userid" SessionField="user_id" Type="Int64" />
            <asp:Parameter Name="top" DefaultValue="40" Type="Int16" />
        </SelectParameters>
    </asp:ObjectDataSource>


</asp:Content>
