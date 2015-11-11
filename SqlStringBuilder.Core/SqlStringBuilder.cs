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
    }
}
