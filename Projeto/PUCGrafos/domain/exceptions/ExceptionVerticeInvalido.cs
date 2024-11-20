using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PUCGrafos.domain.exceptions
{
    internal class ExceptionVerticeInvalido : Exception
    {
        public ExceptionVerticeInvalido()
        {
        }

        public ExceptionVerticeInvalido(string? message) : base(message)
        {
        }

        public ExceptionVerticeInvalido(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ExceptionVerticeInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
