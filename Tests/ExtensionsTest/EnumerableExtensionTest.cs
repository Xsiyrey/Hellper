using Hellper.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ExtensionsTest
{
    [TestClass]
    public class EnumerableExtensionTest
    {
        [TestMethod]
        public void TestForEachAction()
        {
            var a = new List<TestDataClass>()
            {
                new TestDataClass{Number = 1},
                new TestDataClass{Number = 2},
                new TestDataClass{Number = 3}
            }.AsEnumerable();

            var result1 = a.Sum(x => x.Number) == 6;

            a.ForEach(x => x.Number += 1);
            var result2 = a.Sum(x => x.Number) == 9;
            Assert.IsTrue(result1 && result2);
        }

        [TestMethod]
        public void TestForEachFunction()
        {
            var a = new List<TestDataClass>()
            {
                new TestDataClass{Number = 1},
                new TestDataClass{Number = 2},
                new TestDataClass{Number = 3}
            }.AsEnumerable();

            var result1 = a.Sum(x => x.Number) == 6;

            var b = a.ForEach(x => x.Number.ToString() + "Hello");

            var result2 = b.All(x => x.Contains("Hello"));

            Assert.IsTrue(result1 && result2);
        }

        private class TestDataClass
        {
            public int Number { get; set; }
        }
    }
}
