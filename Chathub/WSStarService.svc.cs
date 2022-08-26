using StarMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation; 
using System.Text;

namespace Chathub
{
    
    [System.ComponentModel.ToolboxItem(false)]
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [System.Web.Script.Services.ScriptService]
    public class WSStarService
    {


        List<PublicChatItem> objLst = new List<PublicChatItem>();

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SqlConnectionString"].ToString());

        private static class MsgEnd
        {
            private static string msg;

            public static string Msg
            {
                get { return msg; }
                set { msg = value; }
            }


        }
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //[WebGet(ResponseFormat=WebMessageFormat.Xml)] 
        //     and include the following line in the operation body:
        //    WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // Add your operation implementation here
            return;
        }
        [OperationContract]
        public List<PublicChatItem> insertPublicMsg(int userid, int roomid, string chatdesc)
        {

            try
            {

                if (chatdesc.Contains(".com") || chatdesc.Contains("www") || chatdesc.Contains(".in") || chatdesc.Contains(".org") || chatdesc.Contains(".info") || chatdesc.Contains(".mobi") || chatdesc.Contains(".us") || chatdesc.Contains("<script>"))
                {

                }
                else
                {
                    if (chatdesc.Length >= 2 && chatdesc.Length < 150)
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
                objLst = PublicMstChatSelect(roomid, userid);
                return objLst;

            }
            catch (Exception)
            {

                throw;
            }
        }

        [OperationContract]
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


        // Add more operations here and mark them with [OperationContract]
    }
}
