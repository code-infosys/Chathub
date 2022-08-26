<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="viewuserprofile.aspx.cs" Inherits="Chathub.viewuserprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="<%#Page.ResolveUrl("~/css/pages/historical-timeline.css") %>" rel="stylesheet" />
    <link href="<%#Page.ResolveUrl("~/plugins/jquery.colorbox/example1/colorbox.css") %>" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
     <div class="row-fluid">
                <div class="span12">


                    <ul class="breadcrumb">


                        <li><i class="icon-eye-open"></i>Basic User Profile 
                        </li>
                    </ul>

                </div>
            </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:Label ID="lblblocklistmsg" runat="server" Text=""></asp:Label>

    <asp:Panel ID="pnlCloseoverallBlocklist" runat="server">


        <div class="container-fluid">
           
            <div id="user-profile" class="social-box">
                <div class="body">
                    <div class="row-fluid">
                        <div class="span2">
                            <div class="row-fluid">
                                <img id="ImageUser" runat="server" style="float: left;" class="img-polaroid avatar span12" />

                            </div>
                            <p>

                                <a runat="server" id="linksendmsg" class="btn btn-block btn-success"><i class="icon-envelope-alt"></i>Send Message</a>
                            </p>



                        </div>
                        <div class="span10">
                            <div class="row-fluid">

                                <div id="user-status" class="span10 text-left">
                                    <h3>
                                        <asp:Literal ID="litUsername" runat="server"></asp:Literal></h3>

                                    Profile Visits(<asp:Literal ID="litProfileVisit" runat="server"></asp:Literal>)<br />

                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="lbtnSendRequest" EventName="Click" />
                                        </Triggers>
                                        <ContentTemplate>

                                            <asp:LinkButton Style="color: green;" runat="server" OnClick="lbtnSendRequest_Click" OnClientClick="this.disabled = true; this.value = 'Submitting...';" ID="lbtnSendRequest" Text="Add As Friend"></asp:LinkButton><br />
                                            <asp:LinkButton ID="lbtnUnfriend" Visible="false" OnClientClick="return confirm('! are you sure')" OnClick="lbtnUnfriend_Click" runat="server">Unfriend</asp:LinkButton>
                                            <br />
                                            <asp:HiddenField ID="hideDelid" runat="server" />
                                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <br />
                                     
                                    <asp:UpdateProgress ID="upprog" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                        <ProgressTemplate>
                                            <div class="progress progress-striped active">
                                                <div class="bar" style="width: 100%;"></div>
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>




                                </div>


                            </div>



                        </div>
                    </div>
                    <div class="row-fluid">

                        <div class="span10">

                            <div class="advanced-tab double">

                                <ul id="advancedTab1" class="nav nav-tabs">
                                    <li><asp:Literal ID="Literal1" runat="server"></asp:Literal></li>
                                    <asp:Literal ID="litFriendslist" runat="server"></asp:Literal>
                                </ul>

                            </div>

                        </div>
                    </div>
                </div>
            </div>



        </div>















        <div class="container-fluid">
            <div class="row-fluid">
               
            </div>
            <div class="row-fluid">
                <div id="timelineContainer">

                    <br class="clear">



                    <asp:ListView ID="listviewbindpost" runat="server" EnableModelValidation="True" DataKeyNames="postid" OnPagePropertiesChanged="listviewbindpost_PagePropertiesChanged">

                        <EmptyItemTemplate>
                            ! You Have No Post
                        </EmptyItemTemplate>
                        <ItemTemplate>

                            <asp:Panel ID="pnllockcheck" runat="server" Visible='<%#Eval("AudienceLockID").ToString()=="2" || Eval("AudienceLockID").ToString()=="1"?true:false %>'>


                                <div class="timelineMajor">
                                    <h2 class="timelineMajorMarker"><span><%#Eval("UserName") %></span></h2>
                                    <dl class="timelineMinor">
                                        <dt id="19540517">
                                            <img src="../star.ashx?w=35&h=35&iurl=<%#Eval("userimg").ToString().Length>0? Eval("userimg"):"male.jpg"%>" style='border: 1px solid black; width: 35px; <%#Eval("sex").ToString() == "Male" ? "display: block;": "display: none;" %>' />
                                            <img src="../star.ashx?w=35&h=35&iurl=<%#Eval("userimg").ToString().Length>0? Eval("userimg"):"female.jpg"%>" style="border: 1px solid black; width: 35px; padding: 3px; <%#Eval("sex").ToString() == "Male" ? "display: none;": "display: block;" %>" />

                                        </dt>
                                        <dd class="timelineEvent" id="19540517EX" style="display: block;">
                                            <div class="label label-inverse"><%# TimeAgo(Convert.ToDateTime(Eval("dateAdded"))) %></div>
                                               <br class="clear">
                                             <p>
                                                <blockquote>
                                                    <a href="/<%#Eval("postid") %>/postdetail/star">
                                                        <%#Eval("postdetail") %>
                                                         <br class="clear">
                                                        <%#Eval("postimg").ToString().Length>3?"<img style='width:50%;' src='../starimg/"+Eval("postimg")+"'/>":"" %> 
                             
                                                    </a>
                                                </blockquote>
                                                <br class="clear">

                                                <a class="label label-success" href="/<%#Eval("postid") %>/postdetail/star">Add Star(<%#Eval("likeCount") %>)</a>
                                                <a class="badge badge-warning" href="/<%#Eval("postid") %>/postdetail/star">Add Comment(<%#Eval("CommentCount") %>)</a>
                                                <a class="badge" href="/<%#Eval("postid") %>/postdetail/star">Post Visit(<%#Eval("PostVisitCount") %>)</a>

                                            </p>
                                            <br class="clear">
                                        </dd>
                                    </dl>
                                </div>



                            </asp:Panel>
                        </ItemTemplate>


                        <LayoutTemplate>

                            <div class="clearfix"></div>
                            <div runat="server" id="itemPlaceholderContainer" style=""><span runat="server" id="itemPlaceholder" /></div>
                            <div class="paginationStar">

                                <div class="clearfix"></div>
                                <i class="icon-arrow-right"></i>
                                <asp:DataPager runat="server" ID="DataPager1" PageSize="5">
                                    <Fields>
                                        <%--  <asp:NextPreviousPagerField ButtonType="Link"  PreviousPageText="Back Post" ShowNextPageButton="False"></asp:NextPreviousPagerField>
                                        --%>
                                        <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn" NextPageText="View More Posts" ShowPreviousPageButton="false"></asp:NextPreviousPagerField>

                                    </Fields>
                                </asp:DataPager>

                            </div>
                        </LayoutTemplate>

                    </asp:ListView>




                    <br class="clear">
                </div>
            </div>
        </div>


         

         
        <script>
            $(document).ready(function () {

                $.timeliner({
                    startOpen: ['#19550828EX', '#19630828EX']
                });
                // Colorbox Modal
                $(".CBmodal").colorbox({ inline: true, initialWidth: 100, maxWidth: 682, initialHeight: 100, transition: "elastic", speed: 750 });
            });
  </script>
        <script src="<%#Page.ResolveUrl("~/plugins/jquery.timeliner/js/timeliner.min.js") %>"></script>

    </asp:Panel>
</asp:Content>
