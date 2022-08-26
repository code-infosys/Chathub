<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="photos.aspx.cs" Inherits="Chathub.photos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="<%#Page.ResolveUrl("~/js/jswpesrcps.js") %>"></script>
    <link rel="stylesheet" href="<%#Page.ResolveUrl("~/plugins/jquery.colorbox/example1/colorbox.css") %>"/>
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
                           My Photos 
                </li> 
            </ul>

        </div>
    </div>
     
    
    


    <br />


     


    <div class="fileupload fileupload-new" data-provides="fileupload">

        <div class="fileupload-preview fileupload-exists thumbnail" style="width: 50px; height: 50px;"></div>
        <span class="btn btn-file">
            <span class="fileupload-new">Select Image</span>
            <span class="fileupload-exists">Change</span>
            <asp:FileUpload ID="fuImgPost" runat="server" CssClass="file-upload" />

        </span>
        <a href="#" class="btn fileupload-exists" data-dismiss="fileupload">Remove</a>
        <div style="color:red;" id="uploadPreview"></div>
    </div>





    <br />

    Privacy:
    <asp:DropDownList ID="ddlAudi" CssClass="dropdown-toggle" runat="server" DataTextField="AudienceName" DataValueField="id" DataSourceID="obsGetAudienceLock"></asp:DropDownList>
    <asp:ObjectDataSource ID="obsGetAudienceLock" runat="server" SelectMethod="GetAudienceLock" TypeName="Chathub.Methodsall"></asp:ObjectDataSource>
    <br />
    <br />




    <asp:LinkButton ID="btnImageUpload" OnClientClick="OkProcess();" CssClass="btn btn-primary" runat="server" OnClick="btnImageUpload_Click"> <i class="icon-picture"></i> Upload </asp:LinkButton>
    <br />
    <asp:Label ID="lblPhotomsg" runat="server" ForeColor="Red"></asp:Label>

    <img src="../images/loader.gif" id="imgProcesss" style="width: 40px; display: none;" />
    <script>
        function OkProcess() {
            document.getElementById("imgProcesss").style.display = "Block";
        }
    </script>


    <br />






    <div class="row-fluid">
        <ul class="thumbnails">

            <asp:ListView ID="ListView1" runat="server" DataSourceID="objUsersget" EnableModelValidation="True" DataKeyNames="id" OnItemCommand="ListView1_ItemCommand">

                <ItemTemplate>

                    <li class="span3">
                        <a rel="gallery_group" href="starimg/<%#Eval("img_name") %>" class="thumbnail">
                            <div class="zoom">
                                <img src="star.ashx?w=150&h=160&iurl=<%#Eval("img_name")%>" alt="">
                                <asp:HiddenField ID="hideimg" Value='<%#Eval("img_name") %>' runat="server" />
                                <div class="clearfix"></div>
                                <div class="badge badge-success">
                                    Star Like  <span class="badge badge-inverse"><%#Eval("LikeCounts").ToString()==""?"0":Eval("LikeCounts") %></span>
                                </div>

                            </div>
                        </a>

                        <asp:DropDownList ID="ddlAudiLv" SelectedValue='<%#Eval("AudienceLockID") %>' runat="server" DataTextField="AudienceName" DataValueField="id" DataSourceID="obsGetAudienceLock"></asp:DropDownList>

                        <asp:LinkButton ID="lnkUpdateimg" CommandName="UpdateImag" CssClass="btn btn-info" CommandArgument='<%#Eval("id")%>' runat="server">Update</asp:LinkButton>
                        <asp:LinkButton ID="lbtndelimg" CommandArgument='<%#Eval("id")%>' CommandName="Deleimg" runat="server" CssClass="btn btn-danger" Text="Delete This"></asp:LinkButton>


                    </li>

                </ItemTemplate>


                <LayoutTemplate>

                    <div class="clearfix"></div>
                    <div runat="server" id="itemPlaceholderContainer" style=""><span runat="server" id="itemPlaceholder" /></div>
                    <div class="dataTables_paginate paging_bootstrap pagination">

                        <div class="clearfix"></div>
                        <asp:DataPager runat="server" ID="DataPager1" PageSize="6">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-inverse" ShowFirstPageButton="True" PreviousPageText="<" FirstPageText="<<" ShowNextPageButton="False"></asp:NextPreviousPagerField>
                                <asp:NumericPagerField NumericButtonCssClass="active"></asp:NumericPagerField>
                                <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True" ButtonCssClass="btn btn-inverse" NextPageText=">" LastPageText=">>" ShowPreviousPageButton="false"></asp:NextPreviousPagerField>
                            </Fields>
                        </asp:DataPager>

                    </div>
                </LayoutTemplate>

            </asp:ListView>


        </ul>
    </div>

    <asp:ObjectDataSource ID="objUsersget" runat="server" SelectMethod="GetUserAllImages"
        TypeName="Chathub.Methodsall">
        <SelectParameters>
            <asp:SessionParameter Name="userid" SessionField="user_id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>



    <script src="<%#Page.ResolveUrl("~/plugins/jquery.mousewheel/jquery.mousewheel.min.js") %>"></script>
    <script src="<%#Page.ResolveUrl("~/plugins/jquery.colorbox/jquery.colorbox-min.js") %>"></script>

    <script>
        /*<![CDATA[*/
        $(".thumbnail").colorbox({ rel: 'group1', transition: "none", width: "75%", height: "75%" });
        /*]]>*/
    </script>

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
                        if (s > 1000)
                        {
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
