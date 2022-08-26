using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Chathub.roompages
{
    public partial class profileviewer : System.Web.UI.Page
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

            Page.Title = "Chathub.in Your Profile Visitors List";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "Sonustar Creation , hi friends welcome to sonustar world ,by using my these website chathub.in you can make your new friends on world-wide  and also communicate with them ";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = "Profile visitor list,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features ,login ,sign up";
            Page.Header.Controls.Add(keywords1);

        }
    }
}