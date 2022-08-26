<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="jsAll.ascx.cs" Inherits="Chathub.uc.jsAll" %>
<%@ OutputCache Duration="3600" VaryByParam="None"%>
<script src="<%#Page.ResolveUrl("~/js/jquery.min.js") %>"> </script>
 
<script>window.jQuery || document.write('<script src="<%#Page.ResolveUrl("~/plugins/jquery/jquery.min.js") %>"><\/script>')</script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.ui/jquery-ui-1.10.1.custom.min.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.ui.touch-punch/jquery.ui.touch-punch.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/twitter-bootstrap/bootstrap.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.slimscroll/jquery.slimscroll.min.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.cookie/jquery.cookie.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.simplecolorpicker/jquery.simplecolorpicker.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.uipro/uipro.min.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.ui.chatbox/jquery.ui.chatbox.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.livefilter/jquery.liveFilter.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/js/chatboxManager.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/js/extents.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/js/app.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/js/demo-settings.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/js/sidebar.js") %>"></script>
<script>
    /*<![CDATA[*/
    $(function () {
        App.init();

        SideBar.init({
            shortenOnClickOutside: false
        });
    });
    /*]]>*/
    </script>


<script src="<%#Page.ResolveUrl("~/plugins/jquery.fullcalendar/fullcalendar.min.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.jqvmap/jquery.vmap.min.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.jqvmap/maps/jquery.vmap.world.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.jqvmap/data/jquery.vmap.sampledata.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.flot/jquery.flot.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.flot/jquery.flot.resize.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.flot/jquery.flot.selection.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.sparkline/jquery.sparkline.min.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.justgage/raphael.2.1.0.min.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.gritter/jquery.gritter.min.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/bootstrap.daterangepicker/moment.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/bootstrap.daterangepicker/daterangepicker.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/jquery.pulsate/jquery.pulsate.min.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/plugins/bootstrap.fileupload/bootstrap-fileupload.min.js") %>"></script>
<script src="<%#Page.ResolveUrl("~/js/form-stuff.elements.js") %>"></script>

<script src="<%#Page.ResolveUrl("~/js/dashboard.js") %>"></script>
