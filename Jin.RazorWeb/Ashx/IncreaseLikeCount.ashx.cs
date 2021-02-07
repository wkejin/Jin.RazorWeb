using Jin.RazorWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jin.RazorWeb.Ashx
{
    /// <summary>
    /// IncreaseLikeCount 的摘要说明
    /// </summary>
    public class IncreaseLikeCount : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int videoId = Convert.ToInt32(context.Request["id"]);
            if(VideoService.IncreaseLikeCount(videoId))
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("error");
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