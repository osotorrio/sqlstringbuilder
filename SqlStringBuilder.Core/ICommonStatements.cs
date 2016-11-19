namespace SqlBuilder.Core
{
    public interface ICommonStatements
    {
        SqlSb From(string tableNamesSeparatedByComa);
        SqlSb Where(string conditions);
        SqlSb IsNull();
        SqlSb IsNotNull();
        SqlSb And(string conditions);
        SqlSb Or(string conditions);
        SqlSb Between(string parameter);
        SqlSb Like(string parameter);
    }
}
