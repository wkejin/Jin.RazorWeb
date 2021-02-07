using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jin.RazorWeb.Model;
using Jin.RazorWeb.DAL;
using System.Web.SessionState;

namespace Jin.RazorWeb.Ashx
{
    /// <summary>
    /// CreateUpdateArticle 的摘要说明
    /// </summary>
    public class CreateUpdateArticle : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Article article = new Article()
            {
                Author = context.Session["CurrentUser"].ToString(),
                Title = context.Request["articleTitle"].ToString(),
                Content = HttpUtility.UrlDecode(context.Request["articleContent"].ToString()),
                CreateTime = DateTime.Now
            };
            if (ArticleService.Create(article))
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