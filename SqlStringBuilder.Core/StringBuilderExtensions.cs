using System.Text;

namespace SqlBuilder.Core
{
    public static class StringBuilderExtensions
    {
        public static void TrimEnd(this StringBuilder sb)
        {
            if (sb.Length != 0)
            {
                sb.Length--;
            }
        }
    }
}
