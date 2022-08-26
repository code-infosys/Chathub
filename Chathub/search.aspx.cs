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
    public partial class search : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["search"] != null)
                {
                    txtMainSearch.Text = Session["search"].ToString();
                    countChat(Session["search"].ToString());
                    Session["search"] = "";
                    Session["search"] = null;
                }
                bindseo();
            }
        }


        private void bindseo()
        {

            Page.Title = "Chathub.in Search User";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "chathub.in search user , advance search , there you can search to any user using his/her email address and username";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = "Search ,Search User, chathub.in,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features ,login ,sign up ,online users list";
            Page.Header.Controls.Add(keywords1);

        }

         



        DataTable dt = new DataTable();
        Datastar objStar = new Datastar();
        private void countChat(string srch)
        { 
            string rptBind = string.Empty;
            string rpt_sql = "select username,(user_id) as user_id,img_name,sex from star_user where  active='A' and (IsDeleted is null or IsDeleted=0) and user_id !=" + StarExtension.GetUserID + " and  user_id not in(select bl.user_id from star_blockList bl where bl.BlockToUser_id=" + StarExtension.GetUserID + ") and username like '%" + srch + "%' order by crtd_date desc";
           
            dt = objStar.getDataTable(rpt_sql);
            if (dt.Rows.Count > 0)
            {
                ListViewChatFrnd.DataSource = dt;
                ListViewChatFrnd.DataBind();
                Litmsgerr.Text = "";
            }
            else { Litmsgerr.Text = "! No result Found"; }
            dt.Dispose();
             
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMainSearch.Text.Length > 0)
            {
                countChat(txtMainSearch.Text.ToString());
            }
            else
            {
                txtMainSearch.Attributes.Add("style", "border:1px solid red");
            }
        }

        protected void ListViewChatFrnd_PagePropertiesChanged(object sender, EventArgs e)
        {
            countChat(txtMainSearch.Text.ToString());
        }
    }
}