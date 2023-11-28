using AdoNetTask.Helpers;
using AdoNetTask.Models;
using System.Data;

namespace AdoNetTask.Services
{
    public class BlogService : IBaseService<Blog>
    {
        public int Create(Blog data)
        {
            string query = $"INSERT INTO Blogs VALUES (N'{data.Title}', N'{data.Description}', {data.UserId})";
            return SqlHelper.Exec(query);
        }
        public int Delete(int id)
        {
            string query = $"DELETE Blogs WHERE Id = {id}";
            return SqlHelper.Exec(query);
        }
        public ICollection<Blog> GetAll()
        {
            DataTable dt = SqlHelper.GetDatas("SELECT * FROM Blogs");
            ICollection<Blog> list = new List<Blog>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Blog
                {
                    Id = (int)row["Id"],
                    Title = (string)row["Title"],
                    Description = (string)row["Description"],
                    UserId = (int)row["UserId"]
                });
            }
            return list;
        }

        public Blog GetById(int id)
        {
            DataTable dt = SqlHelper.GetDatas($"SELECT * FROM Blogs WHERE Id = {id}");
            Blog blog = null;
            foreach (DataRow row in dt.Rows)
            {
                blog = new Blog
                {
                    Id = (int)row["Id"],
                    Title = (string)row["Title"],
                    Description = (string)row["Description"],
                    UserId = (int)row["UserId"]
                };
            }
            return blog;
        }

        public int Update(int id, Blog data)
        {
            throw new NotImplementedException();
        }
    }
}
