using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hellper.Cryptographic;
using Hellper.Numbers;
using System.Numerics;

namespace Tests.CryptographicTest
{
    [TestClass]
    public class BackpackTest
    {
        [TestMethod]
        public void TestOfSupperUpperElements() 
        {
            BigInteger[] bigs = SimpleNumberWorker.SupperUpperElements(5);
            BigInteger[] mastBe = new BigInteger[] { 2, 3, 6, 12, 24 };
            bool result = true;
            for (int i = 0; i < bigs.Length; i++)
            {
                if (bigs[i]!=mastBe[i])
                {
                    result = false;
                    break;
                }
            }
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestOfCrypto()
        {
            BackpackWorker backpack = new BackpackWorker(1239);
            string shiphr = backpack.Encrypt("АБРАМОВ");
        }
    }
}
