using OnlineStore.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace OnlineStore.Core.Repository.Dapper
{
    public sealed class GenerateDynamicQuery
    {

        public static string GenerateInsertQuery(string tableName, dynamic item)
        {
            PropertyInfo[] props = item.GetType().GetProperties();
            List<string> columns = new List<string>();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetCustomAttribute(typeof(PrimaryKeyAttribute)) == null)
                {
                    columns.Add(prop.Name);
                }
            }

            return $"INSERT INTO {tableName} ({string.Join(",", columns)}) VALUES (@{string.Join(",@", columns)})";
        }

        public static string GenerateUpdateQuery(string tableName, dynamic item)
        {
            PropertyInfo[] props = item.GetType().GetProperties();
            string[] columns = props.Select(p => p.Name).ToArray();

            var parameters = columns.Select(name => name + "=@" + name).ToList();

            return $"UPDATE {tableName} SET {string.Join(",", parameters)} WHERE ID=@ID";
        }

        public static DynamicQueryResult GetDynamicQuery<T>(string tableName, Expression<Func<T, bool>> expression)
        {
            var queryProperties = new List<SqlQueryParameter>();
            var body = (BinaryExpression)expression.Body;
            IDictionary<string, Object> expando = new ExpandoObject();
            var builder = new StringBuilder();

            ExpressionTree(body, ExpressionType.Default, ref queryProperties);

            builder.Append("SELECT * FROM ");
            builder.Append(tableName);
            builder.Append(" WHERE ");

            for (int i = 0; i < queryProperties.Count(); i++)
            {
                SqlQueryParameter item = queryProperties[i];

                if (!string.IsNullOrEmpty(item.LinkingOperator) && i > 0)
                {
                    builder.Append(string.Format("{0} {1} {2} @{1} ", item.LinkingOperator, item.PropertyName, item.QueryOperator));
                }
                else
                {
                    builder.Append(string.Format("{0} {1} @{0} ", item.PropertyName, item.QueryOperator));
                }

                expando[item.PropertyName] = item.PropertyValue;
            }

            return new DynamicQueryResult(builder.ToString().TrimEnd(), expando);
        }

        private static void ExpressionTree(BinaryExpression body, ExpressionType linkingType,
                             ref List<SqlQueryParameter> queryProperties)
        {
            if (body.NodeType != ExpressionType.AndAlso && body.NodeType != ExpressionType.OrElse)
            {
                string propertyName = GetPropertyName(body);
                dynamic propertyValue = body.Right is MemberExpression ? GetPropertyValue((MemberExpression)body.Right) : body.Right;
                string opr = GetOperator(body.NodeType);
                string link = GetOperator(linkingType);

                queryProperties.Add(new SqlQueryParameter(link, propertyName, propertyValue, opr));
            }
            else
            {
                ExpressionTree((BinaryExpression)body.Left, body.NodeType, ref queryProperties);
                ExpressionTree((BinaryExpression)body.Right, body.NodeType, ref queryProperties);
            }
        }

        private static object GetPropertyValue(MemberExpression member)
        {
            var objectMember = Expression.Convert(member, typeof(object));
            var getterLambda = Expression.Lambda<Func<object>>(objectMember);
            var getter = getterLambda.Compile();

            return getter();
        }
        private static string GetPropertyName(BinaryExpression body)
        {
            string propertyName = body.Left.ToString().Split(new char[] { '.' })[1];

            if (body.Left.NodeType == ExpressionType.Convert)
            {
                propertyName = propertyName.Replace(")", string.Empty);
            }

            return propertyName;
        }

        private static string GetOperator(ExpressionType type)
        {
            switch (type)
            {
                case ExpressionType.Equal:
                    return "=";
                case ExpressionType.NotEqual:
                    return "!=";
                case ExpressionType.LessThan:
                    return "<";
                case ExpressionType.GreaterThan:
                    return ">";
                case ExpressionType.AndAlso:
                case ExpressionType.And:
                    return "AND";
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    return "OR";
                case ExpressionType.Default:
                    return string.Empty;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}