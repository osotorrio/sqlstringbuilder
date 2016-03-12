using System;
using NUnit.Framework;

namespace SqlBuilder.Core.UnitTest
{
    [SetUpFixture]
    class TestBase
    {
        protected SqlStringBuilder Query;

        protected static void AssertAreEqual(Func<SqlStringBuilder> sqlStringBuilderMethod, string expectedQuery)
        {
            //Act
            string actualQuery = sqlStringBuilderMethod.Invoke().Status;

            //Assert
            Assert.That(actualQuery, Is.EqualTo(expectedQuery));
        }
    }
}
