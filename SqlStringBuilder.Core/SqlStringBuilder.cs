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

        private SqlStringBuilder AppendWithSpaceInBetween(string keyword, string partialQuery)
        {
            _query.AppendFormat("{0} {1}", keyword, partialQuery);
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

        public SqlStringBuilder From(string tableName)
        {
            return AppendWithSpaceAtBeginningAndBetween("FROM", tableName);
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
    }
}
