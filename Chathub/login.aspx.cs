using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Chathub
{
    public partial class login : System.Web.UI.Page
    {
        Datastar objStar = new Datastar();
        validData objV = new validData();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();

            form1.Action = Request.RawUrl;
            if (!Page.IsPostBack)
            {
                bindseo();
                TotalUsers();
            }
             
        }

        private void TotalUsers()
        {
            try
            {

                dt = new DataTable();
                dt = objStar.getDataTable("select count(user_id) as TotalUsers from star_user");
                if (dt.Rows.Count > 0)
                {
                    litOverAllUsersCount.Text ="("+ dt.Rows[0]["TotalUsers"] + ") User Registered";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void bindseo()
        {

            Page.Title = "Welcome to Chathub.in Login ,Sign Up";

            HtmlMeta description1 = new HtmlMeta();
            description1.Name = "description";
            description1.Content = "Sonustar Creation , hi friends welcome to sonustar world ,by using my these website chathub.in you can make your new friends on world-wide  and also communicate with them ";
            Page.Header.Controls.Add(description1);

            HtmlMeta keywords1 = new HtmlMeta();
            keywords1.Name = "keywords";
            keywords1.Content = "chathub.in,chathub,sonu,sonustar,sonu star,star,chating,chat-hub,free chating website,free chat,make a friend,chat with girls,About of SonuStar,mobile chat,mobile chating website free,Search Your Friends,Public Chating , Private Chating ,Chathub.in Live Chat Features ,login ,sign up";
            Page.Header.Controls.Add(keywords1);
             
        }

        protected void lbtnshowreg_Click(object sender, EventArgs e)
        {
           
            pnlLogin.Visible = false;
        }
        protected void lbtnlogin_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = true;
            
        }
      
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtLoginEmailId.Text.Length > 0 && txtLoginPassword.Text.Length > 0)
            {
                string mailId = objV.ValidateData(txtLoginEmailId.Text.ToString());
                string pass = objV.ValidateData(txtLoginPassword.Text.ToString());

                //decrypt there


                DataTable dt = new DataTable();
                //string sql = "select su.user_id,sde.emstars as mail_id,sde.unstars as username from star_unpwgonext sde inner join star_user su on su.user_id=sde.user_id where (emstars=@emstars or unstars=@emstars) and pwstars=@pwstars";
                //SqlParameter[] param = new SqlParameter[2];
                //param[0] = new SqlParameter("@emstars", mailId);
                //param[1] = new SqlParameter("@pwstars", pass);

                dt = objStar.getUserLogonData(mailId, pass);
                if (dt.Rows.Count > 0)
                {
                    Session["user_id"] = dt.Rows[0]["user_id"].ToString();
                    Session["mail_id"] = dt.Rows[0]["mail_id"].ToString();
                    Session["username"] = dt.Rows[0]["username"].ToString();

                    Response.Redirect("~/home");
                }
                else
                {
                    lblm.Text = "Your username and password are mismatched.Please Check.";
                    lblm.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                txtLoginEmailId.Attributes.Add("style", "border:1px solid red");
                txtLoginPassword.Attributes.Add("style", "border:1px solid red");
            }
 
        }





        private bool EmailValidation(string Emailid)
        {
            String mail = Emailid;
            string expression = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|" + @"0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" + @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";

            Match match = Regex.Match(mail, expression, RegexOptions.IgnoreCase);
            if (match.Success)
            { return true; }
            else
            { return false; }

        }

        private bool checkengname()
        {
            Regex reg = new Regex(@"^[\P{L}\p{IsBasicLatin}]+$");
            Match result = reg.Match(txtusername.Text);
            if (result.Success)
                return true;
            else
                return false;

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            bool emailval = EmailValidation(txtmid.Text);

            if (txtusername.Text.Length > 0 && txtmid.Text.Length > 0 && txtpasswordReg.Text.Length > 0)
            {
                if (emailval == true)
                {


                    if (txtusername.Text.ToString().Contains("@"))
                    {
                        lblmsg.Text = "In Username symbols are not allowed.";
                    }
                    else
                    {
                        if (txtusername.Text.ToString().Length > 30)
                        {
                            lblmsg.Text = "Username Is Much Long.";
                        }
                        else
                        {

                            if (checkengname())
                            {
                                string username = objV.ValidateData(txtusername.Text.ToString());
                                string email = objV.ValidateData(txtmid.Text.ToString());
                                string password = objV.ValidateData(txtpasswordReg.Text.ToString());

                                string sqlcheck = "select user_id from star_unpwgonext  where  unstars='" + username + "' ";
                                DataTable dt_check = new DataTable();
                                dt_check = objStar.getDataTable(sqlcheck);
                                if (dt_check.Rows.Count > 0)
                                {
                                    sp_GetImage.Text = "<img src=\"images/no.gif\" title='Already Used this username'/>";
                                }
                                else
                                {
                                    string sqlcheckEmail = "select user_id from star_unpwgonext  where  emstars='" + email + "' ";
                                    DataTable dt_checkE = new DataTable();
                                    dt_checkE = objStar.getDataTable(sqlcheckEmail);
                                    if (dt_checkE.Rows.Count > 0)
                                    {
                                        Literal1.Text = "<img src=\"images/no.gif\" title='Already Used this Email ID'/>";
                                    }
                                    else
                                    {
                                        string gender = "Male";
                                        if (rbfemale.Checked == true)
                                        {
                                            gender = "Female";
                                        }


                                        Int64 r = objStar.insertNewUser(username, password, email, gender);
                                        if (r > 0)
                                        {
                                            //Email send code apply there  Below peya

                                            lblmsg.Text = "Registration Successfully <a href='/login'> Please Login </a>";


                                            StringBuilder sbMsg = new StringBuilder();

                                            sbMsg.Append("Hi. " + username + " ,");

                                            sbMsg.Append("We think it is great that you have decided to sign up for our chathub.in . You can start chathub.in right now. <br><br>");

                                            sbMsg.Append(".::------------------------------------------------------::.<br>");
                                            sbMsg.Append("Account Information:<br>");
                                            sbMsg.Append("http://www.chathub.in<br>");
                                            sbMsg.Append("Username: " + username + " <br>");
                                            sbMsg.Append("Password: " + password + "<br>");
                                            sbMsg.Append(".::------------------------------------------------------::.<br> <br>");
                                            sbMsg.Append("If you have any questions look at <b>Suggest Us</b> bottom on Chathub.in <br>");

                                            sbMsg.Append("<br>Good luck " + username + "<br><br>");

                                            sbMsg.Append("Thanks, Chathub.In Team<br> ");

                                            bool y = SendMail(sbMsg.ToString(), "Welcome in Chathub.in", email);
                                            if (y == true)
                                            {

                                            }


                                        }
                                        txtusername.Text = "";
                                        txtmid.Text = "";
                                    }
                                }
                            }
                            else
                            {
                                lblmsg.Text = "Use just US English for Username";
                            }



                        }
                    }
                }
                else
                {
                    lblmsg.Text = "Invalid Email ID";
                }
            }
            else
            {
                txtusername.Attributes.Add("style", "border:1px solid red;");
                txtmid.Attributes.Add("style", "border:1px solid red;");
                txtpasswordReg.Attributes.Add("style", "border:1px solid red;");

            }



        }


        private bool SendMail(string body, string subject, string ToAddress)
        {
            try
            {

                MailMessage message = new MailMessage();
                message.To = ToAddress;
                message.From = "support@chathub.in";
                message.Subject = subject;
                message.BodyFormat = MailFormat.Html;

                message.Body = body;
                string Username = "support@chathub.in";
                string Password = "starwap";
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //none, cdoBasic, NTLM
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", Username);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", Password);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2); // cdoNTLM, value 2. The current process security context is used to authenticate with the service.
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", false);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout", 60);

                string SmptServer = "smtpout.secureserver.net";
                System.Web.Mail.SmtpMail.SmtpServer = SmptServer;
                System.Web.Mail.SmtpMail.Send(message);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        protected void btnCheckUserName_Click(object sender, EventArgs e)
        {
            string chkCompMail = objV.ValidateData(txtusername.Text.ToString());
            if (chkCompMail.Contains("@"))
            {
                sp_GetImage.Text = "<img src=\"images/no.gif\" title='Already Used this username'/>";
            }
            else
            {
                string sqlcheck = "select user_id from star_unpwgonext  where  unstars='" + chkCompMail + "' ";
                DataTable dt_check = new DataTable();
                dt_check = objStar.getDataTable(sqlcheck);
                if (dt_check.Rows.Count > 0)
                {
                    sp_GetImage.Text = "<img src=\"images/no.gif\" title='Already Used this username'/>";
                }
                else
                {
                    if (checkengname())
                    {
                        sp_GetImage.Text = "<img src=\"images/yes.gif\" title='Done Your Can Use This username'/>";
                    }
                    else
                    {
                        sp_GetImage.Text = "<img src=\"images/no.gif\" title='Use Just US English'/>";
                    }
                }
            }
        }

        protected void btnemailcheck_Click(object sender, EventArgs e)
        {
            string chkCompMail = objV.ValidateData(txtmid.Text.ToString());
            string sqlcheck = "select user_id from star_unpwgonext  where  emstars='" + chkCompMail + "' ";
            DataTable dt_check = new DataTable();
            dt_check = objStar.getDataTable(sqlcheck);
            if (dt_check.Rows.Count > 0)
            {
                Literal1.Text = "<img src=\"images/no.gif\" title='Already Used this Email ID'/>";
            }
            else
            {
                Literal1.Text = "<img src=\"images/yes.gif\" title='Done Your Can Use This Email ID'/>";

            }
        }



        protected void btnchangeemail_Click(object sender, EventArgs e)
        {
            Datastar objStar = new Datastar();
            if (txtLoginEmailId.Text.Length > 0)
            {

                DataTable dtt = new DataTable();
                dtt = objStar.forgotpwdata(txtLoginEmailId.Text, "SelectForgot");
                if (dtt.Rows.Count > 0)
                {
                    if (txtLoginEmailId.Text.ToString().Trim() == dtt.Rows[0]["emstars"].ToString().Trim())
                    {

                        StringBuilder sb = new StringBuilder();

                        string Subject = "Your Password Successfully Recoverd";
                        string val = dtt.Rows[0]["pw"].ToString().Trim();
                        string Body = "Dear " + txtLoginEmailId.Text + " Your password is reset successfully , now your password is = " + val + "  ";
                        Body += "<br><br> Thanks <br><b>www.Chatbub.in</b> <a href='http://www.sonustar.in'>Star Team</a>";
                        bool y = SendMail(Body, Subject, txtLoginEmailId.Text.Trim());
                        if (y == true)
                        {
                            Label1.Text = "Successfully Recovered Check Your Email ID";
                            Label1.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            Label1.Text = "Problem Sending Email To You Retry again";
                            Label1.ForeColor = System.Drawing.Color.Red;
                        }

                        //System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                        //mail.To.Add(txtLoginEmailId.Text);
                        //mail.From = new MailAddress(FromAddress);
                        //mail.Subject = Subject;
                        //mail.IsBodyHtml = true;
                        //mail.Body = Body;
                        //mail.Priority = System.Net.Mail.MailPriority.High;
                        //SmtpClient client = new SmtpClient();
                        //client.Credentials = new System.Net.NetworkCredential(FromAddress, "star1woofer");
                        //client.Port = 587;
                        //client.Host = "smtp.gmail.com";
                        //client.EnableSsl = true;
                        //try
                        //{
                        //    client.Send(mail);
                        //    Label1.Text = "Successfully Changed";
                        //    Label1.ForeColor = System.Drawing.Color.Green;
                        //}
                        //catch (Exception)
                        //{
                        //    Label1.Text = "Problem Sending Email To You Retry again";
                        //    Label1.ForeColor = System.Drawing.Color.Red;
                        //}


                    }

                }
                else
                {
                    Label1.Text = "You Are Not Chathub User Invalid Email Address";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                txtLoginEmailId.Attributes.Add("style", "border:1px solid red;");
            }
        }











    }
}