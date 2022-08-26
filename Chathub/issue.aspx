<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="issue.aspx.cs" Inherits="Chathub.issue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="error-500">
        <i class="icon-remove-sign icon-4x error-icon"></i>
        <h1>Internal Server Error!</h1>
        <span class="text-error"><small><strong>Error 500</strong></small></span>
        <p>Oops! An error has occured, sorry.</p>
        <h3><a href="/login">Login Again Please</a></h3>
    </div>
    

</asp:Content>
