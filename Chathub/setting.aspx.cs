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
    public partial class setting : System.Web.UI.Page
    {
        Datastar objStar = new Datastar();
        validData valid = new validData();
        DataTable dtt;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] != null)
            {
                string val = Request.QueryString["id"].ToString().Trim();
                if (val == "ac")
                {
                    pnlaccountset.Visible = true;
                }
                else if (val == "pho")
                {
                    pnlmanagePhoto.Visible = true;
                }
                else if (val == "pw")
                {
                    pnlManPassword.Visible = true;
                }
                else if (val == "deactive")
                {
                    pnldeactive.Visible = true;
                    
                }
                else
                {
                    litMsg.Text = "Pange ni Lene Oye Url Nall";
                }

            }
            else
            {
                litMsg.Text = "Kuj ni Hega";
            }
            if (!Page.IsPostBack)
            {

                 bindcountry();
                fillform();
                loadUserImage();
                bindacde();
                bindseo();
            }



        }

        private void bindseo()
        {

            Page.Title = "Chathub.in My Account Setting";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "chathub.in My Account Setting, you can change profile picture , deactive account, some other account settings , country, security question";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = "My Account Setting, Privacy Setting, chathub.in,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features ,login ,sign up ,online users list";
            Page.Header.Controls.Add(keywords1);

        }


        private void bindacde()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(" select * from star_user where IsDeleted=1 and active='D' and user_id="+StarExtension.GetUserID);
                if (dt.Rows.Count > 0)
                {
                    btnDeactive.Visible = false;
                    btnActive.Visible = true;
                }
            }
            catch (Exception)
            {
                 
            }
        }

        private void loadUserImage()
        {
            try
            {

                string sqlUserimg = "select img_name,sex from star_user where user_id=" + StarExtension.GetUserID + "";
                DataTable dt_imgUser = new DataTable();
                dt_imgUser = objStar.getDataTable(sqlUserimg);
                string sexx = dt_imgUser.Rows[0]["sex"].ToString();
                string img_name = string.Empty;
                if (dt_imgUser.Rows.Count > 0)
                {
                    img_name = dt_imgUser.Rows[0]["img_name"].ToString();
                    if (img_name.Length > 2)
                    {
                        litimg.Text = "<div style='padding:5px; border:1px solid; width:200px;'> <img src='../" + objStar.getImage(img_name) + "' style='width:200px'/> </div>";
                    }
                    else { litimg.Text = ""; }
                }


                dt_imgUser.Dispose();
            }
            catch (Exception)
            {
                 
            }
        }

        private void bindcountry()
        {
            string sql_con = "select '0' as country_id,'Select' as country_name union select country_id,country_name from country where approve='A'";
            dtt = objStar.getDataTable(sql_con); 
            ddlCountry.DataSource = dtt;
            ddlCountry.DataBind();
        }

        private void fillform()
        {
            string sql = "select user_id,username,sec_answer, country from star_user where user_id=" + StarExtension.GetUserID + "";
            dtt = new DataTable();
            dtt = objStar.getDataTable(sql);
            if (dtt.Rows.Count > 0)
            {
                txtusername.Text = dtt.Rows[0]["username"].ToString();
                txtsecAns.Text = dtt.Rows[0]["sec_answer"].ToString();
                //ddlCountry.SelectedValue = dtt.Rows[0]["country"].ToString();
            }

        }


        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {

                string username = valid.ValidateData(txtusername.Text.ToString());

                string secQ = valid.ValidateData(ddlSecurityQ.SelectedItem.Text.ToString());
                string secAns = valid.ValidateData(txtsecAns.Text.ToString());

                string country = valid.ValidateData(ddlCountry.SelectedValue);
                string img_name = string.Empty;

                string sql_up = "update star_user set  sec_question='" + secQ + "',sec_answer='" + secAns + "', country='" + country + "',mod_date=GETDATE() where user_id=" + StarExtension.GetUserID + "";

                int insert = objStar.ExecuteSql(sql_up);
                if (insert > 0)
                {
                    btnSignUp.Text = "Done";
                    btnSignUp.Enabled = false;
                    lblmsgchange.Text = "Your Account Settings Updated Successfully";
                    bindcountry();
                }
            }

            catch (Exception ex)
            {
               
            }


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
                            int audilockid = Convert.ToInt32(ddlAudi.SelectedItem.Value);
                            sql_postit = "update star_user set img_name='" + imgpath + "',mod_date=GETDATE(),ProfilePicAudienceLockID=" + audilockid + " where user_id=" + StarExtension.GetUserID + "";
                            int ad = objStar.ExecuteSql(sql_postit);
                            if (ad > 0)
                            {
                                lblPhotomsg.Text = "Your Image Successfully Uploaded";
                                lblPhotomsg.ForeColor = System.Drawing.Color.Green;
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
            pnlaccountset.Visible = false;

            pnlmanagePhoto.Visible = true;

            pnlManPassword.Visible = false;
            loadUserImage();

        }
        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text.Length > 0 && txtNewPassword.Text.Length > 0 && txtConfirmPassword.Text.Length > 0)
                {
                    Int64 user = 0;

                    user = objStar.ChangePasswordUser(valid.ValidateData(txtPassword.Text), valid.ValidateData(txtConfirmPassword.Text.Trim()), "settingSelectPw");
                    if (user > 0)
                    {
                        lblm.Text = "Successfully Changed";
                        lblm.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblm.Text = "Old Password Incorrect";
                         lblm.ForeColor = System.Drawing.Color.Red;
                    }
                    //string sql = "select user_id,emstars, unstars,CONVERT (VARCHAR(100),DECRYPTBYKEY(pwstarsnew)) as password from star_unpwgonext where user_id=" + StarExtension.GetUserID + "";
                    //dtt = new DataTable();
                    //dtt = objStar.getDataTable(sql);
                    //if (dtt.Rows.Count > 0)
                    //{
                    //    if (txtPassword.Text.ToString().Trim() == dtt.Rows[0]["password"].ToString().Trim())
                    //    {
                    //        string sqlup = "update star_user set password='" + txtConfirmPassword.Text + "',mod_date=GETDATE() where user_id=" + StarExtension.GetUserID + "";
                    //        int ad = objStar.ExecuteSql(sqlup);
                    //        if (ad > 0)
                    //        {
                    //            lblm.Text = "Successfully Changed";
                    //            lblm.ForeColor = System.Drawing.Color.Green;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        lblm.Text = "Old Password Incorrect";
                    //        lblm.ForeColor = System.Drawing.Color.Red;
                    //    }
                    //}



                }
                else
                {
                    txtPassword.Attributes.Add("style", "border:1px solid red;");
                    txtNewPassword.Attributes.Add("style", "border:1px solid red;");
                    txtConfirmPassword.Attributes.Add("style", "border:1px solid red;");
                }
            }
            catch (Exception)
            {
                 
            }
        }

        protected void btnDeactive_Click(object sender, EventArgs e)
        {
            try
            {

                string sql_up = "update star_user set IsDeleted=1 , active='D',DeleteReason='" + valid.ValidateData(txtReasion.Text) + "' ,mod_date=GETDATE() where user_id=" + StarExtension.GetUserID + "";

                int insert = objStar.ExecuteSql(sql_up);
                btnDeactive.Enabled = false;
                lblmsgDeactive.Text = "Deactive Successfully..";
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception)
            {
                 
            }
        }

        protected void btnActive_Click(object sender, EventArgs e)
        {
            try
            { 
                string sql_up = "update star_user set IsDeleted=0 , active='A',mod_date=GETDATE() where user_id=" + StarExtension.GetUserID + "";

                int insert = objStar.ExecuteSql(sql_up);
                btnActive.Enabled = false;
                lblmsgDeactive.Text = "Active Successfully..";
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception)
            {
                 
            }
        }
    }
}