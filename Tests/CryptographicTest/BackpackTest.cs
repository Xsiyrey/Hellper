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
            bool testStatus = true;
            string[] defaultShiphr = new string[]
            {
                "155",
                "365",
                "558",
                "155",
                "924",
                "1239",
                "470",
            };
            BackpackWorker backpack = new BackpackWorker(270, 31, 420, new BigInteger[] { 2, 3, 6, 13, 27, 52, 105, 210 },
                                                         new BigInteger[] { 62, 93, 186, 403, 417, 352, 315, 210 });
            string[] shiphr = backpack.Encrypt("АБРАМОВ").Split(new char[] { ' ' },
                                                                StringSplitOptions.RemoveEmptyEntries);
            if (shiphr.Length == defaultShiphr.Length)
                for (int i = 0, length = shiphr.Length; i < length; i++)
                {
                    if (shiphr[i] != defaultShiphr[i])
                    {
                        testStatus = false;
                        break;
                    }
                }
            else
                testStatus = false;
            Assert.IsTrue(testStatus);
        }
    }
}
