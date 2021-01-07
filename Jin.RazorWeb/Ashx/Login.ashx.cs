using Jin.RazorWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Jin.RazorWeb.Ashx
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string username = context.Request["username"].ToString();
            string password = context.Request["password"].ToString();
            if(UserService.CheckLogin(username, password))
            {
                context.Session.Timeout = 60;
                context.Session["CurrentUser"] = username;
                context.Response.Write("登录成功");
            }
            else
            {
                context.Response.Write("登录失败");
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