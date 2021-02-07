using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jin.RazorWeb.Model
{
    public class Picture
    {
        /// <summary>
        /// 唯一标识Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 图片标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 所在相册Id，可为空
        /// </summary>
        public int? AlbumId { get; set; }
        /// <summary>
        /// 上传用户
        /// </summary>
        public string UploadUser { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? UploadTime { get; set; }
    }
}
