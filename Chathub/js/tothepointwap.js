$(document).ready(function () {
     
        $('#txtmsg').keypress(function (e) {
            if (e.keyCode == 13) {
                $('#btnSend').click();
                return false;

            }
        });

        $("html, body").animate({ scrollTop: $(document).height() - $(window).height() });
     
    $(window).load(function () {
        //$("html, body").animate({ scrollTop: $(document).height() - $(window).height() });
        //$("#stboxchat").scrollTop($("#stboxchat")[0].scrollHeight);
        //$("html, body").scrollTop($(document).scrollHeight);
    });

    GetNameStar();

});


function GetNameStar() {

    $.ajax({
        type: "POST",
        url: "../StarService.asmx/PublicMstChatSelect",
        data: "{'roomid': " + $("#hidef").text() + ",'userid': '" + $("#hideid").text() + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            bStar(response.d);
            //CountPP(response.d);
        },
        failure: function (msg) {
            alert(msg);
        }
    });
}

function bStar(PublicChatItem) {
    var root = document.getElementById('msgall');
    var str = "";
    $.each(PublicChatItem, function (index, PublicChatItem) {


        var msg = PublicChatItem.ChatDesc;
        var created_date = PublicChatItem.crtd_date;
        var uname = PublicChatItem.username;
        var imgname = PublicChatItem.img_name;
        var uid = PublicChatItem.uid;
        var sessionid = $("#hideid").text();

        str += "<div style=\"margin-bottom:2px;padding:5px; border-bottom:1px dotted black;\"> <span class=\"Usern\">";
        if (sessionid == uid) {
            str += "<span class='badge badge-success'> " + uname + "</span>";
        }
        else {
            str += "<a class='label label-info' href='/visitprofile/" + uid + "'> " + uname + "</a> ";
        }
        str += "</span>:" + msg + "<br>"; 
        str += "<span style='color:silver;margin-left:10px;font-size:8px;'>" + created_date + "</span> ";
        str += " <div  style=\"clear:both;\"></div> ";
        str += "</div> ";

    });

    root.innerHTML = str;

}





function InsertStar() {

    var msg = document.getElementById('txtmsg');
    if (msg.value == null || msg.value == "") {
        msg.className = "search-query span6";
    }
    else {
        $.ajax({
            type: "POST",
            url: "../StarService.asmx/insertPublicMsg",
            data: "{'userid': '" + $("#hideid").text() + "','roomid': '" + $("#hidef").text() + "','chatdesc': '" + msg.value + "'}",

            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                bStar(response.d);
                msg.value = "";
                $("#txtmsg").focus();
                // scrollsetting();
            },
            failure: function (msg) {
                alert(msg);
            }
        });
    }
}