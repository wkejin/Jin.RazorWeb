using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Jin.RazorWeb.Model
{
    public class User
    {
        /// <summary>
        /// 唯一标识Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string HeadPhotoUrl { get; set; }
        /// <summary>
        /// 用户状态(正常(1),封禁(0))
        /// </summary>
        public int State { get; set; }
    }
}