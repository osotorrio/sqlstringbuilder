using NUnit.Framework;

namespace SqlStringBuilder.Examples
{
    [TestFixture]
    class QueriesOneTableExamples
    {
        private Core.SqlStringBuilder _query;

        [SetUp]
        public void InitBeforeEachTest()
        {
            _query = new Core.SqlStringBuilder();
        }

        [Test]
        public void Select_All_Example()
        {
            const string selectAll = "SELECT ALL * FROM TableName;";

            string query = _query.SelectAll().From("TableName").ToString();

            Assert.That(query, Is.EqualTo(selectAll));
        }

        [Test]
        public void Select_Distinct_Example()
        {
            const string selectDistinct = "SELECT DISTINCT * FROM TableName;";

            string query = _query.SelectDistinct().From("TableName").ToString();

            Assert.That(query, Is.EqualTo(selectDistinct));
        }

        [Test]
        public void Select_Columns_Example()
        {
            const string selectColumns = "SELECT ColumnA, ColumnB FROM TableName;";

            string query = _query.Select("ColumnA, ColumnB").From("TableName").ToString();

            Assert.That(query, Is.EqualTo(selectColumns));
        }
    }
}
