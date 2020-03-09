using System;
using System.Collections.Generic;
using System.Linq;

namespace Hellper.Models {
    public static class EnumController {
        public static IEnumerable<T> GetListOfValues<T> () where T : Enum => Enum.GetValues (typeof (T))?.Cast<T> ();
        public static IEnumerable<T> GetListOfValues<T> (params T[] ignore) where T : Enum => GetListOfValues<T> ().Where (x => !ignore.Contains (x));
        public static IEnumerable<T> GetListOfValues<T> (Func<T, bool> predicate) where T : Enum => GetListOfValues<T> ().Where (x => predicate (x));
    }
}