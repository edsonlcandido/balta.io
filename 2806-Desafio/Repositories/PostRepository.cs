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
    internal class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;
        public PostRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }
        public List<Post> GetWithCategoryAuthor()
        {
            var query = @"
                SELECT
                    [Post].*,
                    [Category].*,
                    [User].*
                FROM
                    [Post]
                    LEFT JOIN [Category] ON [Category].[Id] = [Post].[CategoryId]
                    LEFT JOIN [User] ON [User].[Id] = [Post].[AuthorId]";

            var posts = _connection.Query<Post, Category, User, Post>(query,
        (post, category, user) =>
        {
            return new Post
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body,
                Slug = post.Slug,
                Summary = post.Summary,
                CategoryId = post.CategoryId,
                AuthorId = post.AuthorId,
                Category = category,
                Author = user
            };
        },
        splitOn: "Id,Id");

            return posts.ToList();
        }
    }
}
