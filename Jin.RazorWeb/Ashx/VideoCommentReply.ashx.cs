using Jin.RazorWeb.DAL;
using Jin.RazorWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Jin.RazorWeb.Ashx
{
    /// <summary>
    /// VideoCommentReply 的摘要说明
    /// </summary>
    public class VideoCommentReply : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            
            if(context.Request["act"].ToString() == "create")
            {
                int commentId = Convert.ToInt32(context.Request["commentId"]);
                string replyUser = context.Session["CurrentUser"].ToString();
                string toUser = context.Request["commentUser"].ToString();
                DateTime replyTime = DateTime.Now;
                string replyContent = context.Request["replyContent"].ToString();
                Reply reply = new Reply()
                {
                    Content = replyContent,
                    ReplyUser = replyUser,
                    ReplyTime = replyTime,
                    ToUser = toUser,
                    CommentId = commentId
                };
                if(ReplyService.Create(reply))
                {
                    context.Response.Write("回复成功");
                }
                else
                {
                    context.Response.Write("回复失败");
                }
            }
            else
            {
                int commentId = Convert.ToInt32(context.Request["commentId"]);
                List<Reply> replies = ReplyService.GetReplies(commentId);
                IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
                timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm";
                string jsonReplies = JsonConvert.SerializeObject(replies, Formatting.Indented, timeConverter);
                context.Response.Write(jsonReplies);
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