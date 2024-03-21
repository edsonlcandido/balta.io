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
    internal class UserRoleRepository : Repository<UserRole>
    {
        private readonly SqlConnection _connection;
        public UserRoleRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }
        public void DeleteRole(UserRole  userRole)
        {
            var query = "DELETE FROM [UserRole] WHERE UserId = @userId AND RoleId = @roleId";
            _connection.Query(query, userRole);
        }
    }
}
