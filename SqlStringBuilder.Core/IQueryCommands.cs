namespace SqlBuilder.Core
{
    public interface IQueryCommands
    {
        SqlStringBuilder SelectAll();
        SqlStringBuilder SelectDistinct();
        SqlStringBuilder Select(string parameters);
        SqlStringBuilder From(string tableNamesSeparatedByComa);
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
