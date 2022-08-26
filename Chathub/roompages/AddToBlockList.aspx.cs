using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Chathub.roompages
{
    public partial class AddToBlockList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        private void bindseo()
        {

            Page.Title = "Chathub.in User Block List";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "chathub.in block user, there you can block to any user";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = "chathub block list, user block list,Search ,Search User, chathub.in,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features ,login ,sign up ,online users list";
            Page.Header.Controls.Add(keywords1);

        }





        DataTable dt = new DataTable();
        Datastar objStar = new Datastar();
        private void countChat(string srch)
        {

            string rptBind = string.Empty;
            string rpt_sql = "select username,(su.user_id) as user_id,img_name,sex from star_user su   where  active='A' and (IsDeleted is null or IsDeleted=0) and su.user_id !=" + StarExtension.GetUserID + " and su.user_id not in(select BlockToUser_id from star_blockList bl where bl.user_id=" + StarExtension.GetUserID + ")  and su.username like '%" + srch + "%' order by crtd_date desc";

            dt = objStar.getDataTable(rpt_sql);
            if (dt.Rows.Count > 0)
            {
                ListViewChatFrnd.DataSource = dt;
                ListViewChatFrnd.DataBind();
                Litmsgerr.Text = "";
            }
            else { Litmsgerr.Text = "! No result Found"; }
            dt.Dispose();

            //rebinding

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

        protected void ListViewChatFrnd_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Blokuser")
                {
                    decimal userid = Convert.ToDecimal(e.CommandArgument);

                    string Entry = "insert into star_blockList (user_id,BlockToUser_id,DateAdded) values("+StarExtension.GetUserID+","+userid+",getdate())";
                    objStar.ExecuteSql(Entry);

                    Response.Redirect(Request.RawUrl.ToString());

                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "btnUnblock")
                {
                    Int64 idd = Convert.ToInt64(e.CommandArgument);

                    objStar.ExecuteSql("delete from star_blockList where id="+idd);
                    Response.Redirect(Request.RawUrl.ToString());
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