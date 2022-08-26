using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
namespace Chathub
{
    public partial class frequest : System.Web.UI.Page
    {
        DataTable dt;
        Datastar objStar = new Datastar();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindseo();
            }
        }
        private void bindseo()
        {
            Page.Title = "Chathub.in friends requests";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "Chathub.in there if you have come any friend request you can accept or reject them";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = "chathub.in,chathub,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls ,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,friends request";
            Page.Header.Controls.Add(keywords1);
        }

        protected void ListViewFriendReq_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                LinkButton lbtnA = (LinkButton)e.Item.FindControl("lbtnA");
                LinkButton lbtnR = (LinkButton)e.Item.FindControl("lbtnR");
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "lbtnApprove")
                {
                    string sql = "update star_frnd_list set request='A',lst_mod_date=GETDATE(),mod_by=" + StarExtension.GetUserID + " where id="+id+" and request='R'";
                    int r = objStar.ExecuteSql(sql);
                    if (r > 0)
                    {
                        lbtnA.Text = "Approved";
                        lbtnA.Enabled = false;
                        lbtnR.Enabled = false;
                    }
                }
                if (e.CommandName == "lbtnReject")
                {

                    string sql = "update star_frnd_list set request='F',lst_mod_date=GETDATE(),mod_by=" + StarExtension.GetUserID + " where id=" + id + " and request='R'";
                    int r = objStar.ExecuteSql(sql);
                    if (r > 0)
                    {
                        lbtnR.Text = "Rejected";
                        lbtnA.Enabled = false;
                        lbtnR.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        
    }
}