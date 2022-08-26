<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imageDeleter.aspx.cs" Inherits="Chathub.roompages.imageDeleter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
         <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" Text="Delete" />
        <pre>








        </pre>
         <asp:Repeater ID="rptImages" runat="server">
                       <ItemTemplate> 

                           <asp:HiddenField ID="hideID" Value='<%#Eval("id") %>' runat="server" />
                        <asp:HiddenField ID="HideImage" Value='<%#Eval("ImgSrc") %>' runat="server" />
                        <asp:HiddenField ID="hideUserid" Value='<%#Eval("user_id") %>' runat="server" /> 
                           <%#Eval("ImgSrc") %>
                        <%--<img src="http://www.chathub.in/starimg/<%#Eval("ImgSrc") %>" title="<%#Eval("user_id") %>" style="width:100px;margin:10px; border:1px solid; padding:10px; float:left;"/>--%>

                         
                       </ItemTemplate>
                   </asp:Repeater>

         

       
    </div>
    </form>
</body>
</html>
