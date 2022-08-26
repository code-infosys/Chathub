using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Chathub.roompages
{
    public partial class whoisinsideroom : System.Web.UI.Page
    {
        Datastar objStar = new Datastar();
        validData valid = new validData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                if (!IsPostBack)
                {
                    bindseo();
                }
            }
            else
            {
                Response.Redirect("~/login");
            }
        }


        private void bindseo()
        {

            Page.Title = "Welcome to Chathub.in Submit Suggestion";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "Sonustar Creation , hi friends welcome to sonustar world ,by using my these website chathub.in you can make your new friends on world-wide  and also communicate with them ";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = "suggestion,suggestion box,chathub.in,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features ,login ,sign up";
            Page.Header.Controls.Add(keywords1);

        }



        protected void btnsug_Click(object sender, EventArgs e)
        {
            if (txtsuggestion.Text.Length > 0 && txtsuggestion.Text.Length <400)
            {
                int uid = StarExtension.GetUserID > 0 ? StarExtension.GetUserID : 0;
                string sql_seen = "insert into star_suggestionsBox (msg,user_id,ip) values(N'" + valid.ValidateData(txtsuggestion.Text) + "'," + uid + ",'" + Request.UserHostAddress + "')";
                objStar.ExecuteSql(sql_seen);
                btnsug.Text = "Sent Successfully";
                btnsug.Enabled = false;
                txtsuggestion.Text = "";

            }
            else
            {
                txtsuggestion.Attributes.Add("style", "border:1px solid red");
            }
        }
    }
}