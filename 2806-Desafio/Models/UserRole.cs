﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    [Table("[UserRole]")]
    internal class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
