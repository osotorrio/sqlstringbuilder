using System.Text;

namespace SqlStringBuilder.Core
{
    public class SqlStringBuilder : ISqlStringBuilder
    {
        private readonly StringBuilder _query;

        public SqlStringBuilder()
        {
            _query = new StringBuilder();
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

        public SqlStringBuilder From(string tableName)
        {
            return AppendWithSpaceAtBeginningAndBetween("FROM", tableName);
        }

        public SqlStringBuilder Where(string conditions)
        {
            return AppendWithSpaceAtBeginningAndBetween("WHERE", conditions);
        }

        private SqlStringBuilder AppendWithoutSpaces(string partialQuery)
        {
            _query.Append(partialQuery);
            return this;
        }

        private SqlStringBuilder AppendWithSpaceInBetween(string keyword, string partialQuery)
        {
            _query.AppendFormat("{0} {1}", keyword, partialQuery);
            return this;
        }

        private SqlStringBuilder AppendWithSpaceAtBeginningAndBetween(string keyword, string partialQuery)
        {
            _query.AppendFormat(" {0} {1}", keyword, partialQuery);
            return this;
        }
    }
}
