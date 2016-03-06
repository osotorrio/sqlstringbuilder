using NUnit.Framework;

namespace SqlBuilder.Core.UnitTest
{
    [TestFixture]
    class QueringMutipleTablesTest: TestBase
    {
        [SetUp]
        protected void InitBeforeEachTest()
        {
            Query = new SqlStringBuilder();
        }

        [Test]
        public void From_Should_Add_Table_Names_Separated_By_Coma()
        {
            AssertAreEqual(() => Query.From("TableNameA", "TableNameB"), " FROM TableNameA, TableNameB;");
        }
    }
}
