namespace SqlBuilder.Core
{
    public interface ICUDCommands
    {
        SqlSb InsertInto(string tableName);
        SqlSb Values(string valuesSeparatedByComa);
        SqlSb Delete();
    }
}
