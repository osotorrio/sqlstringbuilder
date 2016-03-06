using NUnit.Framework;
using SqlBuilder.Core;

namespace SqlBuilder.Examples
{
    [TestFixture]
    class QueringOneTableExamples
    {
        private Core.IQueryCommands _query;

        [SetUp]
        public void InitBeforeEachTest()
        {
            _query = new SqlStringBuilder();
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
        public void Combining_Where_Conditions_Example_1()
        {
            const string selectWhere = "SELECT ALL * FROM TableName WHERE ColumnA = @ColumnA AND ColumnB < @ColumnB;";

            string query = _query.SelectAll()
                .From("TableName")
                .Where("ColumnA = @ColumnA").And("ColumnB < @ColumnB")
                .ToString();

            Assert.That(query, Is.EqualTo(selectWhere));
        }

        [Test]
        public void Combining_Where_Conditions_Example_2()
        {
            const string selectWhere = "SELECT ALL * FROM TableName WHERE ColumnA BETWEEN @Param1 AND @Param2;";

            string query = _query.SelectAll()
                .From("TableName")
                .Where("ColumnA").Between("@Param1").And("@Param2")
                .ToString();

            Assert.That(query, Is.EqualTo(selectWhere));
        }

        [Test]
        public void Combining_Where_Conditions_Example_3()
        {
            const string selectWhere = "SELECT ALL * FROM TableName WHERE ColumnA BETWEEN @Param1 AND @Param2 OR ColumnA > @Param3;";

            string query = _query.SelectAll()
                .From("TableName")
                .Where("ColumnA").Between("@Param1").And("@Param2")
                .Or("ColumnA > @Param3")
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

        [Test]
        public void OrderBy_Single_Column_Example()
        {
            const string selectOrderBy = "SELECT ALL * FROM TableName ORDER BY ColumnA ASC;";

            string query = _query.SelectAll()
                .From("TableName")
                .OrderByAscending("ColumnA")
                .ToString();

            Assert.That(query, Is.EqualTo(selectOrderBy));
        }

        [Test]
        public void OrderBy_Multiple_Columns_Example()
        {
            const string selectOrderBy = "SELECT ALL * FROM TableName ORDER BY ColumnA, ColumnB ASC;";

            string query = _query.SelectAll()
                .From("TableName")
                .OrderByAscending("ColumnA, ColumnB")
                .ToString();

            Assert.That(query, Is.EqualTo(selectOrderBy));
        }

        [Test]
        public void OrderBy_Combining_Order_By_Example()
        {
            const string selectOrderBy = "SELECT ALL * FROM TableName ORDER BY ColumnA, ColumnB ASC, ColumnC DESC;";

            string query = _query.SelectAll()
                .From("TableName")
                .OrderByAscending("ColumnA, ColumnB")
                .OrderByDescending("ColumnC")
                .ToString();

            Assert.That(query, Is.EqualTo(selectOrderBy));
        }
    }
}
