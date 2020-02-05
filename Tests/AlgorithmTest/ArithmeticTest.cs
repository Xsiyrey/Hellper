using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hellper.Algorithm;

namespace Tests.AlgorithmTest
{
    [TestClass]
    public class ArithmeticTest
    {
        [TestMethod]
        public void LCFSlowTest()
        {
            Assert.AreEqual(7, Arithmetic.LCFRecSlow(1414, 6671));
        }

        [TestMethod]
        public void LCFFastTest()
        {
            Assert.AreEqual(7, Arithmetic.LCFRecFast(1414, 6671));
        }

        [TestMethod]
        public void TestForSpeed()
        {
            int[] array = new int[129999999];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            decimal sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestForEachSpeed()
        {
            int[] array = new int[129999999];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            decimal sum = 0;

            foreach (int item in array)
            {
                sum += item;
            }
            Assert.IsTrue(true);
        }
    }
}
