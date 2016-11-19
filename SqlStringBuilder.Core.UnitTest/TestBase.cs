using System;
using NUnit.Framework;

namespace SqlBuilder.Core.UnitTest
{
    [SetUpFixture]
    class TestBase
    {
        protected SqlSb Query;

        protected static void AssertAreEqual(Func<SqlSb> sqlStringBuilderMethod, string expectedQuery)
        {
            //Act
            string actualQuery = sqlStringBuilderMethod.Invoke().Status;

            //Assert
            Assert.That(actualQuery, Is.EqualTo(expectedQuery));
        }
    }
}
