namespace SqlStringBuilder.Core
{
    public interface ISqlStringBuilder
    {
        SqlStringBuilder SelectAll();
        SqlStringBuilder SelectDistinct();
        SqlStringBuilder Select(string parameters);
        SqlStringBuilder From(string tableName);
        SqlStringBuilder Where(string conditions);
        SqlStringBuilder IsNull();
        SqlStringBuilder IsNotNull();
        SqlStringBuilder And(string conditions);
        SqlStringBuilder Or(string conditions);
        SqlStringBuilder Between(string parameter);
        SqlStringBuilder OrderByAscending(string columnNames);
        SqlStringBuilder OrderByDescending(string columnNames);
    }
}
