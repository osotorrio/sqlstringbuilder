using System;
using NUnit.Framework;

namespace SqlStringBuilder.Core.UnitTest
{
    [TestFixture]
    class QueriesOneTableTest
    {
        private ISqlStringBuilder _query;

        [SetUp]
        public void InitBeforeEachTest()
        {
            _query = new SqlStringBuilder();
        }

        [Test]
        public void ToString_Should_Add_A_Semicolon()
        {
            //Arrange
            const string expectedQuery = ";";

            //Act
            string actualQuery = _query.ToString();

            //Assert
            Assert.That(actualQuery, Is.EqualTo(expectedQuery));
        }

        [Test]
        public void SelectAll_Should_Return_A_Select_All_Statement()
        {
            AssertAreEqual(_query.SelectAll, "SELECT ALL *;");
        }

        [Test]
        public void SelectDistinct_Should_Return_A_Select_Distinct_Statement()
        {
            AssertAreEqual(_query.SelectDistinct, "SELECT DISTINCT *;");
        }

        [Test]
        public void Select_Should_Add_Parameters_To_Select_Statement()
        {
            AssertAreEqual(() => _query.Select("ColumnA, ColumnB"), "SELECT ColumnA, ColumnB;");
        }

        [Test]
        public void From_Should_Add_An_Space_Before_Keyword_And_The_Table_Name_After()
        {
            AssertAreEqual(() => _query.From("TableName"), " FROM TableName;");
        }

        [Test]
        public void Where_Should_Add_An_Space_Before_Keyword_And_Conditions_After()
        {
            AssertAreEqual(() => _query.Where("ColumnA = @ColumnA"), " WHERE ColumnA = @ColumnA;");
        }

        [Test]
        public void IsNull_Should_Add_An_Space_Before_Keywords()
        {
            AssertAreEqual(_query.IsNull, " IS NULL;");
        }

        [Test]
        public void IsNotNull_Should_Add_An_Space_Before_Keywords()
        {
            AssertAreEqual(_query.IsNotNull, " IS NOT NULL;");
        }

        [Test]
        public void And_Should_Add_An_Space_Before_Keyword_And_The_Conditions_After()
        {
            AssertAreEqual(() => _query.And("ColumnB < @ColumnB"), " AND ColumnB < @ColumnB;");
        }

        [Test]
        public void Or_Should_Add_An_Space_Before_Keyword_And_the_Conditions_After()
        {
            AssertAreEqual(() => _query.Or("ColumnB < @ColumnB"), " OR ColumnB < @ColumnB;");
        }

        [Test]
        public void Between_Should_Add_Space_Before_Keyword_And_The_Parameter_After()
        {
            AssertAreEqual(() => _query.Between("@ColumnB"), " BETWEEN @ColumnB;");
        }

        private static void AssertAreEqual(Func<SqlStringBuilder> sqlStringBuilderMethod, string expectedQuery)
        {
            //Act
            string actualQuery = sqlStringBuilderMethod.Invoke().ToString();

            //Assert
            Assert.That(actualQuery, Is.EqualTo(expectedQuery));
        }
    }
}
