using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{

    public class Calculator
    {
        public int Add(int x,int y)
        {
            return x + y;
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Calculator calc = new Calculator();
            int x = 4;
            int y = 5;
            int result = calc.Add(x, y);
            Assert.AreEqual(x + y, result);
        }
    }
}
