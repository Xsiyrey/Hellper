using System;
using System.Linq;
using System.Numerics;

namespace Hellper.Numbers
{
    public static class SimpleNumberWorker
    {
        /// <summary>
        /// Checking the number for simplicity
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsPrime(this BigInteger num)
        {
            if (num == null) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;

            for (BigInteger i = 3; i <= num / 2; i += 2)
            {
                if (num % i == 0) return false;
            }

            return true;
        }
        /// <summary>
        /// Сheck for mutually prime number
        /// </summary>
        /// <param name="firstNum"></param>
        /// <param name="secondNum"></param>
        /// <returns></returns>
        public static bool IsMutuallyPrimary(BigInteger firstNum, BigInteger secondNum)
        {
            if (firstNum == null || secondNum == null) return false;
            BigInteger n = firstNum < secondNum ? firstNum : secondNum;

            for (BigInteger i = 2; i < n; i++)
            {
                if ((firstNum % i == 0) && (secondNum % i == 0)) return false;
            }

            return true;
        }
        /// <summary>
        /// Get array of SupperUpperElements
        /// </summary>
        /// <param name="count">count of element</param>
        /// <returns></returns>
        public static BigInteger[] SupperUpperElements(int count)
        {
            if (count < 1)
                throw new Exception("Count mast be great then zero");
            BigInteger[] bigs = new BigInteger[count];
            BigInteger element = 2;

            for (int i = 0, length = bigs.Length; i < length; i++)
            {
                while (bigs.SumOfBigInt() >= element)
                {
                    if (element==25)
                    {
                        int a = 4;
                    }
                    element++;
                }
                bigs[i] = element;
            }
            return bigs;
        }
        public static BigInteger SumOfBigInt(this BigInteger[] bigs)
        {
            BigInteger sum = 0;
            for (int i = 0, length = bigs.Length; i < length; i++)
            {
                sum += bigs[i];
            }
            return sum;
        }
        public static BigInteger FindPrimitive(BigInteger P)
        {
            BigInteger primitive = 2;
            for (BigInteger i = 2; i < P - 1; i++)
            {
                if (IsPrimitiveRoot(i, P))
                {
                    primitive = i;
                    break;
                }
            }
            return primitive;
        }
        /// <summary>
        /// Сheck for primitive root for numbers
        /// </summary>
        /// <param name="el"></param>
        /// <param name="P"></param>
        /// <returns></returns>
        private static bool IsPrimitiveRoot(BigInteger el, BigInteger P)
        {
            BigInteger sum = 0;
            for (int i = 0; i < P - 1; i++)
            {
                sum += BigInteger.ModPow(el, i, P);
            }
            if (sum == el * P)
                return true;
            return false;
        }
    }
}
