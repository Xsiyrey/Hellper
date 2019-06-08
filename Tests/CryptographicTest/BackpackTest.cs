using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.CryptographicTest
{
    [TestClass]
    public class BackpackTest
    {
        [TestMethod]
        public void TestMethod1()//изменить название при добавление теста 
        {
            int a = 5 + 4;
            Assert.AreEqual(a, 10);
        }
    }
}
