using NUnit.Framework;

namespace SqlStringBuilder.Examples
{
    [TestFixture]
    class QueriesOneTableExamples
    {
        private Core.ISqlStringBuilder _query;

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

        [Test]
        public void Select_Columns_With_Alias_Example()
        {
            const string selectColumns = "SELECT T.ColumnA AS SomeAlias FROM TableName AS T;";

            string query = _query.Select("T.ColumnA AS SomeAlias").From("TableName AS T").ToString();

            Assert.That(query, Is.EqualTo(selectColumns));
        }

        [Test]
        public void Simple_Where_Example()
        {
            const string selectWhere = "SELECT ALL * FROM TableName WHERE ColumnA = @ColumnA;";

            string query = _query.SelectAll()
                .From("TableName")
                .Where("ColumnA = @ColumnA")
                .ToString();

            Assert.That(query, Is.EqualTo(selectWhere));
        }

        [Test]
        public void Where_Is_Not_Null_Example()
        {
            const string selectWhere = "SELECT ALL * FROM TableName WHERE ColumnA IS NOT NULL;";

            string query = _query.SelectAll()
                .From("TableName")
                .Where("ColumnA").IsNotNull()
                .ToString();

            Assert.That(query, Is.EqualTo(selectWhere));
        }

        [Test]
        public void Where_Is_Null_Example()
        {
            const string selectWhere = "SELECT ALL * FROM TableName WHERE ColumnA IS NULL;";

            string query = _query.SelectAll()
                .From("TableName")
                .Where("ColumnA").IsNull()
                .ToString();

            Assert.That(query, Is.EqualTo(selectWhere));
        }
    }
}
