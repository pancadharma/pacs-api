using System;
using System.Collections.Generic;

namespace Mahas.Components.CustomExceptions
{
    public class DefaultException : Exception
    {
        public DefaultException(string message, List<string> errors, object attachment = null) : base(message)
        {
            Error = new ErrorResponse(message, errors, attachment);
        }

        public DefaultException(string message, object attachment = null) : base(message)
        {
            Error = new ErrorResponse(message, attachment : attachment);
        }

        public DefaultException(ErrorResponse errors) : base(errors.Message)
        {
            Error = errors;
        }

        public ErrorResponse Error { get; private set; }
    }
}
