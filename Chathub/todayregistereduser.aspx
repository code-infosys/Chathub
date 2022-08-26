<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="todayregistereduser.aspx.cs" Inherits="Chathub.todayregistereduser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
     <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                   Chathub.in Today Join Users List
                </li>

            </ul>

        </div>
    </div>



        <asp:ListView ID="ListViewFriendList" runat="server" DataSourceID="objUsersget" EnableModelValidation="True" DataKeyNames="user_id">

        <ItemTemplate>
             
                    <a href='/visitprofile/<%#Eval("user_id") %>'>
                        <div class="well" style="margin-bottom: 8px; padding: 5px; border-bottom: 1px dotted #cbcbcb;">
                            
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


        <LayoutTemplate>

            <div class="clearfix"></div>
            <div runat="server" id="itemPlaceholderContainer" style=""><span runat="server" id="itemPlaceholder" /></div>
            <div class="paginationStar">
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


    <asp:ObjectDataSource ID="objUsersget" runat="server" SelectMethod="TodayJoinedUser" TypeName="Chathub.Methodsall"></asp:ObjectDataSource>


</asp:Content>
