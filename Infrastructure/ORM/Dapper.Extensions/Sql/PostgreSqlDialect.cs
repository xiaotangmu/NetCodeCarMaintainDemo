using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DapperExtensions.Sql
{
    public class PostgreSqlDialect : SqlDialectBase
    {
        public override string GetIdentitySql(string tableName)
        {
            return "SELECT LASTVAL() AS Id";
        }

        public override string GetPagingSql(string sql, int page, int resultsPerPage, IDictionary<string, object> parameters)
        {
            return GetSetSql(sql, page, resultsPerPage, parameters);
        }

        public override string GetSetSql(string sql, int pageNumber, int maxResults, IDictionary<string, object> parameters)
        {
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            //可用于设置为-1时，返回全部数据
            if (pageNumber < 0)
            {
                return sql;
            }
            pageNumber = pageNumber - 1;//常规地页面从1开始，但postgresql中以0为第一行

            string result = string.Format("{0} LIMIT @maxResults OFFSET @pageStartRowNbr", sql);
            parameters.Add("@maxResults", maxResults);
            parameters.Add("@pageStartRowNbr", pageNumber * maxResults);
            return result;
        }

        public override string GetColumnName(string prefix, string columnName, string alias)
        {
            return base.GetColumnName(null, columnName, alias).ToLower();
        }

        public override string GetTableName(string schemaName, string tableName, string alias)
        {
            return base.GetTableName(schemaName, tableName, alias).ToLower();
        }
    }

}
