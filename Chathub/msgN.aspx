<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="msgN.aspx.cs" Inherits="Chathub.msgN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
    <script src="<%#Page.ResolveUrl("~/js/jswpesrcps.js") %>"></script>



    <script>

        $(document).ready(function () {
            var root = document.getElementById('boxMessage1');
            $.ajax({
                type: "POST",
                url: "../StarService.asmx/GetUserMessagesInboxPage",

                data: "<%=hideUserid.Value%>",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    
                    var lstMsgUsers = response.d;
                    root.innerHTML = response.d;
                     
                    var strInner = "";

                    $.each(lstMsgUsers, function (index, lstMsgUsers) {

                        var uid = lstMsgUsers.user_id;
                        var name = lstMsgUsers.username;
                        var clas = "well";
                        if (lstMsgUsers.seen == "N")
                        {
                            clas = "well  alert alert-block";
                        }
                        strInner += "<a href=\"../chat/" + uid + "\">";
                        strInner += "<div class=\"" + clas + "\" style=\"padding: 8px; margin-bottom: 10px;\">";
                        strInner += "<div class=\"row-fluid\">";
                        strInner += "<div class=\"span3\">";
                       
                        var img = "../starimg/nophoto.png";
                        if (lstMsgUsers.img_name.length>2)
                        {
                            img = lstMsgUsers.img_name;
                        }
                        strInner += "<img src=\"/starimg/" + img + "\" style='width:50px;height:50px;' alt=\"thubm\">";
                        strInner += "</div>";
                        strInner += "<div class=\"span9\">";
                        strInner += "<small class=\"pull-right\" style=\"margin-right: 5px;\">" + lstMsgUsers.crtd_date + "</small>";
                        strInner += "<p class='badge  label-info badge-right'> " + name + "</p> <br>";
                        if (lstMsgUsers.user_online == "True") {
                            strInner += "<i class='badge badge-success'> Online</i> ";
                        }
                        else { strInner += "<i class='badge'> Offline</i>"; }
                        strInner += "</div></div></div></a>";


                    });

                     

                    root.innerHTML = strInner;

                },
                failure: function (msg) {
                    alert(msg);
                }
                
            });
            
        });


    </script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblblocklistmsg" runat="server" Text=""></asp:Label>

    <asp:Panel ID="pnlCloseoverallBlocklist" runat="server">


        <asp:LinkButton runat="server" Visible="false" OnClick="lbtnRefresh_Click" ID="lbtnRefresh">Refresh Page</asp:LinkButton>

        <div class="container-fluid">
            <div class="row-fluid">
                <div class="span12">
                    <h3 class="page-title">Chat Inbox</h3>

                    <ul class="breadcrumb">
                        <li>
                            <i class="icon-home"></i>
                            <a href="/home">Dashboard</a>
                            <span class="icon-angle-right"></span>
                        </li>

                        <li>
                            <asp:HiddenField ID="txthide" runat="server" Value="0" />
                        </li>
                    </ul>

                </div>
            </div>
            <div class="row-fluid">
                <div class="social-box social-bordered">
                    <div class="body">











                        <div class="span4">
                            <div class="form-inline">
                                <input type="text" class="search-query span12" placeholder="Search...">
                            </div>

                            <div id="users-list">
                                <div class="content" id="boxMessage1">
                                    
                                </div>
                            </div>
                        </div>
































                        <div class="span8">

                            <div class="social-box social-blue social-bordered">
                                <div class="header">
                                    <h4>
                                        <asp:Literal ID="litNameofuser" runat="server"></asp:Literal></h4>

                                    <div class="tools">
                                        <div class="btn-group">
                                            <button class="btn dropdown-toggle" data-toggle="dropdown">
                                                <i class="icon-cog"></i>
                                                Actions
                                            </button>
                                            <ul class="dropdown-menu pull-right">
                                                <li>
                                                    <asp:LinkButton runat="server" OnClick="btnRefreshTop_Click" ID="btnRefreshTop">Refresh Page</asp:LinkButton>
                                                    <span class="icon-angle-right"></span></li>
                                                <li class="divider"></li>
                                                <li>
                                                    <asp:LinkButton ID="lbtnPrevious" runat="server" OnClick="lbtnPrevious_Click">Previous Messages</asp:LinkButton>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>

                                </div>

                                <div class="body chat">

                                    <div class="chat-messages-list" style="height: 400px; overflow: auto;">
                                        <div class="content" id="msgall">
                                        </div>
                                    </div>


                                    <div class="chat-composer">
                                        <div class="chat-form">
                                            <div class="chat-input">
                                                <input id="composerMessage" type="text" placeholder="Type a message..." />
                                            </div>
                                            <span id="btnSend" class="btn btn-primary chat-sender" onclick="InsertStar()">
                                                <span class="icon icon-share-alt "></span>
                                            </span>

                                            <span id="fakebtn" style="display: none;" class="btn btn-primary chat-sender">Sending..</span>


                                        </div>


                                        <div>
                                            <br />
                                            Or Send Photo 

                                            <div class="fileupload fileupload-new" data-provides="fileupload">

                                                <div class="fileupload-preview fileupload-exists thumbnail" style="width: 50px; height: 50px;"></div>
                                                <span class="btn btn-file">
                                                    <span class="fileupload-new">Select Image</span>
                                                    <span class="fileupload-exists">Change</span>
                                                    <asp:FileUpload ID="fuImgPost" runat="server" CssClass="file-upload" />

                                                </span>
                                                <a href="#" class="btn fileupload-exists" data-dismiss="fileupload">Remove</a>
                                                <span id="uploadPreview"></span>
                                                <asp:LinkButton ID="btnUploadPhoto" OnClick="btnUploadPhoto_Click" OnClientClick="OkProcess();" runat="server" CssClass="btn btn-primary">
                                               <i class="icon-picture"></i> Send Photo
                                                </asp:LinkButton>
                                            </div>



                                            <script>
                                                $(function () {
                                                    FormElements.init();
                                                });
                                         </script>






                                            <asp:Label ID="lblmsgs" runat="server"></asp:Label>

                                            <img src="../images/loader.gif" id="imgProcesss" style="width: 40px; display: none;" />
                                            <script>
                                                function OkProcess() {
                                                    document.getElementById("imgProcesss").style.display = "Block";
                                                }
                                            </script>
                                        </div>



                                    </div>

                                </div>

                            </div>
                        </div>

                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </div>








        <script>
            $(function () {
                $(".chat-messages-list .content").slimScroll({ start: "bottom", railVisible: true, alwaysVisible: false, height: '400px' });
                $("#users-list .content").slimScroll({ "height": '460px' });
            });
  </script>


        <script src="<%#Page.ResolveUrl("~/plugins/jquery.ui.chatbox/jquery.ui.chatbox.js") %>"></script>





















        <script>


            function InsertStar() {

                document.getElementById('btnSend').style.display = 'none';
                document.getElementById('fakebtn').style.display = 'Block';

                var msg = document.getElementById('composerMessage');
                //msg = msg.replace(/\'/g, "\''");

                if (msg.value == null || msg.value == "") {
                    msg.className = "openchatrbox";
                    document.getElementById('btnSend').style.display = 'Block';
                    document.getElementById('fakebtn').style.display = 'none';
                }
                else {
                    $.ajax({
                        type: "POST",
                        url: "../StarService.asmx/InsertPrivateChating",
                        data: "<%=hideInsert.Value%>",

                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {

                            GetNameStar();
                            msg.value = "";
                            $("#txtmsg").focus();

                            document.getElementById('btnSend').style.display = 'Block';
                            document.getElementById('fakebtn').style.display = 'none';

                        },
                        failure: function (msg) {
                            alert(msg);
                            document.getElementById('btnSend').style.display = 'Block';
                            document.getElementById('fakebtn').style.display = 'none';
                        }
                    });
                }
            }

        </script>














        <asp:HiddenField ID="hideSelect" runat="server" />
        <asp:HiddenField ID="hideInsert" runat="server" />
        <asp:HiddenField ID="hideUserid" runat="server" />
        <asp:Literal ID="litIdWraper" runat="server"></asp:Literal>
    </asp:Panel>


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
