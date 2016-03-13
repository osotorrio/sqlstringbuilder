namespace SqlBuilder.Core
{
    public interface IQueryCommands
    {
        SqlStringBuilder SelectAll();
        SqlStringBuilder SelectDistinct();
        SqlStringBuilder Select(string parameters);
        SqlStringBuilder OrderByAscending(string columnNames);
        SqlStringBuilder OrderByDescending(string columnNames);
    }
}
