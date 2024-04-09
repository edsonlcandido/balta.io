using Blog.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    internal class CategoryPosts
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int PostCount { get; set; } = 0;
    }
}
