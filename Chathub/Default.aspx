<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Chathub.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
     <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                    Join Private Chat Room
                </li>

            </ul>

        </div>
    </div> 
    <asp:Repeater ID="rptChatFrnd" runat="server"> 
        <ItemTemplate>
              
            <div class="btn btn-block disabled" style="text-align:left;"> 
             <i class="icon-white icon-share-alt"></i>
                <a href="/roomusers/<%#Eval("ID") %>"> <%#Eval("RoomName")%> </a> (<%#count(Convert.ToInt32(Eval("ID")))%>)
             </div>  
           
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
