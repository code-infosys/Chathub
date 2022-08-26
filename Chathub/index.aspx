<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" ValidateRequest="false" EnableEventValidation="false" CodeBehind="index.aspx.cs" Inherits="Chathub.index" %>

<%@ Register Src="~/uc/HeaderAdvertisement.ascx" TagPrefix="uc2" TagName="HeaderAdvertisement" %>
<%@ Register Src="~/uc/HomeAds.ascx" TagPrefix="uc2" TagName="HomeAds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="<%#Page.ResolveUrl("~/css/pages/timeline.css") %>" />

    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>

    <script src="<%#Page.ResolveUrl("~/js/rtf/jquery.classyedit.js") %>" type="text/javascript"></script>
    <link href="<%#Page.ResolveUrl("~/js/rtf/jquery.classyedit.css") %>" rel="stylesheet" />
    <script>
        $(document).ready(function () {
            $(".span12").ClassyEdit();
        });
            </script>--%>
    <script>
        function postprocess() {
            document.getElementById("imgs").style.display = "Block";
            document.getElementById('<%#btnSimplePost.ClientID%>').style.display = 'none';
            document.getElementById('fakebtn').style.display = 'Block';

        }
        $(function () {
            FormElements.init();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div id="social-timeline" class="row-fluid" style="padding-top: 15px">
            <div class="span9">
                <div class="row-fluid">

                    <asp:Panel ID="pnlsimplepost" runat="server" CssClass="media social-box social-composer ">


                        <a class="pull-left social-users-avatars" href="#">
                            <img id="ImageUser" runat="server" class="media-object" width="55" height="55" alt="Star">
                        </a>

                        <div>
                            <div class="media-body social-body">
                                <asp:TextBox ID="txtposttext" CssClass="span12" runat="server" placeholder="What's happening, Star?" TextMode="MultiLine"></asp:TextBox>

                                <div class="social-footer">
                                    <div class="btn-group">

                                        <div class="fileupload fileupload-new" data-provides="fileupload">

                                            <div class="fileupload-preview fileupload-exists thumbnail" style="width: 50px; height: 50px;"></div>
                                            <span class="btn btn-file">
                                                <span class="fileupload-new"><i class="icon-camera"></i>Select Image</span>
                                                <span class="fileupload-exists">Change</span>
                                                <asp:FileUpload ID="fuImgPost" runat="server" CssClass="file-upload" />
                                            </span>
                                            <a href="#" class="btn fileupload-exists" data-dismiss="fileupload">Remove</a>

                                            <asp:DropDownList ID="ddlAudi" CssClass="btn" Width="80" runat="server" DataTextField="AudienceName" DataValueField="id" DataSourceID="obsGetAudienceLock"></asp:DropDownList>

                                        </div>

                                        <asp:ObjectDataSource ID="obsGetAudienceLock" runat="server" SelectMethod="GetAudienceLock" TypeName="Chathub.Methodsall"></asp:ObjectDataSource>
                                        <asp:Label ID="lblmsgs" runat="server" ForeColor="Red"></asp:Label>



                                    </div>
                                    <asp:Button ID="btnSimplePost" runat="server" OnClick="btnSimplePost_Click" Text="Post" OnClientClick="postprocess();" CssClass="btn btn-primary pull-right" />

                                    <span id="fakebtn" style="display: none;" class="btn btn-primary pull-right">Posting..</span>
                                    <span id="uploadPreview"></span>

                                </div>
                            </div>
                        </div>



                    </asp:Panel>






                    <asp:ListView ID="listviewbindpost" runat="server" OnItemCommand="listviewbindpost_ItemCommand1" EnableModelValidation="true" DataKeyNames="postid" OnPagePropertiesChanged="listviewbindpost_PagePropertiesChanged1">
                        <EmptyDataTemplate>
                            <h4>! Write Something on Your Wall</h4>
                        </EmptyDataTemplate>

                        <ItemTemplate>

                            <asp:Panel ID="pnllockcheck" runat="server" Visible='<%#GetFriendListByFriendCheck(Convert.ToInt64(Eval("uid")))==true?Eval("AudienceLockID").ToString()=="2" || Eval("AudienceLockID").ToString()=="1"?true:false :true %>'>


                                <div class="media social-box">

                                    <a class="pull-left social-users-avatars" href="#">
                                        <img src="../star.ashx?w=35&h=35&iurl=<%#Eval("userimg").ToString().Length>0? Eval("userimg"):"nophoto.png"%>" class="media-object" />

                                    </a>


                                    <div class="media-body social-body">
                                        <p>
                                            <span class="badge badge-success"><%#Eval("UserName") %></span>
                                            <span class="label label-inverse" style="font-size: 8px;"><%# TimeAgo(Convert.ToDateTime(Eval("dateAdded"))) %></span>
                                            <br />

                                            <i runat="server" id="imgsese" visible='<%#Eval("uid").ToString().Trim()==Chathub.StarExtension.GetUserID.ToString()?true:false %>' class="icon-lock"></i>
                                            <asp:DropDownList ID="ddlAudi" Visible='<%#Eval("uid").ToString().Trim()==Chathub.StarExtension.GetUserID.ToString()?true:false %>' SelectedValue='<%#Eval("AudienceLockID") %>' CssClass="btn" Width="80" runat="server" DataTextField="AudienceName" DataValueField="id" DataSourceID="obsGetAudienceLock"></asp:DropDownList>
                                            <asp:Button ID="btnChangeLock" CommandArgument='<%#Eval("postid") %>' CommandName="changelock" runat="server" Text="Change" Visible='<%#Eval("uid").ToString().Trim()==Chathub.StarExtension.GetUserID.ToString()?true:false %>' CssClass="btn btn-inverse" />
                                            <asp:Button ID="btndeletepost" CommandArgument='<%#Eval("postid") %>' CommandName="deletepost" OnClientClick="return confirm('are you sure !')" runat="server" Text="Delete" Visible='<%#Eval("uid").ToString().Trim()==Chathub.StarExtension.GetUserID.ToString()?true:false %>' CssClass="btn btn-danger" />
                                            <br />

                                            <blockquote>
                                                <%#Eval("postdetail") %>
                                                <br />
                                                <a href="/<%#Eval("postid") %>/postdetail/star">
                                                    <%#Eval("postimg").ToString().Length>3?"<img style='width:35%;' src='../starimg/"+Eval("postimg")+"'/>":"" %> 
                                     
                                                </a>
                                            </blockquote>
                                        </p>

                                        <div class="social-footer">
                                            <div class="social-controls">
                                                <span><i class="icon-thumbs-up "></i><a href="/<%#Eval("postid") %>/postdetail/star">Add Star <span class="badge badge-info"><%#Eval("likeCount") %></span></a></span>
                                                <span><i class="icon-comment"></i><a href="/<%#Eval("postid") %>/postdetail/star">Add Comment <span class="badge badge-info"><%#Eval("CommentCount") %></span></a></span>

                                            </div>



                                        </div>

                                    </div>

                                </div>


                            </asp:Panel>

                        </ItemTemplate>


                        <LayoutTemplate>

                            <div class="clearfix"></div>
                            <div runat="server" id="itemPlaceholderContainer" style=""><span runat="server" id="itemPlaceholder" /></div>
                            <div class="paginationStar">

                                <div class="clearfix"></div>
                                <asp:DataPager runat="server" ID="DataPager1" PageSize="5">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonCssClass="btn btn-mini" ButtonType="Link" NextPageText="View More Posts" ShowPreviousPageButton="false"></asp:NextPreviousPagerField>

                                    </Fields>
                                </asp:DataPager>

                            </div>
                        </LayoutTemplate>

                    </asp:ListView>






                </div>
            </div>

            <div id="rigth-bar" class="span3 hidden-phone">

                <div class="social-nav-list" style="max-width: 340px; padding: 0;">

                    <ul class="nav nav-list dividers">
                        <li class="nav-header"><i class="icon-font"></i>Advertisement</li>
                        <li>
                            <uc2:HeaderAdvertisement runat="server" ID="he1" />
                        </li>
                        <li>

                            <uc2:HomeAds runat="server" ID="HomeAds" />


                        </li>
                    </ul>




                    <ul class="nav nav-list dividers">
                        <li class="nav-collapser text-center" data-toggle="collapse" data-target="#collapsible-nav">
                            <a href="#"><i class="icon-caret-down icon-2x"></i></a>
                        </li>
                    </ul>

                </div>


                <%-- <div id="people-you-may-know" class="social-nav-list" style="max-width: 340px; padding: 0;">
                    <ul class="nav nav-list dividers">
                        <li class="nav-header">People you may know</li>

                        <li class="nav-header fade in">
                            <div class="media" data-dismiss="alert">
                                <a class="close" href="#">&times;</a>
                                <a class="pull-left" href="#">
                                    <img class="media-object" src="../../assets/img/people-face/user6_55.jpg" alt="Jack Smith">
                                </a>
                                <div class="media-body">
                                    <h6 class="media-heading" style="color: #000"><strong>Jack Smith</strong></h6>
                                    <small>25 mutual friends</small>
                                </div>
                            </div>
                        </li>


                        <li class="nav-header">
                            <div class="media">
                                <a class="pull-left" href="#">
                                    <img class="media-object" src="../../assets/img/people-face/user5_55.jpg" alt="David Street">
                                </a>
                                <div class="media-body">
                                    <h6 class="media-heading" style="color: #000"><strong>David Street</strong></h6>
                                    <small>17 mutual friends</small>
                                </div>
                            </div>
                        </li>

                    </ul>
                </div>--%>
            </div>



        </div>
    </div>


    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
    <script>

        $(document).ready(function () {

            function readImage(file) {

                var reader = new FileReader();
                var image = new Image();

                reader.readAsDataURL(file);
                reader.onload = function (_file) {
                    image.src = _file.target.result;              // url.createObjectURL(file);
                    image.onload = function () {
                        var s = ~~(file.size / 1024);
                        if (s > 1000) {
                            $('#uploadPreview').text('You Cannot able to Upload Upto 1mb');
                            $('#uploadPreview').addClass("alert alert-error");
                        }
                        else {
                            $('#uploadPreview').text(s + 'KB');
                            $('#uploadPreview').removeClass("alert alert-error");
                            $('#uploadPreview').addClass("badge badge-success");
                        }
                    };
                    image.onerror = function () {
                        alert('Invalid file type: ' + file.type);
                    };
                };

            }
            $(".file-upload").change(function (e) {
                if (this.disabled) return alert('File upload not supported!');
                var F = this.files;
                if (F && F[0]) for (var i = 0; i < F.length; i++) readImage(F[i]);
            });
        });
    </script> 

</asp:Content>
