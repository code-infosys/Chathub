using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Chathub
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

           

           // Application["OnlineUsers"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Application.Lock();
            //Application["OnlineUsers"] = (int)Application["OnlineUsers"] + 1;
            //Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //if (Request.RawUrl.Contains("contact/2"))
            //{
            //    Context.RewritePath("~/contactus.aspx?Category=2");
            //}

            //string requestedUrl = HttpContext.Current.Request.Url.ToString().ToLower();
            //string requestedDomain = "http://chathub.in";
            //string correctDomain = "http://www.chathub.in";

            //if (requestedUrl.Contains(requestedDomain))
            //{ 
            //    HttpContext.Current.Response.Status = "301 Moved Permanently";

            //    HttpContext.Current.Response.AddHeader("Location", requestedUrl.Replace(requestedDomain, correctDomain));

            //}


            string main_path = Request.Path.ToLower();

            //if (main_path.IndexOf("/pcs/") >= 0)
            //{

            //    String[] txt = Regex.Split(HttpContext.Current.Request.Url.ToString(), @"/");
            //    String page = txt[txt.Length - 1];

            //    Context.RewritePath(String.Concat("~/msgN.aspx?chat_id=", page), false);

            //} 


            if (main_path.IndexOf("/chat/") >= 0)
            {

                String[] txt = Regex.Split(HttpContext.Current.Request.Url.ToString(), @"/");
                String page = txt[txt.Length - 1];

                Context.RewritePath(String.Concat("~/msgN.aspx?chat_id=", page), false);

            } 

            if (main_path.IndexOf("/visitprofile/") >= 0)
            {

                String[] txt = Regex.Split(HttpContext.Current.Request.Url.ToString(), @"/");
                String page = txt[txt.Length - 1]; 
               

                Context.RewritePath(String.Concat("~/viewuserprofile.aspx?uid=", page), false);

            }
            if (main_path.IndexOf("/infoprofile/") >= 0)
            {

                String[] txt = Regex.Split(HttpContext.Current.Request.Url.ToString(), @"/");
                String page = txt[txt.Length - 1];
                 
                Context.RewritePath(String.Concat("~/roompages/userProfileInfo.aspx?uid=", page), false);

            }

            if (main_path.IndexOf("/viewphotos/") >= 0)
            {

                String[] txt = Regex.Split(HttpContext.Current.Request.Url.ToString(), @"/");
                String page = txt[txt.Length - 1];

                Context.RewritePath(String.Concat("~/roompages/userPhotosList.aspx?uid=", page), false);

            }

            //
            if (main_path.IndexOf("/postdetail/") >= 0)
            {

                String[] txt = Regex.Split(HttpContext.Current.Request.Url.ToString(), @"/");
                String page = txt[txt.Length - 3];

                Context.RewritePath(String.Concat("~/roompages/postDetails.aspx?pwap=", page), false);

            }






            if (main_path.IndexOf("/roomusers/") >= 0)
            { 

                String[] txt = Regex.Split(HttpContext.Current.Request.Url.ToString(), @"/");
                String page = txt[txt.Length - 1];
              

                Context.RewritePath(String.Concat("~/users.aspx?rval=", page), false);

            }


            if (main_path.IndexOf("/friendlist/") >= 0)
            {

                String[] txt = Regex.Split(HttpContext.Current.Request.Url.ToString(), @"/");
                String page = txt[txt.Length - 1];
                 
                Context.RewritePath(String.Concat("~/listfriends.aspx?uid=", page), false);

            } 


             //   
             
            if (Request.RawUrl.Contains("/login"))
            {
                Context.RewritePath("~/login.aspx");
            }
            if (Request.RawUrl.Contains("/newregister"))
            {
                Context.RewritePath("~/registeruser.aspx");
            }


            if (Request.RawUrl.Contains("/home"))
            {
                Context.RewritePath("~/index.aspx");
            }
            if (Request.RawUrl.Contains("/chatrooms"))
            {
                Context.RewritePath("~/Default.aspx");
            }
             
            if (Request.RawUrl.Contains("/profile"))
            {
                Context.RewritePath("~/profile.aspx");
            }
            if (Request.RawUrl.Contains("/starwall"))
            {
                Context.RewritePath("~/roompages/myWall.aspx");
            } 
            if (Request.RawUrl.Contains("/onlinestar"))
            {
                Context.RewritePath("~/onlineusers.aspx");
            }
            if (Request.RawUrl.Contains("/search"))
            {
                Context.RewritePath("~/search.aspx");
            }
            if (Request.RawUrl.Contains("/inbox"))
            {
                Context.RewritePath("~/message.aspx");
            }

            if (Request.RawUrl.Contains("/myphotos"))
            {
                Context.RewritePath("~/photos.aspx");
            }

           
             if (Request.RawUrl.Contains("/friends"))
            {
                Context.RewritePath("~/listfriends.aspx");
            }
             if (Request.RawUrl.Contains("/chatroompublic"))
            {
                Context.RewritePath("~/publicrooms.aspx");
            }
             if (Request.RawUrl.Contains("/help"))
            {
                Context.RewritePath("~/starshelp.aspx");
            }
             if (Request.RawUrl.Contains("/terms"))
            {
                Context.RewritePath("~/termsnconditions.aspx");
            }
             if (Request.RawUrl.Contains("/tour"))
            {
                Context.RewritePath("~/tour.aspx");
            }
             if (Request.RawUrl.Contains("/todayusers"))
             {
                 Context.RewritePath("~/todayregistereduser.aspx");
             }
             if (Request.RawUrl.Contains("/forgot"))
             {
                 Context.RewritePath("~/forgot.aspx");
             }
             if (Request.RawUrl.Contains("/suggestionbox"))
             {
                 Context.RewritePath("~/roompages/whoisinsideroom.aspx");
             }
             if (Request.RawUrl.Contains("/profilevisitors"))
             {
                 Context.RewritePath("~/roompages/profileviewer.aspx");
             }

             if (Request.RawUrl.Contains("/wrapupfriend"))
             {
                 Context.RewritePath("~/frequest.aspx");
             }

             if (Request.RawUrl.Contains("/upcoming"))
             {
                 Context.RewritePath("~/roompages/upcomingfeatures.aspx");
             }
             if (Request.RawUrl.Contains("/notification"))
             {
                 Context.RewritePath("~/roompages/notificationtouser.aspx");
             }

             if (Request.RawUrl.Contains("/blocklist"))
             {
                 Context.RewritePath("~/roompages/AddToBlockList.aspx");
             } 


            if (main_path.IndexOf("/publicusers/") >= 0)
            {

                String[] txt = Regex.Split(HttpContext.Current.Request.Url.ToString(), @"/");
                String page = txt[txt.Length - 1];
                //string[] idstr = Regex.Split(page.ToString(), "/");
                //string id = idstr[idstr.Length - 1];

                Context.RewritePath(String.Concat("~/userpublicroom.aspx?rmid=", page), false);

            } 
            if (main_path.IndexOf("/editprofile/") >= 0)
            {

                String[] txt = Regex.Split(HttpContext.Current.Request.Url.ToString(), @"/");
                String page = txt[txt.Length - 1];
                //string[] idstr = Regex.Split(page.ToString(), "/");
                //string id = idstr[idstr.Length - 1];

                Context.RewritePath(String.Concat("~/profilealter.aspx?id=", page), false);

            } 
            if (main_path.IndexOf("/editprofiledetail/") >= 0)
            {

                String[] txt = Regex.Split(HttpContext.Current.Request.Url.ToString(), @"/");
                String id = txt[txt.Length - 2];
                 
                String ismultiple = txt[txt.Length - 1];
                

                Context.RewritePath(String.Concat("~/profilealterdetail.aspx?id=", id,"&ism=",ismultiple), false);

            }
            if (main_path.IndexOf("/myaccout/") >= 0)
            {

                String[] txt = Regex.Split(HttpContext.Current.Request.Url.ToString(), @"/");
                String page = txt[txt.Length - 1];
            

                Context.RewritePath(String.Concat("~/setting.aspx?id=", page), false);

            } 
             


            
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError().GetBaseException();

            // Handle HTTP errors
            if (ex.GetType() == typeof(HttpException))
            {

                if (ex.Message.Contains("NoCatch") || ex.Message.Contains("maxUrlLength"))
                    return;

                Server.Transfer("~/issue.aspx?id=oops", true);
            }

            // string ErrorMsg = "<b>Exception Details: </b> " + ex.GetType().FullName.ToString() + " &nbsp;&nbsp;&nbsp;" + ex.Message.ToString() + "<br> ";

            // StarM.ExceptionSend(StarExtension.GetUserID, ErrorMsg, Request.RawUrl.ToString(), Request.UserHostAddress);


            Server.ClearError();

            Server.Transfer("~/issue.aspx?id=oops", true);
        }

        protected void Session_End(object sender, EventArgs e)
        { 
            try
            { 
                if (Session["user_id"] != null)
                {
                    Datastar objStar = new Datastar(); 
                    string Entry = "update star_user set user_online=0 where user_id=" + Session["user_id"].ToString();
                    objStar.ExecuteSql(Entry);
                    Session["mail_id"] = "";
                    Session["username"] = "";
                    Session["user_id"] = "";
                    Session.Abandon();
                }
                else
                {
                    Response.Redirect("~/login");
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/login");
            }


        }

        protected void Application_End(object sender, EventArgs e)
        {
            //Application.Lock();
            //Application["OnlineUsers"] = (int)Application["OnlineUsers"] - 1;
            //Application.UnLock();
        }
    }
}