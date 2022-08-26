using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chathub.roompages
{
    public partial class notificationtouser : System.Web.UI.Page
    {
        Datastar objStar = new Datastar();
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        protected void ListviewNoti_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "btnok")
                {
                    string sql_seen = "update AdminStar_Notification set seen=1 where id=" + id;
                    objStar.ExecuteSql(sql_seen);
                }
                ListviewNoti.DataBind();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        
    }
}