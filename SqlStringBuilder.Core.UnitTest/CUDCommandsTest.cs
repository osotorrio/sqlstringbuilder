using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SqlBuilder.Core.UnitTest
{
    [TestFixture]
    class CUDCommandsTest: TestBase
    {
        [SetUp]
        protected void InitBeforeEachTest()
        {
            Query = new SqlStringBuilder();
        }

        [Test]
        public void InsertInto_Should_Have_An_Space_Between_InsertInto_An_The_Table_Name()
        {
            AssertAreEqual(() => Query.InsertInto("TableName"), "INSERT INTO TableName;");
        }
    }
}
