using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jin.RazorWeb.Model
{
    public class Reply
    {
        /// <summary>
        /// 唯一标识Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 回复用户
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// 回复的评论的用户
        /// </summary>
        public string ToUser { get; set; }
        /// <summary>
        /// 回复的评论Id
        /// </summary>
        public int CommentId { get; set; }
        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime ReplyTime { get; set; }

    }
}