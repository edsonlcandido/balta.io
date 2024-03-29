using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Blog.Models
{
    [Table("[Post]")]
    public class Post
    {
        public Post()
        {
            Tags = new List<Tag>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        [Write(false)]
        public Category Category { get; set; }
        [Write(false)]
        public User Author { get; set; }
        [Write(false)]
        public List<Tag> Tags { get; set; }
    }
}