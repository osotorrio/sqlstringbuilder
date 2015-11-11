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
    }
}
