namespace SqlBuilder.Core
{
    public interface ICUDCommands
    {
        SqlStringBuilder InsertInto(string tableName);
        SqlStringBuilder Columns(string columnsSeparatedByComa);
        SqlStringBuilder Values(string valuesSeparatedByComa);
    }
}
