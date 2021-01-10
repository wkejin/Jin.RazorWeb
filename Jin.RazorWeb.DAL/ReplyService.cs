using Jin.RazorWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jin.RazorWeb.DAL
{
    public static class ReplyService
    {
        /// <summary>
        /// 创建回复
        /// </summary>
        /// <param name="reply">回复实例</param>
        /// <returns>返回true表示创建成功，false表示失败</returns>
        public static bool Create(Reply reply)
        {
            string sqlStr = "insert into Replies(ReplyUser,ToUser,ReplyTime,ReplyContent,CommentId) values(@ReplyUser,@ToUser,@ReplyTime,@ReplyContent,@CommentId)";
            SqlParameter[] parameters =
            {
                new SqlParameter("ReplyUser", reply.ReplyUser),
                new SqlParameter("ToUser", reply.ToUser),
                new SqlParameter("ReplyTime", reply.ReplyTime),
                new SqlParameter("ReplyContent", reply.Content),
                new SqlParameter("CommentId", reply.CommentId),
            };
            int result = SqlHelper.ExecuteNonQuery(sqlStr, parameters);
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 通过评论Id获取其下的所有回复
        /// </summary>
        /// <param name="commentId">评论Id</param>
        /// <returns>返回回复的集合</returns>
        public static List<Reply> GetReplies(int commentId)
        {
            List<Reply> replies = new List<Reply>();
            string sqlStr = "select * from Replies where CommentId=@CommentId";
            SqlParameter parameter = new SqlParameter("CommentId", commentId);
            DataTable table = SqlHelper.GetDataTable(sqlStr, parameter);
            foreach (DataRow row in table.Rows)
            {
                Reply reply = ToModel(row);
                replies.Add(reply);
            }
            return replies;
        }

        /// <summary>
        /// 将查询出的DataTable转换为Reply实例
        /// </summary>
        /// <param name="row">DataTable的行</param>
        /// <returns>返回回复实例</returns>
        private static Reply ToModel(DataRow row)
        {
            Reply reply = new Reply()
            {
                Id = Convert.ToInt32(row["Id"]),
                Content = row["ReplyContent"].ToString(),
                ReplyUser = row["ReplyUser"].ToString(),
                ToUser = row["ToUser"].ToString(),
                ReplyTime = Convert.ToDateTime(row["ReplyTime"]),
                CommentId = Convert.ToInt32(row["CommentId"])
            };
            return reply;
        }
    }
}
