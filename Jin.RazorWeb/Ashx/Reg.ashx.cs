using Jin.RazorWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jin.RazorWeb.Ashx
{
    /// <summary>
    /// Reg 的摘要说明
    /// </summary>
    public class Reg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string username = context.Request["username"].ToString();
            string password = context.Request["password"].ToString();
            if(UserService.Create(username, password))
            {
                context.Response.Write("注册成功");
            }
            else
            {
                context.Response.Write("注册失败");
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