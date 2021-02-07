using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jin.RazorWeb.Model
{
    public class Article
    {
        /// <summary>
        /// 唯一标识Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 文章作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }
        /// <summary>
        /// 浏览数
        /// </summary>
        public int ViewCount { get; set; }
    }
}
