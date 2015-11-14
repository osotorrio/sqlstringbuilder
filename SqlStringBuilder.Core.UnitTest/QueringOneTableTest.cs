using System;
using NUnit.Framework;

namespace SqlStringBuilder.Core.UnitTest
{
    [TestFixture]
    class QueringOneTableTest: BaseTest
    {
        [Test]
        public void ToString_Should_Add_A_Semicolon()
        {
            //Arrange
            const string expectedQuery = ";";

            //Act
            string actualQuery = Query.ToString();

            //Assert
            Assert.That(actualQuery, Is.EqualTo(expectedQuery));
        }

        [Test]
        public void SelectAll_Should_Return_A_Select_All_Statement()
        {
            AssertAreEqual(Query.SelectAll, "SELECT ALL *;");
        }

        [Test]
        public void SelectDistinct_Should_Return_A_Select_Distinct_Statement()
        {
            AssertAreEqual(Query.SelectDistinct, "SELECT DISTINCT *;");
        }

        [Test]
        public void Select_Should_Add_Parameters_To_Select_Statement()
        {
            AssertAreEqual(() => Query.Select("ColumnA, ColumnB"), "SELECT ColumnA, ColumnB;");
        }

        [Test]
        public void From_Should_Add_An_Space_Before_Keyword_And_The_Table_Name_After()
        {
            AssertAreEqual(() => Query.From("TableName"), " FROM TableName;");
        }

        [Test]
        public void Where_Should_Add_An_Space_Before_Keyword_And_Conditions_After()
        {
            AssertAreEqual(() => Query.Where("ColumnA = @ColumnA"), " WHERE ColumnA = @ColumnA;");
        }

        [Test]
        public void IsNull_Should_Add_An_Space_Before_Keywords()
        {
            AssertAreEqual(Query.IsNull, " IS NULL;");
        }

        [Test]
        public void IsNotNull_Should_Add_An_Space_Before_Keywords()
        {
            AssertAreEqual(Query.IsNotNull, " IS NOT NULL;");
        }

        [Test]
        public void And_Should_Add_An_Space_Before_Keyword_And_The_Conditions_After()
        {
            AssertAreEqual(() => Query.And("ColumnB < @ColumnB"), " AND ColumnB < @ColumnB;");
        }

        [Test]
        public void Or_Should_Add_An_Space_Before_Keyword_And_the_Conditions_After()
        {
            AssertAreEqual(() => Query.Or("ColumnB < @ColumnB"), " OR ColumnB < @ColumnB;");
        }

        [Test]
        public void Between_Should_Add_Space_Before_Keyword_And_The_Parameter_After()
        {
            AssertAreEqual(() => Query.Between("@ColumnB"), " BETWEEN @ColumnB;");
        }

        [Test]
        public void OrderByAscending_Should_Add_Space_Before_keyword_And_Column_Names_Before_Asc()
        {
            //ORDER BY column_name ASC|DESC, column_name ASC|DESC;
            AssertAreEqual(() => Query.OrderByAscending("ColumnA"), " ORDER BY ColumnA ASC;");
        }

        [Test]
        public void OrderByAscending_Should_Include_Coma_When_There_Is_Already_Order_By()
        {
            Query.OrderByAscending("ColumnA");
            AssertAreEqual(() => Query.OrderByAscending("ColumnB"), " ORDER BY ColumnA ASC, ColumnB ASC;");
        }

        [Test]
        public void OrderByDescending_Should_Add_Space_Before_keyword_And_Column_Names_Before_Asc()
        {
            AssertAreEqual(() => Query.OrderByDescending("ColumnA"), " ORDER BY ColumnA DESC;");
        }

        [Test]
        public void OrderByDescending_Should_Include_Coma_When_There_Is_Already_Order_By()
        {
            Query.OrderByDescending("ColumnA");
            AssertAreEqual(() => Query.OrderByDescending("ColumnB"), " ORDER BY ColumnA DESC, ColumnB DESC;");
        }
    }
}
