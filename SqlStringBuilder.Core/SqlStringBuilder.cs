using System.Text;

namespace SqlStringBuilder.Core
{
    public class SqlStringBuilder
    {
        private StringBuilder _query;

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
    }
}
