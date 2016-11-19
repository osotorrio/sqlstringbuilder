namespace SqlBuilder.Core
{
    public interface IQueryCommands
    {
        SqlSb SelectAll();
        SqlSb SelectDistinct();
        SqlSb Select(string parameters);
        SqlSb OrderByAscending(string columnNames);
        SqlSb OrderByDescending(string columnNames);
    }
}
