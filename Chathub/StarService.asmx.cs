using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using StarMethods;

namespace Chathub
{
    /// <summary>
    /// Summary description for StarService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class StarService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //[WebMethod]
        //public string PublicMstChatSelect(int roomidd)
        //{
        //    try
        //    {
        //        return StarM.PublicMstChatSelect(roomidd).GetXml();
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
           
        //}
        List<PublicChatItem> objLst = new List<PublicChatItem>();

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SqlConnectionString"].ToString());

        private static  class MsgEnd
        {
            private static string msg;

            public static string Msg
            {
                get { return msg; }
                set { msg = value; }
            }

 
        }

        [WebMethod]
        public List<PublicChatItem> insertPublicMsg(int userid, int roomid, string chatdesc)
        {
             
            try
            {

                if (chatdesc.Contains(".com") || chatdesc.Contains("www") || chatdesc.Contains(".in") || chatdesc.Contains(".org") || chatdesc.Contains(".info") || chatdesc.Contains(".mobi") || chatdesc.Contains(".us") || chatdesc.Contains("<script>"))
                {

                }
                else
                {
                    if (chatdesc.Length >= 2 && chatdesc.Length<150)
                    {
                       
                        if (MsgEnd.Msg == chatdesc)
                        {

                        }
                        else
                        {
                            MsgEnd.Msg = "";
                            SqlParameter[] parm = new SqlParameter[5];
                            parm[0] = new SqlParameter("@Action", "InsertOpenChat");
                            parm[1] = new SqlParameter("@user_id", userid);
                            parm[2] = new SqlParameter("@room_id", roomid);
                            parm[3] = new SqlParameter("@msgdesc", chatdesc);
                            parm[4] = new SqlParameter("@outid", SqlDbType.Int);
                            parm[4].Direction = ParameterDirection.Output;
                            StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "publicChat", parm);
                        }
                       
                        MsgEnd.Msg = chatdesc;
                    }
                }
                objLst = PublicMstChatSelect(roomid,userid);
                return objLst;

            }
            catch (Exception)
            {

                throw;
            }
        }

       

        [WebMethod]
        public DataTable GetAdversiteWebsites(Int64 userid , Int64 friends_id,int COUNTVAL)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] parm = new SqlParameter[4];

                parm[0] = new SqlParameter("@Action", "SelectChating");
                parm[1] = new SqlParameter("@user_id", userid);
                parm[2] = new SqlParameter("@frnd_user_id", friends_id);
                parm[3] = new SqlParameter("@COUNTVAL", COUNTVAL);

                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "PrivateChating", parm);
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }



        [WebMethod]
        public Int64 InsertPrivateChating(Int64 userid, string user_name,Int64 friends_id,string Chatdesc,string IP,string imagename)
        {
            validData valid = new validData();
            Int64 r = 0;
            try
            {
                Chatdesc = valid.Reverse_ValidateData(Chatdesc);
                Chatdesc = valid.ValidateData(Chatdesc);
                 SqlParameter[] parm = new SqlParameter[8];
                            parm[0] = new SqlParameter("@Action", "InsertChating");
                            parm[1] = new SqlParameter("@user_id", userid);
                            parm[2] = new SqlParameter("@user_name", user_name);
                            parm[3] = new SqlParameter("@frnd_user_id", friends_id);
                            parm[4] = new SqlParameter("@chat_desc", valid.ValidateData1(Chatdesc));
                            parm[5] = new SqlParameter("@IP",IP); 
                            parm[6] = new SqlParameter("@outid", SqlDbType.Int);
                            parm[6].Direction = ParameterDirection.Output;
                            parm[7] = new SqlParameter("@imagename", imagename);
                      StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "PrivateChating", parm);

                      return r = Convert.ToInt64(parm[6].Value);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        [WebMethod]
        public Int64 InsertWallPost(Int64 userid, string postdesc, string IP, string imagename, string videourl, int AudienceLockID)
        {
            Int64 r = 0;
            try
            {
      
                SqlParameter[] parm = new SqlParameter[8];
                parm[0] = new SqlParameter("@Action", "InsertPost");
                parm[1] = new SqlParameter("@user_id", userid);
                parm[2] = new SqlParameter("@postdetail", postdesc);
                parm[3] = new SqlParameter("@postimg", imagename);
                parm[4] = new SqlParameter("@video", videourl);
                parm[5] = new SqlParameter("@IP", IP);
                parm[6] = new SqlParameter("@outid", SqlDbType.Int);
                parm[6].Direction = ParameterDirection.Output;
                parm[7] = new SqlParameter("@AudienceLockID", AudienceLockID);
                 
                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "starWallPostSystem", parm);

                return r = Convert.ToInt64(parm[6].Value);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [WebMethod]
        public DataTable SelectOwnPost(string action, Int64 user_id)
        { 
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter("@Action", action);
                parm[1] = new SqlParameter("@user_id", user_id);
               
                dt= StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "starWallPostSystem", parm);
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        [WebMethod]
        public List<PublicChatItem> PublicMstChatSelect(int roomid, Int64 userid)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SqlConnectionString"].ToString());
            DataTable dt = new DataTable();
            Datastar objStar = new Datastar();
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@Action", "SelectOpenChat");
                parm[1] = new SqlParameter("@room_id", roomid);
                parm[2] = new SqlParameter("@user_id", userid);
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "publicChat", parm);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PublicChatItem objs = new PublicChatItem();
                    objs.uid = Convert.ToInt64(dt.Rows[i]["user_id"]);
                    objs.room_id = Convert.ToInt32(dt.Rows[i]["room_id"]);
                    objs.crtd_date = objStar.TimeAgo(Convert.ToDateTime(dt.Rows[i]["crtd_date"]));
                    objs.ChatDesc = dt.Rows[i]["ChatDesc"].ToString();
                    objs.ChatImage = dt.Rows[i]["ChatImage"].ToString();
                    objs.username = dt.Rows[i]["username"].ToString();
                    objs.img_name = dt.Rows[i]["img_name"].ToString();
                    objLst.Add(objs);

                }
                return objLst;

            }
            catch (Exception)
            {

                throw;
            }
        }

        List<PrivateChatMsgItems> objLstPrivate = new List<PrivateChatMsgItems>();

        [WebMethod]
        public List<PrivateChatMsgItems> SelectPrivateChat(Int64 Userid, Int64 frndUserid, int COUNTVAL)
        {
            try
            { 
                DataTable dt = new DataTable();
                Datastar objstar = new Datastar();
                SqlParameter[] parm = new SqlParameter[4];

                parm[0] = new SqlParameter("@Action", "SelectChating");
                parm[1] = new SqlParameter("@user_id", Userid);
                parm[2] = new SqlParameter("@frnd_user_id", frndUserid);
                parm[3] = new SqlParameter("@COUNTVAL", COUNTVAL);

                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "PrivateChating", parm);
                 
                if (dt.Rows.Count > 0)
                { 
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PrivateChatMsgItems ite = new PrivateChatMsgItems();
                        ite.id = Convert.ToInt64(dt.Rows[i]["id"].ToString());
                        ite.img = dt.Rows[i]["imagename"].ToString();
                        ite.msg = dt.Rows[i]["chat_desc"].ToString();
                        ite.seen = dt.Rows[i]["seen"].ToString().Trim().TrimStart().TrimEnd();
                        ite.userid = Convert.ToInt64(dt.Rows[i]["user_id"].ToString());
                        ite.frndUserID = frndUserid;
                        ite.date = objstar.TimeAgo(Convert.ToDateTime(dt.Rows[i]["crtd_date"].ToString()));
                        ite.username = dt.Rows[i]["username"].ToString();
                        objLstPrivate.Add(ite);
                    }
                }
                 
                return objLstPrivate;
            }
            catch (Exception)
            {
                
                throw;
            }
        }






        

        [WebMethod]
        public List<lstMsgUsers> GetUserMessagesInboxPage(Int64 Userid, int top)
        {
            try
            {
                List<lstMsgUsers> objlstMsgUsers = new List<lstMsgUsers>();

                DataTable dt = new DataTable();
                Methodsall m=new Methodsall();
                Datastar objstar = new Datastar();
                dt = m.GetUserMessagesInboxPage(Userid, top);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lstMsgUsers ite = new lstMsgUsers();
                        ite.img_name = dt.Rows[i]["img_name"].ToString();
                        ite.crtd_date = objstar.TimeAgo(Convert.ToDateTime(dt.Rows[i]["crtd_date"].ToString()));
                        ite.seen = dt.Rows[i]["seen"].ToString().Trim().TrimStart().TrimEnd();
                        ite.user_id = Convert.ToInt64(dt.Rows[i]["user_id"].ToString());
                        ite.sex = dt.Rows[i]["sex"].ToString().Trim().TrimStart().TrimEnd(); ;
                        ite.user_online = dt.Rows[i]["user_online"].ToString().Trim();
                        ite.username = dt.Rows[i]["username"].ToString();
                        objlstMsgUsers.Add(ite);
                    }
                }

                return objlstMsgUsers;
            }
            catch (Exception)
            {

                throw;
            }
        }






        public class lstMsgUsers
        {
            public string img_name { get; set; }
            public string username { get; set; }
            public Int64 user_id { get; set; }
            public string sex { get; set; }
            public string seen { get; set; }
            public string crtd_date { get; set; }
            public string user_online { get; set; }
        }











    }
    public class PublicChatItem
    {
        public Int64 uid { get; set; }
        public int room_id { get; set; }
        public string crtd_date { get; set; }
        public string ChatDesc { get; set; }
        public string ChatImage { get; set; }
        public string username { get; set; }
        public string img_name { get; set; }
    }


    public class PrivateChatMsgItems
    {
        public Int64 id { get; set; }
        public string msg { get; set; }
        public string img { get; set; }
        public string date { get; set; }
        public string seen { get; set; }
        public Int64 frndUserID { get; set; }
        public Int64 userid { get; set; }
        public string username { get; set; }
    }
}
