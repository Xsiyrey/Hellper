using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hellper.Exceptions
{
    [Serializable]
    public class PageNotFoundedException : Exception
    {
        public PageNotFoundedException() { }
        public PageNotFoundedException(string message) : base(message) { }
        public PageNotFoundedException(string message, Exception inner) : base(message, inner) { }
        protected PageNotFoundedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
