using NUnit.Framework;

namespace SqlBuilder.Core.UnitTest
{
    [TestFixture]
    class CUDCommandsTest: TestBase
    {
        [SetUp]
        protected void InitBeforeEachTest()
        {
            Query = new SqlStringBuilder();
        }

        [Test]
        public void InsertInto_Should_Add_Table_To_Command_Statement_And_Space_At_The_End()
        {
            AssertAreEqual(() => Query.InsertInto("TableName"), "INSERT INTO TableName ");
        }

        [Test]
        public void Values_Should_Add_Columns_Before_Values_And_Space_At_The_End()
        {
            AssertAreEqual(() => Query.Values("@Column1, @Column2"), "(Column1, Column2) VALUES (@Column1, @Column2) ");
        }

        [Test]
        public void Delete_Should_Add_Delete_Statement_And_Space_At_The_End()
        {
            AssertAreEqual(() => Query.Delete(), "DELETE ");
        }
    }
}
