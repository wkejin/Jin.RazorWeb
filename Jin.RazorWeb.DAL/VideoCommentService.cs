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
    public static class VideoCommentService
    {
        /// <summary>
        /// 将查询出的数据转换成VideoComment实例
        /// </summary>
        /// <param name="row">查询出的数据行</param>
        /// <returns>返回VideoComment实例</returns>
        private static VideoComment ToModel(DataRow row)
        {
            VideoComment videoComment = new VideoComment()
            {
                Id = Convert.ToInt32(row["Id"]),
                Content = row["Content"].ToString(),
                User = row["User"].ToString(),
                VideoId = Convert.ToInt32(row["VideoId"]),
                CommentTime = Convert.ToDateTime(row["CommentTime"])
            };
            return videoComment;
        }

        /// <summary>
        /// 获取指定视频下的所有评论
        /// </summary>
        /// <param name="videoId">视频Id</param>
        /// <returns>返回视频评论的集合</returns>
        public static List<VideoComment> GetVideoComments(int videoId)
        {
            List<VideoComment> videoComments = new List<VideoComment>();
            string sqlStr = "select * from VideoComments where VideoId=@VideoId";
            SqlParameter parameter = new SqlParameter("VideoId", videoId);
            DataTable table = SqlHelper.GetDataTable(sqlStr, parameter);
            foreach (DataRow row in table.Rows)
            {
                VideoComment videoComment = ToModel(row);
                videoComments.Add(videoComment);
            }
            return videoComments;
        }

        /// <summary>
        /// 添加一条评论
        /// </summary>
        /// <param name="videoComment">评论实例</param>
        /// <returns>返回true表示添加成功，false表示失败</returns>
        public static bool Create(VideoComment videoComment)
        {
            string sqlStr = "insert into VideoComments(Content,User,VideoId,CommentTime) values(@Content,@User,@VideoId,@CommentTime)";
            SqlParameter[] parameters =
            {
                new SqlParameter("Content", videoComment.Content),
                new SqlParameter("User", videoComment.User),
                new SqlParameter("VideoId", videoComment.VideoId),
                new SqlParameter("CommentTime", videoComment.CommentTime),
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
    }
}
