using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Chathub
{
    public partial class msgN : System.Web.UI.Page
    {
        Datastar objStar = new Datastar();
        validData valid = new validData();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { 
                if (Request.QueryString["chat_id"] != null)
                {
                    if (Session["user_id"] != null)
                    {
                        //if (!Page.IsPostBack)
                        //{
                            //PublicChat(Request.QueryString["rmid"]);

                           
                        bindHideAjaxDetail();


                         bindseo();

                         fastchat(Session["user_id"].ToString());
                        //}
                    }
                     
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void fastchat(string r)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objStar.getDataTable("select user_id from AdminStar_ApplicationUser where user_id=" + r + " and IsActive=1");
                if (dt.Rows.Count > 0)
                { 
                    string script = "<script type=\"text/javascript\">  window.setInterval(\"refreshDiv()\", 1000);  function refreshDiv() {  GetNameStar(); } </script>";
                    Literal cssLiteral2 = new Literal();
                    cssLiteral2.Text = script;
                    Page.Header.Controls.Add(cssLiteral2);
                }
                else
                {
                    
                }

            }
            catch (Exception)
            { 

            }
        }

        private void bindHideAjaxDetail()
        {
             litIdWraper.Text = " <div id=\"hideid\" style=\"display:none;\">" + StarExtension.GetUserID + "</div>";
             
            hideSelect.Value = "{'Userid': '" + StarExtension.GetUserID + "','frndUserid': " + Request.QueryString["chat_id"] + ",'COUNTVAL': '" + txthide.Value + "'}";
            //Int64 userid, string user_name,Int64 friends_id,string Chatdesc,string IP,string imagename
            hideInsert.Value = "{'userid': '" + StarExtension.GetUserID + "','user_name': '" + Session["username"].ToString() + "','friends_id': '" + Request.QueryString["chat_id"] + "','Chatdesc': '\" + msg.value + \"','IP': '" + Request.UserHostAddress + "','imagename': ''}";

            hideUserid.Value = "{'Userid': '" + StarExtension.GetUserID + "','top': 10}";
        }


        protected void lbtnPrevious_Click(object sender, EventArgs e)
        {
            int countf = int.Parse(txthide.Value.ToString());
            txthide.Value = (countf + 3).ToString();
            //litIdWraper.Text = "<div id=\"hidef\" style=\"display:block;\">" + Request.QueryString["chat_id"] + "</div> <div id=\"hideid\" style=\"display:block;\">" + StarExtension.GetUserID + "</div> <div id=\"hideCount\" style=\"display:block;\">" + (countf + 3).ToString() + "</div>";
            bindHideAjaxDetail();
        }




        private void bindseo()
        {

            string star = Request.QueryString["chat_id"].ToString();

            try
            {

                if (Convert.ToInt64(star) == StarExtension.GetUserID)
                {
                    pnlCloseoverallBlocklist.Visible = false;
                    lblblocklistmsg.Text = "! You have no access view own self on this page";
                    lblblocklistmsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    //block list checking
                    DataTable dtbl = new DataTable();
                    dtbl = objStar.getDataTable("select user_id from star_user where user_id=" + star + " and  user_id not in(select bl.user_id from star_blockList bl where bl.BlockToUser_id=" + StarExtension.GetUserID + ")");
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
                    //
                }

                int getFrnd_id = Convert.ToInt32(star);

                Methodsall m = new Methodsall();
                DataTable dt = new DataTable();
                dt = m.GetOtherUserInfoByID(getFrnd_id);
                if (dt.Rows.Count > 0)
                {
                    this.Page.Title = "" + dt.Rows[0]["username"].ToString() + " - Messages ";
                    litNameofuser.Text = dt.Rows[0]["username"].ToString();

                    HtmlMeta description1 = new HtmlMeta();
                    description1.Name = "description";
                    description1.Content = "Sonustar Creation Messages ,chat with friend";
                    Page.Header.Controls.Add(description1);

                    HtmlMeta keywords1 = new HtmlMeta();
                    keywords1.Name = "keywords";
                    keywords1.Content = "chathub.in,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features ,login ,sign up";
                    Page.Header.Controls.Add(keywords1);
                }
            }
            catch (Exception)
            {
                 
            }

        }

        private static class MsgEnd
        {
            private static string msg;

            public static string Msg
            {
                get { return msg; }
                set { msg = value; }
            }
             
        }

        protected void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["chat_id"] != null)
            {
                Int64 user_id = 0;
                string frnd_id = string.Empty;
                string username = string.Empty;

              
                user_id = StarExtension.GetUserID;
                username = Session["username"].ToString();


                string chatmsg = "See Photo";// valid.ValidateData(txtChatMsg.Text.ToString());
                //23?chat_id=23
                 
                int getFrnd_id = Convert.ToInt32(Request.QueryString["chat_id"]);
                frnd_id = getFrnd_id.ToString();



                if (MsgEnd.Msg == fuImgPost.FileName)
                {
                    //txtChatMsg.Text = "";
                    //txtChatMsg.Focus();
                    //PrivateChat();
                    bindHideAjaxDetail();
                }
                else
                {
                    MsgEnd.Msg = "";

                    StarService s = new StarService();
                    string imgpath = string.Empty;
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


                            Int64 resutl = s.InsertPrivateChating(user_id, username, Convert.ToInt64(frnd_id), chatmsg, Request.UserHostAddress.ToString(), imgpath);
                            //int resutl = objStar.ExecuteSql(sql_inst);
                            if (resutl > 0)
                            {
                                MsgEnd.Msg = fuImgPost.FileName;

                                //txtChatMsg.Text = "";
                                //txtChatMsg.Focus();
                                //PrivateChat();
                                bindHideAjaxDetail();
                                btnUploadPhoto.Focus();

                            }



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
                 
            }
        }

        protected void btnRefreshTop_Click(object sender, EventArgs e)
        {
            bindHideAjaxDetail();
            btnRefreshTop.Focus();
        }

        protected void lbtnRefresh_Click(object sender, EventArgs e)
        {
            bindHideAjaxDetail();
            lbtnRefresh.Focus();
        }

    }
}