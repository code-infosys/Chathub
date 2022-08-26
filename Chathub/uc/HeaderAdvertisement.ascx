<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderAdvertisement.ascx.cs" Inherits="Chathub.uc.HeaderAdvertisement" %>
 
	 	<script runat="server">
			// This section defines Vserv invocasion code and should be used AS IS.
			// We recommend placing the following code in a separate file that is imported where needed. 
			string vservADRequest(string vservMsisdn, string vservMarkup, string vservZoneid, bool vservTestMode){
			try{
				StringBuilder vservParams = new StringBuilder();
				vservParams.Append("vr").Append("=").Append(Server.UrlEncode("1.1.0-csharp-20100726")).Append("&");
				vservParams.Append("tm").Append("=").Append(Server.UrlEncode(vservTestMode.ToString())).Append("&");
				vservParams.Append("ml").Append("=").Append(Server.UrlEncode(vservMarkup)).Append("&");
				vservParams.Append("si").Append("=").Append(Server.UrlEncode(Session.SessionID)).Append("&");
				vservParams.Append("mo").Append("=").Append(Server.UrlEncode(vservMsisdn)).Append("&");
				vservParams.Append("ip").Append("=").Append(Server.UrlEncode(Request.UserHostAddress)).Append("&");
	
				if(Request.Headers.GetValues("x-forwarded-for") != null)
					vservParams.Append("ff").Append("=").Append(Server.UrlEncode(Request.Headers["x-forwarded-for"])).Append("&");
				
				if(Request.Headers.GetValues("via") != null)
					vservParams.Append("hv").Append("=").Append(Server.UrlEncode(Request.Headers["via"])).Append("&");

				vservParams.Append("ht").Append("=").Append(Server.UrlEncode(Request.Headers["host"])).Append("&");
				vservParams.Append("ru").Append("=").Append(Server.UrlEncode(Request.Path)).Append("&");				
				vservParams.Append("ua").Append("=").Append(Server.UrlEncode(Request.UserAgent)).Append("&");

				if(Request.Headers.GetValues("x-operamini-phone-ua") != null)
					vservParams.Append("ou").Append("=").Append(Server.UrlEncode(Request.Headers["x-operamini-phone-ua"])).Append("&");

				if(Request.Headers.GetValues("x-wap-profile") != null)
					vservParams.Append("up").Append("=").Append(Server.UrlEncode(Request.Headers["x-wap-profile"])).Append("&");

				ArrayList vservNotToLog = ArrayList.Adapter(new String[] { "PRAGMA", "CACHE-CONTROL", "CONNECTION", "KEEP-ALIVE"});
				foreach (string vservHeaderName in Request.Headers){
				  if (!vservNotToLog.Contains(vservHeaderName.ToUpper())){
					vservParams.Append(Server.UrlEncode("hd["+vservHeaderName+"]")).Append("=").Append(Server.UrlEncode(Request.Headers[vservHeaderName])).Append("&");
					}
				}
				vservParams.Append("zoneid").Append("=").Append(Server.UrlEncode(vservZoneid));
				ASCIIEncoding vservAscii = new ASCIIEncoding();
				byte[] vservPostBytes = vservAscii.GetBytes(vservParams.ToString());
				string vservAdUrl= "http://rq.vserv.mobi/delivery/adapi.php?"+vservZoneid;
				System.Net.HttpWebRequest vservReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(vservAdUrl);		
				if (vservReq != null){
					vservReq.Method = "POST";
					vservReq.ContentType = "application/x-www-form-urlencoded";
					vservReq.ContentLength = vservPostBytes.Length;
					vservReq.Timeout = 7000;
					if(Context.Items["X-VSERV-CONTEXT"]!=null && !Context.Items["X-VSERV-CONTEXT"].ToString().Equals("")){
						vservReq.Headers.Add("X-VSERV-CONTEXT", Context.Items["X-VSERV-CONTEXT"].ToString());
					}
					// add post data to request
					System.IO.Stream vservPostStream = vservReq.GetRequestStream();
					vservPostStream.Write(vservPostBytes, 0, vservPostBytes.Length);
					vservPostStream.Close();
					System.Net.HttpWebResponse vservRes = (System.Net.HttpWebResponse) vservReq.GetResponse();
					string newVservContext=vservRes.GetResponseHeader("X-VSERV-CONTEXT");
					Context.Items.Remove("X-VSERV-CONTEXT");
					Context.Items.Add("X-VSERV-CONTEXT",newVservContext);
					System.IO.StreamReader vservSR = new System.IO.StreamReader(vservRes.GetResponseStream());
					StringBuilder vservOutput = new StringBuilder();
					vservOutput.Append(vservSR.ReadToEnd().Trim());
					vservSR.Close();
					return vservOutput.ToString();
				}else{return ""; }
				
				}catch (Exception vserve) { return "";}
		}
		</script>
		<%
		// In Case of Second request For the ad In same page. just Call the below Function with proper zoneid
		//Set vservTestMode to true for testing
		try{
			string vservMsisdn="";
			string vservMarkup="xhtml";
			string vservZoneid="7a5e6f17";	
			bool vservTestMode=false;	
			Response.Write(vservADRequest(vservMsisdn,vservMarkup, vservZoneid, vservTestMode));
		}catch (Exception vserve) {}
		%> 