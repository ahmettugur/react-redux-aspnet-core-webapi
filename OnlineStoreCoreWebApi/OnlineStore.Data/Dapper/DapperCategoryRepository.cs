using Microsoft.Extensions.Configuration;
using OnlineStore.Core.Repository.Dapper;
using OnlineStore.Data.Contracts;
using OnlineStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace OnlineStore.Data.Dapper
{
    public class DapperCategoryRepository : DapperGenericRepository<Category>, ICategoryRepository
    {
        private SqlDbConnection _connection;
        public DapperCategoryRepository()
        {
            _connection = new SqlDbConnection();
        }
        public override IDbConnection Connection => _connection.GetSqlServerConnection();

        public override string TableName => "Categories";
    }
}
