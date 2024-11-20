using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PUCGrafos.domain.exceptions
{
    public class ExceptionArestaInvalida : Exception
    {
        public ExceptionArestaInvalida()
        {
        }

        public ExceptionArestaInvalida(string? message) : base(message)
        {
        }

        public ExceptionArestaInvalida(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
