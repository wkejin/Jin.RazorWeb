using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Jin.RazorWeb.Model;

namespace Jin.RazorWeb.DAL
{
    public static class UserService
    {
        /// <summary>
        /// 将查询出来的DataTable行转换为具体的用户实例
        /// </summary>
        /// <param name="row">DataTable的DataRow</param>
        /// <returns></returns>
        private static User ToModel(DataRow row)
        {
            User user = new User()
            {
                Id = Convert.ToInt32(row["Id"]),
                UserName = row["UserName"].ToString(),
                Password = row["Password"].ToString(),
                HeadPhotoUrl = row["HeadPhotoUrl"].ToString(),
                State = Convert.ToInt32(row["State"])
            };
            return user;
        }

        /// <summary>
        /// 创建用户（注册）
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>返回true表示创建成功，false表示创建失败</returns>
        public static bool Create(string username, string password)
        {
            string sqlStr = "insert into Users(UserName,Password) values(@UserName,@Password)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserName", username),
                new SqlParameter("@Password", password)
            };
            bool res = SqlHelper.ExecuteNonQuery(sqlStr, parameters) >= 1 ? true : false;
            return res;
        }

        /// <summary>
        /// 删除一个用户(通过用户Id)
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns>返回true表示删除成功，false表示删除失败</returns>
        public static bool Remove(int id)
        {
            string sqlStr = "delete from Users where Id=@Id";
            SqlParameter parameter = new SqlParameter("Id", id);
            bool res = SqlHelper.ExecuteNonQuery(sqlStr) >= 1 ? true : false;
            return res;
        }

        /// <summary>
        /// 判断用户输入的用户名是否已经存在
        /// </summary>
        /// <param name="username">输入的用户名</param>
        /// <returns>返回true表示该用户名已存在,false表示不存在</returns>
        public static bool IsExisted(string username)
        {
            string sqlStr = "select count(*) from Users where UserName=@UserName";
            SqlParameter parameter = new SqlParameter("UserName", username);
            int result = Convert.ToInt32(SqlHelper.ExecuteScalar(sqlStr, parameter));
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查用户登录信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>返回true表示登录成功，false为失败</returns>
        public static bool CheckLogin(string username, string password)
        {
            string sqlStr = "select count(*) from Users where UserName=@UserName and Password=@Password";
            SqlParameter[] parameters =
            {
                new SqlParameter("UserName", username),
                new SqlParameter("Password", password)
            };
            int result = Convert.ToInt32(SqlHelper.ExecuteScalar(sqlStr, parameters));
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns>返回一个存储所有用户对象信息的泛型集合</returns>
        public static List<User> GetUsers()
        {
            string sqlStr = "select * from Users";
            DataTable table = SqlHelper.GetDataTable(sqlStr);
            List<User> users = new List<User>();
            foreach (DataRow row in table.Rows)
            {
                User user = ToModel(row);
                users.Add(user);
            }
            return users;
        }

        /// <summary>
        /// 更新用户头像信息
        /// </summary>
        /// <param name="url">头像地址</param>
        /// <returns>返回true表示更新成功，false表示失败</returns>
        public static bool UpdateHeadPhoto(string url)
        {
            string sqlStr = "update Users set HeadPhotoUrl=@HeadPhotoUrl";
            SqlParameter parameter = new SqlParameter("HeadPhotoUrl", url);
            bool res = SqlHelper.ExecuteNonQuery(sqlStr, parameter) >= 1 ? true : false;
            return res;
        }

        /// <summary>
        /// 根据用户名查找用户头像
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public static string GetHeadPhoto(string username)
        {
            string sqlStr = "select HeadPhoto from Users where UserName=@UserName";
            SqlParameter parameter = new SqlParameter("UserName", username);
            return SqlHelper.ExecuteScalar(sqlStr, parameter).ToString();
        }
    }
}
