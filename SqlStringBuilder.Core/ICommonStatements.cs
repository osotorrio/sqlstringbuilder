namespace SqlBuilder.Core
{
    public interface ICommonStatements
    {
        SqlStringBuilder From(string tableNamesSeparatedByComa);
        SqlStringBuilder Where(string conditions);
        SqlStringBuilder IsNull();
        SqlStringBuilder IsNotNull();
        SqlStringBuilder And(string conditions);
        SqlStringBuilder Or(string conditions);
        SqlStringBuilder Between(string parameter);
        SqlStringBuilder Like(string parameter);
    }
}
