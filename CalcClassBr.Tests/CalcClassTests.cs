using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalcClassBr;
using System.Data.SqlTypes;

namespace CalcClassBr.Tests
{
    [TestClass]
    public class CalcClassTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                    "testData.xml",
                    "Operation", DataAccessMethod.Sequential)]

        public void SubTest()
        {
            //Arrange
            long expression_1 = Convert.ToInt64(TestContext.DataRow["expression_1"]);
            long expression_2 = Convert.ToInt64(TestContext.DataRow["expression_2"]);
            string expected = Convert.ToString(TestContext.DataRow["expected"]);

            //Act
            string result;
            try
            {
                result = Convert.ToString(CalcClass.Sub(expression_1, expression_2));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                result = ex.ParamName;
            }

            Assert.AreEqual(expected, result);
        }
    }
}

//public void SubTest()
//{
//    //Arrange
//    long expression_1 = Convert.ToInt64(TestContext.DataRow["expression_1"]);
//    long expression_2 = Convert.ToInt64(TestContext.DataRow["expression_2"]);
//    string expected = Convert.ToString(TestContext.DataRow["expected"]);

//    //Act
//    string result = Convert.ToString(CalcClass.Sub(expression_1, expression_2));

//    Assert.AreEqual(expected, result);
//}