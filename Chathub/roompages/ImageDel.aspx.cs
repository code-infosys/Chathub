using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using StarMethods;
using System.Drawing;
namespace Chathub.roompages
{
    public partial class ImageDel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

            }

        }

        private void NewMethod(int skip,int take)
        {
            string path = Server.MapPath("~/starimg/");

            DirectoryInfo di = new DirectoryInfo(path);
           
            FileInfo[] Images = di.GetFiles("*.*");
            rlejre.DataSource = Images.Take(take).Skip(skip);
            rlejre.DataBind();
            //GridView1.DataSource = Images.Take(take).Skip(skip);
            //GridView1.DataBind();
        }

        protected void rlejre_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (Session["username"].ToString() == "ravi")
            {
                if (e.CommandName == "delimg")
                {
                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/starimg/"));
                    FileInfo[] files = dir.GetFiles(e.CommandArgument.ToString());

                    foreach (FileInfo info in files)
                    {
                        info.Delete();
                    }

                }
                NewMethod(txtskip.Text.ConvertToInt32(), txttake.Text.ConvertToInt32());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            NewMethod(txtskip.Text.ConvertToInt32(),txttake.Text.ConvertToInt32());
        }

        
    }
}