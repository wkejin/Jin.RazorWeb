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
    public class PictureService
    {
        private static Picture ToModel(DataRow row)
        {
            Picture picture = new Picture()
            {
                Id = Convert.ToInt32(row["Id"]),
                Url = row["Url"].ToString(),
                Title = row["Title"].ToString(),
                UploadUser = row["UploadUser"].ToString(),
                AlbumId = Convert.ToInt32(row["AlbumId"]),
            };
            return picture;
        }

        public static List<Picture> GetPictures()
        {
            string sqlStr = "select * from Pictures order by Id desc";
            DataTable table = SqlHelper.GetDataTable(sqlStr);
            List<Picture> pictures = new List<Picture>();
            foreach (DataRow row in table.Rows)
            {
                Picture picture = ToModel(row);
                pictures.Add(picture);
            }
            return pictures;
        }

        public static Picture GetPicture(int id)
        {
            string sqlStr = "select * from Pictures where Id=@Id";
            SqlParameter parameter = new SqlParameter("Id", id);
            DataTable table = SqlHelper.GetDataTable(sqlStr, parameter);
            Picture picture = ToModel(table.Rows[0]);
            return picture;
        }
    }
}
