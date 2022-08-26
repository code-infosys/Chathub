using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
namespace Chathub
{
    public partial class index : System.Web.UI.Page
    {
        Datastar objStar = new Datastar();
        validData valid = new validData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.DataBind();
                bindseo();
                bindPosts();
                
            }
        }

        private void bindseo()
        {

            Page.Title = "Welcome to chathub.in:  Make New Friends, Chat, Upload Photos, Likes ,Public Chating , Private Chating ,Search Your Friends";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "Sonustar Creation , hi friends welcome to sonustar world ,by using my these website chathub.in you can make your new friends on world-wide  and also communicate with them ";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = "chathub.in,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features";
            Page.Header.Controls.Add(keywords1);


            //get Image
            DataTable dt = new DataTable();
            dt = objStar.getDataTable("select img_name  from star_user where user_id=" + StarExtension.GetUserID);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["img_name"].ToString().Length > 2)
                {
                    ImageUser.Src = objStar.getImage(dt.Rows[0]["img_name"].ToString());
                }
                else { ImageUser.Src = "/starimg/nophoto.png"; }
            }

            dt.Dispose();
            //get image end
             
        }


        protected bool GetFriendListByFriendCheck(Int64 FriendID)
        {
            Int64 UserDIid = StarExtension.GetUserID;
            string sql_f = @"select id,user_id,request from star_frnd_list where user_id=" + UserDIid + " and   frnd_user_id=" + FriendID + " and request in('R','A') union select id,user_id,request  from star_frnd_list where frnd_user_id=" + UserDIid + " and user_id=" + FriendID + "    and request in('R','A')";
            DataTable dt = new DataTable();
            dt = objStar.getDataTable(sql_f);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        

        protected string TimeAgo(DateTime date)
        {

            TimeSpan timeSince = DateTime.Now.Subtract(date);

            if (timeSince.TotalMilliseconds < 1)
                return "not yet";
            if (timeSince.TotalMinutes < 1)
                return "just now";
            if (timeSince.TotalMinutes < 2)
                return "1 minute ago";
            if (timeSince.TotalMinutes < 60)
                return string.Format("{0} minutes ago", timeSince.Minutes);
            if (timeSince.TotalMinutes < 120)
                return "1 hour ago";
            if (timeSince.TotalHours < 24)
                return string.Format("{0} hours ago", timeSince.Hours);
            if (timeSince.TotalDays == 1)
                return "yesterday";
            if (timeSince.TotalDays < 7)
                return string.Format("{0} days ago", timeSince.Days);
            if (timeSince.TotalDays < 14)
                return "last week";
            if (timeSince.TotalDays < 21)
                return "2 weeks ago";
            if (timeSince.TotalDays < 28)
                return "3 weeks ago";
            if (timeSince.TotalDays < 60)
                return "last month";
            if (timeSince.TotalDays < 365)
                return string.Format("{0} months ago", Math.Round(timeSince.TotalDays / 30));
            if (timeSince.TotalDays < 730)
                return "last year";

            //last but not least...
            return string.Format("{0} years ago", Math.Round(timeSince.TotalDays / 365));

        }


        private void bindPosts()
        {
            try
            {
                StarService s = new StarService();
                DataTable dt = new DataTable();
                dt = s.SelectOwnPost("SelectPostesForOwn", StarExtension.GetUserID);
                if (dt.Rows.Count > 0)
                {
                    listviewbindpost.DataSource = dt;
                    listviewbindpost.DataBind();
                }
            }
            catch (Exception)
            {

            }
        }


        protected void btnSimplePost_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtposttext.Text.Length > 4)
                {

                    StarService s = new StarService();
                    string imgpath = string.Empty;
                    if (fuImgPost.FileName.Length > 0)
                    {
                        if (fuImgPost.PostedFile.ContentLength <= 1048576)
                        {
                            if (fuImgPost.PostedFile.ContentType == "image/jpeg" || fuImgPost.PostedFile.ContentType == "image/png" || fuImgPost.PostedFile.ContentType == "image/gif")
                            {

                                imgpath = fuImgPost.FileName.ToString();
                                if (imgpath.IndexOf(".png") > 0)
                                {
                                    imgpath = imgpath.Replace(".png", "");
                                }
                                imgpath = imgpath.Replace(".jpg", "");
                                Bitmap image = objStar.ResizeImage(fuImgPost.PostedFile.InputStream, 200, 400);
                                image.Save(Server.MapPath("~/starimg/") + imgpath + DateTime.Now.ToString("dd_mm_yyyyhh") + ".jpg", ImageFormat.Jpeg);

                                imgpath = imgpath + DateTime.Now.ToString("dd_mm_yyyyhh") + ".jpg";

                            }
                            else
                            {
                                lblmsgs.Text = "! File Format is Not valid";
                            }
                        }
                        else
                        {
                            lblmsgs.Text = "! Please Use a Image Size Less then 1Mb";
                        }
                    }


                    string videourl = string.Empty;
                    int AudienceLockID = 0;

                    AudienceLockID = Convert.ToInt32(ddlAudi.SelectedItem.Value);

                    Int64 resutl = s.InsertWallPost(StarExtension.GetUserID, valid.ValidateData(txtposttext.Text), Request.UserHostAddress.ToString(), imgpath, videourl, AudienceLockID);

                    if (resutl > 0)
                    {
                        Response.Redirect(Page.ResolveUrl("~/home"));

                    }

                }
                else
                {
                    txtposttext.Attributes.Add("style", "border:1px solid red");
                }
            }
            catch (Exception)
            {

            }
        }


        

        protected void listviewbindpost_ItemCommand1(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "changelock")
                {
                    DropDownList ddllist = (DropDownList)e.Item.FindControl("ddlAudi");
                    objStar.ExecuteSql("update star_post set AudienceLockID=" + ddllist.SelectedItem.Value + " where postid=" + e.CommandArgument + "");
                    bindPosts();
                }
                if (e.CommandName == "deletepost")
                {
                    objStar.ExecuteSql("update star_post set IsDelete=1 where postid=" + e.CommandArgument + "");
                    Response.Redirect(Page.ResolveUrl("~/home"));
                    bindPosts();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void listviewbindpost_PagePropertiesChanged1(object sender, EventArgs e)
        {
            bindPosts();
        }

    }
}