using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    internal class CategoryRepository : Repository<CategoryPosts>
    {
        private readonly SqlConnection _connection;
        public CategoryRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }
        public List<CategoryPosts> GetCategoryPosts()
        {
            string query = @"SELECT c.Id as CategoryId, c.Name as  CategoryName, COUNT(p.Id) as PostCount
FROM Category c
LEFT JOIN Post p ON c.Id = p.CategoryId
GROUP BY c.Id, c.Name
ORDER BY PostCount DESC,  CategoryName ASC;";
            var categoriesPost = _connection.Query<CategoryPosts>(query).ToList();

            return categoriesPost;
        }
    }
}
