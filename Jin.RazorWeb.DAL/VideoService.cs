using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jin.RazorWeb.DAL
{
    public static class VideoService
    {
        private static Video ToModel(DataRow row)
        {
            Video video = new Video()
            {
                Id = Convert.ToInt32(row["Id"]),
                Url = row["Url"].ToString(),
                Title = row["Title"].ToString(),
                CoverUrl = row["CoverUrl"].ToString(),
                UploadUser = row["UploadUser"].ToString(),
                UploadTime = Convert.ToDateTime(row["UploadTime"]),
                Description = row["Description"].ToString(),
                LikeCount = Convert.ToInt32(row["LikeCount"])
            };
            return video;
        }
        public static List<Video> GetVideos()
        {
            string sqlStr = "select * from Videos";
            DataTable table = SqlHelper.GetDataTable(sqlStr);
            List<Video> videos = new List<Video>();
            foreach (DataRow row in table.Rows)
            {
                Video video = ToModel(row);
                videos.Add(video);
            }
            return videos;
        }

        /// <summary>
        /// 通过Id查询获得一个Video实例
        /// </summary>
        /// <param name="id">视频Id</param>
        /// <returns>返回查询出的具体Video实例</returns>
        public static Video GetVideo(int id)
        {
            string sqlStr = "select * from Videos where Id=@Id";
            SqlParameter parameter = new SqlParameter("Id", id);
            DataTable table = SqlHelper.GetDataTable(sqlStr, parameter);
            Video video = ToModel(table.Rows[0]);
            return video;
        }

        /// <summary>
        /// 创建视频，添加一个视频的信息到数据库
        /// </summary>
        /// <param name="video">要添加的视频实例</param>
        /// <returns>返回true表示添加成功，false表示失败</returns>
        public static bool Create(Video video)
        {
            string sqlStr = "insert into Videos(Url,Title,UploadUser,UploadTime) values(@Url,@Title,@UploadUser,@UploadTime)";
            SqlParameter[] parameters =
            {
                new SqlParameter("Url", video.Url),
                new SqlParameter("Title", video.Title),
                new SqlParameter("UploadUser", video.UploadUser),
                new SqlParameter("UploadTime", video.UploadTime)
            };
            int result = SqlHelper.ExecuteNonQuery(sqlStr, parameters);
            if(result >= 1)
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
