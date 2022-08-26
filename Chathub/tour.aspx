<%@ Page Title="" Language="C#" MasterPageFile="~/blank.Master" AutoEventWireup="true" CodeBehind="tour.aspx.cs" Inherits="Chathub.tour" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
     <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                  Chathub.in Take a Tour
                </li>

            </ul>

        </div>
    </div>


     <asp:ListView ID="ListView1" runat="server" EnableModelValidation="True" DataSourceID="ObjectDataSource1"  >
         
        <EmptyDataTemplate>
          <h4>No Tour Data</h4>
         </EmptyDataTemplate>
        <ItemTemplate> 
                <div class="well" style="margin-bottom: 8px; padding: 5px; border-bottom: 1px dotted #cbcbcb;">
                    <%--  star.ashx?w=35&h=35&iurl=--%>
                   <img src="/starimg/<%#Eval("ImgName") %>" style="width:50%;" />
                    <br />
                   <div>
                       <%#Eval("Detail") %>
                   </div>
                    <div style="clear: both">
                    </div>
                </div>
             
        </ItemTemplate>
        <LayoutTemplate>
            <table id="Table1" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td1" runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr id="Tr2" runat="server" style="">
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                           
                        </table>
                    </td>
                </tr>
                <tr id="Tr3" runat="server">
                    <td id="Td2" runat="server" style="">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="1" >
                         <Fields>
                            <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-inverse" ShowFirstPageButton="True" PreviousPageText="<" FirstPageText="<<" ShowNextPageButton="False"></asp:NextPreviousPagerField>
                            <asp:NumericPagerField NumericButtonCssClass="active"></asp:NumericPagerField>
                            <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True" ButtonCssClass="btn btn-inverse" NextPageText=">" LastPageText=">>" ShowPreviousPageButton="false"></asp:NextPreviousPagerField>
                        </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="">
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
  

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllTour" TypeName="Chathub.Methodsall">
        <SelectParameters>
           <asp:Parameter Type="Int16" Name="Islatest" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>



    <br />
</asp:Content>
