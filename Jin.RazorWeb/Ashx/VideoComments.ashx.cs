using Jin.RazorWeb.DAL;
using Jin.RazorWeb.Model;
using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Web.SessionState;

namespace Jin.RazorWeb.Ashx
{
    /// <summary>
    /// VideoComments 的摘要说明
    /// </summary>
    public class VideoComments : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if(context.Request["act"].ToString() == "get")  //获取评论
            {
                int videoId = Convert.ToInt32(context.Request.QueryString["videoId"]);
                List<VideoComment> videoComments = VideoCommentService.GetVideoComments(videoId);
                IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
                timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm";
                string jsonComments = JsonConvert.SerializeObject(videoComments, Formatting.Indented, timeConverter);
                context.Response.Write(jsonComments);
            }
            else //添加评论
            {
                int videoId = Convert.ToInt32(context.Request["videoId"]);
                string content = context.Request["commentContent"].ToString();
                string commentUser = context.Session["CurrentUser"].ToString();
                DateTime commentTime = DateTime.Now;
                VideoComment comment = new VideoComment()
                {
                    VideoId = videoId,
                    CommentUser = commentUser,
                    CommentTime = commentTime,
                    Content = content
                };
                if (VideoCommentService.Create(comment))
                {
                    context.Response.Write("评论成功");
                }
                else
                {
                    context.Response.Write("评论失败");
                }
            }
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