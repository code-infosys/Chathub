<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="frequest.aspx.cs" Inherits="Chathub.frequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function OkProcess() {
            document.getElementById("imgProcesss").style.display = "Block";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     

     <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                    Friend Request List
                </li>

            </ul>

        </div>
    </div>


    <img src="../images/loader.gif" id="imgProcesss" style="width: 40px; display: none;" />




    <asp:ListView ID="ListViewFriendReq" runat="server" DataSourceID="objUsersget" EnableModelValidation="True" DataKeyNames="id" OnItemCommand="ListViewFriendReq_ItemCommand">
        <EmptyDataTemplate>
            <h4>! No Request</h4>
        </EmptyDataTemplate>
        <ItemTemplate>

            <div class="media">
                <a class="pull-left" href="/visitprofile/<%#Eval("user_id") %>"> 
                    <img src="/starimg/<%#Eval("img_name").ToString().Length>0? Eval("img_name"):"nophoto.png"%>" style="width:50px;" class="media-object"  />
                </a>
                <div class="media-body">
                    <h4 class="media-heading">
                        <a href="/visitprofile/<%#Eval("user_id") %>"><%#Eval("username")%></a>
                    </h4> 
                    <p class="pull-left"> 
                        <asp:LinkButton ID="lbtnA" runat="server" OnClientClick="OkProcess();" CommandArgument='<%#Eval("id")%>' CommandName="lbtnApprove" CssClass="btn btn-info" > <i class="icon-white icon-thumbs-up"></i> Confirm </asp:LinkButton>
                        <asp:LinkButton ID="lbtnR" CssClass="btn" runat="server" OnClientClick="OkProcess();" CommandArgument='<%#Eval("id")%>' CommandName="lbtnReject" > <i class="icon-trash"></i>Reject </asp:LinkButton>
 
                    </p>
                </div>
            </div>

              
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



    <asp:ObjectDataSource ID="objUsersget" runat="server" SelectMethod="GetFriendRequest" TypeName="Chathub.Methodsall"></asp:ObjectDataSource>

</asp:Content>
