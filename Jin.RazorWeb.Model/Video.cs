using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jin.RazorWeb.DAL
{
    public class Video
    {
        /// <summary>
        /// 唯一标识Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 视频地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 视频标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 视频封面
        /// </summary>
        public string CoverUrl { get; set; }
        /// <summary>
        /// 视频上传的日期时间
        /// </summary>
        public DateTime UploadTime { get; set; }
        /// <summary>
        /// 视频上传用户
        /// </summary>
        public string UploadUser { get; set; }
        /// <summary>
        /// 视频简介
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 播放数
        /// </summary>
        public int PlayCount { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int LikeCount { get; set; }

    }
}