using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Core.Repository.Dapper
{
    internal class SqlQueryParameter
    {
        internal SqlQueryParameter(string linkingOperator, string propertyName, dynamic propertyValue, string queryOperator)
        {
            LinkingOperator = linkingOperator;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            QueryOperator = queryOperator;
        }

        public string LinkingOperator { get; set; }
        public string PropertyName { get; set; }
        public dynamic PropertyValue { get; set; }
        public string QueryOperator { get; set; }


    }
}
