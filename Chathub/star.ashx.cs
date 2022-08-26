using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
 

namespace Chathub
{
    
    public class star : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int W = Int32.Parse(context.Request.QueryString["w"]);
            int H = Int32.Parse(context.Request.QueryString["h"]);
            string ImgUrl = context.Request.QueryString["iurl"];
            Image img = Image.FromFile(context.Server.MapPath("~/starimg/" + ImgUrl));
            Image _img = new Bitmap(W, H);
            Graphics g = Graphics.FromImage(_img);
            g.DrawImage(img, 0, 0, W, H);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            g.Dispose();
            img.Dispose();
            MemoryStream str = new MemoryStream();
            _img = _img.GetThumbnailImage(W, H, null, IntPtr.Zero);
            _img.Save(str, System.Drawing.Imaging.ImageFormat.Png);
            _img.Dispose();
            str.WriteTo(context.Response.OutputStream);
            str.Dispose();
            str.Close();
            context.Response.ContentType = ".png";
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}