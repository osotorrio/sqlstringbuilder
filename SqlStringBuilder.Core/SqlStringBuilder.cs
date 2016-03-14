﻿using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SqlBuilder.Core
{
    public class SqlStringBuilder : ICommonStatements, IQueryCommands, ICUDCommands
    {
        public string Status
        {
            get { return _query.ToString(); }
        }

        private readonly StringBuilder _query;

        public SqlStringBuilder()
        {
            _query = new StringBuilder();
        }

        #region IQueryCommands Implementation
        public string SemiColon()
        {
            _query.TrimEnd();
            _query.Append(";");
            return _query.ToString();
        }

        public SqlStringBuilder SelectAll()
        {
            return AppendSpaceAtTheEnd("SELECT ALL *");
        }

        public SqlStringBuilder SelectDistinct()
        {
            return AppendSpaceAtTheEnd("SELECT DISTINCT *");
        }

        public SqlStringBuilder Select(string parameters)
        {
            return AppendSpaceAtTheEnd("SELECT", parameters);
        }

        public SqlStringBuilder OrderByAscending(string columnNames)
        {
            return OrderBy(columnNames, "ASC");
        }

        public SqlStringBuilder OrderByDescending(string columnNames)
        {
            return OrderBy(columnNames, "DESC");
        }
        #endregion

        #region ICUDCommands Implementation
        public SqlStringBuilder InsertInto(string tableName)
        {
            return AppendSpaceAtTheEnd("INSERT INTO", tableName);
        }

        public SqlStringBuilder Values(string valuesSeparatedByComa)
        {
            var matches = Regex.Matches(valuesSeparatedByComa, @"\w+").Cast<Match>();
            var columns = string.Join(", ", matches);
            _query.AppendFormat("({0}) VALUES ({1}) ", columns, valuesSeparatedByComa);
            return this;
        }

        public SqlStringBuilder Delete()
        {
            return AppendSpaceAtTheEnd("DELETE");
        }

        public SqlStringBuilder From(string tableNamesSeparatedByComa)
        {
            return AppendSpaceAtTheEnd("FROM", tableNamesSeparatedByComa);
        }

        public SqlStringBuilder Where(string conditions)
        {
            return AppendSpaceAtTheEnd("WHERE", conditions);
        }

        public SqlStringBuilder IsNull()
        {
            return AppendSpaceAtTheEnd("IS NULL");
        }

        public SqlStringBuilder IsNotNull()
        {
            return AppendSpaceAtTheEnd("IS NOT NULL");
        }

        public SqlStringBuilder And(string conditions)
        {
            return AppendSpaceAtTheEnd("AND", conditions);
        }

        public SqlStringBuilder Or(string conditions)
        {
            return AppendSpaceAtTheEnd("OR", conditions);
        }

        public SqlStringBuilder Between(string parameter)
        {
            return AppendSpaceAtTheEnd("BETWEEN", parameter);
        }

        public SqlStringBuilder Like(string parameter)
        {
            return AppendSpaceAtTheEnd("LIKE", parameter);
        }
        #endregion

        #region Private Methods
        private SqlStringBuilder AppendSpaceAtTheEnd(string sqlStatement)
        {
            _query.AppendFormat("{0} ", sqlStatement).ToString();
            return this;
        }

        private SqlStringBuilder AppendSpaceAtTheEnd(string sqlStatement, string parameters)
        {
            _query.AppendFormat("{0} {1} ", sqlStatement, parameters).ToString();
            return this;
        }

        private SqlStringBuilder AppendSpaceAtTheEnd(string sqlStatement1, string parameters, string sqlStatement2)
        {
            _query.AppendFormat("{0} {1} {2} ", sqlStatement1, parameters, sqlStatement2).ToString();
            return this;
        }

        private SqlStringBuilder TrimEndBeforeAppendSpaceAtTheEnd(string sqlStatement1, string parameters, string sqlStatement2)
        {
            _query.TrimEnd();
            return AppendSpaceAtTheEnd(sqlStatement1, parameters, sqlStatement2);
        }

        private SqlStringBuilder OrderBy(string columnNames, string direction)
        {
            return _query.ToString().Contains("ORDER BY")
                ? TrimEndBeforeAppendSpaceAtTheEnd(",", columnNames, direction)
                : AppendSpaceAtTheEnd("ORDER BY", columnNames, direction);
        }
        #endregion
    }
}
