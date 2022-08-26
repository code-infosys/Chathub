<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="profilealter.aspx.cs" Inherits="Chathub.profilealter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                     Profile Management
                </li>

            </ul>

        </div>
    </div>


    <asp:Label ID="lblMsg" ForeColor="Green" runat="server"></asp:Label>
    
   
            <%--  /editprofiledetail--%>
            <table>
                 
                <asp:Repeater ID="rptAttributes" runat="server" DataSourceID="odsPAttri" OnItemCommand="rptAttributes_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField ID="hideAttriId" Value='<%#Eval("id") %>' runat="server" />
                            <td ><b><%#Eval("Headtext") %> &nbsp; &nbsp; &nbsp;</b> </td>
                            <td>
                                <asp:Repeater ID="rptProfile" runat="server" DataSourceID="odsProfile">
                                    <ItemTemplate>
                                        <div><%#Eval("AttributesValue") %>  </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:ObjectDataSource ID="odsProfile" runat="server" SelectMethod="GetProfileValues" TypeName="Chathub.Methodsall">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hideAttriId" Type="Int32" Name="ProfileAttriID" DefaultValue="0" />
                                        <asp:SessionParameter Type="Int32" Name="User_id" SessionField="user_id" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td><a class="btn" href="/editprofiledetail/<%#Eval("id") %>/<%#Eval("IsMultiple") %>"> <i class="icon-edit"></i>Edit  </a></td>
                        </tr>


                    </ItemTemplate>
                </asp:Repeater>

            </table>


            <asp:ObjectDataSource ID="odsPAttri" runat="server" SelectMethod="GetProfileAttributes" TypeName="Chathub.Methodsall">
                <SelectParameters>
                    <asp:QueryStringParameter Name="CatID" QueryStringField="id" Type="Int32" DefaultValue="0" />
                </SelectParameters>
            </asp:ObjectDataSource>
      

    <asp:ObjectDataSource ID="obsGetAudienceLock" runat="server" SelectMethod="GetAudienceLock" TypeName="Chathub.Methodsall"></asp:ObjectDataSource>
  <br />
       
    <a class="btn btn-inverse disabled" href="/profile"> <i class="icon-white icon-share-alt"></i>Back To Profile</a>
         
</asp:Content>
