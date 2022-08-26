<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="postDetails.aspx.cs" Inherits="Chathub.roompages.postDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                    Post Display
                </li>

            </ul>

        </div>
    </div>

    <div class="span10">
        <asp:Literal ID="litBidPostDetailData" runat="server"></asp:Literal>
        <br style="clear: both;" />
        <asp:LinkButton ID="lbtnLikeStar" CssClass="label label-success" runat="server" OnClick="lbtnLikeStar_Click" Text="Like Star"></asp:LinkButton>
       <span class="badge badge-inverse">  <asp:Literal ID="litLikeCountStar" runat="server"></asp:Literal> </span>
     <asp:Literal ID="litPostVisitCount" runat="server"></asp:Literal>

        <br />




        <asp:ListView ID="listComments" runat="server" EnableModelValidation="True" DataKeyNames="ID" OnPagePropertiesChanged="listComments_PagePropertiesChanged">

            <EmptyItemTemplate>
                ! No Comment Now
            </EmptyItemTemplate>
            <ItemTemplate>

                <div class="commentlsits">
                    <table class="psttables">
                        <tr>
                            <td>

                                <img src="/star.ashx?w=25&h=25&iurl=<%#Eval("userimg").ToString().Length>0? Eval("userimg"):"male.jpg"%>" style='border: 1px solid black; width: 25px; <%#Eval("sex").ToString() == "Male" ? "display: block;": "display: none;" %>' />
                                <img src="/star.ashx?w=25&h=25&iurl=<%#Eval("userimg").ToString().Length>0? Eval("userimg"):"female.jpg"%>" style="border: 1px solid black; width: 25px; padding: 3px; <%#Eval("sex").ToString() == "Male" ? "display: none;": "display: block;" %>" />

                            </td>
                            <td>
                                <span class="label"><%#Eval("UserName") %> </span>
                                <div style="font-size: 8px;"><%# TimeAgo(Convert.ToDateTime(Eval("dateAdded"))) %></div>

                            </td>
                        </tr>

                    </table>

                    <div style="text-transform: capitalize; margin-left: 35px;"><%#Eval("CommentText") %></div>
                    <div style="clear: both;"></div>
                </div>

            </ItemTemplate>

            <LayoutTemplate>

                <div class="clearfix"></div>
                <div runat="server" id="itemPlaceholderContainer" style=""><span runat="server" id="itemPlaceholder" /></div>
                <div class="paginationStar">

                    <div class="clearfix"></div>
                    <asp:DataPager runat="server" ID="DataPager1" PageSize="4">
                        <Fields>

                            <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="label label-info pull-right" NextPageText="View More Comments" ShowPreviousPageButton="false"></asp:NextPreviousPagerField>

                        </Fields>
                    </asp:DataPager>

                </div>
            </LayoutTemplate>

        </asp:ListView>




        <div>
            <div>Post Your Comment</div>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtcomment" CssClass="input-block-level" runat="server"  TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnPostcomment" OnClick="btnPostcomment_Click" runat="server" CssClass="btn">
                            <i class="icon-comment"></i> Submit
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear"></div>
    </div> 
</asp:Content>
