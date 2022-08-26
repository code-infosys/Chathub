<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="userProfileInfo.aspx.cs" Inherits="Chathub.roompages.userProfileInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                    Profile Information Of
                    <asp:Literal ID="litname" runat="server"></asp:Literal>
                </li>

            </ul>

        </div>
    </div>


    <asp:Label ID="lblblocklistmsg" runat="server" Text=""></asp:Label>

    <asp:Panel ID="pnlCloseoverallBlocklist" runat="server">

        <asp:Repeater ID="rptCategorys" runat="server" DataSourceID="odsPCate">
            <ItemTemplate>







                <div class="social-box">

                    <header>
                        <h4>
                            <i class="icon-certificate"></i>
                            <%#Eval("Name") %>
                        </h4>
                        <div class="tools">
                            <div class="btn-group">
                            </div>
                        </div>
                    </header>

                </div>










                <table style="width: 100%;">
                    <asp:HiddenField ID="hideCatid" Value='<%#Eval("id") %>' runat="server" />
                    <asp:Repeater ID="rptAttributes" runat="server" DataSourceID="odsPAttri">
                        <ItemTemplate>
                            <asp:HiddenField ID="hideAttriId" Value='<%#Eval("id") %>' runat="server" />

                            <tr>
                                <td style="text-align: left; vertical-align: top;"><b><%#Eval("Headtext") %> :</b> </td>
                                <td style="text-align: left;">
                                    <asp:Repeater ID="rptProfile" runat="server" DataSourceID="odsProfile">
                                        <ItemTemplate>
                                            <div><%#Eval("AttributesValue") %>  </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <asp:ObjectDataSource ID="odsProfile" runat="server" SelectMethod="GetProfileValuesForOtherUser" TypeName="Chathub.Methodsall">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="hideAttriId" Type="Int32" Name="ProfileAttriID" DefaultValue="0" />
                                            <asp:QueryStringParameter QueryStringField="uid" Type="Int32" Name="User_id" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>

                                </td>
                            </tr>

                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <asp:ObjectDataSource ID="odsPAttri" runat="server" SelectMethod="GetProfileAttributes" TypeName="Chathub.Methodsall">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hideCatid" Type="Int32" Name="CatID" DefaultValue="0" />
                    </SelectParameters>
                </asp:ObjectDataSource>

                <br />
            </ItemTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="odsPCate" runat="server" SelectMethod="GetProfileCategory" TypeName="Chathub.Methodsall"></asp:ObjectDataSource>



    </asp:Panel>

</asp:Content>
