using Dapper;
using OnlineStore.Core.Repository.Dapper;
using OnlineStore.Data.Contracts;
using OnlineStore.Entity.ComplexType;
using OnlineStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OnlineStore.Data.Dapper
{
    public class DapperProductRepository : DapperGenericRepository<Product>, IProductRepository
    {
        private SqlDbConnection _connection;
        public DapperProductRepository()
        {
            _connection = new SqlDbConnection();
        }
        public override IDbConnection Connection => _connection.GetSqlServerConnection();

        public override string TableName => "Products";

        public List<ProductWithCategory> GetAllProductWithCategory()
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT p.Id " +
                    "ProductId,p.CategoryId ," +
                    "p.Name,p.Price," +
                    "p.StockQuantity," +
                    "c.Name CategoryName, " +
                    "p.Details FROM Products p " +
                    "INNER JOIN Categories c on p.CategoryId = c.Id";

                List<ProductWithCategory> productWithCategory = conn.Query<ProductWithCategory>(sql).ToList();

                return productWithCategory;
            }
        }
    }
}
