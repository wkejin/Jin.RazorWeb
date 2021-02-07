using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jin.RazorWeb.Model
{
    public class Album
    {
        /// <summary>
        /// 唯一标识Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 相册名称
        /// </summary>
        public string AlbumName { get; set; }
        /// <summary>
        /// 相册所属用户
        /// </summary>
        public string AlbumUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 相册描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }
        /// <summary>
        /// 浏览数
        /// </summary>
        public int ViewCount { get; set; }
    }
}
