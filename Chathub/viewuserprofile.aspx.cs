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
    public partial class viewuserprofile : System.Web.UI.Page
    {
        Datastar objStar = new Datastar();
        validData valid = new validData();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["uid"] != null)
            {
                if (!IsPostBack)
                {

                    String[] txt = Request.QueryString["uid"].ToString().Split(Convert.ToChar("="));
                    string star = txt[txt.Length - 1];
                    Int64 r = Convert.ToInt64(star);
                    bindInfoOfUser(r);

                    if (r == StarExtension.GetUserID)
                    {
                        pnlCloseoverallBlocklist.Visible = false;
                        lblblocklistmsg.Text = "! You have no access view own self on this page";
                        lblblocklistmsg.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {



                        //block list checking
                        DataTable dtbl = new DataTable();
                        dtbl = objStar.getDataTable("select user_id from star_user where user_id=" + r + " and  user_id not in(select bl.user_id from star_blockList bl where bl.BlockToUser_id=" + StarExtension.GetUserID + ")");
                        if (dtbl.Rows.Count > 0)
                        {
                            pnlCloseoverallBlocklist.Visible = true;
                        }
                        else
                        {
                            pnlCloseoverallBlocklist.Visible = false;
                            lblblocklistmsg.Text = "! You Have No Access Because this person is Block Yourself";
                            lblblocklistmsg.ForeColor = System.Drawing.Color.Red;

                        }
                    }
                    //

                    //Profile visit
                    StarM.Profilevisit(r, StarExtension.GetUserID);
                    //string sql_seen = "insert into star_profilevisitor (user_id,visitor_user_id) values(" + r + "," + StarExtension.GetUserID + ")";
                    //objStar.ExecuteSql(sql_seen);
                    //

                    Methodsall objmal = new Methodsall();
                    dt = new DataTable();
                    dt = objmal.GetFriendListByFriendCheck(StarExtension.GetUserID, r);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["request"].ToString().Trim() == "R")
                        {
                            lbtnSendRequest.Enabled = false;
                            lbtnSendRequest.Text = "Already In Process..";
                        }
                        else
                        {
                            lbtnSendRequest.Enabled = false;
                            lbtnSendRequest.Visible = false;
                            hideDelid.Value = dt.Rows[0]["id"].ToString();
                            lbtnUnfriend.Visible = true;
                            // lbtnSendRequest.Text = "Already Friend";
                        }
                        //else if (dt.Rows[0]["request"].ToString().Trim() == "A")
                        //{
                        //    lbtnSendRequest.Text = "Unfriend";
                        //}

                    }

                    dt = new DataTable();
                    dt = objStar.getDataTable("select * from star_frnd_list where user_id=" + StarExtension.GetUserID + " and frnd_user_id=" + r + " and request='R'");
                    if (dt.Rows.Count > 0)
                    {

                        lbtnSendRequest.Enabled = false;

                        lbtnSendRequest.Text = "Already Sent";
                    }


                    dt = new DataTable();
                    dt = objStar.getDataTable("select user_id from AdminStar_ApplicationUser where user_id=" + r + " and IsActive=1");
                    if (dt.Rows.Count > 0)
                    {
                        Literal1.Text = " <img src=\"../images/adminofstar.gif\"  style=\"width:35px;\" />";
                    }
                    else
                    {
                        Literal1.Text = "";
                    }

                    bindseo(r);
                    bindPosts(r);

                }

            }
        }



        private void bindPosts(Int64 userid)
        {
            try
            {
                StarService s = new StarService();
                DataTable dt = new DataTable();
                dt = s.SelectOwnPost("SelectPostesForOther", userid);
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



        private void bindseo(Int64 user)
        {
            

            Methodsall m = new Methodsall();
            DataTable dt = new DataTable();
            dt = m.GetOtherUserInfoByID(user);
            if (dt.Rows.Count > 0)
            {
                this.Page.Title = "Chathub.in Visit Wall Of " + dt.Rows[0]["username"].ToString() + "";

                HtmlMeta description1 = new HtmlMeta();
                description1.Name = "description";
                description1.Content = "chathub.in there you can visit wall of your friends and view this daily updated posts";
                Page.Header.Controls.Add(description1);

                HtmlMeta keywords1 = new HtmlMeta();
                keywords1.Name = "keywords";
                keywords1.Content = "wall of chathub ,user wall , view posts ,sonu,sonustar";
                Page.Header.Controls.Add(keywords1);
            }
        }

        protected void listviewbindpost_PagePropertiesChanged(object sender, EventArgs e)
        {
            if (Request.QueryString["uid"] != null)
            {
                try
                {
                    bindPosts(Convert.ToInt64(Request.QueryString["uid"]));
                }
                catch (Exception)
                {
                    
                    throw;
                }
                

                
            }
        }
        

        private void bindInfoOfUser(Int64 UID)
        {
            try
            {
                //get Image
                linksendmsg.HRef = "/chat/" + UID;

                dt = new DataTable();
                dt = objStar.getDataTable("select img_name  from star_user where active='A' and user_id=" + UID);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["img_name"].ToString().Length > 2)
                    {
                        ImageUser.Src = objStar.getImage(dt.Rows[0]["img_name"].ToString());
                    }
                    else { ImageUser.Src = objStar.getImage("nophoto.png"); }
                }

                dt.Dispose();
                //get image end

                //get online and offline begin
                dt = new DataTable();
                dt = objStar.getDataTable(@"select s.username ,(s.user_id) as user_id ,s.img_name,s.sex
                                          ,s.mail_id,s.crtd_date,s.dob,(select country_name from country where country_id=s.country) as country,
                                            s.profile_visit from star_user s where  s.active='A' and s.user_id=" + UID);
                if (dt.Rows.Count > 0)
                {
                    litUsername.Text = "<b style=\"text-transform: capitalize;\">" + dt.Rows[0]["username"].ToString() + "</b><br><br> Sex: " + dt.Rows[0]["sex"].ToString();
                    litProfileVisit.Text = dt.Rows[0]["profile_visit"].ToString().Length > 0 ? dt.Rows[0]["profile_visit"].ToString() : "0";
                    //Methodsall m=new Methodsall();
                    //dt=new DataTable();
                    //dt = m.GetProfileVisitors(UID);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    litProfileVisit.Text = dt.Rows.Count.ToString();
                    //}
                    //<li> </li>
                    litFriendslist.Text = " <li class=\"active\"><a href='/infoprofile/" + UID + "'>Profile Info</a> </li>  <li> <a href='/viewphotos/" + UID + "'>View Photos</a>  </li>  <li> <a href='/friendlist/" + UID + "'>View Friends List</a>  </li>";
                }
               


                //get online and offline begin end
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void lbtnSendRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["uid"] != null)
                {

                    String[] txt = Request.QueryString["uid"].ToString().Split(Convert.ToChar("="));
                    string star = txt[txt.Length - 1];
                    int friendid = Convert.ToInt32(star);
                    string sql_first = string.Empty;
                    int result1 = 0;
                    //Methodsall objmal = new Methodsall();

                    //dt = new DataTable();
                    //dt = objmal.GetFriendListByFriendCheck(StarExtension.GetUserID, friendid);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    if (dt.Rows[0]["request"].ToString().Trim() == "A")
                    //    {

                    //        string sql = "update star_frnd_list set request='F',lst_mod_date=GETDATE(),mod_by=" + StarExtension.GetUserID + " where id=" + friendid + " and request='A'";
                    //        int r = objStar.ExecuteSql(sql);
                    //        Label1.Text = "Unfriend Successfully";
                    //        lbtnSendRequest.Enabled = false;

                    //    }
                    //}
                    //else
                    //{
                        dt = new DataTable();
                        dt = objStar.getDataTable("select * from star_frnd_list where user_id=" + StarExtension.GetUserID + " and frnd_user_id=" + friendid + " and request='R'");
                        if (dt.Rows.Count > 0)
                        {
                            Label1.Text = "Already Sent.";
                        }
                        else
                        {
                            sql_first = @"insert into star_frnd_list (user_id,frnd_user_id,request,crtd_date,lst_mod_date,idconcat,crtd_by,mod_by) 
                                                      values(" + StarExtension.GetUserID + ", " + friendid + ",'R',GETDATE(),GETDATE()," + StarExtension.GetUserID + friendid + "," + StarExtension.GetUserID + "," + StarExtension.GetUserID + ")";
                            result1 = objStar.ExecuteSql(sql_first);
                        }

                        if (result1 > 0)
                        {
                            Label1.Text = "Sent Successfully";
                            lbtnSendRequest.Enabled = false;
                        }

                   // }





                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        
        protected void lbtnUnfriend_Click(object sender, EventArgs e)
        {
            try
            {
                string Entry = "delete from star_frnd_list where id=" + hideDelid.Value;
                objStar.ExecuteSql(Entry);
                lbtnUnfriend.Enabled = false;

                Label1.Text = "Unfriends Successfully..";
                
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

       
    }
}