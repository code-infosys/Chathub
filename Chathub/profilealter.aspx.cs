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
    public partial class profilealter : System.Web.UI.Page
    { 
        Datastar objStar = new Datastar();
        validData valid = new validData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer.ToString().Contains("editprofiledetail"))
            { 
                lblMsg.Text = "Updated Profile Successfully.";
            }

            if (!Page.IsPostBack)
            {
                bindseo();
            }
        }
        private void bindseo()
        {

            Page.Title = "Chathub.in My Profile Edit Properity";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "chathub.in My Profile, view all profile attributes and also you can change it";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = "My Profile Edit Properity , My Photos, chathub.in,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features ,login ,sign up ,online users list";
            Page.Header.Controls.Add(keywords1);

        }
        protected void rptAttributes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
             
        }
    }
}