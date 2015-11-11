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
            _query.Append("SELECT ALL *");
            return this;
        }

        public SqlStringBuilder SelectDistinct()
        {
            _query.Append("SELECT DISTINCT *");
            return this;
        }

        public SqlStringBuilder Select(string parameters)
        {
            _query.AppendFormat("SELECT {0}", parameters);
            return this;
        }

        public SqlStringBuilder From(string tableName)
        {
            _query.AppendFormat(" FROM {0}", tableName);
            return this;
        }

        public SqlStringBuilder Where(string conditions)
        {
            _query.AppendFormat(" WHERE {0}", conditions);
            return this;
        }
    }
}
