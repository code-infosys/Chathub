<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="listfriends.aspx.cs" Inherits="Chathub.listfriends" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

     <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                    Friends List of
            <asp:Literal ID="litname" runat="server"></asp:Literal>
                </li>

            </ul>

        </div>
    </div>



    <br />

    <asp:Label ID="lblblocklistmsg" runat="server" Text=""></asp:Label>

    <asp:Panel ID="pnlCloseoverallBlocklist" runat="server">



        <asp:ListView ID="ListViewFriendList" runat="server" DataSourceID="objUsersget" EnableModelValidation="True" DataKeyNames="id">

            <ItemTemplate>

                <asp:HiddenField Value='<%#Eval("id")%>' runat="server" ID="HideID" />
                <asp:Repeater ID="rptFlistfull" runat="server" DataSourceID="objLisstf">

                    <ItemTemplate>
                        <a href='/visitprofile/<%#Eval("user_id") %>'>
                            <div style="margin-bottom: 8px; padding: 5px; border-bottom: 1px dotted #cbcbcb;" class="well">

                                <%#Eval("user_online").ToString()=="True"?" <img src='/images/online.png' title='Online' class='onlinoffcls' /> ":" <img src='/images/offline.png' class='onlinoffcls' title='Offline' />" %>

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
                </asp:Repeater>


                <asp:ObjectDataSource ID="objLisstf" runat="server" SelectMethod="GetFriendzListDetail" TypeName="Chathub.Methodsall">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HideID" Type="Int32" Name="ides" />
                        <asp:QueryStringParameter Type="Int64" Name="qstring" QueryStringField="uid" DefaultValue="0" />
                    </SelectParameters>
                </asp:ObjectDataSource>



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
            <EmptyDataTemplate>
                <h4>! No Friend</h4>
            </EmptyDataTemplate>
        </asp:ListView>


        <asp:ObjectDataSource ID="objUsersget" runat="server" SelectMethod="GetFriendListOtherUserview" TypeName="Chathub.Methodsall">
            <SelectParameters>
                <asp:QueryStringParameter Type="Int64" Name="userid" QueryStringField="uid" DefaultValue="0" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </asp:Panel>


</asp:Content>
