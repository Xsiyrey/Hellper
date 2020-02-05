using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hellper.Exceptions
{
    [Serializable]
    public class NullArgumentException : Exception
    {
        public NullArgumentException() { }
        public NullArgumentException(string message) : base(message) { }
        public NullArgumentException(string message, Exception inner) : base(message, inner) { }
        protected NullArgumentException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
