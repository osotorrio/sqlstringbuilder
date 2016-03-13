namespace SqlBuilder.Core
{
    public interface ICUDCommands
    {
        SqlStringBuilder InsertInto(string tableName);
        SqlStringBuilder Values(string valuesSeparatedByComa);
        SqlStringBuilder Delete();
    }
}
