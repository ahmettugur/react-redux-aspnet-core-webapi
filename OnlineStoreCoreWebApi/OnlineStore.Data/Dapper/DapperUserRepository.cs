using Dapper;
using OnlineStore.Core.Repository.Dapper;
using OnlineStore.Data.Contracts;
using OnlineStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OnlineStore.Data.Dapper
{
    public class DapperUserRepository : DapperGenericRepository<User>, IUserRespository
    {
        private SqlDbConnection _connection;
        public DapperUserRepository()
        {
            _connection = new SqlDbConnection();
        }
        public override IDbConnection Connection => _connection.GetSqlServerConnection();

        public override string TableName => "Users";

        public string[] GetUserRoles(User user)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT r.Id,r.Name FROM Roles r " +
                    "INNER JOIN UserRoles ur ON r.Id = ur.RoleId " +
                    "WHERE ur.UserId = @UserId";

                conn.Open();
                string[] role = conn.Query<Role>(sql, new { user.UserId }).ToList().Select(_ => _.Name).ToArray();
                conn.Close();
                return role;
            }
        }
    }
}
