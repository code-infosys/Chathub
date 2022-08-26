using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Chathub
{
    public partial class tour : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                bindseo();
            }
        }
        private void bindseo()
        {

            Page.Title = "Chathub.in Take a tour";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "chathub.in there we provide to you what is in this website all features or options ,UI";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = " Take a tour , chathub.in,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features ,login ,sign up ,online users list";
            Page.Header.Controls.Add(keywords1);

        }
    }
}