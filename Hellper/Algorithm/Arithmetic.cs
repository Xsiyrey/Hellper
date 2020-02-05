using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hellper.Algorithm
{
    /// <summary>
    /// Largest common factor
    /// </summary>
    public static class Arithmetic
    {
        /// <summary>
        /// Largest common factor on default algorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static T LCFRecSlow<T>(T a, T b) where T : struct
        {
            //if ((dynamic)a < 0 || (dynamic)b < 0)
            //    throw new Exception("A and B mast be bigger then zero");
            if ((dynamic)a == 0 || (dynamic)b == 0)
                return (dynamic)a > b ? a : b;
            return (dynamic)a >= b ? LCFRecSlow(b, (dynamic)a - b) : LCFRecSlow(a, (dynamic)b - a);
        }
        /// <summary>
        /// Largest common factor on fast algorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static T LCFRecFast<T>(T a, T b) where T : struct
        {
            if ((dynamic)a < 0 || (dynamic)b < 0)
                throw new Exception("A and B mast be bigger then zero");
            //if ((dynamic)a == 0 || (dynamic)b == 0)
            //    return (dynamic)a > b ? a : b;
            //return (dynamic)a > b ? LCFRecFast(b, (dynamic)a % b) : LCFRecFast(a, (dynamic)b % a);
            return (dynamic)b == 0 ? GeneralAbs(a) : LCFRecFast(b, (dynamic)a % b);
        }

        private static T GeneralAbs<T>(T a) where T : struct
        {
            if ((dynamic)a < 0)
                a = (dynamic)a * -1;
            return a;
        }
    }
}
