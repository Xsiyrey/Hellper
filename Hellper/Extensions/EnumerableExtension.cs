using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hellper.Extensions
{
    public static class EnumerableExtension
    {
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (var s in source)
                action(s);
        }

        public static IEnumerable<TResult> ForEach<TSource,TResult>(this IEnumerable<TSource> source, Func<TSource,TResult> func)
        {
            List<TResult> result = new List<TResult>();
            foreach (var s in source)
                result.Add(func(s));
            return result;
        }
    }
}
