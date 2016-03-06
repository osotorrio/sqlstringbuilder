using System.Linq;
using System.Text;

namespace SqlBuilder.Core
{
    public class SqlStringBuilder : ISqlStringBuilder
    {
        private readonly StringBuilder _query;

        public SqlStringBuilder()
        {
            _query = new StringBuilder();
        }

        private SqlStringBuilder AppendWithSpaceAtBeginning(string partialQuery)
        {
            _query.AppendFormat(" {0}", partialQuery);
            return this;
        }

        private SqlStringBuilder AppendWithSpaceAtBeginningAndBetween(string keyword, string partialQuery)
        {
            _query.AppendFormat(" {0} {1}", keyword, partialQuery);
            return this;
        }

        private SqlStringBuilder AppendWithSpaceAtBeginningInBetweenAndExtraKeyword(string keyword, string columnNames, string extraKeyword)
        {
            _query.AppendFormat(" {0} {1} {2}", keyword, columnNames, extraKeyword);
            return this;
        }

        private SqlStringBuilder AppendWithSpaceInBetween(string keyword, string partialQuery)
        {
            _query.AppendFormat("{0} {1}", keyword, partialQuery);
            return this;
        }

        private SqlStringBuilder AppendWithSpaceInBetweenAndExtraKeyword(string keyword, string partialQuery, string extraKeyword)
        {
            _query.AppendFormat("{0} {1} {2}", keyword, partialQuery, extraKeyword);
            return this;
        }

        private SqlStringBuilder AppendWithoutSpaces(string partialQuery)
        {
            _query.Append(partialQuery);
            return this;
        }

        public override string ToString()
        {
            _query.Append(";");
            return _query.ToString();
        }

        public SqlStringBuilder SelectAll()
        {
            return AppendWithoutSpaces("SELECT ALL *");
        }

        public SqlStringBuilder SelectDistinct()
        {
            return AppendWithoutSpaces("SELECT DISTINCT *");
        }

        public SqlStringBuilder Select(string parameters)
        {
            return AppendWithSpaceInBetween("SELECT", parameters);
        }

        public SqlStringBuilder From(params string[] tableNames)
        {
            return AppendWithSpaceAtBeginningAndBetween("FROM", string.Join(", ", tableNames));
        }

        public SqlStringBuilder Where(string conditions)
        {
            return AppendWithSpaceAtBeginningAndBetween("WHERE", conditions);
        }

        public SqlStringBuilder IsNull()
        {
            return AppendWithSpaceAtBeginning("IS NULL");
        }

        public SqlStringBuilder IsNotNull()
        {
            return AppendWithSpaceAtBeginning("IS NOT NULL");
        }

        public SqlStringBuilder And(string conditions)
        {
            return AppendWithSpaceAtBeginningAndBetween("AND", conditions);
        }

        public SqlStringBuilder Or(string conditions)
        {
            return AppendWithSpaceAtBeginningAndBetween("OR", conditions);
        }

        public SqlStringBuilder Between(string parameter)
        {
            return AppendWithSpaceAtBeginningAndBetween("BETWEEN", parameter);
        }

        public SqlStringBuilder OrderByAscending(string columnNames)
        {
            return OrderBy(columnNames, "ASC");
        }

        public SqlStringBuilder OrderByDescending(string columnNames)
        {
            return OrderBy(columnNames, "DESC");
        }

        private SqlStringBuilder OrderBy(string columnNames, string direction)
        {
            return _query.ToString().Contains("ORDER BY")
                ? AppendWithSpaceInBetweenAndExtraKeyword(",", columnNames, direction)
                : AppendWithSpaceAtBeginningInBetweenAndExtraKeyword("ORDER BY", columnNames, direction);
        }
    }
}
