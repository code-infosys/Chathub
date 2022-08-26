<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Chathub.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                    Edit Profile  
                </li>



            </ul>

        </div>
    </div>




    <div>
        <a href="/myaccout/pho">
            <img title="Click To Change" id="ImageUser" runat="server" style="float: left;" class="profileimg" />

        </a>

        <div style="width: 40%; float: left; margin-left: 20px;">
            <b>
                <span class="label label-inverse">
                    <asp:Literal ID="litUsername" runat="server"></asp:Literal>
                </span>
            </b>
            <br />
            <br />
            <a href="/profilevisitors" class="btn btn-mini"><i class=" icon-globe"></i>Profile Visitors
                    <span class="badge badge-success">
                        <asp:Literal ID="litProfileVisit" runat="server"></asp:Literal>
                    </span>
            </a>

            <br /> <br /> 
              <asp:Literal ID="litProfileCompe" runat="server"></asp:Literal> 
            <br />
            <a class="btn btn-primary btn-mini right" href="/myphotos"><i class="icon-pencil"></i>Manage Photos</a>
            <div style="clear: both;"></div>
        </div>


        <div style="clear: both;"></div>

    </div>

    <br />




    <asp:Repeater ID="rptCategorys" runat="server" DataSourceID="odsPCate">
        <ItemTemplate>
            <div class="social-box">

                <header>
                    <h4>
                        <i class="icon-desktop"></i>
                        <%#Eval("Name") %>
                    </h4>
                    <div class="tools">
                        <div class="btn-group">
                            <a class="btn btn-primary right" href="/editprofile/<%#Eval("id") %>"><i class="icon-pencil"></i>Edit </a>
                        </div>
                    </div>
                </header>

            </div>

            <asp:HiddenField ID="hideCatid" Value='<%#Eval("id") %>' runat="server" />


            <table style="width: 100%;">
                <asp:Repeater ID="rptAttributes" runat="server" DataSourceID="odsPAttri">
                    <ItemTemplate>
                        <asp:HiddenField ID="hideAttriId" Value='<%#Eval("id") %>' runat="server" />
                        <tr>
                            <td>
                                <div style="width: 40%; text-align: left; vertical-align: top; float: left;"><b><%#Eval("Headtext") %> :</b> </div>

                                <div style="text-align: left; width: 40%; float: left; vertical-align: top;">
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
                                </div>
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


</asp:Content>
