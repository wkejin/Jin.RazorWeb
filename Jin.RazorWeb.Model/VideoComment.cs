using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jin.RazorWeb.Model
{
    public class VideoComment
    {
        /// <summary>
        /// 唯一标识Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 评论用户
        /// </summary>
        public string CommentUser { get; set; }
        /// <summary>
        /// 评论的视频Id
        /// </summary>
        public int VideoId { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CommentTime { get; set; }

    }
}