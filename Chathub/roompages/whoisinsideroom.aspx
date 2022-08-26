<%@ Page Title="" Language="C#" MasterPageFile="~/blank.Master" AutoEventWireup="true" CodeBehind="whoisinsideroom.aspx.cs" Inherits="Chathub.roompages.whoisinsideroom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="h1list"> Add Your Suggestion Chathub </h1> 
     
    <br />
    <asp:TextBox ID="txtsuggestion" runat="server" CssClass="tbox" TextMode="MultiLine" ></asp:TextBox><br /><br />
      <asp:Button ID="btnsug" runat="server" Text="login" CssClass="button thin green-gradient glossy" OnClick="btnsug_Click" />

</asp:Content>
