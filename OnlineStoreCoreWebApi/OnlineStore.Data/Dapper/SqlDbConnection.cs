using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace OnlineStore.Data.Dapper
{
    public class SqlDbConnection
    {
        public IConfigurationRoot Configuration { get; set; }
        public SqlDbConnection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        public SqlConnection GetSqlServerConnection()
        {
            return new SqlConnection(Configuration["ConnectionStrings:OnlineStoreContext"]);
        }
    }
}
