<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageDel.aspx.cs" Inherits="Chathub.roompages.ImageDel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            skip<asp:TextBox ID="txtskip" runat="server"></asp:TextBox> <br />
            take<asp:TextBox ID="txttake" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Button" />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                     
                    <asp:Repeater ID="rlejre" runat="server" OnItemCommand="rlejre_ItemCommand">
                        <ItemTemplate>
                            <div style="width:100px;float:left;padding:10px; height:100px;">
                                <asp:ImageButton ImageUrl='<%#Eval("Name","~/starimg/{0}") %>' CommandArgument='<%#Eval("Name") %>' CommandName="delimg" runat="server" ID="stark" Width="100" Height="100" />
                            <%# Convert.ToDateTime( Eval("CreationTime").ToString()).ToString("dd MMM yyyy") %>
                            </div>
                            
                        </ItemTemplate>
                    </asp:Repeater>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
