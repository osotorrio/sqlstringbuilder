﻿using NUnit.Framework;
using SqlBuilder.Core;

namespace SqlBuilder.Examples
{
    [TestFixture]
    class QueringMultipleTablesExamples
    {
        private IQueryCommands _query;

        [SetUp]
        public void InitBeforeEachTest()
        {
            _query = new SqlStringBuilder();
        }

        [Test]
        public void Select_Multiple_Tables_Example_1()
        {
            const string multipleTables = "SELECT ALL * FROM TableA, TableB, TableC;";

            string query = _query.SelectAll()
                .From("TableA, TableB, TableC")
                .SemiColon();

            Assert.That(query, Is.EqualTo(multipleTables));
        }

        [Test]
        public void Select_Multiple_Tables_Example_2()
        {
            const string multipleTables = "SELECT ALL * FROM TableA, TableB, TableC;";

            string query = _query.SelectAll()
                .From("TableA, TableB, TableC")
                .SemiColon();

            Assert.That(query, Is.EqualTo(multipleTables));
        }
    }
}
