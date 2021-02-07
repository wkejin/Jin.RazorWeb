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
    public class ArticleService
    {
        /// <summary>
        /// 将查询出的数据DataTable行转换为文章实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private static Article ToModel(DataRow row)
        {
            Article article = new Article()
            {
                Id = Convert.ToInt32(row["Id"]),
                Author = row["Author"].ToString(),
                Title = row["Title"].ToString(),
                Content = row["Content"].ToString(),
                CreateTime = Convert.ToDateTime(row["CreateTime"]),
                ViewCount = Convert.ToInt32(row["ViewCount"])
            };
            if(!(row["LastUpdateTime"] is DBNull))
            {
                article.LastUpdateTime = Convert.ToDateTime(row["LastUpdateTime"]);
            }
            return article;
        }

        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        public static List<Article> GetArticles()
        {
            string sqlStr = "select * from Articles order by Id desc";
            DataTable table = SqlHelper.GetDataTable(sqlStr);
            List<Article> articles = new List<Article>();
            foreach (DataRow row in table.Rows)
            {
                Article article = ToModel(row);
                articles.Add(article);
            }
            return articles;
        }

        public static Article GetArticle(int id)
        {
            string sqlStr = "select * from Articles where Id=@Id";
            SqlParameter parameter = new SqlParameter("Id", id);
            Article article = ToModel(SqlHelper.GetDataTable(sqlStr, parameter).Rows[0]);
            return article;
        }

        /// <summary>
        /// 浏览数+1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IncreaseViewCount(int id)
        {
            string sqlStr = "update Articles set ViewCount=ViewCount+1 where Id=@Id";
            SqlParameter parameter = new SqlParameter("Id", id);
            bool res = SqlHelper.ExecuteNonQuery(sqlStr, parameter) >= 1 ? true : false;
            return res;
        }

        /// <summary>
        /// 创建文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static bool Create(Article article)
        {
            string sqlStr = "insert into Articles(Author,Title,Content,CreateTime) values(@Author,@Title,@Content,@CreateTime)";
            SqlParameter[] parameters =
            {
                new SqlParameter("Author", article.Author),
                new SqlParameter("Title", article.Title),
                new SqlParameter("Content", article.Content),
                new SqlParameter("CreateTime", article.CreateTime)
            };
            bool res = SqlHelper.ExecuteNonQuery(sqlStr, parameters) >= 1 ? true : false;
            return res;
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public static bool Remove(int articleId)
        {
            string sqlStr = "delete from Articles where Id=@Id";
            SqlParameter parameter = new SqlParameter("Id", articleId);
            bool res = SqlHelper.ExecuteNonQuery(sqlStr, parameter) >= 1 ? true : false;
            return res;
        }

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static bool Update(Article article)
        {
            string sqlStr = "update Articles set Author=@Author,Title=@Title,Content=@Content,LastUpdateTime=@LastUpdateTime where Id=@Id";
            SqlParameter[] parameters =
            {
                new SqlParameter("Author", article.Author),
                new SqlParameter("Title", article.Title),
                new SqlParameter("Content", article.Content),
                new SqlParameter("LastUpdateTime", article.LastUpdateTime),
                new SqlParameter("Id", article.Id)
            };
            bool res = SqlHelper.ExecuteNonQuery(sqlStr, parameters) >= 1 ? true : false;
            return res;
        }

        /// <summary>
        /// 浏览数+1
        /// </summary>
        /// <returns></returns>
        public static bool IncreaseViewCount()
        {
            string sqlStr = "update Articles set ViewCount=ViewCount+1";
            bool res = SqlHelper.ExecuteNonQuery(sqlStr) >= 1 ? true : false;
            return res;
        }
    }
}
