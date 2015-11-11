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
    }
}
