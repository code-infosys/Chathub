<%@ Page Title="" Language="C#" MasterPageFile="~/blank.Master" AutoEventWireup="true" CodeBehind="starshelp.aspx.cs" Inherits="Chathub.starshelp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                     Chathub.in Help
                </li>

            </ul>

        </div>
    </div>



    <ul>
        <li><a class="label label-info" href="/terms"> Terms Of Use This Application</a></li>
         <li><a class="label label-info" href="/tour"> Take a Tour</a></li>
        <li><a class="label label-info" href="/upcoming"> Upcoming Features </a></li>

    </ul>
    <asp:Button ID="Button1" Visible="false" OnClick="Button1_Click" runat="server" Text="send" />
</asp:Content>
