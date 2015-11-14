using System;
using NUnit.Framework;

namespace SqlStringBuilder.Core.UnitTest
{
    [SetUpFixture]
    class TestBase
    {
        protected ISqlStringBuilder Query;

        [SetUp]
        protected void InitBeforeEachTest()
        {
            Query = new SqlStringBuilder();
        }
        protected static void AssertAreEqual(Func<SqlStringBuilder> sqlStringBuilderMethod, string expectedQuery)
        {
            //Act
            string actualQuery = sqlStringBuilderMethod.Invoke().ToString();

            //Assert
            Assert.That(actualQuery, Is.EqualTo(expectedQuery));
        }
    }
}
