namespace SqlStringBuilder.Core
{
    public interface ISqlStringBuilder
    {
        SqlStringBuilder SelectAll();
        SqlStringBuilder SelectDistinct();
        SqlStringBuilder Select(string parameters);
        SqlStringBuilder From(string tableName);
        SqlStringBuilder Where(string conditions);
    }
}
