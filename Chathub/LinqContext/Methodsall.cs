using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using StarMethods;
namespace Chathub 
{
    public class Methodsall
    { 
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SqlConnectionString"].ToString());
         
        Datastar objStar = new Datastar();
        public DataTable GetAllUsers(int userid, int roomid)
        {
            try
            {
                 
                DataTable dt = new DataTable();
                string rptBind = string.Empty;

                string go = string.Format(@"select s.username ,(s.user_id) as user_id ,s.img_name,s.sex,s.user_online from starUsersAndRoomMaping map inner join star_user s 
  on s.user_id=map.UserID where RoomID=" + roomid + " and s.active='A' and s.user_id !=" + userid + " and s.user_id not in(select bl.user_id from star_blockList bl where bl.BlockToUser_id=" + userid + ") order by s.crtd_date desc");

                dt = objStar.getDataTable(go);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetAdversiteWebsites()
        {
            try
            { 
                DataTable dt = new DataTable();
                string rptBind = string.Empty;

                string go = string.Format(@"select * from star_advertiseWebsite order by SortOrder asc");

                dt = objStar.getDataTable(go);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable GetAdversiteScripts(int IsHeader)
        {
            try
            {
                DataTable dt = new DataTable();
                string rptBind = string.Empty;

                string go = string.Format(@"select id,ScriptDesc,Img_Url,Title,IsHeader from star_Advertisement where IsActive=1 and IsHeader=" + IsHeader + " order by id asc");

                dt = objStar.getDataTable(go);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable GetUserMessages(int userid)
        {
            try
            {
                string rptBind = string.Empty;
                string rpt_sql = "select s_chat.chat_desc,s_chat.crtd_date,su.img_name,su.username,(su.user_id) as user_id,su.sex  from star_chating s_chat inner join star_user su on s_chat.user_id=su.user_id  where su.active='A' and s_chat.active='A' and s_chat.frnd_user_id in(" + userid + ") and s_chat.seen='N' and su.user_id not in(select bl.user_id from star_blockList bl where bl.BlockToUser_id=" + userid + ") order by s_chat.crtd_date desc";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(rpt_sql);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

         public DataTable GetUserMessagesInboxPage(Int64 userid,int top)
        {
            string rptBind = string.Empty;
            try
            { 
                string rpt_sql = @";WITH latestMessages AS (  SELECT top "+top+"  su.img_name,su.username,(su.user_id) as user_id,su.sex,s_chat.seen,s_chat.crtd_date,su.user_online, ROW_NUMBER() OVER (Partition BY su.user_id  ORDER BY s_chat.crtd_date desc) RN FROM   star_chating s_chat inner join star_user su on s_chat.user_id=su.user_id  where s_chat.active='A' and s_chat.frnd_user_id in(" + userid + ") and su.active='A' and su.user_id not in(select bl.user_id from star_blockList bl where bl.BlockToUser_id=" + userid + ") ) SELECT   img_name,username,(user_id) as user_id,sex,seen,crtd_date,user_online FROM    latestMessages WHERE   RN = 1 order BY crtd_date desc";

                DataTable dt = new DataTable();
                dt = objStar.getDataTable(rpt_sql);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


         public DataTable GetUserMessagesInboxPageCounter(int userid)
         {
             try
             {
                 string rptBind = string.Empty;
                 string rpt_sql = @"select distinct s_chat.user_id 
  from star_chating s_chat inner join star_user su on s_chat.user_id=su.user_id  
  where s_chat.active='A' and s_chat.frnd_user_id in(" + userid + ") and su.active='A' and su.user_id not in(select bl.user_id from star_blockList bl where bl.BlockToUser_id=" + userid + ") and s_chat.seen='N'";
                 DataTable dt = new DataTable();
                 dt = objStar.getDataTable(rpt_sql);
                 return dt;
             }
             catch (Exception)
             {

                 throw;
             }
         }



         public DataTable GetOtherUserInfoByID(Int64 userid)
         {
             try
             {
                 string rptBind = string.Empty;
                 string rpt_sql = @"select img_name,username, user_id, sex from star_user WHERE  active='A' and (IsDeleted=0 or IsDeleted is null) and user_id not in(select bl.user_id from star_blockList bl where bl.BlockToUser_id=" + userid + ") and  user_id=" + userid;
                 DataTable dt = new DataTable();
                 dt = objStar.getDataTable(rpt_sql);
                 return dt;
             }
             catch (Exception)
             {

                 throw;
             }
         }
         
        public DataTable GetOnlineUsers()
        {
            try
            {
                string rptBind = string.Empty;
                string rpt_sql = "select s.username ,(s.user_id) as user_id ,s.user_online,s.img_name,s.sex from star_user s where user_online=1 and active='A' and  user_id not in(select bl.user_id from star_blockList bl where bl.BlockToUser_id=" + StarExtension.GetUserID + ") and user_id !=" + StarExtension.GetUserID;
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(rpt_sql);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetUserAllImages(int userid)
        {
            try
            { 
                string rptBind = string.Empty;
                string rpt_sql = "select * from star_images where user_id=" + userid + " and IsActive=1 order by id desc";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(rpt_sql);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetUserAllImagesForOther(int userid)
        {
            try
            {
                DataTable dtt = new DataTable();
                dtt = GetFriendListByFriendCheck(StarExtension.GetUserID, userid);
                string sql_f = string.Empty;
                if (dtt.Rows.Count > 0)
                {
                    sql_f = "select * from star_images where user_id=" + userid + " and AudienceLockID in(1,2) and IsActive=1 order by id desc";
                }
                else
                {
                    sql_f = "select * from star_images where user_id=" + userid + " and AudienceLockID in(1) and IsActive=1 order by id desc";

                }
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable GetFriendRequest()
        {
            try
            {
                validData val = new validData();
                string sql_list = @"select fl.id, UPPER(su.username) as username,su.sex,su.img_name,su.user_id
 from star_user su inner join star_frnd_list fl on su.user_id=fl.user_id where  su.active='A'  and  fl.frnd_user_id=" + val.ValidateData(StarExtension.GetUserID.ToString()) + " and fl.request='R' ";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_list);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetFriendList()
        {
            try
            {
                string sql_f = "select user_id as id from star_frnd_list where user_id=" + StarExtension.GetUserID + " and request='A' union select frnd_user_id as id from star_frnd_list where user_id=" + StarExtension.GetUserID + " and request='A' union select user_id as id from star_frnd_list where frnd_user_id=" + StarExtension.GetUserID + " and request='A'  union select frnd_user_id as id from star_frnd_list where frnd_user_id=" + StarExtension.GetUserID + " and request='A'";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetFriendsListWhichAreOnline()
        {
            try
            {
                string sql_f = "select count(user_id) as onlines from star_user where user_id in(select user_id as id from star_frnd_list where user_id=" + StarExtension.GetUserID + " and request='A' union select frnd_user_id as id from star_frnd_list where user_id=" + StarExtension.GetUserID + " and request='A' union select user_id as id from star_frnd_list where frnd_user_id=" + StarExtension.GetUserID + " and request='A'  union select frnd_user_id as id from star_frnd_list where frnd_user_id=" + StarExtension.GetUserID + " and request='A') and user_online=1 and active='A'";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                string s = string.Empty;
                if (dt.Rows.Count > 0)
                {
                    s = dt.Rows[0]["onlines"].ToString();
                    Int64 wer = Convert.ToInt64(s);
                    wer = wer > 0 ? (wer - 1) : 0;
                    s = wer.ToString();
                }

                return s;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetFriendzListDetail(int ides,Int64 qstring)
        {
            try
            {
                string sql_user = string.Empty;
                if (qstring > 0)
                {
                    sql_user = "select user_id,user_online,username,img_name,sex from star_user where active='A' and (IsDeleted=0 or IsDeleted is null) and user_id=" + ides + " and user_id !=" + qstring + " and user_id not in(select bl.user_id from star_blockList bl where bl.BlockToUser_id=" + StarExtension.GetUserID + ") and user_id !=" + StarExtension.GetUserID;
                }
                else
                {
                    sql_user = "select user_id,user_online,username,img_name,sex from star_user where active='A' and (IsDeleted=0 or IsDeleted is null) and  user_id=" + ides + " and  user_id not in(select bl.user_id from star_blockList bl where bl.BlockToUser_id=" + StarExtension.GetUserID + ") and user_id !=" + StarExtension.GetUserID;

                }


                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_user);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetFriendListByFriend(int UserDIid)
        {
            try
            {
                string sql_f = "select user_id as id from star_frnd_list where user_id=" + UserDIid + " and request='A' union select frnd_user_id as id from star_frnd_list where user_id=" + UserDIid + " and request='A' union select user_id as id from star_frnd_list where frnd_user_id=" + UserDIid + " and request='A'  union select frnd_user_id as id from star_frnd_list where frnd_user_id=" + UserDIid + " and request='A'";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetFriendListByFriendCheck(Int64 UserDIid, Int64 FriendID)
        {
            try
            {
                string sql_f = @"select id,user_id,request from star_frnd_list where user_id=" + UserDIid + " and   frnd_user_id=" + FriendID + " and request in('R','A') union select id,user_id,request  from star_frnd_list where frnd_user_id=" + UserDIid + " and user_id=" + FriendID + "    and request in('R','A')";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetProfileCategory()
        {
            try
            {
                string sql_f = "select * from star_ProfileCategory where IsActive=1";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetProfileAttributes(int CatID)
        {
            try
            {
                string sql_f = "select * from star_ProfileAttributes where IsActive=1 and ProfileCategoryID=" + CatID;
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetProfileValues(int ProfileAttriID, int User_id)
        {
            try
            {
                string sql_f = " select * from star_Profile  where  user_id=" + User_id + " and ProfileAttributesID=" + ProfileAttriID;
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetProfileValuesForOtherUser(int ProfileAttriID, int User_id)
        {
            try
            {
                DataTable dtt = new DataTable();
                dtt = GetFriendListByFriendCheck(StarExtension.GetUserID, User_id);
                string sql_f = string.Empty;
                if (dtt.Rows.Count > 0)
                {
                    sql_f = " select * from star_Profile  where  user_id=" + User_id + " and AudienceID in(1,2) and ProfileAttributesID=" + ProfileAttriID;
                }
                else
                {
                    sql_f = " select * from star_Profile  where  user_id=" + User_id + " and AudienceID in(1) and ProfileAttributesID=" + ProfileAttriID;

                }
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetAudienceLock()
        {
            try
            {
                string sql_f = "select * from star_AudienceLock where IsActive=1";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetAllTour(int Islatest)
        {
            try
            {
                string sql_f = "select * from star_tourAndUpcoming where IsLatest=" + Islatest + " order by id desc";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable TodayJoinedUser()
        {
            try
            {
                string sql_f = "select * from star_user where CONVERT(date,crtd_date,1)=CONVERT(date,getdate(),1) and (IsDeleted is null or IsDeleted=0) and active='A' and  user_id not in(select bl.user_id from star_blockList bl where bl.BlockToUser_id=" + StarExtension.GetUserID + ")  and user_id !=" + StarExtension.GetUserID + "  order by user_id desc";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public DataTable WhoIsInside(int roomid)
        {
            try
            {
                string sql_f = " select  s.user_id  from starUsersAndRoomMaping map inner join star_user s on s.user_id=map.UserID where RoomID=" + roomid + " and s.active='A'";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
          
        public DataTable GetProfileVisitors(int userid)
        {
            try
            {
                string rptBind = string.Empty;
                string rpt_sql = "select s.username , s.user_id,s.user_online ,s.img_name,s.sex from star_user s inner join star_profilevisitor spv on s.user_id=spv.visitor_user_id where  s.active='A' and (s.IsDeleted=0 or s.IsDeleted is null) and s.user_id not in(select bl.user_id from star_blockList bl where bl.BlockToUser_id=" + userid + ") and  spv.user_id=" + userid + " order by spv.id desc";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(rpt_sql);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

         
        public DataTable GetFriendListOtherUserview(Int64 userid)
        {
            try
            {
                string sql_f = string.Empty;
                if (userid > 0)
                {
                    //sql_f = "select user_id as id from star_frnd_list where user_id=" + userid + " and request='A' union select frnd_user_id as id from star_frnd_list where user_id=" + userid + " and request='A' union select user_id as id from star_frnd_list where frnd_user_id=" + userid + " and request='A'  union select frnd_user_id as id from star_frnd_list where frnd_user_id=" + userid + " and request='A'";
                    sql_f = " select * from ( ";
                    sql_f += " select sfl.user_id as id, su.user_online from star_frnd_list sfl inner join star_user su on sfl.user_id=su.user_id  where sfl.user_id=" + userid + " and sfl.request='A' ";
                    sql_f += " union all select frnd_user_id as id ,su.user_online  from star_frnd_list sfl inner join star_user su on sfl.frnd_user_id=su.user_id   where sfl.user_id=" + userid + " and sfl.request='A' ";
                    sql_f += " union all select sfl.user_id as id,su.user_online from star_frnd_list sfl inner join star_user su on sfl.user_id=su.user_id  where frnd_user_id=" + userid + " and sfl.request='A' ";
                    sql_f += " union select sfl.frnd_user_id as id,su.user_online from star_frnd_list sfl inner join star_user su on sfl.frnd_user_id=su.user_id  where sfl.frnd_user_id=" + userid + " and sfl.request='A'";
                    sql_f += " ) a order by  user_online desc";
                }
                else
                {
                    userid = StarExtension.GetUserID;
                    sql_f = " select * from ( ";
                    sql_f += " select sfl.user_id as id, su.user_online from star_frnd_list sfl inner join star_user su on sfl.user_id=su.user_id  where sfl.user_id=" + userid + " and sfl.request='A' ";
                    sql_f += " union all select frnd_user_id as id ,su.user_online  from star_frnd_list sfl inner join star_user su on sfl.frnd_user_id=su.user_id   where sfl.user_id=" + userid + " and sfl.request='A' ";
                    sql_f += " union all select sfl.user_id as id,su.user_online from star_frnd_list sfl inner join star_user su on sfl.user_id=su.user_id  where frnd_user_id=" + userid + " and sfl.request='A' ";
                    sql_f += " union select sfl.frnd_user_id as id,su.user_online from star_frnd_list sfl inner join star_user su on sfl.frnd_user_id=su.user_id  where sfl.frnd_user_id=" + userid + " and sfl.request='A'";
                    sql_f += " ) a order by  user_online desc";
                    //sql_f = "select user_id as id from star_frnd_list where user_id=" + userid + " and request='A' union select frnd_user_id as id from star_frnd_list where user_id=" + userid + " and request='A' union select user_id as id from star_frnd_list where frnd_user_id=" + userid + " and request='A'  union select frnd_user_id as id from star_frnd_list where frnd_user_id=" + userid + " and request='A'";
                }

                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetNotificationOfUser()
        {
            try
            {
                string sql_f = "select * from AdminStar_Notification where user_id=" + StarExtension.GetUserID + " and (seen=0 or seen is null) order by DateAdded desc";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetAdminStar_ImageDelete()
        {
            try
            {
                string sql_f = "select * from AdminStar_ImageDelete where IsDeleted=0 order by DateAdded desc";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable MyBlockListUser()
        {
            try
            {
                string sql_f = "select bl.id,bl.user_id as buserid,bl.BlockToUser_id ,s.username , s.user_id,s.user_online ,s.img_name,s.sex from star_user s inner join  star_blockList bl on bl.BlockToUser_id=s.user_id where bl.user_id=" + StarExtension.GetUserID + " order by bl.DateAdded desc";
                DataTable dt = new DataTable();
                dt = objStar.getDataTable(sql_f);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataSet SelectPostDetail(Int64 postid)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@Action", "SelectPostesDetail");
                parm[1] = new SqlParameter("@pid", postid);
                parm[2] = new SqlParameter("@user_id", StarExtension.GetUserID);
               
                ds = StarHelper.ExecuteDataSet(con, CommandType.StoredProcedure, "starWallPostSystem", parm);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void InsertPostLikeCount(Int64 postid)
        {
            
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@Action", "insertlike");
                parm[1] = new SqlParameter("@user_id", StarExtension.GetUserID);
                parm[2] = new SqlParameter("@pid", postid);

                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "starWallPostSystem", parm);
                 
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Int64 InsertCommentOnPost(Int64 postid,string commenttext,string imgurl)
        {
            Int64 r = 0;
            try
            {
                SqlParameter[] parm = new SqlParameter[6];
                parm[0] = new SqlParameter("@Action", "InsertCommentOnPost");
                parm[1] = new SqlParameter("@user_id", StarExtension.GetUserID);
                parm[2] = new SqlParameter("@pid", postid);
                parm[3] = new SqlParameter("@CommentText", commenttext);
                parm[4] = new SqlParameter("@ImgUrl", imgurl);
                
                parm[5] = new SqlParameter("@outid", SqlDbType.Int);
                parm[5].Direction = ParameterDirection.Output;

                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "starWallPostSystem", parm);

                return r=Convert.ToInt64(parm[5].Value);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }






    public static class StarM
    {

        

        public static DataSet PublicMstChatSelect(int roomid)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SqlConnectionString"].ToString());
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter("@Action", "SelectOpenChat");
                parm[1] = new SqlParameter("@room_id", roomid);

                ds = StarHelper.ExecuteDataSet(con, CommandType.StoredProcedure, "publicChat", parm);

                return ds;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public static int ExceptionSend(int UserID, string Message, string PageUrl, string IP)
        {
            int R = 0;
            try
            {
                Datastar objStar = new Datastar();
                string Entry = "insert into star_Exceptionlog(user_id,exMsg,Url,IP) values(" + UserID + ",'" + Message + "','" + PageUrl + "','" + IP + "')";
                R = objStar.ExecuteSql(Entry); 
                 
                return R;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public static Int64 Profilevisit(Int64 userid, Int64 visitorid)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SqlConnectionString"].ToString());
            Int64 r = 0;
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@Action", "VisitorProfile");
                parm[1] = new SqlParameter("@user_id", userid);
                parm[2] = new SqlParameter("@visitorUserID", visitorid);
                r = StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "ProfileVisitors", parm);

                return r;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void ReSetchatRooms()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SqlConnectionString"].ToString());
           
            try
            {
                Datastar ds = new Datastar();
                ds.ExecuteSql("delete from starUsersAndRoomMaping"); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        

    }
}