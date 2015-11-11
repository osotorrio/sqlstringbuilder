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
    }
}
