using System;
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

            BigInteger limit = num / 2;
            for (BigInteger i = 3; i <= limit; i += 2)
            {
                if (num % i == 0) return false;
            }

            return true;
        }
        public static bool IsPrime<T>(T num) where T : struct
        {
            if ((dynamic)num == 2) return true;
            if ((dynamic)num % 2 == 0) return false;

            T limit = (dynamic)num / 2;
            for (T i = (dynamic)3; i <= (dynamic)limit; i += (dynamic)2)
            {
                if ((dynamic)num % i == 0) return false;
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
        public static BigInteger FindPrimitive(BigInteger p)
        {
            BigInteger primitive = 2;
            for (BigInteger i = 2; i < p - 1; i++)
            {
                if (IsPrimitiveRoot(i, p))
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
        /// <param name="p"></param>
        /// <returns></returns>
        private static bool IsPrimitiveRoot(BigInteger el, BigInteger p)
        {
            BigInteger sum = 0;
            for (int i = 0; i < p - 1; i++)
            {
                sum += BigInteger.ModPow(el, i, p);
            }
            if (sum == el * p)
                return true;
            return false;
        }
    }
}
