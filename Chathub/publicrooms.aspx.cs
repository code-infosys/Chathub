using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Chathub
{
    public partial class publicrooms : System.Web.UI.Page
    {
        Datastar objStar = new Datastar();

        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            { 
                countChat();
                bindseo();
            }
        }

        private void bindseo()
        {

            Page.Title = "Chathub.in Public Chat Room";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "Chathub.in Public Chat Room , there you can select any room and then chat with room all friends, room users";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = "Public Chat Room, chathub.in,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features ,login ,sign up ,online users list";
            Page.Header.Controls.Add(keywords1);

        }
        

        private void countChat()
        {
            string rptBind = string.Empty;
            string rpt_sql = "select * from star_rooms where IsActive=1 order by ID asc";
            DataTable dt = new DataTable();
            dt = objStar.getDataTable(rpt_sql);
            rptChatFrnd.DataSource = dt;
            rptChatFrnd.DataBind();
             

        }

        protected int count(int roomid)
        {
            int r = 0;
            string sql = " select count(s.user_id) as count from starUsersAndRoomMaping map inner join star_user s on s.user_id=map.UserID where RoomID=" + roomid + " and s.active='A'";
            DataTable dt = new DataTable();
            dt = objStar.getDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                r = Convert.ToInt32(dt.Rows[0]["count"]);
            }
            return r;
        }

    }
}