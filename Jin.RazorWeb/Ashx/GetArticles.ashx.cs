using Jin.RazorWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Jin.RazorWeb.DAL;

namespace Jin.RazorWeb.Ashx
{
    /// <summary>
    /// GetArticles 的摘要说明
    /// </summary>
    public class GetArticles : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            List<Article> articles = ArticleService.GetArticles();
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy-MM-dd";
            string jsonArticles = JsonConvert.SerializeObject(articles, timeConverter);
            context.Response.Write(jsonArticles);
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