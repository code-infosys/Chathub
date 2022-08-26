using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI.HtmlControls;
namespace Chathub.roompages
{
    public partial class postDetails : System.Web.UI.Page
    {
        Datastar objStar = new Datastar();
        validData valid = new validData();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["pwap"] != null)
                {
                    bindInfoOfUserPostData(Request.QueryString["pwap"]);
                    bindComments(Request.QueryString["pwap"]);
                }
                  
            }

        }

        private void bindInfoOfUserPostData(string p)
        {
            try
            {
                Methodsall m = new Methodsall();

                DataSet ds = new DataSet();
                ds = m.SelectPostDetail(Convert.ToInt64(p));

                StringBuilder sb = new StringBuilder();
                string male = "male.jpg";
                string female = "female.jpg";
                sb.Append("");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sb.Append("<div class=\"postouter\"> <table class=\"psttables\"><tr> <td> ");
                    
                    if(ds.Tables[0].Rows[0]["userimg"].ToString().Length > 3)
                    {
                        female = ds.Tables[0].Rows[0]["userimg"].ToString();
                        male = ds.Tables[0].Rows[0]["userimg"].ToString();
                    }

                    if (ds.Tables[0].Rows[0]["sex"].ToString() == "Male")
                    {
                        sb.Append(" <img src=\" " + Page.ResolveUrl("~/starimg/" + male + "") + "\" style=\"width: 40px; border: 1px solid; padding: 3px;\" /> ");

                    }
                    else
                    {
                        sb.Append(" <img src=\" " + Page.ResolveUrl("~/starimg/" + female + "") + "\" style=\"width: 40px; border: 1px solid; padding: 3px;\" /> ");

                    }


                    sb.Append(" </td>  <td> <h2> " + ds.Tables[0].Rows[0]["UserName"].ToString() + " </h2> <div class='label label-inverse'> " + objStar.TimeAgo(Convert.ToDateTime(ds.Tables[0].Rows[0]["dateAdded"])) + "   </div> </td>");
                    sb.Append(" </tr> </table><blockquote>  <div> ");
                    if (ds.Tables[0].Rows[0]["postimg"].ToString().Length > 3)
                    {
                        sb.Append(" <img style='width:35%;' src=\"" + Page.ResolveUrl("~/starimg/" + ds.Tables[0].Rows[0]["postimg"].ToString() + "") + "\" />  ");
                    }
                    sb.Append(" <br /> <div style=\"font-family:Verdana;font-size:15px; text-transform:capitalize;\">" + ds.Tables[0].Rows[0]["postdetail"].ToString() + "</div>  ");
                    sb.Append("  <div style=\"clear: both;\"></div> </div> </blockquote>  <div style=\"clear: both;\"></div>");
                    sb.Append("</div>");


                    litLikeCountStar.Text = ds.Tables[0].Rows[0]["likeCount"].ToString();
                    litPostVisitCount.Text = "<span class='badge badge-warning'>Post Visit(" + ds.Tables[0].Rows[0]["PostVisitCount"].ToString() + ")</span>";

                    bindseo(ds.Tables[0].Rows[0]["postdetail"].ToString());
                }


                litBidPostDetailData.Text = sb.ToString();

                if (ds.Tables[3].Rows.Count > 0)
                {
                    lbtnLikeStar.Text = "Unlike Star";
                }
                else
                {
                    lbtnLikeStar.Text = "Like Star";
                }



            }
            catch (Exception)
            {

                throw;
            }
        }

        private void bindComments(string p)
        {
             Methodsall m = new Methodsall();

                DataSet ds = new DataSet();
                ds = m.SelectPostDetail(Convert.ToInt64(p));
             
                if (ds.Tables[0].Rows.Count > 0)
                {
                    listComments.DataSource = ds.Tables[2];
                    listComments.DataBind();
                }

            
        }


        private void bindseo(string detail)
        {

            Page.Title = "Chathub.in: Post Detail";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "chathub.in wall detail: " + detail + " ";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = "chathub.in, chathub wall post detail, my wall, submit your post";
            Page.Header.Controls.Add(keywords1);

        }


        protected void lbtnLikeStar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["pwap"] != null)
                {
                    Int64 val = 0;
                    try
                    {
                        val = Convert.ToInt64(Request.QueryString["pwap"]);

                        Methodsall m = new Methodsall();
                        m.InsertPostLikeCount(val);
 
                        bindInfoOfUserPostData(val.ToString());
                   

                        
                    }
                    catch (Exception)
                    {
                         
                    }

                   
                }
            }
            catch (Exception)
            {
                
                throw;
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

        protected void btnPostcomment_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["pwap"] != null)
                {
                    Int64 val = 0;
                    try
                    {
                        val = Convert.ToInt64(Request.QueryString["pwap"]);

                        Methodsall m = new Methodsall();

                             Int64 r = 0;
                             if (txtcomment.Text.Length > 0)
                             {
                                 r = m.InsertCommentOnPost(val, valid.ValidateData(txtcomment.Text), "");
                                 if (r > 0)
                                 {
                                     txtcomment.Text = "";
                                     bindInfoOfUserPostData(val.ToString());
                                     bindComments(val.ToString());
                                    
                                 }
                             }
                             else
                             {
                                 txtcomment.Attributes.Add("style", "border:1px solid red");
                             }

                        
                    }
                    catch (Exception)
                    {
                         
                    }

                   
                }

                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void listComments_PagePropertiesChanged(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["pwap"] != null)
                {

                    bindComments(Request.QueryString["pwap"]);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}