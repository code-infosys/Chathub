<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="notificationtouser.aspx.cs" Inherits="Chathub.roompages.notificationtouser" %>

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
                    Notifications
             
                </li>

            </ul>

        </div>
    </div>
    
    <img src="../images/loader.gif" id="imgProcesss" style="width:40px;display:none;" />

       
    <asp:ListView ID="ListviewNoti" OnItemCommand="ListviewNoti_ItemCommand" runat="server" DataSourceID="objUsersget" EnableModelValidation="True" DataKeyNames="id" >
        <EmptyDataTemplate>
            <h4>! No Notification You have</h4>
        </EmptyDataTemplate>
        <ItemTemplate>

            <div class="well">
                <div> 
                    <%#Eval("NotiMsg") %>
                </div>
                <span style='color: #B8EDFF; padding-left: 10px; font-size: 8px;'><%#Convert.ToDateTime(Eval("DateAdded")).ToString("dd MMM yyyy") %>  </span>
               
                <br />
                 <asp:LinkButton ID="lbtnA" runat="server" OnClientClick="OkProcess();" CssClass="button thin white-gradient glossy" CommandArgument='<%#Eval("id")%>' CommandName="btnok" Text="Confirm"></asp:LinkButton> &nbsp;&nbsp;
           
                 <div style="clear: both"></div>
            </div>

            <div style="border-bottom: 1px dotted #cbcbcb; margin: 3px;"></div>
        </ItemTemplate>


        <LayoutTemplate>

            <div class="clearfix"></div>
            <div runat="server" id="itemPlaceholderContainer" style=""><span runat="server" id="itemPlaceholder" /></div>
            <div class="paginationStar">
                <br />
                <div class="clearfix"></div>
                <asp:DataPager runat="server" ID="DataPager1" PageSize="10">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="True" PreviousPageText="<" FirstPageText="<<" ShowNextPageButton="False"></asp:NextPreviousPagerField>
                        <asp:NumericPagerField></asp:NumericPagerField>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True" NextPageText=">" LastPageText=">>" ShowPreviousPageButton="false"></asp:NextPreviousPagerField>
                    </Fields>
                </asp:DataPager>

            </div>
        </LayoutTemplate>

    </asp:ListView>



    <asp:ObjectDataSource ID="objUsersget" runat="server" SelectMethod="GetNotificationOfUser" TypeName="Chathub.Methodsall"></asp:ObjectDataSource>


</asp:Content>
