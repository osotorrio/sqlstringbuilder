using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SqlBuilder.Core
{
    public class SqlSb : ICommonStatements, IQueryCommands, ICUDCommands
    {
        public string Status
        {
            get { return _query.ToString(); }
        }

        private readonly StringBuilder _query;

        public SqlSb()
        {
            _query = new StringBuilder();
        }

        #region IQueryCommands Implementation
        public SqlSb SelectAll()
        {
            return AppendSpaceAtTheEnd("SELECT ALL *");
        }

        public SqlSb SelectDistinct()
        {
            return AppendSpaceAtTheEnd("SELECT DISTINCT *");
        }

        public SqlSb Select(string parameters)
        {
            return AppendSpaceAtTheEnd("SELECT", parameters);
        }

        public SqlSb OrderByAscending(string columnNames)
        {
            return OrderBy(columnNames, "ASC");
        }

        public SqlSb OrderByDescending(string columnNames)
        {
            return OrderBy(columnNames, "DESC");
        }
        #endregion

        #region ICUDCommands Implementation
        public SqlSb InsertInto(string tableName)
        {
            return AppendSpaceAtTheEnd("INSERT INTO", tableName);
        }

        public SqlSb Update(string tableName)
        {
            return AppendSpaceAtTheEnd("UPDATE", tableName);
        }

        public SqlSb Set(string columnValuePairs)
        {
            return AppendSpaceAtTheEnd("SET", columnValuePairs);
        }

        public SqlSb Values(string valuesSeparatedByComa)
        {
            var matches = Regex.Matches(valuesSeparatedByComa, @"\w+").Cast<Match>();
            var columns = string.Join(", ", matches);
            _query.AppendFormat("({0}) VALUES ({1}) ", columns, valuesSeparatedByComa);
            return this;
        }

        public SqlSb Delete()
        {
            return AppendSpaceAtTheEnd("DELETE");
        }
        #endregion

        #region ICommonStatements Implementation
        public SqlSb From(string tableNamesSeparatedByComa)
        {
            return AppendSpaceAtTheEnd("FROM", tableNamesSeparatedByComa);
        }

        public SqlSb Where(string conditions)
        {
            return AppendSpaceAtTheEnd("WHERE", conditions);
        }

        public SqlSb IsNull()
        {
            return AppendSpaceAtTheEnd("IS NULL");
        }

        public SqlSb IsNotNull()
        {
            return AppendSpaceAtTheEnd("IS NOT NULL");
        }

        public SqlSb And(string conditions)
        {
            return AppendSpaceAtTheEnd("AND", conditions);
        }

        public SqlSb Or(string conditions)
        {
            return AppendSpaceAtTheEnd("OR", conditions);
        }

        public SqlSb Between(string parameter)
        {
            return AppendSpaceAtTheEnd("BETWEEN", parameter);
        }

        public SqlSb Like(string parameter)
        {
            return AppendSpaceAtTheEnd("LIKE", parameter);
        }
        #endregion

        #region Private Methods
        private SqlSb AppendSpaceAtTheEnd(string sqlStatement)
        {
            _query.AppendFormat("{0} ", sqlStatement).ToString();
            return this;
        }

        private SqlSb AppendSpaceAtTheEnd(string sqlStatement, string parameters)
        {
            _query.AppendFormat("{0} {1} ", sqlStatement, parameters).ToString();
            return this;
        }

        private SqlSb AppendSpaceAtTheEnd(string sqlStatement1, string parameters, string sqlStatement2)
        {
            _query.AppendFormat("{0} {1} {2} ", sqlStatement1, parameters, sqlStatement2).ToString();
            return this;
        }

        private SqlSb TrimEndBeforeAppendSpaceAtTheEnd(string sqlStatement1, string parameters, string sqlStatement2)
        {
            _query.TrimEnd();
            return AppendSpaceAtTheEnd(sqlStatement1, parameters, sqlStatement2);
        }

        private SqlSb OrderBy(string columnNames, string direction)
        {
            return _query.ToString().Contains("ORDER BY")
                ? TrimEndBeforeAppendSpaceAtTheEnd(",", columnNames, direction)
                : AppendSpaceAtTheEnd("ORDER BY", columnNames, direction);
        }
        #endregion

        public override string ToString()
        {
            _query.TrimEnd();
            _query.Append(";");
            return _query.ToString();
        }
    }
}
