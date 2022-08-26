using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Chathub
{
    public partial class photos : System.Web.UI.Page
    {

        Datastar objStar = new Datastar();
        validData valid = new validData();
        DataTable dtt;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindseo();
            }
        }
        private void bindseo()
        {

            Page.Title = "Chathub.in My Photos List";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "chathub.in My Photos List, my wallpapers ,profile pictures list";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = "My Photos, chathub.in,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features ,login ,sign up ,online users list";
            Page.Header.Controls.Add(keywords1);

        }

        protected void btnImageUpload_Click(object sender, EventArgs e)
        {
            string imgpath = string.Empty;
            string sql_postit = string.Empty;
            if (fuImgPost.HasFile == true)
            { 
                try
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


                            sql_postit = "insert into star_images (img_name,user_id,DateAdded,IsActive,AudienceLockID) values('" + imgpath + "'," + StarExtension.GetUserID + ",GETDATE(),1," + ddlAudi.SelectedItem.Value + ")";
                            int ad = objStar.ExecuteSql(sql_postit);

                            //sql_postit = "update star_user set img_name='" + imgpath + "',mod_date=GETDATE() where user_id=" + StarExtension.GetUserID + "";
                            //int ad = objStar.ExecuteSql(sql_postit);
                            if (ad > 0)
                            {
                                lblPhotomsg.Text = "Your Image Successfully Uploaded";
                                lblPhotomsg.ForeColor = System.Drawing.Color.Green;

                                ListView1.DataBind();
                            }
                        }
                    }
                    else
                    {
                        lblPhotomsg.Text = "Please Use a Image Size Less then 1Mb";
                    }
                }
                catch (Exception er)
                {
                    lblPhotomsg.Text = "Please Use a Image Size Less then 1Mb";
                }
            }
            else
            {
                lblPhotomsg.Text = "First Select Your Image";
            }
            

        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "UpdateImag")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    DropDownList ddlAudiLv = (DropDownList)e.Item.FindControl("ddlAudiLv");

                    string sql_seen = "update star_images set  AudienceLockID="+ddlAudiLv.SelectedValue+" where id=" + id;
                    objStar.ExecuteSql(sql_seen);

                    ListView1.DataBind();
                }
                if (e.CommandName == "Deleimg")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    HiddenField HideImage = (HiddenField)e.Item.FindControl("hideimg");
                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/starimg/"));
                    FileInfo[] files = dir.GetFiles(HideImage.Value);

                    foreach (FileInfo info in files)
                    {
                        info.Delete();
                    }

                    string sql_seen = "delete from star_images where id=" + id;
                    objStar.ExecuteSql(sql_seen);

                    ListView1.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}