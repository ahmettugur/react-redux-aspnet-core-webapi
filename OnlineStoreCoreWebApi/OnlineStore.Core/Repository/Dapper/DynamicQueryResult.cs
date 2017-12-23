using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Core.Repository.Dapper
{
    public class DynamicQueryResult
    {
        private string sql;
        private dynamic parameter;

        public DynamicQueryResult(string sql, dynamic parameter)
        {
            this.sql = sql;
            this.parameter = parameter;
        }

        public string Sql { get => sql; set => sql = value; }
        public dynamic Parameter { get => parameter; set => parameter = value; }
    }
}
