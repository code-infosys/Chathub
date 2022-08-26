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
    public partial class listfriends : System.Web.UI.Page
    {
        Datastar objStar = new Datastar();
        validData valid = new validData();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["uid"] != null)
            {
                if (!IsPostBack)
                {

                    String[] txt = Request.QueryString["uid"].ToString().Split(Convert.ToChar("="));
                    string star = txt[txt.Length - 1];
                    Int64 r = Convert.ToInt64(star);


                    if (r == StarExtension.GetUserID)
                    {
                        pnlCloseoverallBlocklist.Visible = false;
                        lblblocklistmsg.Text = "! You have no access view own self on this page";
                        lblblocklistmsg.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {



                        //block list checking
                        DataTable dtbl = new DataTable();
                        dtbl = objStar.getDataTable("select user_id from star_user where user_id=" + r + " and  user_id not in(select bl.user_id from star_blockList bl where bl.BlockToUser_id=" + StarExtension.GetUserID + ")");
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
                    }
                    //



                    bindseo(r);

                }

            }
            else
            {
                bindseo(StarExtension.GetUserID);
            }

        }

        private void bindseo(Int64 user)
        {


            Methodsall m = new Methodsall();
            DataTable dt = new DataTable();
            dt = m.GetOtherUserInfoByID(user);
            if (dt.Rows.Count > 0)
            {
                this.Page.Title = "Chathub.in friends list Of " + dt.Rows[0]["username"].ToString() + "";
                litname.Text = dt.Rows[0]["username"].ToString();
                HtmlMeta description1 = new HtmlMeta();
                description1.Name = "description";
                description1.Content = "chathub.in there you can view all friends list of any user";
                Page.Header.Controls.Add(description1);

                HtmlMeta keywords1 = new HtmlMeta();
                keywords1.Name = "keywords";
                keywords1.Content = "friends list ,friends ,chathub,sonu,sonustar,chathub.in, profile info";
                Page.Header.Controls.Add(keywords1);
            }
        }
         
    }
}