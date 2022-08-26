$(document).ready(function () {
    $('#composerMessage').keypress(function (e) {

        if (e.keyCode == 13) {
            $('#btnSend').click();
            return false;

        }
    });


    $(window).load(function () {

    });

    GetNameStar();

});


function GetNameStar() {

    $.ajax({
        type: "POST",
        url: "../StarService.asmx/SelectPrivateChat",
        //data: "<%=hideSelect.Value%>",
        data: "" + $('#ContentPlaceHolder1_hideSelect').val() + "",
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


        var msg = PublicChatItem.msg;
        var created_date = PublicChatItem.date;
        var uname = PublicChatItem.username;
        var imgname = PublicChatItem.img;
        var uid = PublicChatItem.userid;
        var seen = PublicChatItem.seen;
        var frndUserID = PublicChatItem.frndUserID;
        var sessionid = $("#hideid").text();

        if (sessionid == uid) {

            str += "<div class=\"chat-message  pull-right\"><div class=\"chat-message-avatar\"></div>";

            var ww;
            if (seen == "S") {
                ww = "seen";
            }
            else { ww = "unread"; }

            str += "<div class=\"chat-message-body\">  <div class=\"chat-message-body-header\"> <span class='badge  label-info badge-right'> Me </span> <span style='color:#8081A9;padding-right:10px;font-size:8px;'> " + ww + "  </span>  <span style='font-size:10px;'>" + created_date + "</span> </div>";

            str += "<div class=\"chat-message-body-content\"> " + msg + "";
            if (imgname.length > 5) {
                str += " <img src='../star.ashx?w=120&h=140&iurl=" + imgname + "' style='width:40%;' /> ";
            }
            str += " </div>";

            str += "</div> </div>";

        }
        else {


            str += "<div class=\"chat-message\"><div class=\"chat-message-avatar\"></div>";

             

            str += "<div class=\"chat-message-body\">  <div class=\"chat-message-body-header\"> <a href='/visitprofile/" + uid + "' class=\"OthreUser\"> " + uname + "</a> <small> " + created_date + " </small>    </div>";

            str += "<div class=\"chat-message-body-content\"> " + msg + "";
            if (imgname.length > 5) {
                str += " <img src='../star.ashx?w=120&h=140&iurl=" + imgname + "' style='width:40%;' /> ";
            }
            str += "</div>";

            str += "</div> </div>";





        }









    });

    root.innerHTML = str;

}