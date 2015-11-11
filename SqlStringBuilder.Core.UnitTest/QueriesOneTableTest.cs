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
            //Arrange
            const string expectedQuery = "SELECT ALL *;";

            //Act
            string actualQuery = _query.SelectAll().ToString();

            //Assert
            Assert.That(actualQuery, Is.EqualTo(expectedQuery));
        }

        [Test]
        public void SelectDistinct_Should_Return_A_Select_Distinct_Statement()
        {
            //Arrange
            const string expectedQuery = "SELECT DISTINCT *;";

            //Act
            string actualQuery = _query.SelectDistinct().ToString();

            //Assert
            Assert.That(actualQuery, Is.EqualTo(expectedQuery));
        }
    }
}
