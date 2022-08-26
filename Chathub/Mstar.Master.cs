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
    public partial class Mstar : System.Web.UI.MasterPage
    {
        Datastar objStar = new Datastar();
        DataTable dt;
        int user_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            Page.DataBind();
            form1.Action = Request.RawUrl;
            if (Session["user_id"] != null)
            {
                litusername.Text = "<b>Hi:</b> " + Session["username"].ToString();

                if (!Page.IsPostBack)
                {
                    lbtnLogout.Visible = true;
                    user_id = StarExtension.GetUserID;
                    //online entry 
                    string Entry = "update star_user set user_online=1 where user_id=" + user_id + " ";
                    objStar.ExecuteSql(Entry);
                    // 
                    countmsg();
                    //Total Users Count 
                    TotalUsers();
                    //
                    BindProfileData();

                    bindcoutfriendRequest();


                    dt = new DataTable();
                    dt = objStar.getDataTable("select  count(id) as COUNTT  from star_images where IsActive=1 and user_id=" + StarExtension.GetUserID);
                    litPhotoscount.Text = dt.Rows.Count > 0 ? dt.Rows[0]["COUNTT"].ToString() : "0";

                    Methodsall objmal = new Methodsall();
                    dt = new DataTable();
                    dt = objmal.GetFriendList();
                    string frinList = dt.Rows.Count > 1 ? (dt.Rows.Count - 1).ToString() : "0";

                    litCountflst.Text = "" + frinList + "/<span style='color:green;'>" + objmal.GetFriendsListWhichAreOnline().ToString() + "</span>";




                }

                bindHeaderUrls();
            }
            else
            {
                Response.Redirect("~/login");
            }

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMainSearch.Text.Length > 0)
            {
                Session["search"] = txtMainSearch.Text.ToString();
                Response.Redirect("~/search");
            }
            else
            {
                txtMainSearch.Attributes.Add("style", "border:1px solid red");
            }

        }


        private void BindProfileData()
        {
            try
            {

                //get Image
                dt = new DataTable();
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

                //get online and offline begin
                dt = new DataTable();
                dt = objStar.getDataTable("select count(user_id) as TotalUsersOnline ,(select count(user_id) from star_user where active='A' and user_online=0) as OfflineUsers from star_user where active='A' and user_online=1");
                if (dt.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(dt.Rows[0]["TotalUsersOnline"]) > 2 ? Convert.ToInt32(dt.Rows[0]["TotalUsersOnline"]) : 0;
                    litOnlineCount.Text = "" + count + "";   //<span class=\"offline\">" + dt.Rows[0]["OfflineUsers"] + "</span>";
                }
                //get online and offline begin end




            }
            catch (Exception)
            {

                throw;
            }
        }



        private void bindHeaderUrls()
        {
            try
            { 
                //meta = "<script src=\"" + ResolveUrl("~/js/jquery-1.9.1.js") + "\" type=\"text/javascript\"></script>";
                //Literal listjquery = new Literal();
                //listjquery.Text = meta;

                //Page.Header.Controls.Add(listjquery);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void bindcoutfriendRequest()
        {
            try
            {
                Methodsall objmal = new Methodsall();
                dt = new DataTable();
                dt = objmal.GetFriendRequest();
                if (dt.Rows.Count > 0)
                {
                    LitFriendsRequest.Text = "(" + (dt.Rows.Count).ToString() + ")"; 
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TotalUsers()
        {
            try
            {

                dt = new DataTable();
                dt = objStar.getDataTable("select count(user_id) as TotalUsers from star_user");
                if (dt.Rows.Count > 0)
                {
                    litOverAllUsersCount.Text = dt.Rows[0]["TotalUsers"] + " User Registered";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void countmsg()
        {
            try
            {
                Methodsall s = new Methodsall();

                //dt = new DataTable();
                //dt = s.GetUserMessagesInboxPageCounter(user_id);
                //if (dt.Rows.Count > 0)
                //{
                //    litmsg.Text = "(" + dt.Rows.Count + ")";
                //    listmsg2.Text = "(" + dt.Rows.Count + ")";
                //}
                //objStar.dispose_datatable(dt);
                hideUserid.Value = "{'Userid': '" + Session["user_id"] + "','top': 4}";

                //fire notification
                dt = new DataTable();
                dt = s.GetNotificationOfUser();
                if (dt.Rows.Count > 0)
                {
                    litNoti.Text = dt.Rows.Count.ToString();
                }
                else
                    litNoti.Text = "0";

                objStar.dispose_datatable(dt);
                //

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            try
            {

                if (Session["user_id"] != null)
                {
                    string str_logEntry = "update star_user set user_online=0 where user_id=" + Session["user_id"].ToString() + " ";
                    objStar.ExecuteSql(str_logEntry);
                    Session["mail_id"] = "";
                    Session["username"] = "";
                    Session["user_id"] = "";
                    Session.Abandon();
                    Response.Redirect("~/login");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}