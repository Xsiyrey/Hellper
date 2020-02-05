using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hellper.FormControllers
{
    class PageController
    {
        /// <summary>
        /// Return object of page in path
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <param name="pageName"></param>
        /// <param name="parameters">Params for constructor</param>
        /// <returns></returns>
        public static Page GetPage(string nameSpace, string pageName, params object[] parameters)
        {
            if (pageName == null || pageName == string.Empty)
                throw new Exceptions.NullArgumentException("Argument can't be null.");
            string path = nameSpace == null || nameSpace == string.Empty ? pageName : $"{nameSpace}.{pageName}";
            var type = Type.GetType(path, false, true);
            if (type == null)
                throw new Exceptions.PageNotFoundedException($"Page {pageName} not found into {nameSpace} namespace.");        
            var ctor = type.GetConstructor(parameters.Select(x => x.GetType()).ToArray());
            object obj = ctor.Invoke(new object[0]);
            if (!(obj is Page))
                return null;
            return (Page)obj;
        }
    }
}
