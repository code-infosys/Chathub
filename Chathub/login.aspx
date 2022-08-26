<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" EnableViewState="true" Inherits="Chathub.login" %>

<%@ Register Src="~/uc/google.ascx" TagPrefix="uc1" TagName="google" %>
<%@ Register Src="~/uc/FooterAdvertisement.ascx" TagPrefix="uc1" TagName="FooterAdvertisement" %>
<%@ Register Src="~/uc/HeaderAdvertisement.ascx" TagPrefix="uc2" TagName="HeaderAdvertisement" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ChatHub.in Login</title>
    <meta name="author" content="SonuStar" />
    <meta property="og:site_name" content="Chathub.in" />
    <meta property="og:type" content="website" />
    <meta property="og:image" content="http://chathub.in/images/chathub.png" />
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta name="language" content="english" />
    <link rel="canonical" href="http://www.chathub.in/" />
    <link rel="shortcut icon" href="http://chathub.in/images/chathub.png" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="alexaVerifyID" content="http://www.alexa.com/pro/subscription/configure?site=http%3A%2F%2Fchathub.in&puid=200" />
    <meta name="google-site-verification" content="fU2os4muSZfUcgInHoiu2nYdqwQNs00APb_AGuuDAbk" />


    <link href="css/twitter-bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="css/social.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link href="css/twitter-bootstrap/bootstrap-responsive.css" rel="stylesheet" />

     
   

    <style type="text/css">
        body
        {
            padding-top: 0px;
            padding-bottom: 40px;
            background-color: #e9eaed;
        }
    </style>
    <style>
        .wraper #main
        {
            margin-top: 40px;
        }
    </style>

    <script>
        function eck() {

            document.getElementById('<%#btnCheckUserName.ClientID%>').click();
        }
        function ecke() {

            document.getElementById('<%#btnemailcheck.ClientID%>').click();
        }
    </script>


</head>
<body>
    <form id="form1" runat="server">



        <nav class="navbar  social-navbar social-sm">
            <div class="navbar-inner">
                <div class="container-fluid">

                    <img class="avatar" src="<%=Page.ResolveUrl("~/images/chathub.png") %>" alt="http://www.chathub.in" />
                    <a class="brand" href="http://www.chathub.in">Chathub.in </a>

                </div>
            </div>
        </nav>



        <div class="container">



            <div class="row-fluid tabs-left advanced-tab side orange">

                 


                <div class="span7 nav" style="background-image: url('images/chathubsmall.jpg'); height: 380px;color:#ffffff;">

                    <h3>Chathub.in Live Chat Features</h3>

                    <ul style="list-style: none;">

                        <li><i class="icon-ok-sign"></i>Free Registration</li>
                        <li><i class="icon-ok-sign"></i>Make New Friends All over World, Chat, Upload Photos, Likes</li>
                        <li><i class="icon-ok-sign"></i>Search Your Friends</li>
                        <li><i class="icon-ok-sign"></i>Profile Management</li>
                        <li><i class="icon-ok-sign"></i>Private Chating</li>
                        <li><i class="icon-ok-sign"></i>Public Chating</li>
                        <li><i class="icon-ok-sign"></i>Upload Your Photos</li>
                        <li><i class="icon-ok-sign"></i>Personal Data Privacy </li>
                    </ul>


                </div>

                <div class="span5 ">

                    <uc2:HeaderAdvertisement runat="server" ID="headad" />


                    <asp:Panel ID="pnlLogin" CssClass="form-login" runat="server" DefaultButton="btnLogin">

                        <h2 class="form-heading">Please log in</h2>
                        <asp:TextBox ID="txtLoginEmailId" placeholder="Username" CssClass="input-block-level" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLoginEmailId"
                            ErrorMessage="Username Required" ValidationGroup="l"></asp:RequiredFieldValidator>

                        <asp:TextBox ID="txtLoginPassword" CssClass="input-block-level" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLoginPassword"
                            ErrorMessage="Enter Password" ValidationGroup="l"></asp:RequiredFieldValidator>

                        <div class="row-fluid">
                            <label class="checkbox span6">
                                <input type="checkbox" value="remember-me">
                                Remember me
                            </label>


                            <asp:Button ID="btnLogin" runat="server" Text="log in" CssClass="btn btn-primary pull-right span6" ValidationGroup="l" OnClick="btnLogin_Click" />

                            <asp:Label ID="lblm" runat="server"></asp:Label>

                        </div>
                        <div class="forget-password">
                            <p class="text-center">Forgot password? <a href="#" id="link-forgot">Click here to reset</a></p>
                        </div>
                        <div class="row-fluid">
                            <button id="btn-register" class="btn btn-success pull-right span12" type="button">Register</button>
                        </div>


                    </asp:Panel>


                    <asp:Panel ID="pnlregister" CssClass="form-register hide" runat="server" Visible="true" DefaultButton="btnRegister">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                        <h2 class="form-heading">Register</h2>
                        <div class="alert alert-info hide">
                            We sent you an <strong>activation link</strong> to your email
                        </div>
                        <div id="register-container">
                            <p class="text-center">
                                <ul class="starchatfeature">
                                    <li>Remember Your Username ,Email ID or Password</li>
                                    <li>Use Just US English For Registration</li>
                                </ul>
                            </p>
                            <div class="input-prepend input-fullwidth">
                                <span class="add-on"><i class="icon-user"></i></span>
                                <div class="input-wrapper">

                                    <asp:UpdatePanel ID="pnlUsernamecheck" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>

                                            <asp:TextBox ID="txtusername" placeholder="Profile Name" onblur="eck();" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername"
                                                ErrorMessage="Enter Name" ValidationGroup="r"></asp:RequiredFieldValidator>
                                            <asp:Button ID="btnCheckUserName" OnClick="btnCheckUserName_Click" Style="display: none;" runat="server" Text="" />
                                            <asp:Literal ID="sp_GetImage" runat="server"></asp:Literal>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnCheckUserName" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="pnlUsernamecheck">
                                        <ProgressTemplate>
                                            <img src="images/loader.gif" style="width: 20px;" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>


                                </div>
                            </div>
                            <div class="input-prepend input-fullwidth">

                                <div class="controls row-fluid">

                                    <label class="radio">
                                        <asp:RadioButton ID="rbmale" GroupName="gen" Text="Male" runat="server" Checked="true" />

                                    </label>
                                    <label class="radio">
                                        <asp:RadioButton Text="Female" ID="rbfemale" GroupName="gen" runat="server" />
                                    </label>
                                </div>
                            </div>
                            <div class="input-prepend input-fullwidth">
                                <span class="add-on"><i class="icon-envelope-alt"></i></span>
                                <div class="input-wrapper">

                                    <asp:UpdatePanel ID="upemailcheck" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>

                                            <asp:TextBox ID="txtmid" placeholder="Email-ID" onblur="ecke();" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmid"
                                                ErrorMessage="Enter Email-ID" ValidationGroup="r"></asp:RequiredFieldValidator>
                                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                ControlToValidate="txtmid" Display="Dynamic" ErrorMessage="Entered Email-ID Invalid"
                                                ValidationExpression="^[\w-]+(?:\.[\w-]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7}$"></asp:RegularExpressionValidator>


                                            <asp:Button ID="btnemailcheck" OnClick="btnemailcheck_Click" Style="display: none;" runat="server" Text="" />
                                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnemailcheck" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="upemailcheck">
                                        <ProgressTemplate>
                                            <img src="images/loader.gif" style="width: 20px;" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>


                                </div>
                            </div>
                            <div class="input-prepend input-fullwidth">
                                <span class="add-on"><i class="icon-lock"></i></span>
                                <div class="input-wrapper">
                                    <asp:TextBox ID="txtpasswordReg" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpasswordReg"
                                        ErrorMessage="Enter Password" ValidationGroup="r"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>
                        <div class="form-actions">
                            <button class="btn btn-primary btn-back" type="button"><i class="icon-angle-left"></i>Back</button>
                            <asp:Button ID="btnRegister" CssClass="btn btn-success pull-right" runat="server"
                                Text="Register" OnClick="btnRegister_Click" ValidationGroup="r" />
                            <br />
                            <br />

                        </div>
                    </asp:Panel>



                    <div class="form-forgot hide">
                        <h2 class="form-heading">Forgot password</h2>
                        <p>Enter your email address to reset your password</p>
                        <div class="input-prepend input-fullwidth">
                            <span class="add-on"><i class="icon-envelope-alt"></i></span>
                            <div class="input-wrapper">
                                <asp:TextBox ID="TextBox1" placeholder="Enter Your Email Id" CssClass="tbox"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtLoginEmailId"
                                    ErrorMessage="Enter Email-ID" ValidationGroup="eeeeeeeeer"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtLoginEmailId"
                                    ErrorMessage="Enter Correct Format" ValidationExpression="^[\w-]+(?:\.[\w-]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7}$"
                                    Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-actions">
                            <button class="btn btn-primary btn-back" type="button"><i class="icon-angle-left"></i>Back</button>

                            <asp:Button ID="btnchangeemail" ValidationGroup="eeeeeeeeer" runat="server" Text="Send"
                                CssClass="btn btn-success pull-right" OnClick="btnchangeemail_Click" />

                        </div>
                    </div>

                    <asp:Literal ID="lblmsg" runat="server"></asp:Literal>
                    <asp:Label ID="Label1" runat="server"></asp:Label>


                    

                </div>
                <div class="clearfix"></div>
                <uc1:FooterAdvertisement runat="server" ID="fotead" />

            </div>




            <div class="form-footer-copyright">
                 2013 - <%=DateTime.Now.Year %> © <em>Chathub Powered</em> by <a href="http://www.skilledi.com" target="_blank" class="badge label-warning"><i class="icon-star-empty"></i>Skilledi Infotech</a>
                &nbsp;&nbsp;
                <br />
                <div class="fb-like" data-href="https://www.facebook.com/chathub.in" data-width="100" data-layout="button_count" data-action="like" data-show-faces="false" data-share="true"></div>
                <br />
                <span class="badge label-success badge-right">
                    <i class="icon-user"></i>
                    <asp:Literal ID="litOverAllUsersCount" runat="server"></asp:Literal>
                </span>
            </div>











            <div class="headbelow">
                <span class="label label-inverse">Hi <b>Guest</b></span> <a href="/tour">Take a Tour</a> <i class="icon-arrow-up"></i><a href="/terms">Terms Of Use</a> <i class="icon-arrow-up"></i><a href="/help">Help?</a>
            </div>

            <hr />


             
            <script src="js/jquery.min.js"></script>
            <script>window.jQuery || document.write('<script src="plugins/jquery/jquery.min.js"><\/script>')</script>
            <script src="js/login.js"></script>
            <script>
                $(function () {
                    Login.init()
                });
    </script>

            <div id="fb-root"></div>
            <script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=283066838372754";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

            <uc1:google runat="server" ID="google" />
        </div>
    </form>
</body>
</html>
