using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Jin.RazorWeb.DAL;
using System.Web.SessionState;

namespace Jin.RazorWeb.Ashx
{
    /// <summary>
    /// UploadVideo 的摘要说明
    /// </summary>
    public class UploadVideo : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (context.Request.Files.Count > 0)
            {
                string videoName = context.Request.Files["videoFile"].FileName;
                string videoPath = context.Server.MapPath(@"../Upload/Videos");
                string title = context.Request["Title"].ToString();
                DateTime uploadTime = DateTime.Now;
                string uploadUser = context.Session["CurrentUser"].ToString();
                Video video = new Video()
                {
                    Url = "Upload/Videos/" + videoName,
                    Title = title,
                    UploadUser = uploadUser,
                    UploadTime = uploadTime,
                };
                if(VideoService.Create(video))
                {
                    HttpPostedFile postedFile = context.Request.Files["videoFile"];
                    postedFile.SaveAs(context.Request.MapPath("..//" + video.Url));
                    context.Response.Write("上传成功");
                }
                else
                {
                    context.Response.Write("上传失败");
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