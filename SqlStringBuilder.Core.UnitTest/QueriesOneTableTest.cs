using System;
using NUnit.Framework;

namespace SqlStringBuilder.Core.UnitTest
{
    [TestFixture]
    class QueriesOneTableTest
    {
        private SqlStringBuilder _query;

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
        public void From_Should_Add_An_Space_Before_From_Keyword_And_Table_Name_After()
        {
            AssertAreEqual(() => _query.From("TableName"), " FROM TableName;");
        }

        private static void AssertAreEqual(Func<SqlStringBuilder> sqlStringBuilderMethod, string expectedQuery)
        {
            //Act
            string actualQuery = sqlStringBuilderMethod().ToString();

            //Assert
            Assert.That(actualQuery, Is.EqualTo(expectedQuery));
        }
    }
}
