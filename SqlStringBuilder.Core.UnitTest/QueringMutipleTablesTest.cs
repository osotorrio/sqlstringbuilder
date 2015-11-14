using NUnit.Framework;

namespace SqlStringBuilder.Core.UnitTest
{
    [TestFixture]
    class QueringMutipleTablesTest: TestBase
    {
        [Test]
        public void From_Should_Add_Table_Names_Separated_By_Coma()
        {
            AssertAreEqual(() => Query.From("TableNameA", "TableNameB"), " FROM TableNameA, TableNameB;");
        }
    }
}
