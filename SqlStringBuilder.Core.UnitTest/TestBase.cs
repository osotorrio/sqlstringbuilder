using System;
using NUnit.Framework;

namespace SqlBuilder.Core.UnitTest
{
    [SetUpFixture]
    class TestBase
    {
        protected IQueryCommands Query;

        protected static void AssertAreEqual(Func<SqlStringBuilder> sqlStringBuilderMethod, string expectedQuery)
        {
            //Act
            string actualQuery = sqlStringBuilderMethod.Invoke().ToString();

            //Assert
            Assert.That(actualQuery, Is.EqualTo(expectedQuery));
        }
    }
}
