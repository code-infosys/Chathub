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
    public partial class profilealterdetail : System.Web.UI.Page
    {
        Datastar objStar = new Datastar();
        validData valid = new validData();

        bool multiuse = false;
        int AttriID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hideurl.Value = Request.UrlReferrer.ToString();

            }

            if (Request.QueryString["ism"] != null && Request.QueryString["id"] !=null)
            {
               

                String[] txtmul = Request.QueryString["ism"].ToString().Split(Convert.ToChar("="));
                String m = txtmul[0];

                String[] txt = Request.QueryString["id"].ToString().Split(Convert.ToChar("="));
                String id = txt[0];

                multiuse = Convert.ToBoolean(m);
                AttriID = Convert.ToInt32(id);
                if (!Page.IsPostBack)
                {
                    BindFullyThinks(Convert.ToInt32(id), Convert.ToBoolean(m));
                    bindseo();
                }
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
       

        private void BindFullyThinks(int AttriDd, bool multiuse)
        {
            try
            {
                

                DataTable dt = new DataTable();
                string AttValueBind = string.Empty;
                dt = objStar.getDataTable(" select id,AttributesValue,AudienceID from star_Profile  where ProfileAttributesID=" + AttriID + " and user_id=" + StarExtension.GetUserID + "");
                if(dt.Rows.Count>0)
                {
                     AttValueBind = dt.Rows[0]["AttributesValue"].ToString(); 

                     ddlAudi.SelectedValue =  dt.Rows[0]["AudienceID"].ToString().Trim();
                }
                if (AttriDd == 1)
                {
                    PngGender.Visible = true;
                }
                else if (AttriID == 2)
                {
                    pnlDOB.Visible = true;
                }
                else if (AttriID == 3)
                {
                    PnlRelationShip.Visible = true;
                }
                else if (AttriID == 4)
                {
                    pnlInterestedIn.Visible = true;
                }
                else if (AttriID == 6)
                {
                    pnlLanguages.Visible = true;
                    txtLanguages.Text = AttValueBind;
                }
                else if (AttriID == 7)
                {
                    pnlPolitical.Visible = true;
                    txtPolitical.Text = AttValueBind;
                }
                else if (AttriID == 8)
                {
                    pnlReligion.Visible = true;
                    txtReligion.Text = AttValueBind;
                }
                else if (AttriID == 12)
                {
                    pnlCompany.Visible = true;
                    txtCompany.Text = AttValueBind;
                }
                else if (AttriID == 13)
                {
                    pnlPosition.Visible = true;
                    txtPosition.Text = AttValueBind;
                }
                else if (AttriID == 9)
                {
                    pnlGradSchool.Visible = true;
                    txtGrad.Text = AttValueBind;
                }
                else if (AttriID == 10)
                {
                    pnlCollege.Visible = true;
                    txtCollege.Text = AttValueBind;
                }
                else if (AttriID == 11)
                {
                    pnlHighSchool.Visible = true;
                    txtHighSchool.Text = AttValueBind;
                }
                else if (AttriID == 14)
                {
                    pnlCurrentcity.Visible = true;
                    txtCurrentcity.Text = AttValueBind;
                }
                else if (AttriID == 15)
                {
                    pnlHometown.Visible = true;
                    txtHometown.Text = AttValueBind;
                }
                else if (AttriID == 18)
                {
                    pnlProfile.Visible = true;
                    txtProfile.Text = AttValueBind;
                }
                else if (AttriID == 19)
                {
                    pnlEmail.Visible = true;
                    txtEmail.Text = AttValueBind;
                }
                else if (AttriID == 20)
                {
                    pnlAIM.Visible = true;
                    txtAIM.Text = AttValueBind;
                }
                else if (AttriID == 21)
                {
                    pnlPhones.Visible = true;
                    txtPhones.Text = AttValueBind;
                }
                else if (AttriID == 22)
                {
                    pnlWebsite.Visible = true;
                    txtWebsite.Text = AttValueBind;
                }
                else if (AttriID == 28)
                {
                    pnlAddress.Visible = true;
                    txtAddress.Text = AttValueBind;
                }

                else if (AttriID == 29)
                {
                    pnlNeighborhood.Visible = true;
                    txtNeighborhood.Text = AttValueBind;
                }
                else if (AttriID == 16)
                {
                    pnlQuotes.Visible = true;
                    txtQuotes.Text = AttValueBind;
                }

                else if (AttriID == 17)
                {
                    pnlBio.Visible = true;
                    txtBio.Text = AttValueBind;
                }


                else if (AttriID == 23)
                {
                    pnlBrother.Visible = true;
                    txtBrother.Text = AttValueBind;
                }
                else if (AttriID ==24)
                {
                    pnlSister.Visible = true;
                    txtSister.Text = AttValueBind;
                }

                else if (AttriID == 25)
                {
                    pnlFather.Visible = true;
                    txtFather.Text = AttValueBind;
                }

                else if (AttriID == 26)
                {
                    pnlMother.Visible = true;
                    txtMother.Text = AttValueBind;
                }
                else if (AttriID == 27)
                {
                    pnlQuotations.Visible = true;
                    txtQuotations.Text = AttValueBind;
                }







            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void btnGenderSubmit_Click(object sender, EventArgs e)
        { 
                string aValue = rbmale.Checked == true ? "Male" : "Female";

                UseForAll(aValue);
              
        }

        private void UseForAll(string aValue)
        {
            try
            {
                if (multiuse == false)
                { 
                    //update always
                    DataTable dt = new DataTable();
                    dt = objStar.getDataTable(" select id,AttributesValue,AudienceID from star_Profile  where ProfileAttributesID=" + AttriID + " and user_id=" + StarExtension.GetUserID + "");
                    if (dt.Rows.Count > 0)
                    {
                        string sql = "update star_Profile set  AttributesValue='" + aValue + "' ,AudienceID=" + ddlAudi.SelectedItem.Value + ", DateModified=GETDATE() where id=" + dt.Rows[0]["id"];
                        objStar.ExecuteSql(sql);
                    }
                    else
                    {
                        string sql = " insert into star_Profile (user_id,ProfileAttributesID,AttributesValue,AudienceID,DateAdded,DateModified) values(" + StarExtension.GetUserID + "," + AttriID + ",'" + aValue + "'," + ddlAudi.SelectedItem.Value + ",GETDATE(),GETDATE())";
                        objStar.ExecuteSql(sql);
                    }

                }
                else
                {
                    string sql = " insert into star_Profile (user_id,ProfileAttributesID,AttributesValue,AudienceID,DateAdded,DateModified) values(" + StarExtension.GetUserID + "," + AttriID + ",'" + aValue + "'," + ddlAudi.SelectedItem.Value + ",GETDATE(),GETDATE())";
                    objStar.ExecuteSql(sql);
                }
                Response.Redirect(hideurl.Value.ToString());


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnDOB_Click(object sender, EventArgs e)
        {
            if (ddlmonth.SelectedValue == "0" && ddlday.SelectedValue == "0" && ddlyear.SelectedValue == "0")
            {
                lblMsg.Text = "Fields Selection Should be Must.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                string month = valid.ValidateData(ddlmonth.SelectedItem.Value.ToString());
                string day = valid.ValidateData(ddlday.SelectedItem.Value.ToString());
                string year = valid.ValidateData(ddlyear.SelectedItem.Value.ToString());

                string dob = month + "/" + day + "/" + year;

                UseForAll(dob);

            }
        }

        protected void btnRelationship_Click(object sender, EventArgs e)
        {
            if (ddlRelationShip.SelectedItem.Value == "0")
            {
                lblMsg.Text = "Fields Selection Should be Must.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                UseForAll(ddlRelationShip.SelectedItem.Text);
            }
        }

        protected void btnInterestedIn_Click(object sender, EventArgs e)
        {
            string inn=string.Empty;
            if (chkMen.Checked == true && chkWomen.Checked == true)
            {
                inn = "Men,Women";
            }
            else if (chkMen.Checked == true)
            {
                inn = "Men";
            }
            else
            {
                inn = "Women";
            }

            UseForAll(inn);


        }

        protected void btnLanguages_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtLanguages.Text));
        }

        protected void btnPolitical_Click(object sender, EventArgs e)
        {
            //
            UseForAll(valid.ValidateData(txtPolitical.Text));
        }

        protected void btnReligion_Click(object sender, EventArgs e)
        {
             UseForAll(valid.ValidateData(txtReligion.Text));
            
        }

        protected void btnCompany_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtCompany.Text));
            
        }

        protected void btnPosition_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtPosition.Text));
            
        }

        protected void btnGrad_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtGrad.Text));
            
        }

        protected void btnCollege_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtCollege.Text));
            
        }

        protected void btnHighSchool_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtHighSchool.Text));
            
        }

        protected void btnCurrentcity_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtCurrentcity.Text));
            
        }

        protected void btnHometown_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtHometown.Text));
            
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtProfile.Text));
            
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtEmail.Text));
            
        }

        protected void btnAIM_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtAIM.Text));
            
        }

        protected void btnPhones_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtPhones.Text));
            
        }

        protected void btnWebsite_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtWebsite.Text));
            
        }

        protected void btnAddress_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtAddress.Text));
            
        }

        protected void btnNeighborhood_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtNeighborhood.Text));
            
        }

        protected void btnQuotes_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtQuotes.Text));
            
        }

        protected void btnBio_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtBio.Text));
            
        }

        protected void btnBrother_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtBrother.Text));
            
        }

        protected void btnSister_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtSister.Text));
            
        }

        protected void btnFather_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtFather.Text));
            
        }

        protected void btnMother_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtMother.Text));
            
        }

        protected void btnQuotations_Click(object sender, EventArgs e)
        {
            UseForAll(valid.ValidateData(txtQuotations.Text));
            
        }
    }
}