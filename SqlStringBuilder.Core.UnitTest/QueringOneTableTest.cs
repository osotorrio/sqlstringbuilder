using NUnit.Framework;

namespace SqlBuilder.Core.UnitTest
{
    [TestFixture]
    class QueringOneTableTest: TestBase
    {
        [SetUp]
        protected void InitBeforeEachTest()
        {
            Query = new SqlStringBuilder();
        }

        [Test]
        public void Semicolon_Should_Add_A_Semicolon()
        {
            //Arrange
            const string expectedQuery = ";";

            //Act
            string actualQuery = Query.Semicolon();

            //Assert
            Assert.That(actualQuery, Is.EqualTo(expectedQuery));
        }

        [Test]
        public void SelectAll_Should_Return_A_Select_All_Statement_With_A_Space_At_The_End()
        {
            AssertAreEqual(Query.SelectAll, "SELECT ALL * ");
        }

        [Test]
        public void SelectDistinct_Should_Return_A_Select_Distinct_Statement_With_A_Space_At_The_End()
        {
            AssertAreEqual(Query.SelectDistinct, "SELECT DISTINCT * ");
        }

        [Test]
        public void Select_Should_Add_Parameters_To_Select_Statement_And_Space_At_The_End()
        {
            AssertAreEqual(() => Query.Select("ColumnA, ColumnB"), "SELECT ColumnA, ColumnB ");
        }

        [Test]
        public void From_Should_Add_Tables_To_Select_Statement_And_Space_At_The_End()
        {
            AssertAreEqual(() => Query.From("TableName1, TableName2"), "FROM TableName1, TableName2 ");
        }

        [Test]
        public void Where_Should_Add_Conditions_To_Select_Statement_And_Space_At_The_End()
        {
            AssertAreEqual(() => Query.Where("ColumnA = @ColumnA"), "WHERE ColumnA = @ColumnA ");
        }

        [Test]
        public void IsNull_Should_Add_An_Space_At_The_End()
        {
            AssertAreEqual(Query.IsNull, "IS NULL ");
        }

        [Test]
        public void IsNotNull_Should_Add_An_Space_At_The_End()
        {
            AssertAreEqual(Query.IsNotNull, "IS NOT NULL ");
        }

        [Test]
        public void And_Should_Add_Conditions_To_Select_Statement_And_Space_At_The_End()
        {
            AssertAreEqual(() => Query.And("ColumnB < @ColumnB"), "AND ColumnB < @ColumnB ");
        }

        [Test]
        public void Or_Should_Add_Conditions_To_Select_Statement_And_Space_At_The_End()
        {
            AssertAreEqual(() => Query.Or("ColumnB < @ColumnB"), "OR ColumnB < @ColumnB ");
        }

        [Test]
        public void Between_Should_Add_Parameters_And_Space_At_The_End()
        {
            AssertAreEqual(() => Query.Between("@ColumnB"), "BETWEEN @ColumnB ");
        }

        [Test]
        public void OrderByAscending_Should_Add_Columns_Before_Asc_And_Space_At_The_End()
        {
            AssertAreEqual(() => Query.OrderByAscending("ColumnA"), "ORDER BY ColumnA ASC ");
        }

        [Test]
        public void OrderByAscending_Should_Include_Coma_When_There_Is_Already_Order_By()
        {
            Query.OrderByAscending("ColumnA");
            AssertAreEqual(() => Query.OrderByAscending("ColumnB"), "ORDER BY ColumnA ASC, ColumnB ASC ");
        }

        [Test]
        public void OrderByDescending_Should_Add_Columns_Before_Desc_And_Space_At_The_End()
        {
            AssertAreEqual(() => Query.OrderByDescending("ColumnA"), "ORDER BY ColumnA DESC ");
        }

        [Test]
        public void OrderByDescending_Should_Include_Coma_When_There_Is_Already_Order_By()
        {
            Query.OrderByDescending("ColumnA");
            AssertAreEqual(() => Query.OrderByDescending("ColumnB"), "ORDER BY ColumnA DESC, ColumnB DESC ");
        }
    }
}
