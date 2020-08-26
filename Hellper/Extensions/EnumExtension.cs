using System;
using System.Collections.Generic;
using System.Linq;

namespace Hellper.Extensions
{
    public static class EnumExtension
    {
        public static string[] GetListOfNames<T>() where T : Enum
            => Enum.GetNames(typeof(T));

        public static IEnumerable<string> GetListOfNames<T>(params string[] ignore) where T : Enum
            => GetListOfNames<T>().Where(x => !ignore.Contains(x));

        public static IEnumerable<string> GetListOfNames<T>(Func<string, bool> predicate) where T : Enum
            => GetListOfNames<T>().Where(x => predicate(x));

        public static IEnumerable<T> GetListOfValues<T>() where T : Enum
            => Enum.GetValues(typeof(T))?.Cast<T>();

        public static IEnumerable<T> GetListOfValues<T>(params T[] ignore) where T : Enum
            => GetListOfValues<T>().Where(x => !ignore.Contains(x));

        public static IEnumerable<T> GetListOfValues<T>(Func<T, bool> predicate) where T : Enum
            => GetListOfValues<T>().Where(x => predicate(x));
    }
}