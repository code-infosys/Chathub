using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace Chathub.roompages
{
    public partial class imageDeleter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
            if (!Page.IsPostBack)
            {
                bindImages();
            }
        }

        private void bindImages()
        {
            try
            {
                DataTable dt = new DataTable();
                Methodsall m = new Methodsall();
                dt = m.GetAdminStar_ImageDelete();
                if (dt.Rows.Count > 0)
                {
                    rptImages.DataSource = dt;
                    rptImages.DataBind();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        //protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        //{

        //    CheckBox chk1 = (CheckBox)girdImages.HeaderRow.FindControl("chkSelectAll");

        //    int s = girdImages.Rows.Count;
        //    CheckBox chk2;
        //    if (chk1.Checked == true)
        //    {
        //        for (int i = 0; i < s; i++)
        //        {
        //            chk2 = (CheckBox)girdImages.Rows[i].Cells[0].FindControl("chkDelete");
        //            chk2.Checked = true;
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < s; i++)
        //        {
        //            chk2 = (CheckBox)girdImages.Rows[i].Cells[0].FindControl("chkDelete");
        //            chk2.Checked = false;
        //        }
        //    }

      
        //}
         
        Datastar objStar = new Datastar();

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text.ToString() == "waptop")
                {

                    int s = rptImages.Items.Count;
                    int r = 0;

                    for (int i = 0; i < s; i++)
                    {

                        HiddenField hideID = (HiddenField)rptImages.Items[i].FindControl("hideID");
                        HiddenField HideImage = (HiddenField)rptImages.Items[i].FindControl("HideImage");
                        HiddenField hideUserid = (HiddenField)rptImages.Items[i].FindControl("hideUserid");

                            //update here first
                            string sql_seen = "update AdminStar_ImageDelete set IsDeleted=1 where id=" + hideID.Value;
                            objStar.ExecuteSql(sql_seen);

                            objStar.ExecuteSql("update star_images set IsActive=0 where img_name='" + HideImage.Value + "' and user_id=" + hideUserid.Value); 

                            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/starimg/"));
                            FileInfo[] files = dir.GetFiles(HideImage.Value);

                            foreach (FileInfo info in files)
                            {
                                info.Delete();
                            }

                            r = 1;
                         

                    }
                    if (r > 0)
                    {
                        Response.Write("<script>alert('Deleted..')</script>");
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