using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Chathub
{
    public partial class userpublicroom : System.Web.UI.Page
    {
        Datastar objStar = new Datastar();
        validData valid = new validData();
         
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { 
                if (Request.QueryString["rmid"] != null)
                {
                    if (!Page.IsPostBack)
                    {
                        //PublicChat(Request.QueryString["rmid"]);
                        updateChatroom();

                        litIdWraper.Text = "<div id=\"hidef\" style=\"display:none;\">" + Request.QueryString["rmid"] + "</div> <div id=\"hideid\" style=\"display:none;\">" + StarExtension.GetUserID + "</div>";
                        bindseo();
                    }
                    linkInside.HRef = "/roomusers/" + Request.QueryString["rmid"];

                    roomname(Request.QueryString["rmid"]);
                }
                 
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void roomname(string p)
        {
            try
            { 
                 DataTable dt = new DataTable();
                  dt = objStar.getDataTable("select * from star_rooms where ID="+p+" AND IsActive=1");
                  if (dt.Rows.Count > 0)
                  {
                      lblRoomNme.Text = "  Welcome In <span class='badge badge-warning'>  <b>" + dt.Rows[0]["RoomName"].ToString() + "</b> </span> Chat Room ";
                  }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

       


        private void bindseo()
        {

            Page.Title = "Chathub.in public chat room all users";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "chathub.in there you can chat with all room users";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = " public chat room all users , chathub.in,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features ,login ,sign up ,online users list";
            Page.Header.Controls.Add(keywords1);

        }







        private void updateChatroom()
        {
            try
            {
                if (Request.QueryString["rmid"] != null)
                {
                    int user_id = StarExtension.GetUserID;
                    DataTable dt = new DataTable();

                    string SQLcHECK = "select ID FROM starUsersAndRoomMaping WHERE UserID=" + user_id;

                    dt = objStar.getDataTable(SQLcHECK);

                    string Entry = string.Empty;
                    if (dt.Rows.Count > 0)
                    {
                        Entry = "update starUsersAndRoomMaping set RoomID=" + Request.QueryString["rmid"] + " where UserID=" + user_id;
                    }
                    else
                    {
                        Entry = "insert into starUsersAndRoomMaping (UserID,RoomID,IsActive,DateModifiy) values(" + user_id + "," + Request.QueryString["rmid"] + ",1,GETDATE())";
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