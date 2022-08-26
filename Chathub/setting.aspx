<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="setting.aspx.cs" Inherits="Chathub.setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="<%#Page.ResolveUrl("~/js/jswpesrcps.js") %>"></script>

    <script>
        $(function () {
            FormElements.init();
        });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                    Chathub User Account Management
                </li>

            </ul>

        </div>
    </div>



    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:Literal ID="litMsg" runat="server"></asp:Literal>


    <div class="advanced-tab double">

        <ul id="advancedTab1" class="nav nav-tabs">
             <li class="active"><a href="/myaccout/ac">Account Info</a></li>
             <li><a href="/myaccout/pho">Change Photo</a></li>
             <li><a href="/myaccout/pw">Manage Password</a></li>
             <li><a href="/myaccout/deactive">Deactivate Account</a></li>
        </ul>
         
    </div>



    <br />
    <asp:Panel ID="pnlaccountset" runat="server" Visible="false">

        <asp:UpdatePanel runat="server" ID="pnlUpforAccountsett">
            <ContentTemplate>



                <table style="width: 100%">
                    <tr>
                        <th>Change Your Account Settings
                        </th>
                    </tr>
                    <tr runat="server" visible="false">
                        <td>User Name
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td>
                            <asp:TextBox ID="txtusername" CssClass="tbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername"
                                CssClass="tdvd" Display="Dynamic" ErrorMessage="Enter Name" ValidationGroup="s"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Country
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlCountry" DataValueField="country_id" DataTextField="country_name" CssClass="dropdown" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ControlToValidate="ddlCountry" Display="Dynamic" InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Security Qustion
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlSecurityQ" CssClass="dropdown" runat="server">
                                <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Where did you meet your spouse?</asp:ListItem>
                                <asp:ListItem Value="2">Name of your first school?</asp:ListItem>
                                <asp:ListItem Value="3">Your childhood hero?</asp:ListItem>
                                <asp:ListItem Value="4">Your favourite pastime?</asp:ListItem>
                                <asp:ListItem Value="5">Your favourite sports?</asp:ListItem>
                                <asp:ListItem Value="6">Father's middle name?</asp:ListItem>
                                <asp:ListItem Value="7">High school mascot?</asp:ListItem>
                                <asp:ListItem Value="8">Your first car?</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="--Select--"
                        ControlToValidate="ddlSecurityQ" Display="Dynamic" ErrorMessage="Select Question"
                        ValidationGroup="s"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Security Answer
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtsecAns" CssClass="tbox" runat="server" />
                            &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtsecAns"
                        CssClass="tdvd" Display="Dynamic" ErrorMessage="Enter Answer" ValidationGroup="s"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSignUp" CssClass="btn" runat="server" Text="Change Setting" OnClick="btnSignUp_Click" ValidationGroup="s" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblmsgchange" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>

            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Panel ID="pnlmanagePhoto" runat="server" Visible="false">
        <asp:Literal ID="litimg" runat="server"></asp:Literal>
        <br />
        Change Image<br />

        <asp:UpdatePanel ID="upimg" runat="server" UpdateMode="Conditional">
            <ContentTemplate>


                <div class="fileupload fileupload-new" data-provides="fileupload">

                    <div class="fileupload-preview fileupload-exists thumbnail" style="width: 50px; height: 50px;"></div>
                    <span class="btn btn-file">
                        <span class="fileupload-new">Select Image</span>
                        <span class="fileupload-exists">Change</span>
                        <asp:FileUpload ID="fuImgPost" runat="server" CssClass="file-upload" />

                    </span>
                    <a href="#" class="btn fileupload-exists" data-dismiss="fileupload">Remove</a>
                    <span id="uploadPreview"></span>
                </div>




                <br />

                Privacy:
    <asp:DropDownList ID="ddlAudi" CssClass="dropdown" runat="server" DataTextField="AudienceName" DataValueField="id" DataSourceID="obsGetAudienceLock"></asp:DropDownList>
                <asp:ObjectDataSource ID="obsGetAudienceLock" runat="server" SelectMethod="GetAudienceLock" TypeName="Chathub.Methodsall"></asp:ObjectDataSource>
                <br />
                <br />

                <asp:Button ID="btnImageUpload" CssClass="btn" OnClientClick="OkProcess();" runat="server"
                    Text="Upload" OnClick="btnImageUpload_Click" />
                <asp:Label ID="lblPhotomsg" runat="server" ForeColor="Red"></asp:Label>

                <img src="../images/loader.gif" id="imgProcesss" style="width: 40px; display: none;" />

                <script>
                    function OkProcess() {
                        document.getElementById("imgProcesss").style.display = "Block";
                    }
                </script>

            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnImageUpload" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpimgProgress" runat="server" AssociatedUpdatePanelID="upimg">
            <ProgressTemplate>
                <img src="../images/loader.gif" style="width: 40px;" />

            </ProgressTemplate>
        </asp:UpdateProgress>

    </asp:Panel>

    <asp:Panel ID="pnlManPassword" runat="server" Visible="false">

        <table>
            <tr>
                <td>Old Password:
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtPassword" CssClass="tbox" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>New Password:
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtNewPassword" CssClass="tbox" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Confirm Password:
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" CssClass="tbox" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword"
                        ControlToValidate="txtConfirmPassword" ErrorMessage="mismatched"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnUpdatePassword" runat="server" Text="login" CssClass="btn" OnClick="btnUpdatePassword_Click" />
                    <br />
                    <asp:Label ID="lblm" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

    </asp:Panel>

    <asp:Panel ID="pnldeactive" runat="server" Visible="false">
        <asp:TextBox ID="txtReasion" CssClass="tbox" TextMode="MultiLine" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnDeactive" runat="server" Text="De-Active" CssClass="btn btn-danger" OnClick="btnDeactive_Click" />
        <asp:Label ID="lblmsgDeactive" runat="server"></asp:Label>
        <asp:Button ID="btnActive" Visible="false" runat="server" Text="Active" CssClass="btn btn-success" OnClick="btnActive_Click" />

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
