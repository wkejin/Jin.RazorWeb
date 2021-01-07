using Jin.RazorWeb.DAL;
using Jin.RazorWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Jin.RazorWeb.Ashx
{
    /// <summary>
    /// VideoComments 的摘要说明
    /// </summary>
    public class VideoComments : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int videoId = Convert.ToInt32(context.Request.QueryString["videoId"]);
            List<VideoComment> videoComments = VideoCommentService.GetVideoComments(videoId);
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm";
            string jsonComments = JsonConvert.SerializeObject(videoComments, Formatting.Indented, timeConverter);
            context.Response.Write(jsonComments);
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