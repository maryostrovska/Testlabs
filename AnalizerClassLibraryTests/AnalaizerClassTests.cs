using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using AnalaizerClassLibrary;

namespace AnalizerClassLibrary.Tests
{
    [TestClass]
    public class AnalaizerClassTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                    "testData.xml",
                    "Test", DataAccessMethod.Sequential)]
        public void CreateStackTest()
        {
            //Arrange
            AnalaizerClass.expression = Convert.ToString(TestContext.DataRow["expression"]); // витягуємо дані з xml файлу
            string expected = Convert.ToString(TestContext.DataRow["expected"]);

            //Act
            ArrayList result_list = AnalaizerClass.CreateStack(); // викликаємо метод для тестування

            string result_string = "";
            foreach (var item in result_list) // конвертуємо стек у стрічку
            {
                result_string += item.ToString();
            }

            Assert.AreEqual(result_string, expected); // порівнюємо результат та очікуване значення
        }
    }
}
