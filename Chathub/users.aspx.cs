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
    public partial class users : System.Web.UI.Page
    {
        Datastar objStar = new Datastar();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                  updateChatroom();
                  bindseo();
            }
        }
        private void bindseo()
        {

            Page.Title = "Chathub.in Private Room Users";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "chathub.in there you can view list of all Private Room Users";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = " Private Room Users, chathub.in,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features ,login ,sign up ,online users list";
            Page.Header.Controls.Add(keywords1);

        }


        private void updateChatroom()
        {
            try
            {
                if (Request.QueryString["rval"] != null)
                {
                    int user_id = StarExtension.GetUserID;
                    DataTable dt = new DataTable();

                    string SQLcHECK = "select ID FROM starUsersAndRoomMaping WHERE UserID=" + user_id;

                    dt = objStar.getDataTable(SQLcHECK);

                    string Entry = string.Empty;
                    if (dt.Rows.Count > 0)
                    {
                        Entry = "update starUsersAndRoomMaping set RoomID=" + Request.QueryString["rval"] + " where UserID=" + user_id;
                    }
                    else
                    {
                        Entry = "insert into starUsersAndRoomMaping (UserID,RoomID,IsActive,DateModifiy) values(" + user_id + "," + Request.QueryString["rval"] + ",1,GETDATE())";
                    }

                    objStar.ExecuteSql(Entry);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}