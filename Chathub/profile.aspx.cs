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
    public partial class profile : System.Web.UI.Page
    {
        Datastar objStar = new Datastar();
        validData valid = new validData();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["uid"] != null)
                {
                    bindInfoOfUser(Request.QueryString["uid"]);
                }
                else
                {
                    bindInfoOfUser(StarExtension.GetUserID.ToString());
                }
                bindseo();
            }

        }

        private void bindseo()
        {

            Page.Title = "Chathub.in My Profile";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "chathub.in My Profile, view all profile attributes and also you can change it";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = "My Profile, My Photos, chathub.in,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features ,login ,sign up ,online users list";
            Page.Header.Controls.Add(keywords1);

        }

        private void bindInfoOfUser(string UID)
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






                //litProfileCompe BEGIN
                DataSet ds = new DataSet();
                ds = objStar.getDataSet("select COUNT(id) as FID from  star_ProfileAttributes  select COUNT(id) AS SECID from star_Profile where user_id=" + StarExtension.GetUserID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int valAll = Convert.ToInt32(ds.Tables[0].Rows[0]["FID"].ToString());
                    int valSec = Convert.ToInt32(ds.Tables[1].Rows[0]["SECID"].ToString());
                    decimal val = ((valSec * 100) / valAll);
                    // decimal val=  valSec / valAll * 100;

                    string strproc = string.Empty;
                    strproc += "<div>  <strong class='label'> Profile Completeness</strong> <span class=\"pull-right\">" + val + "%</span>";
                    strproc += "<div class=\"progress progress-striped active\">";
                    strproc += "<div class=\"bar\" style=\"width: " + val + "%;\"></div></div>";
                   
                    strproc += "</div>";
                    




                    litProfileCompe.Text = strproc;



                }

                //

                dt = new DataTable();
                dt = objStar.getDataTable(@"select s.username ,(s.user_id+20) as user_id ,s.img_name,s.sex
                                          ,s.mail_id,s.crtd_date,s.dob,(select country_name from country where country_id=s.country) as country,
                                            s.profile_visit from star_user s where  s.active='A' and s.user_id=" + UID);
                if (dt.Rows.Count > 0)
                {
                    litUsername.Text = dt.Rows[0]["username"].ToString();



                    litProfileVisit.Text = dt.Rows[0]["profile_visit"].ToString().Length > 0 ? dt.Rows[0]["profile_visit"].ToString() : "0";

                    //litBasicInfo.Text = "<table><tr> <td><b>   </b> </td> <td>  </td></tr></table>";
                }



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}