using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        public static Architecture.SQL Arch = new Architecture.SQL();
        public static DataTable dt = new DataTable();
        public static string connectionString = UnitTests.Properties.Settings.Default.sqlConnectionString;

        [TestMethod]
        public void TestConnectionString()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
            }
            catch
            {
                Assert.Fail("Connection Failed!");
            }
        }

        [TestMethod]
        public void TestLoadDataTable()
        {
            DataTable dt1 = new DataTable();
            Arch.LoadDataTable(ref dt1, connectionString, "Select * FROM TestTable");

            Assert.IsTrue(dt1.Rows.Count > 0, "Cannot load DataTable");
        }
    }
}

