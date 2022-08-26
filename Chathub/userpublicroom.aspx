<%@ Page Title="" Language="C#" MasterPageFile="~/Mstar.Master" AutoEventWireup="true" CodeBehind="userpublicroom.aspx.cs" Inherits="Chathub.userpublicroom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
    <script src="<%#Page.ResolveUrl("~/js/tothepointwap.js") %>"></script>
  
    <script type="text/javascript">


        window.setInterval("refreshDiv()", 1000);
        function refreshDiv() {

            GetNameStar();

        }

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title"></h3>

            <ul class="breadcrumb">
                <li>
                    <i class="icon-eye-open"></i>
                   <asp:Literal ID="lblRoomNme" runat="server"></asp:Literal>
                </li>

            </ul>

        </div>
    </div>

    <asp:Literal ID="litIdWraper" runat="server"></asp:Literal>


     




    <div id="stboxchat">

        <div style="" id="divExample">

            <div style="">

                <div id="msgall">
                </div>

                <div style="clear: both;"></div>
            </div>

        </div>


        <div style="border: 1px solid; min-height: 50px; padding: 10px;">

            <input id="txtmsg" type="text" name="name" value="" onkeydown="scrollsetting();" class="search-query span6" style="height: 25px; margin-right: 5px; float: left;" />
            <input id="btnSend" type="button" name="editAjaxGrid" value="Send" style="  height: 34px; float: left;" onclick="InsertStar()" class="btn" />
            <div style="clear: both"></div>
        </div>

        <div style="clear: both"></div>

    </div>

    <br />

    <div class="outdindex">
        <a class="btn btn-mini btn-info" href="/chatroompublic"> <i class="icon-white icon-share-alt"></i>Change Room </a>
    </div>
    <div class="outdindex">
        <asp:LinkButton CssClass="btn btn-mini btn-info" runat="server" ID="lbtnRefresh"> <i class="icon-ok"></i> Refresh Users</asp:LinkButton>
    </div>
    <div class="outdindex">
        <a runat="server" class="btn btn-mini btn-info" id="linkInside"> <i class="icon-align-justify"></i>Who Is Inside </a>
    </div>



    <br />
</asp:Content>
