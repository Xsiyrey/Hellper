using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests.ExtensionsTest
{
    enum EnumForTest
    {
        One = 1,
        Two = 2,
        First = 3,
        Stop = 4
    }
    [TestClass]
    public class EnumControllerTest
    {
        [TestMethod]
        public void TestEnum()
        {
            var a = Hellper.Extensions.EnumExtension.GetListOfValues<EnumForTest>(EnumForTest.Two);
            var b = Hellper.Extensions.EnumExtension.GetListOfValues<EnumForTest>(x=>(int)x>2);
            var c = Hellper.Extensions.EnumExtension.GetListOfValues<EnumForTest>(x=>!new List<EnumForTest>(){EnumForTest.Two}.Contains(x));

            Assert.IsTrue(a.SequenceEqual(c) && b.SequenceEqual(new EnumForTest[] {EnumForTest.First,EnumForTest.Stop}));
        }
    }
}